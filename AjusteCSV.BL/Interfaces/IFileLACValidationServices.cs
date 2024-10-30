using AjusteCSV.BL.Responses;
using Microsoft.AspNetCore.Http;

namespace AjusteCSV.BL.Interfaces
{
    public interface IFileLACValidationServices
    {

        public ResponseQuery<bool> ValidationLAC(IFormFile file, ResponseQuery<bool> response);

    }
}
