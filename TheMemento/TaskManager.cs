/******************************************************************************
 * 
 * Filename    = TaskManager.cs
 *
 * Author      = N. Pawan Kumar
 *
 * Product     = Task Management System
 * 
 * Project     = Task Management
 *
 * Description = Manages the lifecycle of a Task, including saving and restoring
 *               its state using the Memento pattern. Provides undo functionality.
 * 
 *****************************************************************************/

using System;
using System.Collections.Generic;

namespace TheMemento
{
    /// <summary>
    /// Manages a Task, including the ability to update, save, restore, and undo changes.
    /// </summary>
    public class TaskManager
    {
        private readonly Stack<TaskMemento> _history = new Stack<TaskMemento>();

        /// <summary>
        /// Gets the current task being managed.
        /// </summary>
        public Task Task { get; }

        /// <summary>
        /// Initializes a new instance of the TaskManager class with a task.
        /// </summary>
        /// <param name="description">The initial description of the task.</param>
        /// <param name="status">The initial status of the task.</param>
        public TaskManager(string description, string status)
        {
            Task = new Task { Description = description, Status = status };
        }

        /// <summary>
        /// Updates the task's description and status, and saves the previous state.
        /// </summary>
        /// <param name="description">The new description of the task.</param>
        /// <param name="status">The new status of the task.</param>
        public void UpdateTask(string description, string status)
        {
            _history.Push(Task.Save());
            Task.Description = description;
            Task.Status = status;
        }

        /// <summary>
        /// Reverts the task to the most recent saved state.
        /// </summary>
        public void Undo()
        {
            if (_history.Count > 0)
                Task.Restore(_history.Pop());
        }

        /// <summary>
        /// Displays the current task's description and status.
        /// </summary>
        public void ShowTask()
        {
            Console.WriteLine($"Description: {Task.Description}, Status: {Task.Status}");
        }
    }
}
