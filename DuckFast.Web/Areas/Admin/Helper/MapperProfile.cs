using AutoMapper;
using DuckFast.Database.Entities;
using DuckFast.Web.Areas.Admin.Models;

namespace DuckFast.Web.Areas.Admin.Helper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Article, ArticleModel>();
            CreateMap<UserAccount, UserModel>();
            CreateMap<Category, CategoryModel>();
            CreateMap<CategoryModel, Category>();
            CreateMap<ArticleRequestModel, Article>()
                .ForMember(x => x.Author, opt => opt.Ignore())
                .ForMember(x => x.Category, opt => opt.Ignore());
        }
    }
}
