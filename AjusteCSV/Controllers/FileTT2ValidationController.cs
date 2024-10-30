using AjusteCSV.BL.Interfaces;
using AjusteCSV.BL.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AjusteCSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileTT2ValidationController : ControllerBase
    {
        readonly IFileTT2ValidationServices fileServices;

        public FileTT2ValidationController(IFileTT2ValidationServices _fileServices)
        {
            fileServices = _fileServices;
        }
        /// <summary>
        /// Servicio que toma el nombre de un archivo de datos CSV guardado en una ruta específica del programa, lo convierte al formato de datos requerido
        /// y lo guarda en Base de datos
        /// </summary>
        /// <param name="String"></param>
        /// <returns></returns>  
        [HttpPost]
        [Route(nameof(FileTT2ValidationController.ValidationTT2))]
        public async Task<IActionResult> ValidationTT2()
        {
            return await Task.Run(() =>
            {
                ResponseQuery<bool> response = new ResponseQuery<bool>();
                fileServices.ValidationTT2(response);
                return Ok(response);
            });
        }
    }
}
