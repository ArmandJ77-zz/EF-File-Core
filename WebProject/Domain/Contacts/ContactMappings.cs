using AutoMapper;
using Database.Contacts;
using DTOs.Contacts;
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
        }
    }
}
