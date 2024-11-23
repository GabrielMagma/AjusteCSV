using AjusteCSV.BL.Responses;

namespace AjusteCSV.BL.Interfaces
{
    public interface IRamalesServices
    {

        public ResponseEntity<List<string>> SearchData(ResponseEntity<List<string>> response);        

    }
}
