﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace LogisticsCommon
{
    public class MySqlDapperHelper : Lianjie
    {
        private static readonly string MySqlConnection =
           "Data Source=192.168.31.22;Initial Catalog=logistics;User ID=root;password=123456;port=3306;SslMode = none";
        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int Execute(string sql, object param = null)
        {
            using (IDbConnection conn = new MySqlConnection(MySqlConnection))
            {
                try
                {
                    return conn.Execute(sql, param);
                }
                catch (Exception ex)
                {
                    // NLogHelper.Error("执行数据库操作异常", ex);
                    //throw;
                    return 0;
                }
            }
        }


        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public List<T> GetClassLists<T>(string sql, object param = null) where T : class, new()
        {
            using (IDbConnection conn = new MySqlConnection(MySqlConnection))
            {
                conn.Open();
                try
                {
                    List<T> ts = conn.Query<T>(sql, param).ToList();
                    return ts;
                }
                catch (Exception ex)
                {
                    //NLogHelper.Error("数据库异常错误", ex);
                    //throw;
                    return null;
                }
            }
        }

        /// <summary>
        /// 事务1 - 全SQL
        /// </summary>
        /// <param name="sqlarr">多条SQL</param>
        /// <param name="param">param</param>
        /// <returns></returns>
        public int ExecuteTransaction(string[] sqlarr, object[] param)
        {
            using (MySqlConnection con = new MySqlConnection(MySqlConnection))
            {
                con.Open();
                using (var transaction = con.BeginTransaction())
                {
                    try
                    {
                        int result = 0;
                        for (int i = 0; i < sqlarr.Length; i++)
                        {
                            result += con.Execute(sqlarr[i], param[i], transaction);
                        }
                        //foreach (var sql in sqlarr)
                        //{
                        //    result += con.Execute(sql, null, transaction);
                        //}

                        transaction.Commit();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        //NLogHelper.Error("违反事务规则",ex);
                        transaction.Rollback();
                        return 0;
                    }
                }
            }
        }





        /// <summary>
        /// 事务2 - 声明参数
        ///demo:
        ///dic.Add("Insert into Users values (@UserName, @Email, @Address)",
        ///        new { UserName = "jack", Email = "380234234@qq.com", Address = "上海" });
        /// </summary>
        /// <param name="Key">多条SQL</param>
        /// <param name="Value">param</param>
        /// <returns></returns>
        public int ExecuteTransaction(Dictionary<string, object> dic)
        {
            using (MySqlConnection con = new MySqlConnection(MySqlConnection))
            {
                con.Open();
                using (var transaction = con.BeginTransaction())
                {
                    try
                    {
                        int result = 0;
                        foreach (var sql in dic)
                        {
                            result += con.Execute(sql.Key, sql.Value, transaction);
                        }

                        transaction.Commit();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        //NLogHelper.Error("违反事务规则", ex);
                        transaction.Rollback();
                        return 0;
                    }
                }
            }
        }

        public object ExecuteScalar(string sql, object param = null)
        {
            using (IDbConnection con = new MySqlConnection(MySqlConnection))
            {
                con.Open();
                try
                {
                    object i = con.ExecuteScalar(sql, param);
                    return i;
                }
                catch (Exception ex)
                {
                    //NLogHelper.Error("数据库异常错误", ex);
                    //throw;
                    return null;
                }
            }
        }
    }
}
