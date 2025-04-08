using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.BL.Consistants
{
    public static class Permissions
    {
      public static string GeneratePermission(string module, string TypeOfPermission)
      {
          return $"Permission.{module}.{TypeOfPermission}";
      }
        
    }
}
