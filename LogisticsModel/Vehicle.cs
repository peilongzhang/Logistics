using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsModel
{
    /// <summary>
    /// 车辆管理表
    /// </summary>
    public class Vehicle
    {
        public int VehicleId { get; set; }//编号
        public string VehicleBrand { get; set; }//厂牌型号
        public string VehicleCarHao { get; set; }//车牌号
        public string VehicleName { get; set; }//司机姓名
        public string VehicleCompany { get; set; }//所属公司
        public string VehicleCarType { get; set; }//车型（长*宽*高）
        public string VehicleColor { get; set; }//车辆颜色
        public DateTime VehicleDate { get; set; }//购置日期
        public string VehicleYunHao { get; set; }//营运证号
        public DateTime VehicleInsurance { get; set; }//保险到期时间
        public DateTime VehicleAnnual { get; set; }//年检到期时间
        public string VehicleKilometre { get; set; }//保养公里设置
    }
}
