using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsModel
{
    public class OilCost
    {
        public int OilCostId { get; set; }
        public string OilCostCarHao { get; set; }
        public int OilCostPrice { get; set; }
        public int OilCostLitre { get; set; }
        public int OilCostKilometre { get; set; }
        public string OilCostPayment { get; set; }
        public string OilCostBanLiRen { get; set; }
        public string OilCostRemark { get; set; }
        public DateTime OilCostDate { get; set; }
    }
}
