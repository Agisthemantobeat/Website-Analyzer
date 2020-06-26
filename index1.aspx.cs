using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace excel
{
    public partial class index1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            p.Visible = false;

        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            string path = Path.GetFileName(FileUpload12.FileName);
            path = path.Replace(" ", "");
            FileUpload12.SaveAs(Server.MapPath("~/ExcelFile/") + path);
            String ExcelPath = Server.MapPath("~/ExcelFile/") + path;
            p.Visible = true;
            Session["path"] = path;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
           Response.Redirect("WebForm1.aspx");
        }
    }
}