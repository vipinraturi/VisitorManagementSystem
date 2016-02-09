using Evis.VisitorManagement.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Evis.VisitorManagement.DataProject.Model.Entities.Custom;

namespace Evis.VisitorManagement.Web.ViewModel
{
    public class UsersViewModel : PagingInformation
    {
        public IEnumerable<UserList> UsersList { get; set; }
    }
}