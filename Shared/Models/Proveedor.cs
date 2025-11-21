using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class Proveedor
    {
        [Key]
        public int SupplierId { get; set; }
        public string SupplierName { get; set; } = null!;
        public string SupplierDescription { get; set; } = null!;
        public string SupplierPhone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Contact { get; set; } = null!;
    }
}
