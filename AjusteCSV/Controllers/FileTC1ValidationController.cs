using AjusteCSV.BL.Interfaces;
using AjusteCSV.BL.Responses;
using AjusteCSV.BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AjusteCSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileTC1ValidationController : ControllerBase
    {
        readonly IFileTC1ValidationServices fileServices;

        public FileTC1ValidationController(IFileTC1ValidationServices _fileServices)
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
        [Route(nameof(FileTC1ValidationController.ValidationTC1))]
        public async Task<IActionResult> ValidationTC1()
        {
            return await Task.Run(() =>
            {
                ResponseQuery<bool> response = new ResponseQuery<bool>();
                fileServices.ValidationTC1(response);
                return Ok(response);
            });
        }
    }
}
