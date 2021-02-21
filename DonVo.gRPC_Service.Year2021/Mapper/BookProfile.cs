using AutoMapper;
using DonVo.gRPC_Service.Year2021.Protos;
using EfLinqQuerySnippets._03.AdvancedQuerying.Models;
using Google.Protobuf.WellKnownTypes;
using System;

namespace DonVo.gRPC_Service.Year2021.Mapper
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            //CreateMap<Book, BookModel>()
            //    .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => Timestamp.FromDateTime((DateTime)src.ReleaseDate)));

            //CreateMap<BookModel, Book>()
            //    .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate.ToDateTime()));

            CreateMap<Book, BookModel>();

            CreateMap<BookModel, Book>();
        }
    }
}
