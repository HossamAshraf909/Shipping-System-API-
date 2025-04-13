namespace Shipping.BL.DTOs.Auth.Permission
{
    public class AssignPermissionsToRoleDTO
    {
        public string Role { get; set; }
        public List<PermissionDTO> Permissions { get; set; } = new();

    }
}
