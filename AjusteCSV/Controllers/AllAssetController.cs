﻿using AjusteCSV.BL.DTOs;
using AjusteCSV.BL.Interfaces;
using AjusteCSV.BL.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AjusteCSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllAssetController : ControllerBase
    {
        readonly IAllAssetServices allAssetServices;

        public AllAssetController(IAllAssetServices _AllAssetServices)
        {
            allAssetServices = _AllAssetServices;
        }
        /// <summary>
        /// Servicio que toma los datos de la tabla All_Asset, los filtra y los almacena en la tabla All_Asset_New
        /// </summary>
        /// <param></param>
        /// <returns></returns>  
        [HttpPost]
        [Route(nameof(AllAssetController.SearchData))]
        public async Task<IActionResult> SearchData()
        {
            return await Task.Run(() =>
            {
                ResponseEntity<List<AllAssetDTO>> response = new ResponseEntity<List<AllAssetDTO>>();
                allAssetServices.SearchData(response);
                return Ok(response);
            });
        }
    }
}