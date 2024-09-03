# OVERVIEW
The Memento design pattern is a behavioral design pattern that allows an object to capture and save its current state so that it can later be restored to that state. The primary goal of this pattern is to provide the ability to restore an object to a previous state without exposing its internal structure, thereby preserving encapsulation.

The Memento design pattern consists of three main components:

### Originator:
- The Originator is the object whose state needs to be saved and restored. It knows how to save its current state   in a Memento and how to restore its state from a Memento.
- The Originator creates a Memento containing a snapshot of its current state.

### Memento:
- The Memento is an object that stores the internal state of the Originator. It is typically a lightweight object.
- The Memento object is immutable, meaning once it is created, it cannot be modified.
- The Memento protects against direct access to the state stored inside it, ensuring that only the Originator can access and modify its own state.

### Caretaker:
- The Caretaker is responsible for keeping the Memento but does not modify or access its content. It only passes the Memento back to the Originator when a state restoration is needed.
- The Caretaker is usually not aware of the specifics of the Originator's state. It only knows that it has to keep track of the Memento and hand it back when needed.


# DESIGN

In this project, we'll create a simple task management system where users can create tasks, update their descriptions or status, and use undo functionality to revert any changes made to a task. The system will maintain a history of changes to each task, allowing the user to undo operations like modifying the task's description or marking it as completed.

## Key Components:
#### Task Class:
- Represents a task with two properties: Description and Status.
- Contains methods to save its current state (Save) into a TaskMemento and to restore a previous state (Restore) from a TaskMemento.
  
#### TaskMemento Class:
- Stores the state of a Task, capturing its Description and Status.
- Acts as an immutable snapshot of the Task at a specific point in time.

#### TaskManager Class:
- Manages the Task and its state history.
- Uses a stack to keep track of previous states (_history), enabling the ability to undo changes.
- Provides methods to update the task (UpdateTask), undo the last change (Undo), and display the current state of the task (ShowTask).

#### Program Class:
- Demonstrates the usage of TaskManager by creating a task, updating it, and then undoing the change.

## Design Benefits:
#### Encapsulation: 
- The TaskMemento class ensures that the internal state of Task is not exposed or altered unintentionally, adhering to good object-oriented principles.
#### Undo Functionality:
- The use of a stack in TaskManager makes it easy to implement an undo feature, allowing users to revert to previous states of the task.
#### Separation of Concerns: 
- The design clearly separates the task's state management (Task) from the management of state history (TaskManager).


# CLASS DIAGRAM
![IMG_20240903_153746111](https://github.com/user-attachments/assets/f5c4a280-ad33-442a-8773-8f41a51626ce)

# Environment
The project builds and runs on Visual Studio Community 2022.

