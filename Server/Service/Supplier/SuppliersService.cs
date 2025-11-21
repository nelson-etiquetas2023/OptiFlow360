using Microsoft.EntityFrameworkCore;
using Server.Data;
using Shared.Models;

namespace Server.Service.Supplier
{
    public class SuppliersService : ISuppliersService  
    {
        public OptiFlowDbContext context { get; set; }

        public SuppliersService(OptiFlowDbContext context) 
        {
            this.context = context;
        }

        public async Task<List<Proveedor>> GetSuppliersAsync()
        {
            return await context.Proveedores.ToListAsync();
        }
        public async Task<Proveedor> GetSupplierByIdAsync(int id)
        {
            var supplier = await context.Proveedores.FindAsync(id);

            if (supplier == null) 
            {
                throw new InvalidOperationException($"no se encontro el proveedor con el codigo: {id}");
            }

            return supplier;
        }
        public async Task<Proveedor> CreateSupplierAsync(Proveedor supplier)
        {
            context.Proveedores.Add(supplier);
            await context.SaveChangesAsync();
            return supplier; 
        }
        public async Task<Proveedor?> UpdatesSupplierAsync(int id, Proveedor supplier)
        {
            var supplierUpdate = await context.Proveedores.FindAsync(id);

            if (supplierUpdate == null) 
                return null;

            supplierUpdate.SupplierName = supplier.SupplierName;
            supplierUpdate.SupplierDescription = supplier.SupplierDescription;
            supplierUpdate.SupplierPhone = supplier.SupplierPhone;
            supplierUpdate.Email = supplier.Email;
            supplierUpdate.Contact = supplier.Contact;
            await context.SaveChangesAsync();

            return supplierUpdate;

        }
        public async Task<bool> DeleteSupplierAsync(int id)
        {
            var supplier = await context.Proveedores.FindAsync(id);

            if(supplier is null) 
                return false;

            context.Proveedores.Remove(supplier);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
