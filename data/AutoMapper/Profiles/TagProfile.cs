using AutoMapper;
using Curate.Data.AutoMapper.Resolvers;
using Curate.Data.ViewModels;

namespace Curate.Data.AutoMapper.Profiles
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Models.Tag, TagViewModel>()
                .ForMember(dest=> dest.Title, opt => opt.MapFrom(src=>src.Title))
                .ForMember(dest=> dest.Id, opt => opt.MapFrom(src=>src.Id))
                .ForMember(dest=> dest.Description, opt => opt.MapFrom(src=>src.Description))
                .ForMember(dest=>dest.Slug, opt=> opt.MapFrom<TagResolver>())
                .ReverseMap()
                .ForAllOtherMembers(opts => opts.Ignore());
        }

    }
}
