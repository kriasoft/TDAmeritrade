//-----------------------------------------------------------------------
// <copyright file="TaskFactoryExtensions.Iterate.cs" company="KriaSoft, LLC">
//     TD Ameritrade .NET SDK v1.1.0 (June 01, 2011)
//     Copyright © 2011 Konstantin Tarkus (k.tarkus@kriasoft.com)
// </copyright>
//-----------------------------------------------------------------------

namespace System.Threading.Tasks
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Extensions for <see cref="TaskFactory"/>.
    /// </summary>
    public static partial class TaskFactoryExtensions
    {
        #region No Object State Overloads

        /// <summary>
        /// Asynchronously iterates through an enumerable of tasks.
        /// </summary>
        /// <param name="factory">The target factory.</param>
        /// <param name="source">The enumerable containing the tasks to be iterated through.</param>
        /// <returns>A Task that represents the complete asynchronous operation.</returns>
        public static Task Iterate(this TaskFactory factory, IEnumerable<object> source)
        {
            Contract.Requires(factory != null);

            return Iterate(factory, source, null, factory.CancellationToken, factory.CreationOptions, factory.GetTargetScheduler());
        }

        /// <summary>
        /// Asynchronously iterates through an enumerable of tasks.
        /// </summary>
        /// <param name="factory">The target factory.</param>
        /// <param name="source">The enumerable containing the tasks to be iterated through.</param>
        /// <param name="cancellationToken">The cancellation token used to cancel the iteration.</param>
        /// <returns>A Task that represents the complete asynchronous operation.</returns>
        public static Task Iterate(this TaskFactory factory, IEnumerable<object> source, CancellationToken cancellationToken)
        {
            Contract.Requires(factory != null);

            return Iterate(factory, source, null, cancellationToken, factory.CreationOptions, factory.GetTargetScheduler());
        }

        /// <summary>
        /// Asynchronously iterates through an enumerable of tasks.
        /// </summary>
        /// <param name="factory">The target factory.</param>
        /// <param name="source">The enumerable containing the tasks to be iterated through.</param>
        /// <param name="creationOptions">Options that control the task's behavior.</param>
        /// <returns>A Task that represents the complete asynchronous operation.</returns>
        public static Task Iterate(this TaskFactory factory, IEnumerable<object> source, TaskCreationOptions creationOptions)
        {
            Contract.Requires(factory != null);

            return Iterate(factory, source, null, factory.CancellationToken, creationOptions, factory.GetTargetScheduler());
        }

        /// <summary>
        /// Asynchronously iterates through an enumerable of tasks.
        /// </summary>
        /// <param name="factory">The target factory.</param>
        /// <param name="source">The enumerable containing the tasks to be iterated through.</param>
        /// <param name="scheduler">The scheduler to which tasks will be scheduled.</param>
        /// <returns>A Task that represents the complete asynchronous operation.</returns>
        public static Task Iterate(this TaskFactory factory, IEnumerable<object> source, TaskScheduler scheduler)
        {
            Contract.Requires(factory != null);

            return Iterate(factory, source, null, factory.CancellationToken, factory.CreationOptions, scheduler);
        }

        /// <summary>Asynchronously iterates through an enumerable of tasks.</summary>
        /// <param name="factory">The target factory.</param>
        /// <param name="source">The enumerable containing the tasks to be iterated through.</param>
        /// <param name="cancellationToken">The cancellation token used to cancel the iteration.</param>
        /// <param name="creationOptions">Options that control the task's behavior.</param>
        /// <param name="scheduler">The scheduler to which tasks will be scheduled.</param>
        /// <returns>A Task that represents the complete asynchronous operation.</returns>
        public static Task Iterate(this TaskFactory factory, IEnumerable<object> source, CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler)
        {
            return Iterate(factory, source, null, cancellationToken, creationOptions, scheduler);
        }

        #endregion

        #region Object State Overloads and Full Implementation

        /// <summary>
        /// Asynchronously iterates through an enumerable of tasks.
        /// </summary>
        /// <param name="factory">The target factory.</param>
        /// <param name="source">The enumerable containing the tasks to be iterated through.</param>
        /// <param name="state">The asynchronous state for the returned Task.</param>
        /// <returns>A Task that represents the complete asynchronous operation.</returns>
        public static Task Iterate(this TaskFactory factory, IEnumerable<object> source, object state)
        {
            Contract.Requires(factory != null);

            return Iterate(factory, source, state, factory.CancellationToken, factory.CreationOptions, factory.GetTargetScheduler());
        }

        /// <summary>
        /// Asynchronously iterates through an enumerable of tasks.
        /// </summary>
        /// <param name="factory">The target factory.</param>
        /// <param name="source">The enumerable containing the tasks to be iterated through.</param>
        /// <param name="state">The asynchronous state for the returned Task.</param>
        /// <param name="cancellationToken">The cancellation token used to cancel the iteration.</param>
        /// <returns>A Task that represents the complete asynchronous operation.</returns>
        public static Task Iterate(this TaskFactory factory, IEnumerable<object> source, object state, CancellationToken cancellationToken)
        {
            Contract.Requires(factory != null);

            return Iterate(factory, source, state, cancellationToken, factory.CreationOptions, factory.GetTargetScheduler());
        }

        /// <summary>
        /// Asynchronously iterates through an enumerable of tasks.
        /// </summary>
        /// <param name="factory">The target factory.</param>
        /// <param name="source">The enumerable containing the tasks to be iterated through.</param>
        /// <param name="state">The asynchronous state for the returned Task.</param>
        /// <param name="creationOptions">Options that control the task's behavior.</param>
        /// <returns>A Task that represents the complete asynchronous operation.</returns>
        public static Task Iterate(this TaskFactory factory, IEnumerable<object> source, object state, TaskCreationOptions creationOptions)
        {
            Contract.Requires(factory != null);

            return Iterate(factory, source, state, factory.CancellationToken, creationOptions, factory.GetTargetScheduler());
        }

        /// <summary>
        /// Asynchronously iterates through an enumerable of tasks.
        /// </summary>
        /// <param name="factory">The target factory.</param>
        /// <param name="source">The enumerable containing the tasks to be iterated through.</param>
        /// <param name="state">The asynchronous state for the returned Task.</param>
        /// <param name="scheduler">The scheduler to which tasks will be scheduled.</param>
        /// <returns>A Task that represents the complete asynchronous operation.</returns>
        public static Task Iterate(this TaskFactory factory, IEnumerable<object> source, object state, TaskScheduler scheduler)
        {
            Contract.Requires(factory != null);

            return Iterate(factory, source, state, factory.CancellationToken, factory.CreationOptions, scheduler);
        }

        /// <summary>
        /// Asynchronously iterates through an enumerable of tasks.
        /// </summary>
        /// <param name="factory">The target factory.</param>
        /// <param name="source">The enumerable containing the tasks to be iterated through.</param>
        /// <param name="state">The asynchronous state for the returned Task.</param>
        /// <param name="cancellationToken">The cancellation token used to cancel the iteration.</param>
        /// <param name="creationOptions">Options that control the task's behavior.</param>
        /// <param name="scheduler">The scheduler to which tasks will be scheduled.</param>
        /// <returns>A Task that represents the complete asynchronous operation.</returns>
        public static Task Iterate(this TaskFactory factory, IEnumerable<object> source, object state, CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler)
        {
            // Validate/update parameters
            Contract.Requires(factory != null);
            Contract.Requires(source != null);
            Contract.Requires(scheduler != null);

            // Get an enumerator from the enumerable
            var enumerator = source.GetEnumerator();
            if (enumerator == null)
            {
                throw new InvalidOperationException("Invalid enumerable - GetEnumerator returned null");
            }

            // Create the task to be returned to the caller.  And ensure
            // that when everything is done, the enumerator is cleaned up.
            var trs = new TaskCompletionSource<object>(state, creationOptions);
            trs.Task.ContinueWith(_ => enumerator.Dispose(), CancellationToken.None, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);

            // This will be called every time more work can be done.
            Action<Task> recursiveBody = null;
            recursiveBody = antecedent =>
            {
                try
                {
                    // If we should continue iterating and there's more to iterate
                    // over, create a continuation to continue processing.  We only
                    // want to continue processing once the current Task (as yielded
                    // from the enumerator) is complete.
                    if (enumerator.MoveNext())
                    {
                        var nextItem = enumerator.Current;

                        // If we got a Task, continue from it to continue iterating
                        if (nextItem is Task)
                        {
                            var nextTask = (Task)nextItem;
                            nextTask.IgnoreExceptions(); // TODO: Is this a good idea?
                            nextTask.ContinueWith(recursiveBody).IgnoreExceptions();
                        }
                        //// If we got a scheduler, continue iterating under the new scheduler,
                        //// enabling hopping between contexts.
                        else if (nextItem is TaskScheduler)
                        {
                            Task.Factory.StartNew(() => recursiveBody(null), CancellationToken.None, TaskCreationOptions.None, (TaskScheduler)nextItem).IgnoreExceptions();
                        }
                        //// Anything else is invalid
                        else
                        {
                            trs.TrySetException(new InvalidOperationException("Task or TaskScheduler object expected in Iterate"));
                        }
                    }
                    //// Otherwise, we're done!
                    else
                    {
                        trs.TrySetResult(null);
                    }
                }
                //// If MoveNext throws an exception, propagate that to the user,
                //// either as cancellation or as a fault
                catch (Exception exc)
                {
                    var oce = exc as OperationCanceledException;
                    if (oce != null && oce.CancellationToken == cancellationToken)
                    {
                        trs.TrySetCanceled();
                    }
                    else
                    {
                        trs.TrySetException(exc);
                    }
                }
            };

            // Get things started by launching the first task
            factory.StartNew(() => recursiveBody(null), CancellationToken.None, TaskCreationOptions.None, scheduler).IgnoreExceptions();

            // Return the representative task to the user
            return trs.Task;
        }

        #endregion
    }
}
