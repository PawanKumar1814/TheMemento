/******************************************************************************
 * 
 * Filename    = Task.cs
 *
 * Author      = N. Pawan Kumar
 *
 * Product     = Task Management System
 * 
 * Project     = Task Management
 *
 * Description = Defines the Task class representing an individual task.
 *               This class can save its state and restore it using the 
 *               Memento pattern.
 * 
 *****************************************************************************/


namespace TheMemento
{ 
    /// <summary>
    /// Represents an individual task with a description and status.
    /// Implements the ability to save and restore its state using a memento.
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Gets or sets the task description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the task status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Saves the current state of the task.
        /// </summary>
        /// <returns>A memento object containing the current state.</returns>
        public TaskMemento Save() => new TaskMemento(Description, Status);

        /// <summary>
        /// Restores the task state from the provided memento.
        /// </summary>
        /// <param name="memento">The memento from which to restore the state.</param>
        public void Restore(TaskMemento memento)
        {
            Description = memento.Description;
            Status = memento.Status;
        }
    }
}
