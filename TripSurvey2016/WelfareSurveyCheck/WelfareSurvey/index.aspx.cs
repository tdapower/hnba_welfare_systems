using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Text;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;


namespace WelfareSurvey
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtEPF.Attributes.Add("onkeyup", "jsValidateNum(this)");

                ddlCompany.Items.Clear();
                ddlCompany.Items.Add(new ListItem("HNBA", "HNBA"));
                ddlCompany.Items.Add(new ListItem("HNBGI", "HNBGI"));

            }
        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            if (txtEPF.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter EPF Number";
                return;
            }
    
            //if (validateEPF(txtEPF.Text.Trim()))
            //{
                Session["EPF"] = txtEPF.Text.Trim();

                Response.Redirect("SurveyForm.aspx?epf=" + txtEPF.Text.Trim() + "&company=" + ddlCompany.SelectedValue);

           // }
           // else
           // {
          //      lblMsg.Text = "Invalid EPF Number";
           //     return;
           // }
        }

        private bool validateEPF(string epf)
        {
            bool returnVal = false;
            OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());
            OracleDataReader dr;
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            String selectQuery = "";
            selectQuery = "  SELECT T.EPF_NO " +
                             " FROM WS_SURVEY_MAIN T  " +
                              " WHERE T.EPF_NO=" + epf + "";
            cmd.CommandText = selectQuery;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                returnVal = true;
            }

            dr.Close();
            dr.Dispose();
            cmd.Dispose();
            con.Close();
            con.Dispose();

            return returnVal;
        }


        private void saveRequest()
        {

            //if (txtFirstName.Text.Trim() == "")
            //{
            //    lblMsg.Text = "Please Enter First Name";
            //    return;
            //}


            //if (txtEmail.Text.Trim() == "")
            //{
            //    lblMsg.Text = "Please Enter E-mail";
            //    return;
            //}

            //if (txtIssue.Text.Trim() == "")
            //{
            //    lblMsg.Text = "Please Enter the Issue";
            //    return;
            //}


            //try
            //{
            //    OracleConnection conProcess = new OracleConnection(ConfigurationManager.ConnectionStrings["ORAWF"].ToString());
            //    conProcess.Open();
            //    OracleCommand spProcess = null;

            //    spProcess = new OracleCommand("INSERT_CGMU_REQUEST");



            //    spProcess.CommandType = CommandType.StoredProcedure;
            //    spProcess.Connection = conProcess;

            //    spProcess.Parameters.Add("V_FIRST_NAME", OracleType.VarChar).Value = txtFirstName.Text;
            //    spProcess.Parameters.Add("V_LAST_NAME", OracleType.VarChar).Value = txtLastName.Text;
            //    spProcess.Parameters.Add("V_EMAIL", OracleType.VarChar).Value = txtEmail.Text;
            //    spProcess.Parameters.Add("V_ISSUE", OracleType.VarChar).Value = txtIssue.Text;
            //    spProcess.Parameters.Add("V_CUSTOMER_NAME", OracleType.VarChar).Value = txtCustomerName.Text;
            //    spProcess.Parameters.Add("V_CUSTOMER_CONTACT_NO", OracleType.VarChar).Value = txtCustomerContactNo.Text;


            //    spProcess.ExecuteNonQuery();


            //    conProcess.Close();

            //    ClearComponents();
            //    lblMsg.Text = "Feedback Successfully Submitted";
            //}
            //catch (Exception ex)
            //{
            //}
        }

        private void ClearComponents()
        {

            //txtFirstName.Text = "";
            //txtLastName.Text = "";
            //txtEmail.Text = "";
            //txtIssue.Text = "";
            //txtCustomerName.Text = "";
            //txtCustomerContactNo.Text = "";
            lblMsg.Text = "";
        }



      
    }
}
