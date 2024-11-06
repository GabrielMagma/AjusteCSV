using AjusteCSV.BL.Responses;

namespace AjusteCSV.BL.Interfaces
{
    public interface IExcelCSVCompensacionesESSAServices
    {

        public ResponseQuery<string> Convert(ResponseQuery<string> response);

    }
}
