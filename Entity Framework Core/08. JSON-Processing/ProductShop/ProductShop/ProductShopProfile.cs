using System.Linq;
using AutoMapper;
using ProductShop.DTO.User;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<Product, UserSoldProductDTO>()
                .ForMember(x => x.BuyerFirstName,
                    y => y.MapFrom(x => x.Buyer.FirstName))
                .ForMember(x => x.BuyerLastName,
                    y => y.MapFrom(x => x.Buyer.LastName));

            this.CreateMap<User, UserWithSoldProductDTO>()
                .ForMember(x => x.FirstName,
                    y => y.MapFrom(x => x.FirstName))
                .ForMember(x => x.LastName,
                    y => y.MapFrom(x => x.LastName))
                .ForMember(x => x.SoldProducts,
                    y => y.MapFrom(x => x.ProductsSold
                        .Where(p => p.Buyer != null)));
        }
    }
}
