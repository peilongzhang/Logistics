using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsModel
{
    //用户角色表
    public class UsersRole
    {
        //public int UsersRoleId { get; set; }//编号
        //public int UsersId { get; set; }//用户id 
        //public int RoleId { get; set; }//角色id

        //public int RoleMenuId { get; set; }//编号
        //public int RoleIdid { get; set; }//角色id
        //public int jurisdictionid { get; set; }//功能id

        public int jurisdictionId { get; set; }//权限id
        public string jurisdictionName { get; set; }//权限名称
        public int jurisdictionJID { get; set; }//权限id下级
        public string jurisdictionLink { get; set; } //权限链接

        //public int UsersId { get; set; }    //用户id
        //public string UsersName { get; set; }//用户账号
        //public string UsersPass { get; set; }//用户密码
    }
}
