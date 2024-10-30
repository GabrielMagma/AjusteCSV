using AjusteCSV.BL.Responses;

namespace AjusteCSV.BL.Interfaces
{
    public interface IFileLACValidationServices
    {

        public ResponseQuery<bool> ValidationLAC(ResponseQuery<bool> response);

    }
}
