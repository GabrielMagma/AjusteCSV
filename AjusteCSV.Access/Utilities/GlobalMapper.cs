﻿using AjusteCSV.BL.Data;
using AjusteCSV.BL.DTOs;
using AutoMapper;

namespace AjusteCSV.Access.Utilities
{
    public class GlobalMapper : Profile
    {

        public GlobalMapper()
        {
            CreateMap<IdeamDTO, Ideam>().ReverseMap();
            CreateMap<AllAssetDTO, AllAsset>().ReverseMap();
            CreateMap<AllAssetDTO, AllAssetNew>().ReverseMap();

        }
    }
}
