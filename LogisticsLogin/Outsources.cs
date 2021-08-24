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
    public class Outsources
    {
        public IOutsource Ioutsource;


        public Outsources(IOutsource _outsource)
        {
            Ioutsource = _outsource;
        }
        /// <summary>
        /// 外协单位管理
        /// </summary>
        /// <returns></returns>
        public List<Outsource> Outsourcesshow()
        {
            try
            {
                string sql = $"select * from Outsource";

                List<Outsource> _Outsources = Ioutsource.GetT_Dapper(sql);
                return _Outsources;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 外协单位管理查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Outsource> OutsourcesCha(string name)
        {
            try
            {
                string sql = $"select * from Outsource where OutsourceName='{name}'";

                List<Outsource> _Outsources = Ioutsource.GetT_Dapper(sql);
                return _Outsources;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 外协单位管理删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int OutsourcesDel(int id)
        {
            try
            {
                string sql = $"delete from Outsource where OutsourceId={ id}";

                return Ioutsource.Add_Dapper(sql);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 外协单位管理添加
        /// </summary>
        /// <param ></param>
        /// <returns></returns>

        public int OutsourcesAdd(Outsource outsource)
        {
            try
            {

                string sql = $"insert into Outsource(OutsourceId,OutsourceName,OutsourceEmail,OutsourceGuPhone,OutsourceTelephone,OutsourceDiZhi,OutsourceDate) values(@OutsourceId,@OutsourceName,@OutsourceEmail,@OutsourceGuPhone,@OutsourceTelephone,@OutsourceDiZhi,@OutsourceDate)";

                return Ioutsource.Add_Dapper(sql, outsource);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 外协单位反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public Outsource OutsourcesFan(int id)
        {
            try
            {
                string sql = $"select * from Outsource where OutsourceId={id}";

                Outsource _Outsource = Ioutsource.GetT_Dapper(sql).FirstOrDefault();
                return _Outsource;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 外协单位修改
        /// </summary>
        /// <param name="Ownerren"></param>
        /// <returns></returns>
        public int OutsourcesUpd(Outsource outsource)
        {
            try
            {
                string sql = $"update Outsource set OutsourceName='{outsource.OutsourceName}',OutsourceEmail='{outsource.OutsourceEmail}',OutsourceGuPhone='{outsource.OutsourceGuPhone}',OutsourceTelephone='{outsource.OutsourceTelephone}',OutsourceDiZhi = '{outsource.OutsourceDiZhi}',OutsourceDate = '{outsource.OutsourceDate}' where OutsourceId = {outsource.OutsourceId}";

                return Ioutsource.Add_Dapper(sql);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
