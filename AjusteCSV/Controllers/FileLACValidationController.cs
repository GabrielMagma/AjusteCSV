using AjusteCSV.BL.Interfaces;
using AjusteCSV.BL.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AjusteCSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileLACValidationController : ControllerBase
    {
        readonly IFileLACValidationServices fileServices;

        public FileLACValidationController(IFileLACValidationServices _fileServices)
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
        [Route(nameof(FileLACValidationController.ValidationLAC))]
        public async Task<IActionResult> ValidationLAC()
        {
            return await Task.Run(() =>
            {
                ResponseQuery<bool> response = new ResponseQuery<bool>();
                fileServices.ValidationLAC(response);
                return Ok(response);
            });
        }
    }
}
