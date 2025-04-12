using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shipping.DAL.Consistants;
using Shipping.DAL.Entities.Identity;

namespace Shipping.PL.Helpers
{
    public static class PermissionHelper
    {
        public static List<List<string>> GeneratePermissionsForAdminRole()
        {
            var controllers = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(ControllerBase).IsAssignableFrom(t) && !t.IsAbstract);
            var _Permissions = new List<List<string>>();
            foreach (var controller in controllers)
            {
                var controllerName = controller.Name.Replace("Controller", "");
                var permission = Permissions.GenerateAdminPermissions(controllerName);
                _Permissions.Add(permission);
            }
            return _Permissions;
        }
    }
}
