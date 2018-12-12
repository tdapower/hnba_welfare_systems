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
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using MySql.Data.MySqlClient;


namespace WelfareSurvey
{
    public partial class SurveyForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {






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
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());
            MySqlDataReader dr;
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
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
                txtCompany.Text = dr[25].ToString();
                txtEPF.Text = dr[0].ToString();

                txtName.Text = dr[1].ToString();
                if (dr[1].ToString() != "")
                {
                    chkMemberAttended.Checked = true;
                }


                txtNameOfSpouse.Text = dr[8].ToString();
                if (dr[8].ToString() != "")
                {
                    chkSpouseAttended.Checked = true;
                }

                txtCH1Name.Text = dr[10].ToString();
                txtCH1Sex.Text = getChildGenderText(dr[11].ToString());
                txtCH1AgeCategory.Text = getRelevantAgeCategory(dr[12].ToString());
                if (dr[10].ToString() != "")
                {
                    chkChild1Attended.Checked = true;
                }

                txtCH2Name.Text = dr[13].ToString();
                txtCH2Sex.Text = getChildGenderText(dr[14].ToString());

                txtCH2AgeCategory.Text = getRelevantAgeCategory(dr[15].ToString());
                if (dr[13].ToString() != "")
                {
                    chkChild2Attended.Checked = true;
                }

                txtCH3Name.Text = dr[16].ToString();
                txtCH3Sex.Text = getChildGenderText(dr[17].ToString());

                txtCH3AgeCategory.Text = getRelevantAgeCategory(dr[18].ToString());
                if (dr[16].ToString() != "")
                {
                    chkChild3Attended.Checked = true;
                }

                txtCH4Name.Text = dr[19].ToString();

                txtCH4Sex.Text = getChildGenderText(dr[20].ToString());
                txtCH4AgeCategory.Text = getRelevantAgeCategory(dr[21].ToString());
                if (dr[19].ToString() != "")
                {
                    chkChild4Attended.Checked = true;
                }

                txtCH5Name.Text = dr[22].ToString();

                txtCH5Sex.Text = getChildGenderText(dr[23].ToString());
                txtCH5AgeCategory.Text = getRelevantAgeCategory(dr[24].ToString());
                if (dr[22].ToString() != "")
                {
                    chkChild5Attended.Checked = true;
                }


            }

            dr.Close();
            dr.Dispose();
            cmd.Dispose();
            con.Close();
            con.Dispose();
        }


        private string getRelevantAgeCategory(string dob)
        {
            string ageCat = "";

            if (dob == "")
            {
                return "";
            }
            TimeSpan difference = Convert.ToDateTime("20/08/2016") - Convert.ToDateTime(dob);


            //if (difference.TotalDays < 1095)
            //{
            //    ageCat = "Below 3";
            //}
            //else if (difference.TotalDays < 2190)
            //{
            //    ageCat = "4 - 5";
            //}
            //else if (difference.TotalDays < 3285)
            //{
            //    ageCat = "6 - 8";
            //}
            //else if (difference.TotalDays < 4015)
            //{
            //    ageCat = "9 - 10";
            //}
            //else if (difference.TotalDays > 4015)
            //{
            //    ageCat = "Above 10";
            //}
            if (difference.TotalDays < 1095)
            {
                ageCat = "A";
            }
            else if (difference.TotalDays < 2190)
            {
                ageCat = "B";
            }
            else if (difference.TotalDays < 3285)
            {
                ageCat = "C";
            }
            else if (difference.TotalDays < 4015)
            {
                ageCat = "D";
            }
            else if (difference.TotalDays > 4015)
            {
                ageCat = "E";
            }
            return ageCat;


        }

        private string getChildGenderText(string genderCode)
        {
            string gender = "";
            if (genderCode == "")
            {
                return "";
            }

            if (genderCode == "M")
            {
                gender = "Male";
            }
            else if (genderCode == "F")
            {
                gender = "Female";
            }

            return gender;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            HTMLHelper.jsAlertAndRedirect(this, "Details Not Updated", ResolveUrl("~/index.aspx"));
       
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            saveMainDetails();
        }

        private void saveMainDetails()
        {
            if (txtCompany.Text.Trim() == "")
            {
                lblMsg.Text = "Invalid Company";
                return;
            }

            if (txtEPF.Text.Trim() == "")
            {
                lblMsg.Text = "Invalid EPF";
                return;
            }


            if (txtName.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Name";
                return;
            }




            try
            {




                MySqlConnection conProcess = new MySqlConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());
                conProcess.Open();
                MySqlCommand spProcess = null;

                string sql = "";

                sql = "UPDATE ws_survey_2016_main set ";

                ////
                if (chkMemberAttended.Checked)
                {
                    sql = sql + "MEMBER_ATTENDED=1,";
                }
                else
                {
                    sql = sql + "MEMBER_ATTENDED=0,";
                }
                ///////////

                if (chkSpouseAttended.Checked)
                {
                    sql = sql + "SPOUSE_ATTENDED=1,";
                }
                else
                {
                    sql = sql + "SPOUSE_ATTENDED=0,";
                }
                ////////////
                if (chkChild1Attended.Checked)
                {
                    sql = sql + "CH1_ATTENDED=1,";
                }
                else
                {
                    sql = sql + "CH1_ATTENDED=0,";
                }
                if (chkChild2Attended.Checked)
                {
                    sql = sql + "CH2_ATTENDED=1,";
                }
                else
                {
                    sql = sql + "CH2_ATTENDED=0,";
                }
                if (chkChild3Attended.Checked)
                {
                    sql = sql + "CH3_ATTENDED=1,";
                }
                else
                {
                    sql = sql + "CH3_ATTENDED=0,";
                }
                if (chkChild4Attended.Checked)
                {
                    sql = sql + "CH4_ATTENDED=1,";
                }
                else
                {
                    sql = sql + "CH4_ATTENDED=0,";
                }
                if (chkChild5Attended.Checked)
                {
                    sql = sql + "CH5_ATTENDED=1,";
                }
                else
                {
                    sql = sql + "CH5_ATTENDED=0,";
                }

                sql = sql + " ATTENDED_UPD_DATE=now() ";

                sql = sql + " WHERE COMPANY='" + txtCompany.Text + "' AND EPF_NO=" + txtEPF.Text + "";


                spProcess = new MySqlCommand(sql);



                spProcess.Connection = conProcess;












                //---------------------------------


                spProcess.ExecuteNonQuery();


                conProcess.Close();
                conProcess.Dispose();

                ClearComponents();



                HTMLHelper.jsAlertAndRedirect(this, "Details Successfully Updated", ResolveUrl("~/index.aspx"));
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "Message", "alert('Error while updating');", true);
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




    }
}
