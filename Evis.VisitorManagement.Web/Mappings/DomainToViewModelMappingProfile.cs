using AutoMapper;
using Evis.VisitorManagement.DataProject.Model;
using Evis.VisitorManagement.DataProject.Model.Entities;
using Evis.VisitorManagement.DataProject.Model.Entities.Custom;
using Evis.VisitorManagement.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evis.VisitorManagement.Web.Mapping
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappings";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ApplicationUser, RegisterViewModel>();
            Mapper.CreateMap<UserList, RegisterViewModel>();
        }
    }
}