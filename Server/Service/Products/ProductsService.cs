using Microsoft.EntityFrameworkCore;
using Server.Data;
using Shared.Models;

namespace Server.Service.Products
{
    public class ProductsService : IProductsService
    {
        public OptiFlowDbContext context { get; set; }

        public ProductsService(OptiFlowDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await context.Products.ToListAsync();
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await context.Products.FindAsync(id);

            if (product == null)
                throw new InvalidOperationException($"No se encontró el producto con ID {id}.");
            return product;
        }
        public async Task<Product> CreateProductAsync(Product producto)
        {
            context.Products.Add(producto);
            await context.SaveChangesAsync();
            return producto;
        }
        public async Task<Product?> UpdateProductAsync(int id, Product producto)
        {
            var productUpdate = await context.Products.FindAsync([id]);
            if (productUpdate is null) return null;

            productUpdate.ProductName = producto.ProductName;
            productUpdate.Price = producto.Price;
            productUpdate.Costo = producto.Costo;
            productUpdate.Referencia = producto.Referencia;
            productUpdate.Descripcion = producto.Descripcion;
            productUpdate.CodilgoBarra = producto.CodilgoBarra;
            productUpdate.TipoImpuesto = producto.TipoImpuesto;
            productUpdate.Excento = producto.Excento;
            productUpdate.ManejaInventario = producto.ManejaInventario;
            productUpdate.Imagen = producto.Imagen;
            productUpdate.StockMin = producto.StockMin;
            productUpdate.StockMax = producto.StockMax;
            productUpdate.ManejaVencimiento = producto.ManejaVencimiento;
            productUpdate.FechaVencimiento = producto.FechaVencimiento;
            await context.SaveChangesAsync();

            return productUpdate;

        }
        public async Task<bool> DeleteProductAsync(int id)
        {
            var producto = await context.Products.FindAsync(id);
            if (producto is null) return false;
            context.Products.Remove(producto);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
