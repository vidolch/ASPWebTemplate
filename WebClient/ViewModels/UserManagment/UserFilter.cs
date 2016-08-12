using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using DataAccess.Models;
using DataAccess.Repositories;
using Services.EntityServices;

namespace WebClient.ViewModels.UserManagment
{
    public class UserFilter : BaseFilterViewModel<User>
    {
        public UserFilter()
        {
            this.Roles = Role.GetValues(typeof(Role)).Cast<Role>().Select(r => new SelectItem
            {
                Value = r.GetHashCode().ToString(),
                Text = r.ToString(),
                Selected = RoleID != null && (int)r == RoleID.Value
            });
        }

        [Common.Filter(DisplayName = "Username")]
        public string Username { get; set; }

        [Common.Filter(DisplayName = "First Name")]
        public string FirstName { get; set; }

        [Common.Filter(DisplayName = "Last Name")]
        public string LastName { get; set; }

        [Common.Filter(DisplayName = "Email")]
        public string Email { get; set; }
        
        public int? RoleID { get; set; }

        [Common.Filter(DisplayName = "Role", DropDownTargetProperty = "RoleID")]
        public IEnumerable<ISelectItem> Roles { get; set; }

        public override Expression<Func<User, bool>> BuildFilter()
        {
            return u =>     (String.IsNullOrEmpty(Username)     || u.Username.Contains(Username)) &&
                            (String.IsNullOrEmpty(FirstName)    || u.FirstName.Contains(FirstName)) &&
                            (String.IsNullOrEmpty(LastName)     || u.LastName.Contains(LastName)) &&
                            (String.IsNullOrEmpty(Email)        || u.Email.Contains(Email)) &&
                            (RoleID == null || (int)u.Role == RoleID.Value);
        }
    }
}