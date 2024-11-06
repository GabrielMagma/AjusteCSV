using AjusteCSV.BL.Responses;

namespace AjusteCSV.BL.Interfaces
{
    public interface IExcelCSVCompensacionesEEPServices
    {

        public ResponseQuery<string> Convert(ResponseQuery<string> response);

    }
}
