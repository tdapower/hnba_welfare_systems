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


namespace WelareTshirt
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                loadCompanies();



                txtEPF.Attributes.Add("onkeyup", "jsValidateNum(this)");
               // txtNoOfItems.Attributes.Add("onkeyup", "jsValidateNum(this)");

                txtGentsExSmall.Attributes.Add("onkeyup", "jsValidateNum(this)");
                txtLadiesExSmall.Attributes.Add("onkeyup", "jsValidateNum(this)");
                txtGentsSmall.Attributes.Add("onkeyup", "jsValidateNum(this)");
                txtLadiesSmall.Attributes.Add("onkeyup", "jsValidateNum(this)");
                txtGentsMedium.Attributes.Add("onkeyup", "jsValidateNum(this)");
                txtLadiesMedium.Attributes.Add("onkeyup", "jsValidateNum(this)");
                txtGentsLarge.Attributes.Add("onkeyup", "jsValidateNum(this)");
                txtLadiesLarge.Attributes.Add("onkeyup", "jsValidateNum(this)");
                txtGentsExLarge.Attributes.Add("onkeyup", "jsValidateNum(this)");
                txtLadiesExLarge.Attributes.Add("onkeyup", "jsValidateNum(this)");
                txtGentsDExLarge.Attributes.Add("onkeyup", "jsValidateNum(this)");
                txtLadiesDExLarge.Attributes.Add("onkeyup", "jsValidateNum(this)");


                btnSubmit.Attributes.Add("onClick", "if(confirm('Are you sure to submit entered date?','Welfare Society')){}else{return false}");



            }
        }


        private void loadCompanies()
        {
            ddlCompany.Items.Clear();
            ddlCompany.Items.Add(new ListItem("Life", "Life"));
            ddlCompany.Items.Add(new ListItem("General", "General"));
            ddlCompany.Items.Add(new ListItem("Shared", "Shared"));



        }



        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            saveMainDetails();
        }

        private void saveMainDetails()
        {

            if (txtEPF.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter EPF";
                return;
            }


            if (!rbtnYes.Checked && !rbtnNo.Checked)
            {
                lblMsg.Text = "Consent must be selected";
                return;
            }



            try
            {
                OracleConnection conProcess = new OracleConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());
                conProcess.Open();
                OracleCommand spProcess = null;

                spProcess = new OracleCommand("INSERT_WELF_TSHIRT");



                spProcess.CommandType = CommandType.StoredProcedure;
                spProcess.Connection = conProcess;



                spProcess.Parameters.Add("V_COMPANY", OracleType.VarChar).Value = ddlCompany.SelectedValue.ToString();
                spProcess.Parameters.Add("V_EPF_NO", OracleType.Int32).Value = Convert.ToInt32(txtEPF.Text);

                if (rbtnYes.Checked)
                {
                    spProcess.Parameters.Add("V_CONSENT", OracleType.VarChar).Value = "Yes";
                    spProcess.Parameters.Add("V_NO_OF_ITEMS", OracleType.VarChar).Value = 1;
                }
                else if (rbtnNo.Checked)
                {
                    spProcess.Parameters.Add("V_CONSENT", OracleType.VarChar).Value = "No";
                    spProcess.Parameters.Add("V_NO_OF_ITEMS", OracleType.VarChar).Value = "0";
                }




                spProcess.Parameters.Add("V_REMARK", OracleType.VarChar).Value = txtRemarks.Text;





                spProcess.Parameters.Add("V_G_EX_SMALL", OracleType.Int32).Value = Convert.ToInt32(txtGentsExSmall.Text);
                spProcess.Parameters.Add("V_G_SMALL", OracleType.Int32).Value = Convert.ToInt32(txtGentsSmall.Text);
                spProcess.Parameters.Add("V_G_MEDIUM", OracleType.Int32).Value = Convert.ToInt32(txtGentsMedium.Text);
                spProcess.Parameters.Add("V_G_LARGE", OracleType.Int32).Value = Convert.ToInt32(txtGentsLarge.Text);
                spProcess.Parameters.Add("V_G_EX_LARGE", OracleType.Int32).Value = Convert.ToInt32(txtGentsExLarge.Text);
                spProcess.Parameters.Add("V_G_DEX_LARGE", OracleType.Int32).Value = Convert.ToInt32(txtGentsDExLarge.Text);
                spProcess.Parameters.Add("V_L_EX_SMALL", OracleType.Int32).Value = Convert.ToInt32(txtLadiesExSmall.Text);
                spProcess.Parameters.Add("V_L_SMALL", OracleType.Int32).Value = Convert.ToInt32(txtLadiesSmall.Text);
                spProcess.Parameters.Add("V_L_MEDIUM", OracleType.Int32).Value = Convert.ToInt32(txtLadiesMedium.Text);
                spProcess.Parameters.Add("V_L_LARGE", OracleType.Int32).Value = Convert.ToInt32(txtLadiesLarge.Text);
                spProcess.Parameters.Add("V_L_EX_LARGE", OracleType.Int32).Value = Convert.ToInt32(txtLadiesExLarge.Text);
                spProcess.Parameters.Add("V_L_DEX_LARGE", OracleType.Int32).Value = Convert.ToInt32(txtLadiesDExLarge.Text);




                spProcess.ExecuteNonQuery();


                conProcess.Close();




                HTMLHelper.jsAlertAndRedirect(this, "Details Successfully Submitted", ResolveUrl("~/index.aspx"));
            }
            catch (Exception ex)
            {
            }
        }




    }
}