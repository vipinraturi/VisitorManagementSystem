using Evis.VisitorManagement.DataProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using WebGrease.Css.Extensions;

namespace Evis.VisitorManagement.Web.ViewModel
{
    public class RegisterViewModel
    {

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Create Username")]
        [RegularExpression("^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }

        public int GenderId { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string RoleId { get; set; }

        public string Role { set; get; }

        public string Address { get; set; }
        public IEnumerable<ApplicationRole> UserRoles { get; set; }

        public IEnumerable<SelectListItem> AllRoles
        {
            get
            {
                var items = new List<SelectListItem>();
                UserRoles.ForEach(x => items.Add(new SelectListItem { Text = x.Name, Value = x.Id }));
                return items;
            }
        }
    }
}