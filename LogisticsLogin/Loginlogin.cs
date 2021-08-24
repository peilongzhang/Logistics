using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogisticsModel;
using LogisticsIDAL;
using LogisticsDAL;
using LogisticsCommon;

namespace LogisticsLogin
{
   
    public class Loginlogin:Login
    {
        MySqlDapperHelper Helper = new MySqlDapperHelper();


        public ILogin ILogin;

        

        public Loginlogin(ILogin Iloginmouth)
        {
            ILogin = Iloginmouth;
        }

        public Users LoginShow(string UsersName,string UsersPass)
        {
            try
            {
                string sql = $"select * from Users where UsersName='{UsersName}' and UsersPass='{UsersPass}'";

                Users _ILogin = ILogin.GetT_Dapper1(sql).FirstOrDefault();
                return _ILogin;
                //int i = Convert.ToInt32(ILogin.ExucteScalar(sql));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
