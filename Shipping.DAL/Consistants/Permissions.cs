using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.DAL.Consistants
{
    public static class Permissions
    {
      public static string GeneratePermission(string module, string TypeOfPermission)
      {
          return $"Permission.{module}.{TypeOfPermission}";
      }
      public static List<string> GenerateAdminPermissions(string module)
        {
            return new List<string>() 
            {
             $"Permission.{module}.Create",
             $"Permission.{module}.Read",
             $"Permission.{module}.Update",
             $"Permission.{module}.Delete",
            };
        }
    }
}
