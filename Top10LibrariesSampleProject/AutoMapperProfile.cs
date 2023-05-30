using AutoMapper;
using Top10LibrariesSampleProject.Model;

namespace Top10LibrariesSampleProject
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddUpdateProductDTO, AddUpdateProduct>();
        }
    }
}
