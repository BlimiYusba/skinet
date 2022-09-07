using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{

    public class BugHandlingController : BaseApi
    {
        private readonly StoreContext _context;
        public BugHandlingController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("badrequest")]
        public ActionResult badRequest()
        {
            return BadRequest(new ApiResponse(400));
        }
        [HttpGet("notfound")]
        public ActionResult notFound()
        {
            return NotFound(new ApiResponse(404));
        }
    }
}
