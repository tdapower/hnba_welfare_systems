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
    public partial class SurveyForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                loadBranches();

                ddlCompany.Items.Clear();
                ddlCompany.Items.Add(new ListItem("HNBA", "HNBA"));
                ddlCompany.Items.Add(new ListItem("HNBGI", "HNBGI"));

                txtNoOfChildren.Attributes.Add("onkeyup", "jsValidateNum(this)");
                txtEPF.Attributes.Add("onkeyup", "jsValidateNum(this)");



                if (Request.Params["epf"] != null)
                {
                    if (Request.Params["company"] != "" && Request.Params["epf"] != "")
                    {
                        loadEmployeeData(Request.Params["company"].ToString(), Request.Params["epf"].ToString());

                    }
                }


            }
        }





        private void loadEmployeeData(string company, string epf)
        {
            OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());
            OracleDataReader dr;
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            String selectQuery = "";
            selectQuery = "  SELECT T.EPF_NO," + //0
                                    "T.NAME," +//1
                                    "T.SEX," +//2
                                    "T.MARITIAL_STATUS," +//3
                                    "T.BRANCH_CODE," +//4
                                    "T.RES_ADDRESS_1," +//5
                                    "T.RES_ADDRESS_2," +//6
                                    "T.RES_ADDRESS_3," +//7
                                    "T.NAME_OF_SPOUSE," +//8
                                    "T.NO_OF_CHILDREN, " +//9
                                    " T.CH1_NAME," +//10
                                    "T.CH1_SEX," +//11
                                    "T.CH1_DOB ," +//12
                                    "T.CH2_NAME," +//13
                                    "T.CH2_SEX," +//14
                                    "T.CH2_DOB ," +//15
                                    "T.CH3_NAME," +//16
                                    " T.CH3_SEX," +//17
                                    "T.CH3_DOB , " +//18
                                    "T.CH4_NAME," +//19
                                    "T.CH4_SEX," +//20
                                    "T.CH4_DOB ," +//21
                                    "T.CH5_NAME," +//22
                                    "T.CH5_SEX , " +//23
                                    "T.CH5_DOB, " +//24
                                     "T.COMPANY " +//25
                                     " FROM ws_survey_2016_main T  " +
                              " WHERE  T.COMPANY='" + company + "' and T.EPF_NO=" + epf + "";





            cmd.CommandText = selectQuery;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                string sss = dr[25].ToString();

                ddlCompany.SelectedValue = dr[25].ToString();

                txtEPF.Text = dr[0].ToString();
                txtName.Text = dr[1].ToString();

                if (dr[2].ToString() == "M")
                {

                    rbtnMale.Checked = true;
                }
                else if (dr[2].ToString() == "F")
                {
                    rbtnFemale.Checked = true;
                }


                if (dr[3].ToString() == "M")
                {

                    rbtnMaritialStatusMarried.Checked = true;
                    pnlFamilyMemberDetails.Visible = true;
                }
                else if (dr[3].ToString() == "S")
                {
                    rbtnMaritialStatusSingle.Checked = true;
                }
                string a = dr[4].ToString();
                ddlBranch.SelectedValue = dr[4].ToString();

                txtAddressLine1.Text = dr[5].ToString();
                txtAddressLine2.Text = dr[6].ToString();
                txtAddressLine3.Text = dr[7].ToString();


                txtNameOfSpouse.Text = dr[8].ToString();

                txtNoOfChildren.Text = dr[9].ToString();

                ////////////
                txtCH1Name.Text = dr[10].ToString();

                string ss = dr[11].ToString();
                if (dr[11].ToString() == "M")
                {
                    rbtnCH1Male.Checked = true;
                }
                else if (dr[11].ToString() == "F")
                {
                    rbtnCH1Female.Checked = true;
                }


                if (dr[12].ToString().Length > 10)
                {
                    txtCH1DOB.Text = dr[12].ToString().Remove(10);
                }
                /////////////
                txtCH2Name.Text = dr[13].ToString();
                if (dr[14].ToString() == "M")
                {
                    rbtnCH2Male.Checked = true;
                }
                else if (dr[14].ToString() == "F")
                {
                    rbtnCH2Female.Checked = true;
                }
                if (dr[15].ToString().Length > 10)
                {
                    txtCH2DOB.Text = dr[15].ToString().Remove(10);
                }

                /////////////
                txtCH3Name.Text = dr[16].ToString();
                if (dr[17].ToString() == "M")
                {
                    rbtnCH3Male.Checked = true;
                }
                else if (dr[17].ToString() == "F")
                {
                    rbtnCH3Female.Checked = true;
                }


                if (dr[18].ToString().Length > 10)
                {
                    txtCH3DOB.Text = dr[18].ToString().Remove(10);
                }
                /////////////
                txtCH4Name.Text = dr[19].ToString();
                if (dr[20].ToString() == "M")
                {
                    rbtnCH4Male.Checked = true;
                }
                else if (dr[20].ToString() == "F")
                {
                    rbtnCH4Female.Checked = true;
                }



                if (dr[21].ToString().Length > 10)
                {
                    txtCH4DOB.Text = dr[21].ToString().Remove(10);
                }
                /////////////
                txtCH5Name.Text = dr[22].ToString();
                if (dr[23].ToString() == "M")
                {
                    rbtnCH5Male.Checked = true;
                }
                else if (dr[23].ToString() == "F")
                {
                    rbtnCH5Female.Checked = true;
                }


                if (dr[24].ToString().Length > 10)
                {
                    txtCH5DOB.Text = dr[24].ToString().Remove(10);
                }

            }

            dr.Close();
            dr.Dispose();
            cmd.Dispose();
            con.Close();
            con.Dispose();
        }



        private void loadBranches()
        {
            ddlBranch.Items.Clear();
            ddlBranch.Items.Add(new ListItem("Select Branch", "0"));
            OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());
            OracleDataReader dr;
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            String selectQuery = "";
            selectQuery = "  select b.branch_code,b.branch_name from sf_branches b where b.branch_name<>'-'  order by b.branch_name";
            cmd.CommandText = selectQuery;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    ddlBranch.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
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




            if (txtName.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Name";
                return;
            }
            if (txtEPF.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter EPF";
                return;
            }


            if (!rbtnMale.Checked && !rbtnFemale.Checked)
            {
                lblMsg.Text = "Sex must be selected";
                return;
            }


            if (!rbtnMaritialStatusMarried.Checked && !rbtnMaritialStatusSingle.Checked)
            {
                lblMsg.Text = "Maritial Status must be selected";
                return;
            }

            //if (rbtnMaritialStatusMarried.Checked)
            //{

            //    if (txtNameOfSpouse.Text.Trim() == "")
            //    {
            //        lblMsg.Text = "Please Enter Name of spouse";
            //        return;
            //    }

            //}



            if (ddlBranch.SelectedValue == "0")
            {
                lblMsg.Text = "Branch must be selected";
                return;
            }

            if (txtNoOfChildren.Text != "")
            {
                if (Convert.ToInt32(txtNoOfChildren.Text) > 0)
                {

                }
            }



            try
            {

                if (CheckUserIdAlreadySaved(ddlCompany.SelectedValue.ToString(), txtEPF.Text))
                {
                    deletePreviousUserRecord(ddlCompany.SelectedValue.ToString(), txtEPF.Text);
                }


                OracleConnection conProcess = new OracleConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());
                conProcess.Open();
                OracleCommand spProcess = null;

                spProcess = new OracleCommand("INSERT_WS_SURVEY_2016_MAIN");



                spProcess.CommandType = CommandType.StoredProcedure;
                spProcess.Connection = conProcess;

                spProcess.Parameters.Add("V_COMPANY", OracleType.VarChar).Value = ddlCompany.SelectedValue.ToString();
                spProcess.Parameters.Add("V_EPF_NO", OracleType.Number).Value = txtEPF.Text;
                spProcess.Parameters.Add("V_NAME", OracleType.VarChar).Value = txtName.Text;


                spProcess.Parameters.Add("V_BRANCH_CODE", OracleType.VarChar).Value = ddlBranch.SelectedValue.ToString();
                spProcess.Parameters.Add("V_RES_ADDRESS_1", OracleType.VarChar).Value = txtAddressLine1.Text;
                spProcess.Parameters.Add("V_RES_ADDRESS_2", OracleType.VarChar).Value = txtAddressLine2.Text;
                spProcess.Parameters.Add("V_RES_ADDRESS_3", OracleType.VarChar).Value = txtAddressLine3.Text;



                if (rbtnMale.Checked)
                {
                    spProcess.Parameters.Add("V_SEX", OracleType.VarChar).Value = "M";
                }
                else if (rbtnFemale.Checked)
                {
                    spProcess.Parameters.Add("V_SEX", OracleType.VarChar).Value = "F";
                }


                if (rbtnMaritialStatusSingle.Checked)
                {
                    spProcess.Parameters.Add("V_MARITIAL_STATUS", OracleType.VarChar).Value = "S";
                }
                else if (rbtnMaritialStatusMarried.Checked)
                {
                    spProcess.Parameters.Add("V_MARITIAL_STATUS", OracleType.VarChar).Value = "M";
                }


                spProcess.Parameters.Add("V_NAME_OF_SPOUSE", OracleType.VarChar).Value = txtNameOfSpouse.Text;



                if (txtNoOfChildren.Text == "")
                {
                    spProcess.Parameters.Add("V_NO_OF_CHILDREN", OracleType.Number).Value = DBNull.Value;
                }
                else
                {
                    spProcess.Parameters.Add("V_NO_OF_CHILDREN", OracleType.Number).Value = txtNoOfChildren.Text;
                }




                ////--------------------------------
                spProcess.Parameters.Add("V_CH1_NAME", OracleType.VarChar).Value = txtCH1Name.Text;
                if (txtCH1DOB.Text == "")
                {
                    spProcess.Parameters.Add("V_CH1_DOB", OracleType.DateTime).Value = DBNull.Value;
                }
                else
                {
                    spProcess.Parameters.Add("V_CH1_DOB", OracleType.DateTime).Value = txtCH1DOB.Text;
                }
                if (rbtnCH1Male.Checked)
                {
                    spProcess.Parameters.Add("V_CH1_SEX", OracleType.VarChar).Value = "M";
                }
                else if (rbtnCH1Female.Checked)
                {
                    spProcess.Parameters.Add("V_CH1_SEX", OracleType.VarChar).Value = "F";
                }
                else
                {
                    spProcess.Parameters.Add("V_CH1_SEX", OracleType.VarChar).Value = DBNull.Value;
                }
                ////---------------------------------

                ////--------------------------------
                spProcess.Parameters.Add("V_CH2_NAME", OracleType.VarChar).Value = txtCH2Name.Text;
                if (txtCH2DOB.Text == "")
                {
                    spProcess.Parameters.Add("V_CH2_DOB", OracleType.DateTime).Value = DBNull.Value;
                }
                else
                {
                    spProcess.Parameters.Add("V_CH2_DOB", OracleType.DateTime).Value = txtCH2DOB.Text;
                }
                if (rbtnCH2Male.Checked)
                {
                    spProcess.Parameters.Add("V_CH2_SEX", OracleType.VarChar).Value = "M";
                }
                else if (rbtnCH2Female.Checked)
                {
                    spProcess.Parameters.Add("V_CH2_SEX", OracleType.VarChar).Value = "F";
                }
                else
                {
                    spProcess.Parameters.Add("V_CH2_SEX", OracleType.VarChar).Value = DBNull.Value;
                }
                ////---------------------------------

                //--------------------------------
                spProcess.Parameters.Add("V_CH3_NAME", OracleType.VarChar).Value = txtCH3Name.Text;
                if (txtCH3DOB.Text == "")
                {
                    spProcess.Parameters.Add("V_CH3_DOB", OracleType.DateTime).Value = DBNull.Value;
                }
                else
                {
                    spProcess.Parameters.Add("V_CH3_DOB", OracleType.DateTime).Value = txtCH3DOB.Text;
                }
                if (rbtnCH3Male.Checked)
                {
                    spProcess.Parameters.Add("V_CH3_SEX", OracleType.VarChar).Value = "M";
                }
                else if (rbtnCH3Female.Checked)
                {
                    spProcess.Parameters.Add("V_CH3_SEX", OracleType.VarChar).Value = "F";
                }
                else
                {
                    spProcess.Parameters.Add("V_CH3_SEX", OracleType.VarChar).Value = DBNull.Value;
                }
                //---------------------------------


                //--------------------------------
                spProcess.Parameters.Add("V_CH4_NAME", OracleType.VarChar).Value = txtCH4Name.Text;
                if (txtCH4DOB.Text == "")
                {
                    spProcess.Parameters.Add("V_CH4_DOB", OracleType.DateTime).Value = DBNull.Value;
                }
                else
                {
                    spProcess.Parameters.Add("V_CH4_DOB", OracleType.DateTime).Value = txtCH4DOB.Text;
                }
                if (rbtnCH4Male.Checked)
                {
                    spProcess.Parameters.Add("V_CH4_SEX", OracleType.VarChar).Value = "M";
                }
                else if (rbtnCH4Female.Checked)
                {
                    spProcess.Parameters.Add("V_CH4_SEX", OracleType.VarChar).Value = "F";
                }
                else
                {
                    spProcess.Parameters.Add("V_CH4_SEX", OracleType.VarChar).Value = DBNull.Value;
                }
                //---------------------------------

                //--------------------------------
                spProcess.Parameters.Add("V_CH5_NAME", OracleType.VarChar).Value = txtCH5Name.Text;
                if (txtCH5DOB.Text == "")
                {
                    spProcess.Parameters.Add("V_CH5_DOB", OracleType.DateTime).Value = DBNull.Value;
                }
                else
                {
                    spProcess.Parameters.Add("V_CH5_DOB", OracleType.DateTime).Value = txtCH5DOB.Text;
                }

                if (rbtnCH5Male.Checked)
                {
                    spProcess.Parameters.Add("V_CH5_SEX", OracleType.VarChar).Value = "M";
                }
                else if (rbtnCH5Female.Checked)
                {
                    spProcess.Parameters.Add("V_CH5_SEX", OracleType.VarChar).Value = "F";
                }
                else
                {
                    spProcess.Parameters.Add("V_CH5_SEX", OracleType.VarChar).Value = DBNull.Value;
                }
                //---------------------------------


                spProcess.ExecuteNonQuery();


                conProcess.Close();
                conProcess.Dispose();

                ClearComponents();
                /// lblMsg.Text = "Details Successfully Submitted";
                //  Page.ClientScript.RegisterStartupScript(GetType(), "Message", "alert('Details Successfully Submitted')", true);


                // Response.Redirect("index.aspx");


                HTMLHelper.jsAlertAndRedirect(this, "Details Successfully Submitted", ResolveUrl("~/SurveyForm.aspx"));
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "Message", "alert('Error while Saving');", true);
            }
        }






        private void ClearComponents()
        {

            //txtFirstName.Text = "";
            //txtLastName.Text = "";
            //txtEmail.Text = "";
            //txtIssue.Text = "";
            //txtCustomerName.Text = "";
            //txtCustomerContactNo.Text = "";
            //lblMsg.Text = "";
        }



        protected void rbtnMaritialStatusSingle_CheckedChanged(object sender, EventArgs e)
        {
            //if (rbtnMaritialStatusMarried.Checked)
            //{
            //    pnlFamilyMemberDetails.Visible = true;
            //}
            //else
            //{
            //    pnlFamilyMemberDetails.Visible = false;

            //}
        }
        protected void rbtnMaritialStatusMarried_CheckedChanged(object sender, EventArgs e)
        {
            //if (rbtnMaritialStatusMarried.Checked)
            //{
            //    pnlFamilyMemberDetails.Visible = true;
            //}
            //else
            //{
            //    pnlFamilyMemberDetails.Visible = false;

            //}
        }
        private bool CheckUserIdAlreadySaved(string company, string EPF)
        {
            bool returnVal = false;
            OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());
            OracleDataReader dr;

            con.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            String selectQuery = "";
            selectQuery = "SELECT COMPANY,EPF_NO   FROM WS_SURVEY_2016_MAIN WHERE COMPANY  ='" + company + "'  and EPF_NO=" + EPF;

            cmd.CommandText = selectQuery;

            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                returnVal = true;
            }
            dr.Close();
            dr.Dispose();
            cmd.Dispose();
            con.Close();
            con.Dispose();

            return returnVal;
        }

        private void deletePreviousUserRecord(string company, string EPF)
        {
            try
            {
                OracleConnection conProcess = new OracleConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());
                conProcess.Open();
                OracleCommand spProcess = null;

                string strQuery = "";

                strQuery = "DELETE FROM WS_SURVEY_2016_MAIN WHERE  COMPANY  ='" + company + "'  and EPF_NO=" + EPF;

                spProcess = new OracleCommand(strQuery, conProcess);

                spProcess.ExecuteNonQuery();
                conProcess.Close();
                conProcess.Dispose();
            }
            catch (Exception ex)
            {

            }

        }



    }
}
