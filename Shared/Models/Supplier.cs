namespace Shared.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; } = null!;
        public string SupplierDescription { get; set; } = null!;
        public string SupplierPhone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Contact { get; set; } = null!;
    }
}
