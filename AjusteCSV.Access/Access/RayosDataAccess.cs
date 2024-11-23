using AjusteCSV.Access.Data;
using AjusteCSV.Access.DataEep;
using AjusteCSV.BL.Data;
using AjusteCSV.BL.DTOs;
using AjusteCSV.BL.Interfaces;
using AutoMapper;

namespace AjusteCSV.Access.Access
{
    public class RayosCSVDataAccess : IRayosCSVDataAccess
    {
        protected DannteEssaTestingContext context;
        private readonly IMapper mapper;

        public RayosCSVDataAccess(DannteEssaTestingContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public Boolean SaveData(List<MpLightning> request)
        {
            
            context.MpLightnings.AddRange(request);
            context.SaveChanges();
            var result = true;

            return result;
        }

    }
}
