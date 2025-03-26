using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.BL.DTOs.Order;
using Shipping.BL.DTOs.Product;
using Shipping.DAL.UnitOfWork;

namespace Shipping.BL.Services
{
    public class ProductService
    {
        private readonly UnitOfWork _Unit;
        private readonly IMapper _Map;

        public ProductService(UnitOfWork unit, IMapper Map)
        {
            this._Unit = unit;
            _Map = Map;
        }
        public void AddProduct(CreateProductDTO productDTO)
        {
            // Add Product
            _Unit.ProductRepositry.Add(_Map.Map<Product>(productDTO));
            _Unit.Save();
        }
        public void UpdateProduct(EditProductDTO productDTO)
        {
            _Unit.ProductRepositry.Update(_Map.Map<Product>(productDTO));
            _Unit.Save();
        }
        public void DeleteProduct(int id)
        {
            _Unit.ProductRepositry.deleteProduct(id);
            _Unit.Save();
        }
        
    }
}
