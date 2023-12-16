using AutoMapper;
using BookFlight.Model;
using BookFlight.Model.DBO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BookFlight
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<AddSearchModelDBO, SearchModel>();
        }

    }
}
