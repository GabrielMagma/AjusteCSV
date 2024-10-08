using AjusteCSV.BL.Data;
using AjusteCSV.BL.DTOs;

namespace AjusteCSV.BL.Interfaces
{
    public interface IAllAssetOracleDataAccess
    {
        public Boolean SearchData(List<AllAsset> request);

        public Boolean UpdateData(List<AllAssetDTO> request);

        public List<AllAsset> GetListAllAsset();

        public List<AllAsset> GetListAllAssetNews();
    }
}
