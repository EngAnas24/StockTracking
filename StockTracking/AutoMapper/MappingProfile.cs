using AutoMapper;
using StockTracking.Models;
using StockTracking.Models.DTOs;
namespace StockTracking
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          
            CreateMap<ProductDTO, Product>().ForMember(dest => dest.ProductImage, opt => opt.MapFrom(src => FormFileToByteArray(src.ProductImageFile))).ReverseMap();
            CreateMap<Warehouse, WarehouseDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Transactions, TransactionsDTO>().ReverseMap();
            CreateMap<Suppliers, SuppliersDTO>().ReverseMap();
            CreateMap<ProductSuppliers, ProductSuppliersDTO>().ReverseMap();
            CreateMap<ProductWarehouse, ProductWarehouseDTO>().ReverseMap();



        }

        private static byte[] FormFileToByteArray(IFormFile formFile)
        {
            if (formFile == null || formFile.Length == 0)
                return null;

            using (var memoryStream = new MemoryStream())
            {
                formFile.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}