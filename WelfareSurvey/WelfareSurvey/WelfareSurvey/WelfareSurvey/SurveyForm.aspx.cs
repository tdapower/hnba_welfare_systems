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

                setChildrenridGridHeaders();
                loadBranches();

                ddlCompany.Items.Clear();
                ddlCompany.Items.Add(new ListItem("HNBA", "HNBA"));
                ddlCompany.Items.Add(new ListItem("HNBGI", "HNBGI"));

                if (Request.Params["epf"] != null)
                {
                    if (Request.Params["epf"] != "")
                    {
                        loadEmployeeData(Request.Params["epf"].ToString());


                        txtNoOfChildren.Attributes.Add("onkeyup", "jsValidateNum(this)");
                        // setChildrenridGridHeaders();

                       
                    }
                }


            }
        }


        private void setChildrenridGridHeaders()
        {
            DataTable tbChildren = new DataTable();
            tbChildren.Columns.Add("Name", System.Type.GetType("System.String"));
            tbChildren.Columns.Add("DOB", System.Type.GetType("System.String"));
            tbChildren.Columns.Add("Sex", System.Type.GetType("System.String"));
            Session["Children"] = tbChildren;
        }



        private void loadEmployeeData(string epf)
        {
            OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());
            OracleDataReader dr;
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            String selectQuery = "";
            selectQuery = "  SELECT T.EPF_NO,T.NAME,T.SEX,T.MARITIAL_STATUS,T.BRANCH_CODE,T.RES_ADDRESS_1,T.RES_ADDRESS_2,T.RES_ADDRESS_3,T.NAME_OF_SPOUSE,T.NO_OF_CHILDREN " +
                             " FROM WS_SURVEY_MAIN T  " +
                              " WHERE T.EPF_NO=" + epf + "";





            cmd.CommandText = selectQuery;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
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
                if (dr[9].ToString() != "")
                {
                    if (Convert.ToInt32(dr[9].ToString()) > 0)
                    {
                        pnlChildren.Visible = true;

                        loadChildrenDetails(epf);
                    }
                }

            }

            dr.Close();
            dr.Dispose();
            cmd.Dispose();
            con.Close();
            con.Dispose();
        }


        protected void loadChildrenDetails(string EPF)
        {
            try
            {
                grdChildren.DataSource = null;
                grdChildren.DataBind();

                OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());
                OracleDataAdapter da = new OracleDataAdapter();
                string sql = "";
                sql = "SELECT NAME,DOB,SEX FROM WS_SURVEY_CHILD WHERE EMP_EPF=" + EPF + "";
                da.SelectCommand = new OracleCommand(sql, con);
                con.Open();



                OracleDataReader dr = da.SelectCommand.ExecuteReader();

                if (dr.HasRows)
                {
                    grdChildren.DataSource = dr;
                    grdChildren.DataBind();
                }

                con.Close();

            }
            catch (Exception ex)
            {

            }


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




        protected void grdChildren_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // DataRowView drview = e.Row.DataItem as DataRowView;
            //  string temp = ((DataRowView)e.Row.DataItem)["SEX"].ToString();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string field1 = e.Row.DataItem.ToString();

                TextBox txtSex = e.Row.FindControl("txtSex") as TextBox;

                //string userID = [e.Row.RowIndex].Values[1].ToString();
                //string temp = drview[2].ToString();


                //TextBox txtName = e.Row.FindControl("txtName") as TextBox;
                //TextBox txtDateOfBirth = e.Row.FindControl("txtDateOfBirth") as TextBox;



                RadioButton rbtnChildMale = e.Row.FindControl("rbtnChildMale") as RadioButton;
                RadioButton rbtnChildFemale = e.Row.FindControl("rbtnChildFemale") as RadioButton;





                //string name = e.Row.Cells[0].Text;
                //if (name == "&nbsp;")
                //{
                //    name = "";
                //}
                //txtName.Text = name;



                //string dob = e.Row.Cells[1].Text;
                //if (dob == "&nbsp;")
                //{
                //    dob = "";
                //}
                //txtDateOfBirth.Text = dob;



                if (txtSex.Text == "M")
                {

                    rbtnChildMale.Checked = true;
                }
                else if (txtSex.Text == "F")
                {
                    rbtnChildFemale.Checked = true;
                }




            }
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

            if (rbtnMaritialStatusMarried.Checked)
            {

                if (txtNameOfSpouse.Text.Trim() == "")
                {
                    lblMsg.Text = "Please Enter Name of spouse";
                    return;
                }

            }



            if (ddlBranch.SelectedValue == "0")
            {
                lblMsg.Text = "Branch must be selected";
                return;
            }

            if (txtNoOfChildren.Text != "")
            {
                if (Convert.ToInt32(txtNoOfChildren.Text) > 0)
                {
                    if (grdChildren.Rows.Count > 0)
                    {

                        for (int i = 0; i < grdChildren.Rows.Count; i++)
                        {
                            TextBox txtChildName = grdChildren.Rows[i].Cells[0].FindControl("txtName") as TextBox;
                            TextBox txtDateOfBirth = grdChildren.Rows[i].Cells[1].FindControl("txtDateOfBirth") as TextBox;
                            if (txtChildName.Text == "" || txtDateOfBirth.Text == "")
                            {
                                lblMsg.Text = "Please enter details of children";
                                return;
                            }


                        }

                    }
                }
            }


            try
            {
                OracleConnection conProcess = new OracleConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());
                conProcess.Open();
                OracleCommand spProcess = null;

                spProcess = new OracleCommand("UPDATE_WS_SURVEY_MAIN");



                spProcess.CommandType = CommandType.StoredProcedure;
                spProcess.Connection = conProcess;


                spProcess.Parameters.Add("V_EPF_NO", OracleType.Int32).Value = Convert.ToInt32(txtEPF.Text);
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
                spProcess.Parameters.Add("V_NO_OF_CHILDREN", OracleType.VarChar).Value = txtNoOfChildren.Text;




                spProcess.ExecuteNonQuery();


                conProcess.Close();


                deleteChildrenDetails(txtEPF.Text);
                saveChildrenDetails(txtEPF.Text);

                ClearComponents();
                /// lblMsg.Text = "Details Successfully Submitted";
                //  Page.ClientScript.RegisterStartupScript(GetType(), "Message", "alert('Details Successfully Submitted')", true);


                // Response.Redirect("index.aspx");


                HTMLHelper.jsAlertAndRedirect(this, "Details Successfully Submitted", ResolveUrl("~/index.aspx"));
            }
            catch (Exception ex)
            {
            }
        }


        private void saveChildrenDetails(string sEPFNo)
        {


            for (int i = 0; i < grdChildren.Rows.Count; i++)
            {

                try
                {
                    OracleConnection conProcess = new OracleConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());
                    conProcess.Open();
                    OracleCommand spProcess = null;

                    spProcess = new OracleCommand("INSERT_WS_SURVEY_CHILD");
                    spProcess.CommandType = CommandType.StoredProcedure;
                    spProcess.Connection = conProcess;
                    spProcess.Parameters.Add("V_EMP_EPF", OracleType.Number).Value = sEPFNo;

                    TextBox txtName = grdChildren.Rows[i].Cells[0].FindControl("txtName") as TextBox;
                    spProcess.Parameters.Add("V_NAME", OracleType.VarChar).Value = txtName.Text;



                    RadioButton rbChildMale = grdChildren.Rows[i].Cells[2].FindControl("rbtnChildMale") as RadioButton;
                    RadioButton rbChildFemale = grdChildren.Rows[i].Cells[2].FindControl("rbtnChildFemale") as RadioButton;

                    if (rbChildMale.Checked)
                    {
                        spProcess.Parameters.Add("V_SEX", OracleType.VarChar).Value = "M";
                    }
                    else if (rbChildFemale.Checked)
                    {
                        spProcess.Parameters.Add("V_SEX", OracleType.VarChar).Value = "F";
                    }

                    TextBox txtDateOfBirth = grdChildren.Rows[i].Cells[1].FindControl("txtDateOfBirth") as TextBox;
                    spProcess.Parameters.Add("V_DOB", OracleType.DateTime).Value = DateTime.Parse(txtDateOfBirth.Text);

                    spProcess.ExecuteNonQuery();
                    conProcess.Close();

                }
                catch (Exception ex)
                {
                    lblMsg.Text = "Error while saving";

                }
            }
        }

        private void deleteChildrenDetails(string sEPFNo)
        {

            try
            {

                OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());
                OracleDataAdapter da = new OracleDataAdapter();
                string sql = "";
                sql = "DELETE  FROM WS_SURVEY_CHILD WHERE EMP_EPF=" + sEPFNo + "";
                da.DeleteCommand = new OracleCommand(sql, con);
                con.Open();



                da.DeleteCommand.ExecuteNonQuery();


                con.Close();

            }
            catch (Exception ex)
            {

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




        protected void txtNoOfChildren_TextChanged(object sender, EventArgs e)
        {


            Session["Children"] = null;

            grdChildren.DataSource = null;
            grdChildren.DataBind();


            setChildrenridGridHeaders();

            DataTable dt = (DataTable)Session["Children"];
            if (txtNoOfChildren.Text != "")
            {
                if (Convert.ToInt32(txtNoOfChildren.Text) > 0)
                {
                    pnlChildren.Visible = true;

                    for (int i = 0; i < Convert.ToInt32(txtNoOfChildren.Text); i++)
                    {

                        DataRow dr = dt.NewRow();

                        dt.Rows.Add(dr);
                    }

                    Session["Children"] = dt;
                    grdChildren.DataSource = dt;
                    grdChildren.DataBind();
                }
                else
                {
                    grdChildren.DataSource = null;
                    grdChildren.DataBind();

                    pnlChildren.Visible = false;

                    // Session["Children"] = null;


                }




            }
        }

        protected void grdChildren_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void rbtnMaritialStatusSingle_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnMaritialStatusMarried.Checked)
            {
                pnlFamilyMemberDetails.Visible = true;
            }
            else
            {
                pnlFamilyMemberDetails.Visible = false;

            }
        }
        protected void rbtnMaritialStatusMarried_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnMaritialStatusMarried.Checked)
            {
                pnlFamilyMemberDetails.Visible = true;
            }
            else
            {
                pnlFamilyMemberDetails.Visible = false;

            }
        }

        protected void grdChildren_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }


    }
}
