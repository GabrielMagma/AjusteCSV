using AjusteCSV.BL.DTOs;
using AjusteCSV.BL.Interfaces;
using AjusteCSV.BL.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AjusteCSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllAssetOracleController : ControllerBase
    {
        readonly IAllAssetOracleServices allAssetOracleServices;

        public AllAssetOracleController(IAllAssetOracleServices _AllAssetOracleServices)
        {
            allAssetOracleServices = _AllAssetOracleServices;
        }
        /// <summary>
        /// Servicio que toma los datos de la tabla All_Asset, los filtra y los almacena en la tabla All_Asset_New
        /// </summary>
        /// <param></param>
        /// <returns></returns>  
        [HttpPost]
        [Route(nameof(AllAssetOracleController.SearchData))]
        public async Task<IActionResult> SearchData()
        {
            return await Task.Run(() =>
            {
                ResponseEntity<List<AllAssetDTO>> response = new ResponseEntity<List<AllAssetDTO>>();
                allAssetOracleServices.SearchData(response);
                return Ok(response);
            });
        }
    }
}
