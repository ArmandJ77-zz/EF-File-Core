using AutoMapper;
using Database.Files;
using DTOs.Files;
using Enums;
using System;

namespace Domain.FileConfigurations
{
    public class FileConfigurationMappings : Profile
    {
        public FileConfigurationMappings()
        {

            CreateMap<FileConfigurationDto, ClientFileConfiguration>()
                .ForMember(d => d.FileType, s => s.MapFrom(o => (int)Enum.Parse(typeof(FileType), o.FileType.ToString())))
                .ReverseMap();
        }
    }
}
