namespace Shipping.BL.DTOs.Auth.Permission
{
    public class AssignPermissionsToRoleDTO
    {
        public string RoleId { get; set; }
        public List<PermissionDTO> Permissions { get; set; } = new();

    }
}
