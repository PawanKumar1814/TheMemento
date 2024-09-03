using TheMemento;
namespace MementoUnitTest
{
    [TestClass]
    public class TaskTests
    {
        [TestMethod]
        public void Task_ShouldInitializeCorrectly()
        {
            var task = new TheMemento.Task { Description = "Test Task", Status = "Pending" };// Arrange & Act
            Assert.AreEqual("Test Task", task.Description);  // Assert
            Assert.AreEqual("Pending", task.Status);
        }

        [TestMethod]
        public void Save_ShouldCreateMementoWithCurrentState()
        {
            var task = new TheMemento.Task { Description = "Test Task", Status = "Pending" };  // Arrange
            var memento = task.Save();   // Act
            Assert.AreEqual("Test Task", memento.Description);  // Assert
            Assert.AreEqual("Pending", memento.Status);
        }

        [TestMethod]
        public void Restore_ShouldRestoreTaskStateFromMemento()
        {
            var task = new TheMemento.Task { Description = "Initial Task", Status = "Pending" };  // Arrange
            var memento = new TaskMemento("Restored Task", "Completed");
            task.Restore(memento);   
            Assert.AreEqual("Restored Task", task.Description); //// Assert
            Assert.AreEqual("Completed", task.Status);
        }
    }

    [TestClass]
    public class TaskMementoTests
    {
        [TestMethod]
        public void TaskMemento_ShouldStoreStateCorrectly()
        {
            var memento = new TaskMemento("Test Task", "Pending");  // Arrange & Act

            // Assert
            Assert.AreEqual("Test Task", memento.Description);
            Assert.AreEqual("Pending", memento.Status);
        }
    }

    [TestClass]
    public class TaskManagerTests
    {
        [TestMethod]
        public void TaskManager_ShouldInitializeTaskCorrectly()
        {
            var taskManager = new TaskManager("Initial Task", "Pending");  // Arrange & Act

            // Assert
            Assert.AreEqual("Initial Task", taskManager.Task.Description);
            Assert.AreEqual("Pending", taskManager.Task.Status);
        }

        [TestMethod]
        public void UpdateTask_ShouldChangeTaskDetails()
        {
            var taskManager = new TaskManager("Initial Task", "Pending");// Arrange
            taskManager.UpdateTask("Updated Task", "In Progress");  //Act
            Assert.AreEqual("Updated Task", taskManager.Task.Description);  //Assert
            Assert.AreEqual("In Progress", taskManager.Task.Status);
        }

        [TestMethod]
        public void Undo_ShouldRevertToPreviousState()
        {

            var taskManager = new TaskManager("Initial Task", "Pending");  // Arrange
            taskManager.UpdateTask("Updated Task", "In Progress");
            taskManager.Undo(); // Act
            Assert.AreEqual("Initial Task", taskManager.Task.Description); // Assert
            Assert.AreEqual("Pending", taskManager.Task.Status);
        }

        [TestMethod]
        public void Undo_ShouldNotChangeTaskIfNoHistoryExists()
        {
            var taskManager = new TaskManager("Initial Task", "Pending");
            taskManager.Undo();  // Act
            Assert.AreEqual("Initial Task", taskManager.Task.Description);  // Assert
            Assert.AreEqual("Pending", taskManager.Task.Status);
        }

        [TestMethod]
        public void MultipleUndo_ShouldRevertToEarlierStates()
        {
            var taskManager = new TaskManager("Task 1", "Pending");  // Arrange
            taskManager.UpdateTask("Task 2", "In Progress");
            taskManager.UpdateTask("Task 3", "Completed");
            taskManager.Undo(); // Should revert to "Task 2"
            taskManager.Undo(); // Should revert to "Task 1"
            Assert.AreEqual("Task 1", taskManager.Task.Description);
            Assert.AreEqual("Pending", taskManager.Task.Status);
        }
    }
}