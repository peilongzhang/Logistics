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
    public class Owners
    {
        public IOwner Iowner;


        public Owners(IOwner _Iowner)
        {
            Iowner = _Iowner;
        }
        /// <summary>
        /// 货主管理
        /// </summary>
        /// <returns></returns>
        public List<OwnerRen> OwnerRenshow()
        {
            try
            {
                string sql = $"select * from OwnerRen";

                List<OwnerRen> _ren = Iowner.GetT_Dapper(sql);
                return _ren;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 货主管理查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<OwnerRen> OwnerRenCha(string name)
        {
            try
            {
                string sql = $"select * from OwnerRen where OwnerRenName='{name}'";

                List<OwnerRen> _ren = Iowner.GetT_Dapper(sql);
                return _ren;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 货主管理删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int OwnerRenDel(int id)
        {
            try
            {
                string sql = $"delete from OwnerRen where OwnerRenId={ id}";

                return Iowner.Add_Dapper(sql);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 货主管理添加
        /// </summary>
        /// <param name="Ownerren"></param>
        /// <returns></returns>

        public int OwnerRenAdd(OwnerRen Ownerren)
        {
            try
            {

                string sql = $"insert into OwnerRen(OwnerRenId,OwnerRenName,OwnerRenPhone,OwnerRenCompany,OwnerRenDiZhi,OwnerReneffective,OwnerRenImg,OwnerRenRemark,OwnerRenDate) values(@OwnerRenId,@OwnerRenName,@OwnerRenPhone,@OwnerRenCompany,@OwnerRenDiZhi,@OwnerReneffective,@OwnerRenImg,@OwnerRenRemark,@OwnerRenDate)";

                return Iowner.Add_Dapper(sql, Ownerren);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public OwnerRen OwnerRenFan(int id)
        {
            try
            {
                string sql = $"select * from OwnerRen where OwnerRenId={id}";

                OwnerRen _Owner = Iowner.GetT_Dapper(sql).FirstOrDefault();
                return _Owner;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="Ownerren"></param>
        /// <returns></returns>
        public int OwnerRenUpd(OwnerRen Ownerren)
        {
            try
            {
                string sql = $"update OwnerRen set OwnerRenName='{Ownerren.OwnerRenName}',OwnerRenPhone='{Ownerren.OwnerRenPhone}',OwnerRenCompany='{Ownerren.OwnerRenCompany}',OwnerRenDiZhi='{Ownerren.OwnerRenDiZhi}',OwnerReneffective='{Ownerren.OwnerReneffective}',OwnerRenImg='{Ownerren.OwnerRenImg}',OwnerRenRemark='{Ownerren.OwnerRenRemark}',OwnerRenDate='{Ownerren.OwnerRenDate}' where OwnerRenId='{Ownerren.OwnerRenId}'";

                return Iowner.Add_Dapper(sql);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
