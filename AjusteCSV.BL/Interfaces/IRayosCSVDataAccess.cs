using AjusteCSV.BL.Data;
using AjusteCSV.BL.DTOs;

namespace AjusteCSV.BL.Interfaces
{
    public interface IRayosCSVDataAccess
    {

        public Boolean SaveData(List<MpLightning> request);

    }
}
