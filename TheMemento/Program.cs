/******************************************************************************
 * 
 * Filename    = Program.cs
 *
 * Author      = N. Pawan Kumar
 *
 * Product     = Task Management System
 * 
 * Project     = Task Management
 *
 * Description = Entry point of the application demonstrating the use of the 
 *               TaskManager class to manage tasks, including updating and undoing
 *               changes.
 * 
 *****************************************************************************/

using System;

namespace TheMemento

{
    /// <summary>
    /// Entry point for the Task Management System application.
    /// Demonstrates task creation, updates, and undo functionality.
    /// </summary>
    class Program
    {
        static void Main()
        {
            var taskManager = new TaskManager("Initial Task", "Pending");
            taskManager.ShowTask();

            taskManager.UpdateTask("Updated Task", "In Progress");
            taskManager.ShowTask();

            taskManager.Undo();
            taskManager.ShowTask();
        }
    }
}
