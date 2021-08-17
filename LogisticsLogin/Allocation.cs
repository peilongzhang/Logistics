using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogisticsIDAL;
using LogisticsDAL;
using LogisticsCommon;
using LogisticsModel;

namespace LogisticsLogin
{
    public class Allocation
    {
        public IRoleFen IroleFen;


        public Allocation(IRoleFen _IroleFen)
        {
            IroleFen = _IroleFen;
        }

       /// <summary>
       /// 授权登录
       /// </summary>
       /// <param name="UsersName"></param>
       /// <param name="UsersPass"></param>
       /// <returns></returns>
        public List<UsersRole> allocationshow(string UsersName,string UsersPass)
        {
            try
            {
                string sql = $"SELECT C.jurisdictionId,C.jurisdictionName,C.jurisdictionJID,C.jurisdictionLink FROM UsersRole A JOIN  roleMenu B ON A.UsersId=B.RoleIdid JOIN jurisdiction C ON C.jurisdictionId = B.jurisdictionid JOIN Users D on A.UsersId = D.UsersId WHERE D.UsersName = '{UsersName}' and D.UsersPass = '{UsersPass}'";

                List<UsersRole> _roleMenu = IroleFen.GetT_Dapper(sql);
                return _roleMenu;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<UsersRole> allocationCha(int id)
        {
            try
            {
                string sql = $"SELECT C.jurisdictionId,C.jurisdictionName,C.jurisdictionJID,C.jurisdictionLink FROM UsersRole A JOIN  roleMenu B ON A.UsersId=B.RoleIdid JOIN jurisdiction C ON C.jurisdictionId = B.jurisdictionid JOIN Users D on A.UsersId = D.UsersId WHERE C.jurisdictionJID=0 AND A.UsersId={id}";

                List<UsersRole> _roleMenu = IroleFen.GetT_Dapper(sql);
                return _roleMenu;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
