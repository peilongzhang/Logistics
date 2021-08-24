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
    public class PutIns
    {

        public IputIn Iputin;


        public PutIns(IputIn _Iputin)
        {
            Iputin = _Iputin;
        }
        /// <summary>
        /// 入库显示
        /// </summary>
        /// <returns></returns>
        public List<PutInStorage> PutInStorageshow()
        {
            try
            {
                string sql = $"select * from PutInStorage";

                List<PutInStorage> _putin = Iputin.GetT_Dapper(sql);
                return _putin;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 付款添加
        /// </summary>
        /// <param ></param>
        /// <returns></returns>
        public int PutInStorageAdd(PutInStorage PutInstorage)
        {
            try
            {

                string sql = $"insert into PutInStorage(PutId,PutName,PutType,PutTexture,PutSize,PutDiZhi,PutNum,PutPrice,PutPayment,PutMoney,PutRegister,PutRemark,PutDate) values(@PutId,@PutName,@PutType,@PutTexture,@PutSize,@PutDiZhi,@PutNum,@PutPrice,@PutPayment,@PutMoney,@PutRegister,@PutRemark,@PutDate)";

                return Iputin.Add_Dapper(sql, PutInstorage);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
