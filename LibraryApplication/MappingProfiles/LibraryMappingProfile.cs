using AutoMapper;
using LibraryApplication.DTOs;
using LibraryInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryApplication.MappingProfiles
{
    public class LibraryMappingProfile : Profile
    {
        public LibraryMappingProfile()
        {
            CreateMap<Book, BookDTO>()
                 .ForMember(dest => dest.ReviewsNumber, opt => opt.MapFrom(src => src.Reviews.Count))
                 .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Ratings.Count > 0 ? decimal.Round(src.Ratings.Average(r => r.Score), 2) : 0));

            CreateMap<Book, BookDetailsDTO>()
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Ratings.Count > 0 ? decimal.Round(src.Ratings.Average(r => r.Score), 2) : 0))
                .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Reviews));

            CreateMap<Rating, RatingDTO>().ReverseMap();

            CreateMap<Review, ReviewDTO>().ReverseMap();

            CreateMap<SaveBookDTO, Book>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id ?? 0))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Cover, opt => opt.MapFrom(src => src.Cover))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(dest => dest.Ratings, opt => opt.Ignore())
                .ForMember(dest => dest.Reviews, opt => opt.Ignore());
        }
    }

}
