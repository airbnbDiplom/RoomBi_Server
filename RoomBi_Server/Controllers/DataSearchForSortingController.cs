using Microsoft.AspNetCore.Mvc;
using RoomBi.BLL.DTO;
using RoomBi.BLL.Interfaces;

namespace RoomBi_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataSearchForSortingController(IServiceDataSearchForSorting<DataSearchForSorting> forSorting) : ControllerBase
    {
       // GET: api/dataSearchForSortingController
            [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers(DataSearchForSorting dataSearchForSorting)
        {

            //var users = await forSorting.TempGetAll();
            if (dataSearchForSorting == null)
            {
                return NotFound();
            }
            return Ok(dataSearchForSorting);
        }
    }
}
