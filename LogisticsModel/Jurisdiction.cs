using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsModel
{
    //权限（菜单）表
    public class Jurisdiction
    {
        public int jurisdictionId { get; set; }//权限id
        public string jurisdictionName { get; set; }//权限名称
        public int jurisdictionJID { get; set; }//权限id下级
        public string jurisdictionLink { get; set; } //权限链接
    }
}
