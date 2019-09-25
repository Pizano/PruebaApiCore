using Microsoft.AspNetCore.Mvc;
using PruebaCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaCore.Services
{
    public interface IArticuloServices
    {
        Task<IActionResult> GetAll();
        Task<IActionResult> GetById(int? id);
        Task<IActionResult> Create(ArticuloViewModel model);
        Task<IActionResult> Delete(int? id);
        Task<IActionResult> Update(ArticuloViewModel model);
    }
}
