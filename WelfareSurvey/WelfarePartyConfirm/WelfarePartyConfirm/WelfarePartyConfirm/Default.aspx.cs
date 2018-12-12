using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WelfarePartyConfirm
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                txtEPF.Attributes.Add("onkeyup", "jsValidateNum(this)");

            }
        }


        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtEPF.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter EPF Number";
                return;
            }

            if (validateEPF(txtEPF.Text.Trim()))
            {
                deletePreviousRecords(txtEPF.Text.Trim());

                if (saveParticipation(txtEPF.Text.Trim()))
                {
                    txtEPF.Text = "";
                    lblMsg.Text = "Your participation successfully confirmed...";
                }
            }
            else
            {
                lblMsg.Text = "Invalid EPF Number";
                return;
            }
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


        private bool saveParticipation(string sEPFNo)
        {
            bool returnVal = false;

            try
            {
                OracleConnection conProcess = new OracleConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());
                conProcess.Open();
                OracleCommand spProcess = null;

                spProcess = new OracleCommand("INSERT_WELF_PARTY_CONF");
                spProcess.CommandType = CommandType.StoredProcedure;
                spProcess.Connection = conProcess;
                spProcess.Parameters.Add("V_EPF_NO", OracleType.Number).Value = sEPFNo;


                spProcess.ExecuteNonQuery();
                conProcess.Close();

                returnVal = true;
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Error while confirming";

            }

            return returnVal;
        }

        private void deletePreviousRecords(string sEPFNo)
        {

            try
            {

                OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());
                OracleDataAdapter da = new OracleDataAdapter();
                string sql = "";
                sql = "DELETE  FROM WELF_PARTY_CONF WHERE EPF_NO=" + sEPFNo + "";
                da.DeleteCommand = new OracleCommand(sql, con);
                con.Open();


                da.DeleteCommand.ExecuteNonQuery();


                con.Close();

            }
            catch (Exception ex)
            {

            }


        }
    }
}