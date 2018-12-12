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
using System.DirectoryServices;


namespace WelareTshirt
{
    public partial class advisors : System.Web.UI.Page
    {
        string UserName = "";
        string Domain = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                loadCompanies();


                // txtEPF.Attributes.Add("onkeyup", "jsValidateNum(this)");
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

                UserName = User.Identity.Name;

                if (Left(UserName, 4) == "HNBA")
                {
                    Domain = Left(UserName, 4);
                    Session["DOMAIN"] = Domain.ToString();
                    UserName = Right(UserName, (UserName.Length) - 5);
                    Session["USER_ID"] = UserName.ToString();
                    GetUser(UserName.ToString());
                }
                else if (Left(UserName, 5) == "HNBGI")
                {
                    Domain = Left(UserName, 5);
                    Session["DOMAIN"] = Domain.ToString();
                    UserName = Right(UserName, (UserName.Length) - 6);
                    Session["USER_ID"] = UserName.ToString();
                    GetUser(UserName.ToString());
                }
                else
                {
                    Domain = Left(UserName, 6);
                    Session["DOMAIN"] = Domain.ToString();
                    UserName = Right(UserName, (UserName.Length) - 7);
                    Session["USER_ID"] = UserName.ToString();
                    GetUserBranch(UserName.ToString());
                }

                if (Session["Branch"] != null && Session["DOMAIN"] != null)
                {
                    loadAdvisors(Session["Branch"].ToString(), Session["DOMAIN"].ToString());
                }

            }
        }


        private void loadCompanies()
        {
            ddlCompany.Items.Clear();
            ddlCompany.Items.Add(new ListItem("Life", "Life"));
            ddlCompany.Items.Add(new ListItem("General", "General"));
            ddlCompany.Items.Add(new ListItem("Shared", "Shared"));


        }


        private void loadAdvisors(string branchCode, string companyCode)
        {

            ddlAdvisorCode.Items.Clear();
            ddlAdvisorCode.Items.Add(new ListItem("--- Select One ---", "0"));

            OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());
            OracleDataReader dr;

            con.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            String selectQuery = "";
            selectQuery = "SELECT AGENT_CODE,AGENT_NAME FROM welf_advisor  WHERE COMPANY=" + companyCode + "  AND BRANCH_CODE=" + branchCode + "  ORDER BY AGENT_NAME ASC ";


            cmd.CommandText = selectQuery;

            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    ddlAdvisorCode.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));

                }
            }
            dr.Close();
            dr.Dispose();
            cmd.Dispose();
            con.Close();
            con.Dispose();
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            saveMainDetails();
        }

        private void saveMainDetails()
        {

            if (ddlAdvisorCode.SelectedValue.ToString() == "0")
            {
                lblMsg.Text = "Please Enter Advisor Code";
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

                spProcess = new OracleCommand("INSERT_WELF_TSHIRT_ADVISOR");


                spProcess.CommandType = CommandType.StoredProcedure;
                spProcess.Connection = conProcess;


                spProcess.Parameters.Add("V_COMPANY", OracleType.VarChar).Value = ddlCompany.SelectedValue.ToString();
                spProcess.Parameters.Add("V_BRANCH_CODE", OracleType.VarChar).Value = txtBranchCode.Text;


                spProcess.Parameters.Add("V_AGENT_CODE", OracleType.Int32).Value = ddlAdvisorCode.SelectedValue.ToString();

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




                HTMLHelper.jsAlertAndRedirect(this, "Details Successfully Submitted", ResolveUrl("~/advisors.aspx"));
            }
            catch (Exception ex)
            {
            }
        }

        public DirectoryEntry GetUser(string UserName)
        {
            DirectoryEntry de = GetDirectoryObject();
            DirectorySearcher deSearch = new DirectorySearcher();
            deSearch.SearchRoot = de;

            deSearch.Filter = "(&(objectClass=user)(SAMAccountName=" + UserName + "))";
            deSearch.SearchScope = SearchScope.Subtree;
            SearchResult results = deSearch.FindOne();


            if (!(results == null))
            {

                de = new DirectoryEntry(results.Path);
                Session["EmployeeID"] = de.Properties["EmployeeID"][0].ToString();
                Session["DisplayName"] = de.Properties["displayName"][0].ToString();
                Session["HnbaEmail"] = de.Properties["Mail"][0].ToString();
                Session["Departmnet"] = de.Properties["Department"].Value.ToString();
                Session["Branch"] = de.Properties["postalCode"].Value.ToString();


                txtBranchCode.Text = de.Properties["postalCode"].Value.ToString();


                return de;
            }
            else
            {


                return null;
            }
        }

        public DirectoryEntry GetUserBranch(string UserName)
        {
            DirectoryEntry de = GetDirectoryObjectBranch();
            DirectorySearcher deSearch = new DirectorySearcher();
            deSearch.SearchRoot = de;

            deSearch.Filter = "(&(objectClass=user)(SAMAccountName=" + UserName + "))";
            deSearch.SearchScope = SearchScope.Subtree;
            SearchResult results = deSearch.FindOne();

            //Session["EmployeeID"] = "Test";

            if (!(results == null))
            {
                de = new DirectoryEntry(results.Path);
                Session["EmployeeID"] = de.Properties["EmployeeID"][0].ToString();
                Session["DisplayName"] = de.Properties["displayName"][0].ToString();
                Session["HnbaEmail"] = de.Properties["Mail"][0].ToString();
                Session["Departmnet"] = de.Properties["Department"].Value.ToString();

                Session["Branch"] = de.Properties["postalCode"].Value.ToString();


                txtBranchCode.Text = de.Properties["postalCode"].Value.ToString();


                return de;
            }
            else
            {


                return null;

            }
        }

        public DirectoryEntry GetDirectoryObject()
        {
            DirectoryEntry oDE;
            if (Left(UserName, 5) == "HNBGI")
            {
                oDE = new DirectoryEntry("LDAP://192.168.10.210");
            }
            else
            {
                oDE = new DirectoryEntry("LDAP://192.168.10.251");
            }

            return oDE;
        }
        public DirectoryEntry GetDirectoryObjectBranch()
        {
            DirectoryEntry oDEbranch;
            oDEbranch = new DirectoryEntry("LDAP://10.100.200.241");
            return oDEbranch;
        }



        public static string Left(string text, int length)
        {
            return text.Substring(0, length);
        }

        public static string Right(string text, int length)
        {
            return text.Substring(text.Length - length, length);
        }

        public static string Mid(string text, int start, int end)
        {
            return text.Substring(start, end);
        }

        public static string Mid(string text, int start)
        {
            return text.Substring(start, text.Length - start);
        }

    }
}