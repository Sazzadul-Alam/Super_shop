using GTR_WebApiTask.DB;
using GTR_WebApiTask.Model;

namespace GTR_WebApiTask.Repository
{
    public class ProductRepo
    {
        taskContext db;

        

        public ProductRepo(taskContext db)
        {
            this.db = db;
        }
        public bool Add(Product e)
        {
            db.Products.Add(e);
            db.SaveChanges();
            return true;
        }

        public void Delete(int id)
        {
            var s = db.Products.FirstOrDefault(e => e.Id == id);
            db.Products.Remove(s);
            db.SaveChanges();
        }

        public void Edit(Product e)
        {
            var s = db.Products.FirstOrDefault(c => c.Id == e.Id);
            db.Entry(s).CurrentValues.SetValues(e);
            db.SaveChanges();

        }

        public List<Product> Get()
        {
            return db.Products.ToList();
        }

        public Product Get(int id)
        {
            return db.Products.FirstOrDefault(c => c.Id == id);
        }
    }
}
