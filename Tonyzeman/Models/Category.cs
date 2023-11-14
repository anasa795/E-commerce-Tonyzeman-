using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tonyzeman.Models.CustomVaildation;

namespace Tonyzeman.Models
{
    public class Category
    {
        public int ID { get; set; }

        
        public string Name { get; set; }

        public string? Type { get; set; }
        
        public string? ImageUrl { get; set; }
        public bool? IsDeleted { get; set; } = false;
    }
}
