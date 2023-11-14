using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tonyzeman.Models
{   
    public class OrderProduct
    {
        [Required(ErrorMessage = "ProductQuantity quantity cant be empity")]
        public int ProductQuantity {  get; set; }
        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public bool IsDeleted { get; set; } = false;
        virtual public Order? Order { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
       virtual public Product? Product { get; set; }
        public string? ProductNote {  get; set; }


    }
}
