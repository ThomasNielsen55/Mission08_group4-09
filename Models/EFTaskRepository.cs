
using SQLitePCL;

namespace Mission08_group4_09.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private HabitContext _context;
        public EFTaskRepository(HabitContext temp)
        {
            _context = temp;
        }

        public List<ToDoList> ToDoLists => _context.ToDoLists.ToList();

        public void AddToDoList(ToDoList toDoList)
        {
            _context.ToDoLists.Add(toDoList);
            _context.SaveChanges();
        }

        public void UpdateToDoList(ToDoList updated)
        {
            _context.ToDoLists.Update(updated);
            _context.SaveChanges();
        }

        public void RemoveToDoList(ToDoList delete)
        {
            _context.ToDoLists.Remove(delete);
            _context.SaveChanges();
        }

        public List<Category> Categories => _context.Categories.ToList();
        
      
    }
}
