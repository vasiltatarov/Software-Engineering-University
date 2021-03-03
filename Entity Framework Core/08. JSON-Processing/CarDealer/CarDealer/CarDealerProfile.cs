using AutoMapper;
using CarDealer.DTO.Car;
using CarDealer.DTO.Supplier;
using CarDealer.Models;
using System.Linq;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<Supplier, LocalSupplierDTO>()
                .ForMember(x => x.PartsCount,
                    y => y.MapFrom(x => x.Parts.Count));

            this.CreateMap<Car, CarWithPartsDTO>()
                .ForMember(x => x.Car,
                    y => y.MapFrom(x => x))
                .ForMember(x => x.Parts,
                    y => y.MapFrom(x => x.PartCars
                        .Select(pc => new PartDTO
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price.ToString("F2"),
                        })));
        }
    }
}
