using AutoMapper;
using EasyFeedbackAPI.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //User
            CreateMap<User, UserGetDTO>();
            CreateMap<UserDTO, User>();

            //Restaurant
            CreateMap<Restaurant, RestaurantGetDTO>();
            CreateMap<RestaurantPutDTO, Restaurant>();
            CreateMap<RestaurantDTO, Restaurant>();

            //Servicio
            CreateMap<Servicio, ServicioGetDTO>();
            CreateMap<ServicioDTO, Servicio>();

            //Comment
            CreateMap<CommentDTO, Comment>();
            CreateMap<Comment, CommentDTO>();
            
        }
    }
}
