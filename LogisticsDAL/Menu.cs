using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogisticsCommon;
using LogisticsIDAL;
using MySql.Data.MySqlClient;
using System.Data;
using Dapper;

namespace LogisticsDAL
{
    public class Menu<T> : IMenu<T> where T : class, new()
    {
        IDbConnection conn = new MySqlConnection(Lianjie.LianjieString);
         
        public int Add_Dapper(string sql, object obj = null)
        {
            return conn.Execute(sql,new { obj});
        }

        
        public List<T> GetT_Dapper(string sql, object obj = null)
        {
            return conn.Query<T>(sql,obj).ToList();
        }


        public object ExucteScalar(string sql, object obj = null)
        {
            return conn.Execute(sql, new { obj });
        }
        public List<T> GetT_Dapper1(string sql, object obj = null, string UsersPass = null)
        {
            return conn.Query<T>(sql, obj).ToList();
        }
    }
}
