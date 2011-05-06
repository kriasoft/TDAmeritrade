//-----------------------------------------------------------------------
// <copyright file="TaskFactoryExtensions.ContinueWhenAllAny.cs" company="KriaSoft, Ltd.">
//     TD Ameritrade .NET SDK v1.1.0 (June 01, 2011)
//     Copyright © 2011 Konstantin Tarkus (k.tarkus@kriasoft.com)
// </copyright>
//-----------------------------------------------------------------------

namespace System.Threading.Tasks
{
    using System.Collections.Generic;

    /// <summary>
    /// Extensions for TaskFactory.
    /// </summary>
    public static partial class TaskFactoryExtensions
    {
        /// <summary>
        /// Creates a continuation Task that will complete upon
        /// the completion of a set of provided Tasks.
        /// </summary>
        /// <param name="factory">The TaskFactory to use to create the continuation task.</param>
        /// <param name="tasks">The array of tasks from which to continue.</param>
        /// <returns>A task that, when completed, will return the array of completed tasks.</returns>
        public static Task<Task[]> WhenAll(this TaskFactory factory, params Task[] tasks)
        {
            return factory.ContinueWhenAll(tasks, completedTasks => completedTasks);
        }

        /// <summary>
        /// Creates a continuation Task that will complete upon
        /// the completion of a set of provided Tasks.
        /// </summary>
        /// <param name="factory">The TaskFactory to use to create the continuation task.</param>
        /// <param name="tasks">The array of tasks from which to continue.</param>
        /// <returns>A task that, when completed, will return the array of completed tasks.</returns>
        public static Task<Task<TAntecedentResult>[]> WhenAll<TAntecedentResult>(this TaskFactory factory, params Task<TAntecedentResult>[] tasks)
        {
            return factory.ContinueWhenAll(tasks, completedTasks => completedTasks);
        }

        /// <summary>
        /// Creates a continuation Task that will complete upon
        /// the completion of any one of a set of provided Tasks.
        /// </summary>
        /// <param name="factory">The TaskFactory to use to create the continuation task.</param>
        /// <param name="tasks">The array of tasks from which to continue.</param>
        /// <returns>A task that, when completed, will return the completed task.</returns>
        public static Task<Task> WhenAny(this TaskFactory factory, params Task[] tasks)
        {
            return factory.ContinueWhenAny(tasks, completedTask => completedTask);
        }

        /// <summary>
        /// Creates a continuation Task that will complete upon
        /// the completion of any one of a set of provided Tasks.
        /// </summary>
        /// <param name="factory">The TaskFactory to use to create the continuation task.</param>
        /// <param name="tasks">The array of tasks from which to continue.</param>
        /// <returns>A task that, when completed, will return the completed task.</returns>
        public static Task<Task<TAntecedentResult>> WhenAny<TAntecedentResult>(this TaskFactory factory, params Task<TAntecedentResult>[] tasks)
        {
            return factory.ContinueWhenAny(tasks, completedTask => completedTask);
        }
    }
}
