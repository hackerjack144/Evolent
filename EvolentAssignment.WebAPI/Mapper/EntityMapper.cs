using AutoMapper;
using EvolentAssignment.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvolentAssignment.WebAPI.Mappper
{
    public class EntityMapper<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Contact, Models.ContactModel>());
            var config1 = new MapperConfiguration(cfg => cfg.CreateMap<Models.ContactModel, Contact>());
        }
    }
}