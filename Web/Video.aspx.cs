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
    public partial class Video : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                BindVideos();
            }
        }

        private void BindVideos()
        {
            DataTable dt = VideoManager.SelectAll();
            if (dt != null && dt.Rows.Count != 0)
            {
                VideoTopListView.DataSource = dt;
                VideoTopListView.DataBind();
            }
        }
    }
    }
