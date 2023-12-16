using AutoMapper;
using Azure;
using BookFlight.Data;
using BookFlight.Model;
using BookFlight.Model.DBO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BookFlight.Controllers
{
    [Route("api/UserSearch")]
    [ApiController]

    public class UserSearchController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;



        public UserSearchController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<SearchModel>>> GetSearch()
        {

            List<SearchModel> searches = await _context.Search.ToListAsync();


            if (searches.Count == 0)
            {
                return NoContent();
            }

            List<AddSearchModelDBO> result = searches.Select(x => new AddSearchModelDBO
            {
                UserSearched = x.UserSearched


            }).ToList();

            return Ok(result);





        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<SearchModel>> UserSearch(AddSearchModelDBO Search)
        {
         

            if (Search == null)
                return NoContent();

            //TODO--Implement automapper logic here...
            SearchModel searchModel = new SearchModel() { UserSearched = Search.UserSearched };
            _context.Search.Add(searchModel);
            _context.SaveChangesAsync();

            return Ok(searchModel);
        }



    }
}
