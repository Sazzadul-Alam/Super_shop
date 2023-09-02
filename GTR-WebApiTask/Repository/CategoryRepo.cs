using GTR_WebApiTask.DB;
using GTR_WebApiTask.Model;

namespace GTR_WebApiTask.Repository
{

    public class CategoryRepo
    {
        taskContext db;
        public CategoryRepo(taskContext db)
        {
            this.db = db;
        }
        public bool Add(Category e)
        {
            db.Categories.Add(e);
            db.SaveChanges();
            return true;
        }

        public void Delete(int id)
        {
            var e = db.Categories.FirstOrDefault(x => x.Id == id);
            db.Categories.Remove(e);
            db.SaveChanges();
        }

        public void Edit(Category e)
        {
            var d = db.Categories.FirstOrDefault(x => x.Id == e.Id);
            db.Entry(d).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Category> Get()
        {
            return db.Categories.ToList();

        }

        public Category Get(int id)
        {
            return db.Categories.FirstOrDefault(x => x.Id == id);
        }

    }
}
