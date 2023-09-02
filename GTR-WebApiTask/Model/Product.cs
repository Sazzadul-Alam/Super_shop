using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GTR_WebApiTask.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }
              
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public string Description { get; set; }

        public virtual Category Categories { get; set; }
    }
}
