using AutoMapper;

namespace BB205_test
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<CreateCategoryDto, Category>()
                .ForMember(destination => destination.Tag, opr => opr.MapFrom(src => src.TagName));
            
        }
    }
}
