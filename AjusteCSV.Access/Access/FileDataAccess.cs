using AjusteCSV.Access.Data;
using AjusteCSV.BL.DTOs;
using AjusteCSV.BL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace AjusteCSV.Access.Access
{
    public class FileDataAccess : IFileDataAccess
    {
        protected DannteEssaContext context;
        private readonly IMapper mapper;

        public FileDataAccess(DannteEssaContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public Boolean CreateFile(List<IdeamDTO> request)
        {
            List<Ideam> ideamTemp = new List<Ideam>();
            foreach (var item in request)
            {
                var ideam = mapper.Map<Ideam>(item);
                ideamTemp.Add(ideam);
            }
            
            context.Ideams.AddRange(ideamTemp);
            context.SaveChanges();
            var result = true;

            return result;
        }

    }
}
