using AutoMapper;
using Evis.VisitorManagement.DataProject.Model;
using Evis.VisitorManagement.DataProject.Model.Entities.Custom;
using Evis.VisitorManagement.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evis.VisitorManagement.Web.Mapping
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainMappings";
            }
        }

        protected override void Configure()
        {

            Mapper.CreateMap<RegisterViewModel, ApplicationUser>();
            Mapper.CreateMap<RegisterViewModel, UserList>();
        }
    }
}