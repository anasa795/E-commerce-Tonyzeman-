using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tonyzeman.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //[NotMapped]
        //public IFormFile? PhotoFile { get; set; }
        //public string? PhotoPath { get; set; }

        
        public string? color { get; set; }

        public int? rate { get; set; }
        public int? size { get; set; }

        public int? Stock {  get; set; }

        public bool? IsDeleted { get; set; } = false;

        [Required]
        [Column(TypeName ="Money")]
        public decimal Price { get; set; }
        [ForeignKey("Category")]
        public int CategoryId {  get; set; }
        virtual public Category? Category { get; set; }
       virtual public List<OrderProduct>? OrderProducts { get; set; }

    }
}
