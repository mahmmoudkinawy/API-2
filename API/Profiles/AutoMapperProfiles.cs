using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<BlogCreateDto, Blog>();
            CreateMap<BlogUpdateDto, Blog>();

            CreateMap<Blog, BlogDto>();

            CreateMap<AppUser, MemberDto>();
        }
    }
}
