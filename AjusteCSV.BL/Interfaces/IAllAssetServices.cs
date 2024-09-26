using AjusteCSV.BL.DTOs;
using AjusteCSV.BL.Responses;

namespace AjusteCSV.BL.Interfaces
{
    public interface IAllAssetServices
    {

        public ResponseEntity<List<AllAssetDTO>> SearchData(ResponseEntity<List<AllAssetDTO>> response);

    }
}
