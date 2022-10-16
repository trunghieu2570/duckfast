using AutoMapper;
using DuckFast.Database.Entities;
using DuckFast.Web.Models;

namespace DuckFast.Web.Helper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Article, PostModel>();
            CreateMap<UserAccount, UserModel>();
            CreateMap<Category, CategoryModel>();
            CreateMap<CategoryModel, Category>();
        }
    }
}
