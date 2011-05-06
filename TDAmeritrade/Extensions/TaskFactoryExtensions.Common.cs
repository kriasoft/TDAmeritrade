//-----------------------------------------------------------------------
// <copyright file="TaskFactoryExtensions.Common.cs" company="KriaSoft, Ltd.">
//     TD Ameritrade .NET SDK v1.1.0 (June 01, 2011)
//     Copyright © 2011 Konstantin Tarkus (k.tarkus@kriasoft.com)
// </copyright>
//-----------------------------------------------------------------------

namespace System.Threading.Tasks
{
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Extensions for TaskFactory.
    /// </summary>
    public static partial class TaskFactoryExtensions
    {
        /// <summary>
        /// Creates a generic TaskFactory from a non-generic one.
        /// </summary>
        /// <typeparam name="TResult">Specifies the type of Task results for the Tasks created by the new TaskFactory.</typeparam>
        /// <param name="factory">The TaskFactory to serve as a template.</param>
        /// <returns>The created TaskFactory.</returns>
        public static TaskFactory<TResult> ToGeneric<TResult>(this TaskFactory factory)
        {
            return new TaskFactory<TResult>(factory.CancellationToken, factory.CreationOptions, factory.ContinuationOptions, factory.Scheduler);
        }

        /// <summary>
        /// Creates a generic TaskFactory from a non-generic one.
        /// </summary>
        /// <typeparam name="TResult">Specifies the type of Task results for the Tasks created by the new TaskFactory.</typeparam>
        /// <param name="factory">The TaskFactory to serve as a template.</param>
        /// <returns>The created TaskFactory.</returns>
        public static TaskFactory ToNonGeneric<TResult>(this TaskFactory<TResult> factory)
        {
            return new TaskFactory(factory.CancellationToken, factory.CreationOptions, factory.ContinuationOptions, factory.Scheduler);
        }

        /// <summary>
        /// Gets the TaskScheduler instance that should be used to schedule tasks.
        /// </summary>
        /// <param name="factory">The TaskFactory to serve as a template.</param>
        /// <returns>The created TaskScheduler.</returns>
        public static TaskScheduler GetTargetScheduler(this TaskFactory factory)
        {
            Contract.Requires(factory != null);

            return factory.Scheduler ?? TaskScheduler.Current;
        }

        /// <summary>
        /// Gets the TaskScheduler instance that should be used to schedule tasks.
        /// </summary>
        /// <typeparam name="TResult">Specifies the type of Task result for the Task created by the new TaskFactory.</typeparam>
        /// <param name="factory">The TaskFactory to serve as a template.</param>
        /// <returns>The created TaskScheduler.</returns>
        public static TaskScheduler GetTargetScheduler<TResult>(this TaskFactory<TResult> factory)
        {
            Contract.Requires(factory != null);

            return factory.Scheduler != null ? factory.Scheduler : TaskScheduler.Current;
        }

        /// <summary>
        /// Converts TaskCreationOptions into TaskContinuationOptions.
        /// </summary>
        /// <param name="creationOptions">Create options.</param>
        /// <returns>Task continuation options.</returns>
        private static TaskContinuationOptions ContinuationOptionsFromCreationOptions(TaskCreationOptions creationOptions)
        {
            return (TaskContinuationOptions)
                ((creationOptions & TaskCreationOptions.AttachedToParent) |
                 (creationOptions & TaskCreationOptions.PreferFairness) |
                 (creationOptions & TaskCreationOptions.LongRunning));
        }
    }
}
