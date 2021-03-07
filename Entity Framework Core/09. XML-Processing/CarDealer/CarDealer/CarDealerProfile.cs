using AutoMapper;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Export.GetCarsWithDistance;
using CarDealer.Dtos.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<SupplierDTO, Supplier>();

            this.CreateMap<Car, CarWithDistanceDTO>();

            this.CreateMap<Supplier, GetLocalSupplierDTO>();
        }
    }
}
