using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WrenchItWebAPI.Data;
using WrenchItWebAPI.Models;

namespace WrenchItWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ServicesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Services
        [HttpGet]
        public IActionResult GetServices()
        {
            var serviceList = _context.Services.ToList();
            return Ok(serviceList);
        }

        // GET: api/Services/5
        [HttpGet("{id}")]
        public IActionResult GetService(int id)
        {
            Service service = _context.Services.Where(a => a.ServiceId == id).FirstOrDefault();
            if (service != null)
            {
                return Ok(service);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetServiceRequestByCustomerId(long customerid)
        {
            Service service = _context.Services.Where(a => a.CustomerId == customerid).FirstOrDefault();
            if (service != null)
            {
                return Ok(service);
            }
            return NotFound();
        }

        public IActionResult GetServiceByStatus(){
            Service serviceIsNotCompleted = (Service)_context.Services.Where(a => a.IsCompleted != true);
            if (serviceIsNotCompleted != null)
            {
                return Ok(serviceIsNotCompleted);
            }
            return NotFound();
        }

        // PUT: api/Services/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public IActionResult PutService([FromBody] Service service)
        {
            //update service
            var serviceToUpdate = _context.Services.Single(a => a.ServiceId == service.ServiceId);
            if (serviceToUpdate != null)
            {
                serviceToUpdate.IsCompleted = service.IsCompleted;
                _context.SaveChanges();
                return Ok(serviceToUpdate); 
            }

            return NotFound();            
        }

        // POST: api/Services
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult PostService([FromBody]Service service)
        {
            _context.Services.Add(service);
           _context.SaveChanges();

            return Ok(service);
        }
       
    }
}
