using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaCore.Data;
using PruebaCore.EntityModels;
using PruebaCore.Models;

namespace PruebaCore.Services
{
    public class ArticuloServices : Controller, IArticuloServices
    {
        private readonly InventarioDbContext _contextInventario;

        public ArticuloServices(InventarioDbContext context)
        {
            _contextInventario = context;
        }

        public async Task<IActionResult> Create(ArticuloViewModel model)
        {
            ArticuloEntity articuloEntity = new ArticuloEntity();
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, "Modelo no válido.");
                }

                articuloEntity.Sku_NumeroSerie = model.Sku_NumeroSerie;
                articuloEntity.Sku_Codigo = model.Sku_Codigo;
                articuloEntity.Sku_Descripcion = model.Sku_Descripcion;
                articuloEntity.Sku_Cantidad = model.Sku_Cantidad;
                articuloEntity.Sku_Cat_ID = model.Sku_Cat_ID;
                articuloEntity.Sku_Sub_Cat_ID = model.Sku_Sub_Cat_ID;
                articuloEntity.Sku_Latitud = model.Sku_Latitud;
                articuloEntity.Sku_Longitud = model.Sku_Longitud;
                await _contextInventario.Articulo.AddRangeAsync(articuloEntity);
                await _contextInventario.SaveChangesAsync();
                return RedirectToAction("GetById", "Articulos", new { id = articuloEntity.Sku_ID });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrio un error al crear el artículo. " + ex.Message);
            }
            finally
            {
                articuloEntity = null;
                model = null;
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return StatusCode(400, "El identificador es nulo.");
                }
                ArticuloEntity articuloEntity = await _contextInventario.Articulo.FindAsync(id);
                if (articuloEntity == null)
                {
                    return StatusCode(404, "Persona no encontrada.");
                }
                _contextInventario.Articulo.Remove(articuloEntity);
                await _contextInventario.SaveChangesAsync();
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrio un error al eliminar el artículo. " + ex.Message);
            }
        }

        public async Task<IActionResult> GetAll()
        {
            List<ArticuloEntity> articuloEntity = await _contextInventario.Articulo.ToListAsync();
            List<ArticuloViewModel> articuloViewModel = articuloEntity.ConvertAll(x => new ArticuloViewModel(x));
            return StatusCode(200, articuloViewModel);
        }

        public async Task<IActionResult> GetById(int? id)
        {
            try
            {
                if (id == null)
                {
                    return StatusCode(400, "El identificador es nulo.");
                }
                List<ArticuloEntity> articuloEntity = await _contextInventario.Articulo.Where(x => x.Sku_ID.Equals(id)).ToListAsync();
                if (articuloEntity == null || articuloEntity.Count() == 0)
                {
                    return StatusCode(404, "Persona no encontrada.");
                }
                List<ArticuloViewModel> articuloViewModel = articuloEntity.ConvertAll(x => new ArticuloViewModel(x));
                ArticuloViewModel articuloViewModelList = articuloViewModel.FirstOrDefault();
                return StatusCode(200, articuloViewModelList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrio un error al obtener los datos del artículo. " + ex.Message);
            }
        }

        public async Task<IActionResult> Update(ArticuloViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, "Modelo no válido.");
                }
                ArticuloEntity articuloEntity = await _contextInventario.Articulo.FindAsync(model.Sku_ID);
                if (articuloEntity == null)
                {
                    return StatusCode(404, "Artículo no encontrado.");
                }
                articuloEntity.Sku_ID = model.Sku_ID;
                articuloEntity.Sku_NumeroSerie = model.Sku_NumeroSerie;
                articuloEntity.Sku_Descripcion = model.Sku_Descripcion;
                articuloEntity.Sku_Cantidad = model.Sku_Cantidad;
                articuloEntity.Sku_Cat_ID = model.Sku_Cat_ID;
                articuloEntity.Sku_Sub_Cat_ID = model.Sku_Sub_Cat_ID;
                articuloEntity.Sku_Latitud = model.Sku_Latitud;
                articuloEntity.Sku_Longitud = model.Sku_Longitud;

                _contextInventario.Articulo.Update(articuloEntity);
                await _contextInventario.SaveChangesAsync();
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrio un error al actualizar los datos del artículo. " + ex.Message);
            }
        }
    }
}
