
namespace Shared.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string Direction { get; set; } = null!;
        public string Itbis { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Contact { get; set; } = null!;
    }
}
