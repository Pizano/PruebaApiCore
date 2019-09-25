using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaCore.Data;
using PruebaCore.Models;
using PruebaCore.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaCore.Controllers
{
    [Route("api/[controller]")]
    public class ArticulosController : Controller
    {
        private readonly InventarioDbContext _context;
        private readonly IArticuloServices _services;

        public ArticulosController(InventarioDbContext context, IArticuloServices services)
        {
            _context = context;
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await _services.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int? id)
        {
            return await _services.GetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ArticuloViewModel model)
        {
            return await _services.Create(model);

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            return await _services.Delete(id);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ArticuloViewModel model)
        {
            return await _services.Update(model);

        }
    }
}
