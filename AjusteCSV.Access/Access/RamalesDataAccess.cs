using AjusteCSV.Access.Data;
using AjusteCSV.Access.DataEep;
using AjusteCSV.BL.Data;
using AjusteCSV.BL.DTOs;
using AjusteCSV.BL.Interfaces;
using AutoMapper;

namespace AjusteCSV.Access.Access
{
    public class RamalesDataAccess : IRamalesDataAccess
    {
        protected DannteEssaTestingContext context;
        private readonly IMapper mapper;

        public RamalesDataAccess(DannteEssaTestingContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public Boolean SaveData(List<FileIoTemp> request)
        {
            
            context.FileIoTemps.AddRange(request);
            context.SaveChanges();
            var result = true;

            return result;
        }

        public Boolean SaveDataList(List<FileIoTempDetail> request)
        {

            context.FileIoTempDetails.AddRange(request);
            context.SaveChanges();
            var result = true;

            return result;
        }

    }
}
