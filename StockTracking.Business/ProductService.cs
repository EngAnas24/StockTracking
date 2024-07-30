using StockTracking.Data;
using StockTracking.Models.DTOs;
using StockTracking.Models;
using System.IO;
using AutoMapper;

public class ProductService
{
    private readonly IRepository<Product> _ProductRepository;
    private readonly IMapper mapper;

    public ProductService(IRepository<Product> ProductRepository, IMapper mapper)
    {
        _ProductRepository = ProductRepository;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
    {
        var product = await _ProductRepository.GetAllAsync();
        return mapper.Map<IEnumerable<ProductDTO>>(product);
    }

    public async Task<ProductDTO> GetProductByIdAsync(int id)
    {
        var product = await _ProductRepository.GetByIdAsync(id);
        return mapper.Map<ProductDTO>(product);
    }

    public async Task<ProductDTO> AddProductAsync(ProductDTO productDTO)
    {
        if (productDTO == null)
        {
            throw new ArgumentNullException(nameof(productDTO));
        }

        /* byte[] productImage = null;
         if (productDTO.ProductImageFile != null)
         {
             using MemoryStream memoryStream = new MemoryStream();
             await productDTO.ProductImageFile.CopyToAsync(memoryStream);
             productImage = memoryStream.ToArray();
         }*/

        /*   Product product = new Product
           {
               Name = productDTO.Name,
               Description = productDTO.Description,
               Price = productDTO.Price,
               Quantity = productDTO.Quantity,
               AddedDate = DateTime.Now,
               SKU = productDTO.SKU,
               ProductImage = null,
               ProductWarehouses = new List<ProductWarehouse>()
           };

           // Add any associated product warehouses
           if (productDTO.ProductWarehouses != null)
           {
               foreach (var productWarehouseDTO in productDTO.ProductWarehouses)
               {
                   ProductWarehouse productWarehouse = new ProductWarehouse
                   {
                       WarehouseId = productWarehouseDTO.WarehouseId,
                       Quantity = productWarehouseDTO.Quantity
                   };
                   product.ProductWarehouses.Add(productWarehouse);

               }
           }*/
        var product = mapper.Map<Product>(productDTO);

        await _ProductRepository.AddAsync(product);
        return productDTO;
    }


    public async Task<ProductDTO> UpdateProductAsync(int id, ProductDTO productDTO)
    {
        if (productDTO == null)
        {
            throw new ArgumentNullException(nameof(productDTO));
        }

        /*  var existingProduct = await _ProductRepository.GetByIdAsync(id);
          if (existingProduct == null)
          {
              throw new KeyNotFoundException($"Product with ID {id} not found.");
          }

          *//*if (productDTO.ProductImageFile != null)
          {
              // Delete the old image data if it exists
              existingProduct.ProductImage = null;

              // Save the new image data
              using (MemoryStream memoryStream = new MemoryStream())
              {
                  await productDTO.ProductImageFile.CopyToAsync(memoryStream);
                  existingProduct.ProductImage = memoryStream.ToArray();
              }
          }*//*

          existingProduct.Name = productDTO.Name;
          existingProduct.Description = productDTO.Description;
          existingProduct.Price = productDTO.Price;
          existingProduct.Quantity = productDTO.Quantity;
          existingProduct.SKU = productDTO.SKU;

          await _ProductRepository.UpdateAsync(id,existingProduct);
          return existingProduct;*/

        var product = mapper.Map<Product>(productDTO);
        await _ProductRepository.UpdateAsync(id, product);
        return productDTO;
    }


    public async Task DeleteProductAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Invalid Product ID", nameof(id));
        }

        await _ProductRepository.DeleteAsync(id);
    }
}
