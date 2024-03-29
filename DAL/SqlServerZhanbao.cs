﻿using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class SqlServerZhanbao:IZhanbao
    {
        public  DataTable SelectTop5()
        {
            string sql = "select top 5 * from Zhanbao order by z_time desc";
            return DBHelper.GetFillData(sql);
        }
        public  DataTable SelectAll()
        {
            string sql = "select  * from Zhanbao order by z_time desc";
            return DBHelper.GetFillData(sql);
        }
        public DataTable SelectID(int Z_Id)
        {
            string sql = "select  * from Zhanbao where z_id=@z_id";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@z_id", Z_Id)
            };
            DataTable dt = DBHelper.GetFillData(sql, sp);
            return dt;
        }
        public  DataTable SelectTop(int top)
        {
            string sql = "select  top " + top + " * from Zhanbao order by z_time desc";

            return DBHelper.GetFillData(sql);
        }
        public  int Insert(Zhanbao ns)
        {
            string sql = "insert into [Zhanbao]([Z_Title],[Z_Time],[Z_Content]) values(@z_title,@z_time,@z_content)";
            SqlParameter[] sp = new SqlParameter[]
            { 
            new SqlParameter("@z_title",ns.Z_Title),
            new SqlParameter("@z_time",ns.Z_Time),
            new SqlParameter("@z_content",ns.Z_Content)};
            return DBHelper.GetExcuteNonQuery(sql, sp);
        }
    }
}

