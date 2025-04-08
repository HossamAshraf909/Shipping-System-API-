namespace Shipping.BL.DTOs.Auth.Permission
{
    public class PermissionDTO
    {

        public string pageName { get; set; }
        public bool canCreate { get; set; } = false;
        public bool canRead { get; set; } = false;
        public bool canUpdate { get; set; } = false;
        public bool canDelete { get; set; } = false;
    }
}
