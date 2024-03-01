namespace Mission08_group4_09.Models
{
    public interface ITaskRepository
    {
        List<ToDoList> ToDoLists { get; }
        public void AddToDoList(ToDoList toDoList);
        public void RemoveToDoList(ToDoList delete);
        public void UpdateToDoList(ToDoList update);
        List<Category> Categories { get; }
      
        
        
    }

   
}
