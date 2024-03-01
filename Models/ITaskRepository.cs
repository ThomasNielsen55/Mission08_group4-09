namespace Mission08_group4_09.Models
{
    public interface ITaskRepository
    {
        List<ToDoList> ToDoLists { get; }
        public void AddToDoList(ToDoList toDoList);
        List<Category> Categories { get; }
        public void AddCategory(Category category);

        
        
    }

   
}
