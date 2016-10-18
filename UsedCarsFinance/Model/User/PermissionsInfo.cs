using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	/// <summary>
	/// [否决的]
	/// </summary>
   public class MenuPermissionsInfo
   {
       public int RoleId { get; set; }

       public List<int> Menus { get; set; }
       
    }
}
