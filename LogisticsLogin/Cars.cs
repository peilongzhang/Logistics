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
    public class Cars
    {
        public ICar Icar;


        public Cars(ICar _Icar)
        {
            Icar = _Icar;
        }
        /// <summary>
        /// 显示车辆管理
        /// </summary>
        /// <returns></returns>
        public List<Vehicle> Carshow()
        {
            try
            {
                string sql = $"select * from vehicle";

                List<Vehicle> _car = Icar.GetT_Dapper(sql);
                return _car;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 显示车辆查询
        /// </summary>
        /// <returns></returns>
        public List<Vehicle> CarCha(string name)
        {
            try
            {
                string sql = $"select * from vehicle where VehicleName='{name}'";

                List<Vehicle> _car = Icar.GetT_Dapper(sql);
                return _car;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 显示车辆添加
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int CarAdd(Vehicle vehicle)
        { 
            try
            {
                //string sql = $"insert into vehicle values({vehicle.VehicleId},'{vehicle.VehicleBrand}','{vehicle.VehicleCarHao}','{vehicle.VehicleName}','{vehicle.VehicleCompany}','{vehicle.VehicleCarType}','{vehicle.VehicleColor}','{vehicle.VehicleDate}','{vehicle.VehicleYunHao}','{vehicle.VehicleInsurance}','{vehicle.VehicleAnnual}','{vehicle.VehicleKilometre}')";

                string sql = $"insert into vehicle(VehicleId,VehicleBrand,VehicleCarHao,VehicleName,VehicleCompany,VehicleCarType,VehicleColor,VehicleDate,VehicleYunHao,VehicleInsurance,VehicleAnnual,VehicleKilometre) values(@VehicleId,@VehicleBrand,@VehicleCarHao,@VehicleName,@VehicleCompany,@VehicleCarType,@VehicleColor,@VehicleDate,@VehicleYunHao,@VehicleInsurance,@VehicleAnnual,@VehicleKilometre)";

                return Icar.Add_Dapper(sql, vehicle);
                 
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 车辆管理删除
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public int CarDel(int id)
        {
            try
            {
                string sql = $"delete from vehicle where VehicleId={id}";

                return Icar.Add_Dapper(sql);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 车辆管理反填
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Vehicle CarFan(int id)
        {
            try
            {
                string sql = $"select * from vehicle where VehicleId={id}";

                Vehicle _car = Icar.GetT_Dapper(sql).FirstOrDefault();
                return _car;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 车辆管理修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int CarUpd(Vehicle vehicle)
        {
            try
            {
                string sql = $"update vehicle set VehicleBrand='{vehicle.VehicleBrand}',VehicleCarHao='{vehicle.VehicleCarHao}',VehicleName='{vehicle.VehicleName}',VehicleCompany='{vehicle.VehicleCompany}',VehicleCarType = '{vehicle.VehicleCarType}',VehicleColor = '{vehicle.VehicleColor}',VehicleDate = '{vehicle.VehicleDate}',VehicleYunHao = '{vehicle.VehicleYunHao}',VehicleInsurance = '{vehicle.VehicleInsurance}',VehicleAnnual = '{vehicle.VehicleAnnual}',VehicleKilometre = '{vehicle.VehicleKilometre}' where VehicleId = {vehicle.VehicleId}";

                return Icar.Add_Dapper(sql);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
