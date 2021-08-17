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
    public class JurisdictionJ
    {
        //public IjurisdictionS  IjurisdictionS;


        //public JurisdictionJ(IjurisdictionS _IjurisdictionS)
        //{
        //    IjurisdictionS = _IjurisdictionS;
        //}

        jurisdictionS jurisdictionS = new jurisdictionS();

        public List<Jurisdiction> Jurisdictionshow()
        {
            try
            {
                string sql = $"select *from Jurisdiction";

                List<Jurisdiction> _Jurisdiction = jurisdictionS.GetT_Dapper(sql);
                return _Jurisdiction;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Jurisdiction> JurisdictionCha(int id)
        {
            try
            {
                string sql = $"select *from Jurisdiction where jurisdictionJID={id}";

                List<Jurisdiction> _Jurisdiction = jurisdictionS.GetT_Dapper(sql);
                return _Jurisdiction;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public int JurisdictionAdd()
        //{
        //    try
        //    {
        //        string sql = $"";

        //        List<Jurisdiction> _Jurisdiction = IjurisdictionS.GetT_Dapper(sql);
        //        return _Jurisdiction;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}
