using AutoMapper;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UserDTO, User>();

            this.CreateMap<ProductDTO, Product>();

            this.CreateMap<CategoryDTO, Category>();

            this.CreateMap<CategoryProductDTO, CategoryProduct>();

            this.CreateMap<ProductInRangeDTO, Product>();

            //this.CreateMap<Product, UserProductDTO>();

            //this.CreateMap<User, GetUserSoldProductDTO>()
            //    .ForMember(x => x.SoldProducts, 
            //        y => y.MapFrom(s => s.ProductsSold));
        }
    }
}