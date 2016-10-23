using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace sample26
{
    class Program
    {
        [FileIOPermission(SecurityAction.Demand, AllLocalFiles = FileIOPermissionAccess.Read)]
        public static void DeclarativeCAS()
        {
            //To do somenthing
        }

        public static void ImperativeCas()
        {
            FileIOPermission f = new FileIOPermission(PermissionState.None);
            f.AllFiles = FileIOPermissionAccess.Read;
            try
            {
                f.Demand();
            }
            catch (SecurityException s)
            {
                Console.WriteLine(s.Message);
            }
        }

        static void Main(string[] args)
        {
        }
    }
}
