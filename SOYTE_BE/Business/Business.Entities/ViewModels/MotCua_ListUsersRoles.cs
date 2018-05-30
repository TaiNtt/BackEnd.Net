using Business.Entities;
using System;

namespace Business.Entities.ViewModels
{
	public class MotCua_ListUsersRoles
    {
        public int UserRoleID { get; set; }
        public int RoleID { get; set; }
        public int UserID { get; set; }
        public string RoleName { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
    }
}
