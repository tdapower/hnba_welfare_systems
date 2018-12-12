using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WelfareSurvey
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void tmrUpdateTimer_Tick(object sender, EventArgs e)
        {
            loadMemberCount();
            loadSpouseCount();
            loadKidsCount();
            loadKidsBelow6Count();
        }

        private void loadMemberCount()
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());
            MySqlDataReader dr;
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            String selectQuery = "";
            selectQuery = "  select count(*) from ws_survey_2016_main t where t.MEMBER_ATTENDED=1";
            cmd.CommandText = selectQuery;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                ltrlMemberCount.Text = dr[0].ToString();
            }


            dr.Close();
            dr.Dispose();
            cmd.Dispose();
            con.Close();
            con.Dispose();
        }

        private void loadSpouseCount()
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());
            MySqlDataReader dr;
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            String selectQuery = "";
            selectQuery = "  select count(*) from ws_survey_2016_main t where t.SPOUSE_ATTENDED=1";
            cmd.CommandText = selectQuery;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                ltrlSpouseCount.Text = dr[0].ToString();
            }


            dr.Close();
            dr.Dispose();
            cmd.Dispose();
            con.Close();
            con.Dispose();
        }

        private void loadKidsCount()
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());
            MySqlDataReader dr;
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            String selectQuery = "";
            selectQuery = " select (select count(*) from ws_survey_2016_main t where t.CH1_ATTENDED=1)+ " +
  " (select count(*) from ws_survey_2016_main tt where tt.CH2_ATTENDED=1) + " +
  " (select count(*) from ws_survey_2016_main tt where tt.CH3_ATTENDED=1) " +
  " as kids";
            cmd.CommandText = selectQuery;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                ltrlKidsCount.Text = dr[0].ToString();
            }


            dr.Close();
            dr.Dispose();
            cmd.Dispose();
            con.Close();
            con.Dispose();
        }
        private void loadKidsBelow6Count()
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());
            MySqlDataReader dr;
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            String selectQuery = "(select t.CH1_DOB from ws_survey_2016_main t where t.CH1_ATTENDED=1 )    union " +
               " (select t.CH2_DOB from ws_survey_2016_main t where t.CH2_ATTENDED=1 )    union " +
                 " (select t.CH3_DOB from ws_survey_2016_main t where t.CH3_ATTENDED=1 )   ";
            cmd.CommandText = selectQuery;
            dr = cmd.ExecuteReader();

            int count = 0;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    TimeSpan difference = Convert.ToDateTime("20/08/2016") - Convert.ToDateTime(dr[0].ToString());
                    if (difference.TotalDays <= 2190)
                    {
                        count++;
                    }


                }




            }
            ltrlKidsBelow6Count.Text = count.ToString();

            dr.Close();
            dr.Dispose();
            cmd.Dispose();
            con.Close();
            con.Dispose();
        }

    }
}