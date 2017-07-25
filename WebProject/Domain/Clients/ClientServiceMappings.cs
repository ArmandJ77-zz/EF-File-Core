using AutoMapper;
using Database.Clients;
using DTOs.Clients;
using System.Collections.Generic;

namespace Domain.Clients
{
    public class UserServiceMappings : Profile
    {
        public UserServiceMappings() {
            CreateMap<ClientDto, Client>()
              .ReverseMap()
              ;

            CreateMap<List<Client>,List<ClientDto>>()
                .AfterMap((s,d) => {

                    s.ForEach(x =>
                    {
                        d.Add(new ClientDto {
                            Id = x.ClientId,
                            Name = x.Name
                        });
                    });

                })
              .ReverseMap()
              ;
        }
    }
}
