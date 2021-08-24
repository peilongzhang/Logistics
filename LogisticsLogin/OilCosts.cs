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
    public class OilCosts
    {
        public IOilCost Ioilcost;


        public OilCosts(IOilCost _Ioilcost)
        {
            Ioilcost = _Ioilcost;
        }
        /// <summary>
        /// 油费显示
        /// </summary>
        /// <returns></returns>
        public List<OilCost> OilCostshow()
        {
            try
            {
                string sql = $"select * from OilCost";

                List<OilCost> _cost = Ioilcost.GetT_Dapper(sql);
                return _cost;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 油费查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<OilCost> OilCostCha(string name)
        {
            try
            {
                string sql = $"select * from OilCost where OilCostCarHao='{name}'";

                List<OilCost> _Ioilcosts = Ioilcost.GetT_Dapper(sql);
                return _Ioilcosts;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 油费删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int OilCostDel(int id)
        {
            try
            {
                string sql = $"delete from OilCost where OilCostId={ id}";

                return Ioilcost.Add_Dapper(sql);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 油费添加
        /// </summary>
        /// <param ></param>
        /// <returns></returns>

        public int OilCostAdd(OilCost Oilcost)
        {
            try
            {

                string sql = $"insert into OilCost(OilCostId,OilCostCarHao,OilCostPrice,OilCostLitre,OilCostKilometre,OilCostPayment,OilCostBanLiRen,OilCostRemark,OilCostDate) values(@OilCostId,@OilCostCarHao,@OilCostPrice,@OilCostLitre,@OilCostKilometre,@OilCostPayment,@OilCostBanLiRen,@OilCostRemark,@OilCostDate)";

                return Ioilcost.Add_Dapper(sql, Oilcost);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 油费反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public OilCost OilCostFan(int id)
        {
            try
            {
                string sql = $"select * from OilCost where OilCostId={id}";

                OilCost _Ioilcosts = Ioilcost.GetT_Dapper(sql).FirstOrDefault();
                return _Ioilcosts;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 油费修改
        /// </summary>
        /// <param"></param>
        /// <returns></returns>
        public int OilCostUpd(OilCost Oilcost)
        {
            try
            {
                string sql = $"update OilCost set OilCostCarHao='{Oilcost.OilCostCarHao}',OilCostPrice='{Oilcost.OilCostPrice}',OilCostLitre='{Oilcost.OilCostLitre}',OilCostKilometre='{Oilcost.OilCostKilometre}',OilCostPayment='{Oilcost.OilCostPayment}',OilCostBanLiRen='{Oilcost.OilCostBanLiRen}',OilCostRemark='{Oilcost.OilCostRemark}',OilCostDate='{Oilcost.OilCostDate}' where OilCostId={Oilcost.OilCostId}";

                return Ioilcost.Add_Dapper(sql);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
