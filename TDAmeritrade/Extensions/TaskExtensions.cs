//-----------------------------------------------------------------------
// <copyright file="TaskExtensions.cs" company="KriaSoft, LLC">
//     TD Ameritrade .NET SDK v1.1.0 (June 01, 2011)
//     Copyright © 2011 Konstantin Tarkus (k.tarkus@kriasoft.com)
// </copyright>
//-----------------------------------------------------------------------

namespace System.Threading.Tasks
{
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Windows.Threading;

    /// <summary>
    /// Extensions methods for <see cref="T:Task"/>.
    /// </summary>
    public static class TaskExtensions
    {
        #region ContinueWith accepting TaskFactory

        /// <summary>
        /// Creates a continuation task using the specified <see cref="T:TaskFactory"/>.
        /// </summary>
        /// <param name="task">The antecedent Task.</param>
        /// <param name="continuationAction">The continuation action.</param>
        /// <param name="factory">The TaskFactory.</param>
        /// <returns>A continuation task.</returns>
        public static Task ContinueWith(this Task task, Action<Task> continuationAction, TaskFactory factory)
        {
            return task.ContinueWith(continuationAction, factory.CancellationToken, factory.ContinuationOptions, factory.Scheduler);
        }

        /// <summary>
        /// Creates a continuation task using the specified TaskFactory.
        /// </summary>
        /// <typeparam name="TResult">Specifies the type of data contained in the task.</typeparam>
        /// <param name="task">The antecedent Task.</param>
        /// <param name="continuationFunction">The continuation function.</param>
        /// <param name="factory">The TaskFactory.</param>
        /// <returns>A continuation task.</returns>
        public static Task<TResult> ContinueWith<TResult>(this Task task, Func<Task, TResult> continuationFunction, TaskFactory factory)
        {
            return task.ContinueWith(continuationFunction, factory.CancellationToken, factory.ContinuationOptions, factory.Scheduler);
        }

        #endregion

        #region ContinueWith accepting TaskFactory<TResult>

        /// <summary>
        /// Creates a continuation task using the specified TaskFactory.
        /// </summary>
        /// <typeparam name="TResult">Specifies the type of data contained in the task.</typeparam>
        /// <param name="task">The antecedent Task.</param>
        /// <param name="continuationAction">The continuation action.</param>
        /// <param name="factory">The TaskFactory.</param>
        /// <returns>A continuation task.</returns>
        public static Task ContinueWith<TResult>(this Task<TResult> task, Action<Task<TResult>> continuationAction, TaskFactory<TResult> factory)
        {
            return task.ContinueWith(continuationAction, factory.CancellationToken, factory.ContinuationOptions, factory.Scheduler);
        }

        /// <summary>
        /// Creates a continuation task using the specified TaskFactory.
        /// </summary>
        /// <typeparam name="TResult">Specifies the type of data contained in the task.</typeparam>
        /// <typeparam name="TNewResult">Specifies the type of data contained in the new task.</typeparam>
        /// <param name="task">The antecedent Task.</param>
        /// <param name="continuationFunction">The continuation function.</param>
        /// <param name="factory">The TaskFactory.</param>
        /// <returns>A continuation task.</returns>
        public static Task<TNewResult> ContinueWith<TResult, TNewResult>(this Task<TResult> task, Func<Task<TResult>, TNewResult> continuationFunction, TaskFactory<TResult> factory)
        {
            return task.ContinueWith(continuationFunction, factory.CancellationToken, factory.ContinuationOptions, factory.Scheduler);
        }

        #endregion

        #region ToAsync(AsyncCallback, object)

        /// <summary>
        /// Creates a Task that represents the completion of another Task, and 
        /// that schedules an AsyncCallback to run upon completion.
        /// </summary>
        /// <param name="task">The antecedent Task.</param>
        /// <param name="callback">The AsyncCallback to run.</param>
        /// <param name="state">The object state to use with the AsyncCallback.</param>
        /// <returns>The new task.</returns>
        public static Task ToAsync(this Task task, AsyncCallback callback, object state)
        {
            Contract.Requires(task != null);

            var tcs = new TaskCompletionSource<object>(state);
            task.ContinueWith(_ =>
            {
                tcs.SetFromTask(task);
                if (callback != null)
                {
                    callback(tcs.Task);
                }
            });
            return tcs.Task;
        }

        /// <summary>
        /// Creates a Task that represents the completion of another Task, and 
        /// that schedules an AsyncCallback to run upon completion.
        /// </summary>
        /// <typeparam name="TResult">Specifies the type of data contained in the task.</typeparam>
        /// <param name="task">The antecedent Task.</param>
        /// <param name="callback">The AsyncCallback to run.</param>
        /// <param name="state">The object state to use with the AsyncCallback.</param>
        /// <returns>The new task.</returns>
        public static Task<TResult> ToAsync<TResult>(this Task<TResult> task, AsyncCallback callback, object state)
        {
            Contract.Requires(task != null);

            var tcs = new TaskCompletionSource<TResult>(state);
            task.ContinueWith(_ =>
            {
                tcs.SetFromTask(task);
                if (callback != null)
                {
                    callback(tcs.Task);
                }
            });
            return tcs.Task;
        }

        #endregion

        #region Exception Handling

        /// <summary>
        /// Suppresses default exception handling of a Task that would otherwise reraise the exception on the finalizer thread.
        /// </summary>
        /// <param name="task">The Task to be monitored.</param>
        /// <returns>The original Task.</returns>
        public static Task IgnoreExceptions(this Task task)
        {
            task.ContinueWith(
                t =>
                {
                        var ignored = t.Exception;
                },
                CancellationToken.None,
                TaskContinuationOptions.ExecuteSynchronously | TaskContinuationOptions.OnlyOnFaulted,
                TaskScheduler.Default);
            
            return task;
        }

        /// <summary>
        /// Suppresses default exception handling of a Task that would otherwise reraise the exception on the finalizer thread.
        /// </summary>
        /// <typeparam name="T">Specifies the type of data contained in the task.</typeparam>
        /// <param name="task">The Task to be monitored.</param>
        /// <returns>The original Task.</returns>
        public static Task<T> IgnoreExceptions<T>(this Task<T> task)
        {
            return (Task<T>)((Task)task).IgnoreExceptions();
        }

        /// <summary>
        /// Fails immediately when an exception is encountered.
        /// </summary>
        /// <param name="task">The Task to be monitored.</param>
        /// <returns>The original Task.</returns>
        public static Task FailFastOnException(this Task task)
        {
            task.ContinueWith(
                t => Environment.FailFast("A task faulted.", t.Exception),
                CancellationToken.None,
                TaskContinuationOptions.ExecuteSynchronously | TaskContinuationOptions.OnlyOnFaulted,
                TaskScheduler.Default);

            return task;
        }

        /// <summary>
        /// Fails immediately when an exception is encountered.
        /// </summary>
        /// <typeparam name="T">Specifies the type of data contained in the task.</typeparam>
        /// <param name="task">The Task to be monitored.</param>
        /// <returns>The original Task.</returns>
        public static Task<T> FailFastOnException<T>(this Task<T> task)
        {
            return (Task<T>)((Task)task).FailFastOnException();
        }

        /// <summary>
        /// Propagates any exceptions that occurred on the specified task.
        /// </summary>
        /// <param name="task">The Task whose exceptions are to be propagated.</param>
        public static void PropagateExceptions(this Task task)
        {
            if (!task.IsCompleted)
            {
                throw new InvalidOperationException("The task has not completed.");
            }

            if (task.IsFaulted)
            {
                task.Wait();
            }
        }

        /// <summary>
        /// Propagates any exceptions that occurred on the specified tasks.
        /// </summary>
        /// <param name="tasks">A list of Tasks whose exceptions are to be propagated.</param>
        public static void PropagateExceptions(this Task[] tasks)
        {
            Contract.Requires(tasks != null);
            Contract.Requires(tasks.Any(t => t == null) == false);

            if (tasks.Any(t => !t.IsCompleted))
            {
                throw new InvalidOperationException("A task has not completed.");
            }

            Task.WaitAll(tasks);
        }

        #endregion

        #region Timeouts

        /// <summary>
        /// Creates a new Task that mirrors the supplied task but that will be canceled after the specified timeout.
        /// </summary>
        /// <typeparam name="TResult">Specifies the type of data contained in the task.</typeparam>
        /// <param name="task">The task instance.</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns>The new Task that may time out.</returns>
        public static Task WithTimeout(this Task task, TimeSpan timeout)
        {
            var result = new TaskCompletionSource<object>(task.AsyncState);
            var timer = new Timer(state => ((TaskCompletionSource<object>)state).TrySetCanceled(), result, timeout, TimeSpan.FromMilliseconds(-1));
            task.ContinueWith(
                t =>
                {
                    timer.Dispose();
                    result.TrySetFromTask(t);
                },
                TaskContinuationOptions.ExecuteSynchronously);
            return result.Task;
        }

        /// <summary>
        /// Creates a new Task that mirrors the supplied task but that will be canceled after the specified timeout.
        /// </summary>
        /// <typeparam name="TResult">Specifies the type of data contained in the task.</typeparam>
        /// <param name="task">The task instance.</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns>The new Task that may time out.</returns>
        public static Task<TResult> WithTimeout<TResult>(this Task<TResult> task, TimeSpan timeout)
        {
            var result = new TaskCompletionSource<TResult>(task.AsyncState);
            var timer = new Timer(state => ((TaskCompletionSource<TResult>)state).TrySetCanceled(), result, timeout, TimeSpan.FromMilliseconds(-1));
            task.ContinueWith(
                t =>
                {
                    timer.Dispose();
                    result.TrySetFromTask(t);
                },
                TaskContinuationOptions.ExecuteSynchronously);
            return result.Task;
        }

        #endregion

        #region Children

        /// <summary>
        /// Ensures that a parent task can't transition into a completed state
        /// until the specified task has also completed, even if it's not
        /// already a child task.
        /// </summary>
        /// <param name="task">The task to attach to the current task as a child.</param>
        public static void AttachToParent(this Task task)
        {
            Contract.Requires(task != null);

            task.ContinueWith(
                t => t.Wait(),
                CancellationToken.None,
                TaskContinuationOptions.AttachedToParent | TaskContinuationOptions.ExecuteSynchronously,
                TaskScheduler.Default);
        }

        #endregion

        #region Waiting

        /// <summary>
        /// Waits for the task to complete execution, pumping in the meantime.
        /// </summary>
        /// <param name="task">The task for which to wait.</param>
        /// <remarks>This method is intended for usage with Windows Presentation Foundation.</remarks>
        public static void WaitWithPumping(this Task task)
        {
            Contract.Requires(task != null);

            var nestedFrame = new DispatcherFrame();
            task.ContinueWith(_ => nestedFrame.Continue = false);
            Dispatcher.PushFrame(nestedFrame);
            task.Wait();
        }

        /// <summary>Waits for the task to complete execution, returning the task's final status.</summary>
        /// <param name="task">The task for which to wait.</param>
        /// <returns>The completion status of the task.</returns>
        /// <remarks>Unlike Wait, this method will not throw an exception if the task ends in the Faulted or Canceled state.</remarks>
        public static TaskStatus WaitForCompletionStatus(this Task task)
        {
            Contract.Requires(task != null);

            ((IAsyncResult)task).AsyncWaitHandle.WaitOne();
            return task.Status;
        }

        #endregion

        #region Observables

        /// <summary>
        /// Creates an IObservable that represents the completion of a Task.
        /// </summary>
        /// <typeparam name="TResult">Specifies the type of data returned by the Task.</typeparam>
        /// <param name="task">The Task to be represented as an IObservable.</param>
        /// <returns>An IObservable that represents the completion of the Task.</returns>
        public static IObservable<TResult> ToObservable<TResult>(this Task<TResult> task)
        {
            Contract.Requires(task != null);

            return new TaskObservable<TResult> { Task = task };
        }

        /// <summary>
        /// An implementation of IObservable that wraps a Task.
        /// </summary>
        /// <typeparam name="TResult">The type of data returned by the task.</typeparam>
        private class TaskObservable<TResult> : IObservable<TResult>
        {
            /// <summary>
            /// An observable task.
            /// </summary>
            private Task<TResult> task;

            /// <summary>
            /// Gets or sets an observable task.
            /// </summary>
            internal Task<TResult> Task
            {
                get { return this.task; }
                set { this.task = value; }
            }

            /// <summary>
            /// Subscribes to the status change event of the task.
            /// </summary>
            /// <param name="observer">An observer.</param>
            /// <returns>A CancelOnDispose object.</returns>
            public IDisposable Subscribe(IObserver<TResult> observer)
            {
                // Validate arguments
                if (observer == null)
                {
                    throw new ArgumentNullException("observer");
                }

                // Support cancelling the continuation if the observer is unsubscribed
                var cts = new CancellationTokenSource();

                // Create a continuation to pass data along to the observer
                this.task.ContinueWith(
                    t =>
                    {
                        switch (t.Status)
                        {
                            case TaskStatus.RanToCompletion:
                                observer.OnNext(this.task.Result);
                                observer.OnCompleted();
                                break;

                            case TaskStatus.Faulted:
                                observer.OnError(this.task.Exception);
                                break;

                            case TaskStatus.Canceled:
                                observer.OnError(new TaskCanceledException(t));
                                break;
                        }
                    },
                cts.Token);

                // Support unsubscribe simply by canceling the continuation if it hasn't yet run
                return new CancelOnDispose { Source = cts };
            }
        }

        /// <summary>
        /// Translate a call to IDisposable.Dispose to a CancellationTokenSource.Cancel.
        /// </summary>
        private class CancelOnDispose : IDisposable
        {
            /// <summary>
            /// A cancellation token source.
            /// </summary>
            private CancellationTokenSource source;

            /// <summary>
            /// Gets or sets a cancellation token source.
            /// </summary>
            internal CancellationTokenSource Source
            {
                get { return this.source; }
                set { this.source = value; }
            }

            /// <summary>
            /// Disposes an instance of the <see cref="T:CancelOnDispose"/> class.
            /// </summary>
            void IDisposable.Dispose()
            {
                this.source.Cancel();
            }
        }

        #endregion
    }
}
