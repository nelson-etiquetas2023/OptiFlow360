
namespace Shared.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal Costo { get; set; }
        public string Referencia { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string CodilgoBarra { get; set; } = null!;
        public string TipoImpuesto { get; set; } = null!;
        public bool Excento { get; set; }
        public bool ManejaInventario { get; set; }
        public string Imagen { get; set; } = null!;
        public int StockMin { get; set; }
        public int StockMax { get; set; }
        public bool ManejaVencimiento { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}
