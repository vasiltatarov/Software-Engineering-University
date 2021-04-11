using System;
using System.Globalization;
using System.Linq;
using Cinema.Data.Models;
using Cinema.DataProcessor.ExportDto;

namespace Cinema
{
    using AutoMapper;

    public class CinemaProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public CinemaProfile()
        {
            //It not work!!!
            CreateMap<Customer, ExportCustomerDto>()
                .ForMember(x => x.FirstName,
                    y => y.MapFrom(x => x.FirstName))
                .ForMember(x => x.LastName,
                    y => y.MapFrom(x => x.LastName))
                .ForMember(x => x.SpentMoney,
                    y => y.MapFrom(x => decimal.Parse(x.Tickets.Sum(t => t.Price).ToString("F2"))))
                .ForMember(x => x.SpentTime,
                    y => y.MapFrom(x => TimeSpan
                        .FromMilliseconds(x.Tickets.Sum(t => t.Projection.Movie.Duration.TotalMilliseconds))
                        .ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture)));
        }
    }
}
