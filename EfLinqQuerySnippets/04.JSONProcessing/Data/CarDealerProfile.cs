using AutoMapper;
using EfLinqQuerySnippets._04.JSONProcessing.DTOs;
using EfLinqQuerySnippets._04.JSONProcessing.Models;

namespace EfLinqQuerySnippets._04.JSONProcessing.Data
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<Customer, ExperiencedDriverDTO>()
                .ForMember(x => x.BirthDate, y => y.MapFrom(s => s.BirthDate.ToString("dd/MM/yyyy")));

            CreateMap<Customer, CustomerWithCarDTO>()
                .ForMember(x => x.FullName, y => y.MapFrom(s => s.Name))
                .ForMember(x => x.BoughtCars, y => y.MapFrom(s => s.Sales.Count));

            this.CreateMap<Supplier, NationalPartDTO>();
            this.CreateMap<Car, CarToyotaDTO>();
        }
    }
}
