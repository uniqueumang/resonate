using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Resonate.BusinessService.Interface;

namespace Resonate.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class SchemaController : Controller
    {
        private readonly IDataService _dataService;

        public SchemaController(IDataService dataService)
        {
            _dataService = dataService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_dataService.GetSchema());
            }
            catch (Exception e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e);
            }
        }
    }
}