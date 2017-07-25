using AutoMapper;
using Database.Files;
using DTOs.Files;
using Enums;
using System;

namespace Domain.File
{
    public class FileMappings : Profile
    {
        public FileMappings() {

            CreateMap<FileConfigurationDto, FileConfiguration>()
                .ForMember(d => d.FileType, s => s.MapFrom(o => (int)Enum.Parse(typeof(FileType), o.FileType.ToString())))
                .ReverseMap();
                            
        }
    }
}
