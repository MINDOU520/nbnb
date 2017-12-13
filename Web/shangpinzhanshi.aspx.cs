﻿using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Shangpinzhanshi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCommodity();

            }

        }
        private void BindCommodity()
        {

            int id = Request.QueryString["id"] !=null ? int.Parse(Request.QueryString["id"]): 0;

            if (id != 0)
            {
                DataTable dt = CommodityManager.SelectID(id);

                if (dt != null && dt.Rows.Count != 0)
                {
                    DataList1.DataSource = dt;
                    DataList1.DataBind();
                }
            }

            
        }



    }
}