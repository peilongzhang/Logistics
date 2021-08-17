using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsIDAL
{
    public interface IMenu<T> where T:class,new()
    {
        //查询
        List<T> GetT_Dapper(string sql,object obj=null);
        //登录
        List<T> GetT_Dapper1(string sql, object obj = null,string UsersPass=null);
        //增删改
        int Add_Dapper(string sql,object obj=null);

        object ExucteScalar(string sql, object obj = null);
    }
}
