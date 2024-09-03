/******************************************************************************
 * 
 * Filename    = TaskMemento.cs
 *
 * Author      = N. Pawan Kumar
 *
 * Product     = Task Management System
 * 
 * Project     = Task Management
 *
 * Description = Defines the TaskMemento class representing a snapshot of a
 *               Task's state.
 * 
 *****************************************************************************/

namespace TheMemento
{
    /// <summary>
    /// Represents a snapshot of a Task's state at a specific point in time.
    /// This class is immutable and used by the Task class to save and restore
    /// its state.
    /// </summary>
    public class TaskMemento
    {
        /// <summary>
        /// Gets the description of the task at the time the memento was created.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets the status of the task at the time the memento was created.
        /// </summary>
        public string Status { get; }

        /// <summary>
        /// Initializes a new instance of the TaskMemento class with the specified state.
        /// </summary>
        /// <param name="description">The description of the task.</param>
        /// <param name="status">The status of the task.</param>
        public TaskMemento(string description, string status)
        {
            Description = description;
            Status = status;
        }
    }
}
