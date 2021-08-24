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
    public class Lines
    {
        public ILine Iline;


        public Lines(ILine _Iline)
        {
            Iline = _Iline;
        }

        /// <summary>
        /// 线路显示
        /// </summary>
        /// <returns></returns>
        public List<Line> Lineshow()
        {
            try
            {
                string sql = $"select * from Line";

                List<Line> _Line = Iline.GetT_Dapper(sql);
                return _Line;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 线路查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Line> LineCha(string name)
        {
            try
            {
                string sql = $"select * from Line where LineName='{name}'";

                List<Line> _Line = Iline.GetT_Dapper(sql);
                return _Line;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 线路删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int LineDel(int id)
        {
            try
            {
                string sql = $"delete from Line where LineId={ id}";

                return Iline.Add_Dapper(sql);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 线路添加
        /// </summary>
        /// <param ></param>
        /// <returns></returns>

        public int LineAdd(Line line)
        {
            try
            {

                string sql = $"insert into Line(LineId,LineName,LineQiDian,LineZhongDian,LineOutsource,LineHuozhu,LinePhone,LineDanwei,LineRemark,LineDate) values(@LineId, @LineName, @LineQiDian, @LineZhongDian, @LineOutsource, @LineHuozhu,@LinePhone, @LineDanwei, @LineRemark, @LineDate)";

                return Iline.Add_Dapper(sql, line);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 线路反填
        /// </summary>
        /// <param></param>
        /// <returns></returns>

        public Line LineFan(int id)
        {
            try
            {
                string sql = $"select * from Line where LineId={id}";

                Line _Line = Iline.GetT_Dapper(sql).FirstOrDefault();
                return _Line;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 线路修改
        /// </summary>
        /// <param name="Ownerren"></param>
        /// <returns></returns>
        public int LineUpd(Line line)
        {
            try
            {
                string sql = $"update Line set LineName='{line.LineName}',LineQiDian='{line.LineQiDian}',LineZhongDian='{line.LineZhongDian}',LineOutsource='{line.LineOutsource}',LineHuozhu = '{line.LineHuozhu}',LinePhone = '{line.LinePhone}',LineDanwei = '{line.LineDanwei}',LineRemark = '{line.LineRemark}',LineDate = '{line.LineDate}' where LineId ={line.LineId}";

                return Iline.Add_Dapper(sql);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
