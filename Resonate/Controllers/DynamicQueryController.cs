using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Rest;
using Resonate.BusinessService.Interface;

namespace Resonate.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class DynamicQueryController : Controller
    {
        private readonly IDataService _dataService;


        public DynamicQueryController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        [Route("{columnName?}/{filterValue?}")]
        public IActionResult Get(string columnName, string filterValue)
        {
            try
            {
                return Ok(_dataService.GetResultsByColumnFilter(columnName, filterValue));
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(new ValidationException(e.Message));
            }
            catch (Exception e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e);
            }
        }
    }
}