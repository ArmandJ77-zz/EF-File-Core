using AutoMapper;
using Database.Contacts;
using DTOs.Contacts;
using System;
using System.Collections.Generic;

namespace Domain.Contacts
{
    public class ContactMappings : Profile
    {
        public ContactMappings() {
            CreateMap<List<ImportedContactsDto>, List<ImportedContact>>()
                .AfterMap((s,d) => {
                    s.ForEach(item =>
                    {
                        d.Add(new ImportedContact
                        {
                            Age = item.age,
                            Email = item.email,
                            Gender = item.gender,
                            Name = item.name,
                            Phone = item.phone,
                            Photo = item.photo,
                            Region = item.region,
                            Surname = item.surname,
                            Title = item.title
                        });
                    });
                })
             .ReverseMap()
             ;

            CreateMap<string, ImportedContact>()
                .AfterMap((s,d) => {
                    string[] values = s.Split(',');

                    var dto = new ImportedContact()
                    {
                        ImportedContactId = Convert.ToInt16(values[0]),
                        Name = values[1],
                        Surname = values[2],
                        Gender = values[3],
                        Region = values[4],
                        Age = Convert.ToInt16(values[5]),
                        Title = values[6],
                        Phone = values[7],
                        Email = values[8],
                        Photo = values[9]
                    };
                });
        }
    }
}
