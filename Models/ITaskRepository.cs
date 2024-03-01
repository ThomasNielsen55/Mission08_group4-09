namespace Mission08_group4_09.Models
{
    public interface ITaskRepository
    {
        List<ToDoList> ToDoLists { get; }
        public void AddToDoList(ToDoList toDoList);
        public void RemoveFromDoList(ToDoList delete);
        public void UpdateToDoList(ToDoList update);
        List<Category> Categories { get; }
        public void AddCategory(Category category);

        
        
    }

   
}
