﻿using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Saishi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (GetNoticeId()  == 0)
                {
                    BindSaishi();
                }
                else
                {
                    // ListsaishiDetail();
                }

                //ListsaishiDetail();
                //dlBind();
                //Bindup();
            }
        }

        private void BindSaishi()
        {
            DataTable dt = BLL.SaishiManager.SelectAll();

            if (dt != null && dt.Rows.Count != 0)
            {
                SaishiListView.DataSource = dt;
                SaishiListView.DataBind();
            }
        }

        private void ListsaishiDetail()
        {
            try
            {
                int S_Id = GetNoticeId();

                if (S_Id == 0)
                {
                    Response.Redirect("~/");
                    return;
                }

                DataTable data = BLL.SaishiManager.SelectsaishiById(S_Id);

                if (data != null)
                {
                    SaishiListView.DataSource = data;
                    SaishiListView.DataBind();
                }
            }
            catch (Exception ex)
            {
              Label2 .Text = ex.Message;
            }
        }
        protected int GetNoticeId()
        {
            try
            {
                // 注意类型转换
               int  id = !String.IsNullOrEmpty(Request.QueryString["id"]) ? int.Parse(Request.QueryString["id"]) : 0;

                return id;
            }
            catch (Exception ex)
            {
                Label2.Text = ex.Message;
                return 0;
            }
        }

        /// <summary>
        ///  点击参赛按钮，添加参赛记录到数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Button         btn               = (Button)sender;
                HiddenField hideSaishiId = btn.Parent.FindControl("HideSaishiId") as HiddenField;

                int userId   = GetLoginedUserId();
                int saishiId = Convert.ToInt32(hideSaishiId.Value);

                if (userId == 0) // 未登录
                {
                    return;
                }

                Model.Cansai canSai = new Model.Cansai()
                {
                    S_Id = saishiId,
                    UserId = userId
                };

                int line = BLL.CansaiManager.AddCansai(canSai);  // 开始添加参赛记录

                if (line <= 0)
                {
                    // 插入失败
                }
                else
                {
                    // 插入成功
                    BindSaishi(); // 重新查询数据库并绑定，会引起页的回发哦
                }
            }
            catch (Exception)
            {
                // 发生异常执行这里哦
            }
        }

        /// <summary>
        /// 获取登录用户的 ID
        /// </summary>
        /// <returns>用户 ID</returns>
        protected int GetLoginedUserId()
        {
            return Session["UserId"] != null ? Convert.ToInt32(Session["UserId"]) : 0;
        }

        //private void Bindup()
        //{
        //    DataTable dt = SaishiManager.updateS_clickNum();
        //    if (dt != null && dt.Rows.Count != 0)
        //    {
        //       DataList1.DataSource = dt;
        //        DataList1.DataBind();
        //    }
        //}

        //        private void dlBind()
        //        {
        //            int curpage = Convert.ToInt32(this.Label7.Text);
        //            PagedDataSource ps = new PagedDataSource();
        //            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["NBNB"].ConnectionString);
        //            SqlDataAdapter oda = new SqlDataAdapter("select * from Saishi", con);
        //            DataSet ds = new DataSet();
        //            oda.Fill(ds);//这里是数据源

        //            ps.DataSource = ds.Tables[0].DefaultView;
        //            ps.AllowPaging = true; //是否可以分页
        //            ps.PageSize = 10; //显示的数量
        //            ps.CurrentPageIndex = curpage - 1; //取得当前页的页码
        //            this.LinkButton3.Enabled = true;
        //            this.LinkButton4.Enabled = true;
        //            this.LinkButton5.Enabled = true;
        //            this.LinkButton2.Enabled = true;
        //            if (curpage == 1)
        //            {
        //                this.LinkButton2.Enabled = false;//不显示第一页按钮
        //                this.LinkButton3.Enabled = false;//不显示上一页按钮
        //            }
        //            if (curpage == ps.PageCount)
        //            {
        //                this.LinkButton4.Enabled = false;//不显示下一页
        //                this.LinkButton5.Enabled = false;//不显示最后一页
        //            }
        //            this.Label2.Text = Convert.ToString(ps.PageCount);
        //            this.DataList1.DataSource = ps;
        //            this.DataList1.DataKeyField = "s_id";
        //            this.DataList1.DataBind();
        //        }

        //        protected void LinkButton2_Click(object sender, EventArgs e)  //第一页
        //        {
        //            this.Label7.Text = "1";   //Label7.Text为当前页
        //            this.dlBind();
        //        }
        //        protected void LinkButton3_Click(object sender, EventArgs e) //上一页
        //        {
        //            this.Label7.Text = Convert.ToString(Convert.ToInt32(this.Label7.Text) - 1);
        //            this.dlBind();
        //        }
        //        protected void LinkButton4_Click(object sender, EventArgs e)  //下一页
        //        {
        //            this.Label7.Text = Convert.ToString(Convert.ToInt32(this.Label7.Text) + 1);
        //            this.dlBind();
        //        }
        //        protected void LinkButton5_Click(object sender, EventArgs e)  //最后一页
        //        {
        //            this.Label7.Text = this.Label2.Text; //Label2.Text为总页数
        //            this.dlBind();
        //        }
        //    }
        //}
    }
}