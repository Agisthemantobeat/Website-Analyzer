using System;
using System.Drawing;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Net.Mail;
using System.Net.Http;
using System.Data.SqlClient;

namespace excel
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        String ExcelPath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            p2.Visible = false;
            ExcelPath = Server.MapPath("~/ExcelFile/") + Session["path"].ToString();

            OleDbConnection mycon = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties=Excel 8.0; Persist Security Info = False");
            mycon.Open();
            OleDbCommand cmd = new OleDbCommand(@"select * from [Sheet1$]", mycon);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmd;

            DataSet ds = new DataSet();
            da.Fill(ds);

            mycon.Close();


            Excel.Application excelApp = new Excel.Application();
            Workbook wb;
            Worksheet ws;

            // string Path = @"C:\Users\Hp\Documents\visual studio 2015\Projects\excel\excel\ExcelFile\" + Session["path"].ToString();
            string Path = Server.MapPath("~/ExcelFile/") + Session["path"].ToString();
            wb = excelApp.Workbooks.Open(Path);
            ws = wb.Worksheets[1];

            ws.Cells[1, 2].Value = "Website Status";
            ws.Cells[1, 3].Value = "Website Status Code";
            int i = 2, j = 2, k = 3;

            while (ws.Cells[i, 1].Value != null)
            {
                try
                {

                    HttpClient client = new HttpClient();

                    var Url = ws.Cells[i++, 1].Value.ToString();
                    Uri urlCheck = new Uri(Url);
                    var client1 = new SmtpClient();
                    var res = client.GetAsync(urlCheck).Result;
                    var statusCode = res.StatusCode; //should be 404
                                                     //    MessageBox.Show(statusCode.ToString() + ' ' + (int)statusCode);
                    ws.Cells[i - 1, j] = statusCode.ToString();
                    ws.Cells[i - 1, k] = (int)statusCode;
                    wb.Save();


                }



                catch (Exception ex)
                {
                    //  MessageBox.Show(ex.Message);
                    ws.Cells[i - 1, j] = "None";
                    ws.Cells[i - 1, k] = "None";
                    // wb.Save();

                }

            }
            wb.Save();
            wb.Close(1);
            excelApp.Quit();
            OleDbConnection mycon1 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties=Excel 8.0; Persist Security Info = False");
            mycon1.Open();
            OleDbCommand cmd2 = new OleDbCommand(@"select * from [Sheet1$]", mycon1);
            OleDbDataAdapter da1 = new OleDbDataAdapter();
            da1.SelectCommand = cmd2;

            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            GridView1.DataSource = ds1.Tables[0];
            GridView1.DataBind();
            mycon1.Close();



        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            FileInfo file = new FileInfo(ExcelPath);
            if (file.Exists)
            {
                Response.Clear();
                Response.ClearHeaders();
                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment; filename=" + Session["path"].ToString());
                Response.AddHeader("Content-Type", "application/Excel");
                Response.ContentType = "application/vnd.xls";
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.WriteFile(file.FullName);
                Response.End();
            }
            else
            {
                MessageBox.Show("This file does not exist.");
            }


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {

                // Specify the from and to email address
                MailMessage mailMessage = new MailMessage("altson.ecommerce@gmail.com", TextBox1.Text);
                // Specify the email body
                mailMessage.Body = "Hi " + TextBox3.Text+',' + '\n' + "Welcome to Website Analyzer." + '\n' + "This mail is regarding your download request for file " + Session["path"].ToString() + '\n' + "Please find the attached file below";
                // Specify the email Subject
                mailMessage.Subject = "Website|Analyzer File Download";
                if (!string.IsNullOrEmpty(ExcelPath))
               {
                 Attachment attach = new Attachment(ExcelPath);
               mailMessage.Attachments.Add(attach);
          }
                // Specify the SMTP server name and post number
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                // Specify your gmail address and password
                smtpClient.Credentials = new System.Net.NetworkCredential()
                {
                    UserName = "altson.ecommerce@gmail.com",
                    Password = "techbees"
                };
                // Gmail works on SSL, so set this property to true
                smtpClient.EnableSsl = true;
                // Finall send the email message using Send() method
               

                smtpClient.Send(mailMessage);
                p2.Visible = true;
            }
            catch (Exception ex)
            {
                p2.Visible = true;
                p2.InnerHtml = "Please try with another email....";
            }
        }
      
    }
}
          
        
    

      