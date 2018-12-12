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
    public partial class AttendanceList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
            }
        }

        private void loadData()
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
                              " order by  T.COMPANY,T.EPF_NO";





            cmd.CommandText = selectQuery;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                ltrlData.Text = "<table>";
                ltrlData.Text = ltrlData.Text + "<thead> " +
                  " <tr> " +
                  " 	<td>Company </td> " +
                      " <td>EPF </td> " +
                      " <td>Name </td> " +
                      " <td>Member Attended </td> " +
                      " <td>Spouse </td> " +
                      " <td>Spouse Attended. </td> " +
                      " <td>CH1 Name </td> " +
                      " <td>CH1 Sex </td> " +
                      " <td>CH1 Age Category </td> " +
                      " <td>Child1 Attended </td> " +
                      " <td>CH2 Name </td> " +
                      " <td>CH2 Sex </td> " +
                      " <td>CH2 Age Category </td> " +
                      " <td>Child2 Attended </td> " +
                      " <td>CH3 Name </td> " +
                      " <td>CH3 Sex </td> " +
                      " <td>CH3 Age Category </td> " +
                      " <td>Child3 Attended </td> " +
                      //" <td>CH4 Name </td> " +
                      //" <td>CH4 Sex </td> " +
                      //" <td>CH4 Age Category </td> " +
                      //" <td>Child4 Attended </td> " +
                      //" <td>CH5 Name </td> " +
                      //" <td>CH5 Sex </td> " +
                      //" <td>CH5 Age Category </td> " +
                      //" <td>Child5 Attended </td> " +
                  " </tr>" +
                " </<thead> ";


                ltrlData.Text = ltrlData.Text + "<tbody> ";

                while (dr.Read())
                {
                    ltrlData.Text = ltrlData.Text + "<tr> ";
                    ltrlData.Text = ltrlData.Text + "<td> " + dr[25].ToString() + " </td>";

                    ltrlData.Text = ltrlData.Text + "<td> " + dr[0].ToString() + " </td>";
                    ltrlData.Text = ltrlData.Text + "<td> " + dr[1].ToString() + " </td>";
                    ltrlData.Text = ltrlData.Text + "<td> " + "" + " </td>";
                    ltrlData.Text = ltrlData.Text + "<td> " + dr[8].ToString() + " </td>";
                    ltrlData.Text = ltrlData.Text + "<td> " + "" + " </td>";
                    ltrlData.Text = ltrlData.Text + "<td> " + dr[10].ToString() + " </td>";
                    ltrlData.Text = ltrlData.Text + "<td> " + getChildGenderText(dr[11].ToString()) + " </td>";
                    ltrlData.Text = ltrlData.Text + "<td> " + getRelevantAgeCategory(dr[12].ToString()) + " </td>";
                    ltrlData.Text = ltrlData.Text + "<td> " + "" + " </td>";

                    ltrlData.Text = ltrlData.Text + "<td> " + dr[13].ToString() + " </td>";
                    ltrlData.Text = ltrlData.Text + "<td> " + getChildGenderText(dr[14].ToString()) + " </td>";
                    ltrlData.Text = ltrlData.Text + "<td> " + getRelevantAgeCategory(dr[15].ToString()) + " </td>";
                    ltrlData.Text = ltrlData.Text + "<td> " + "" + " </td>";

                    ltrlData.Text = ltrlData.Text + "<td> " + dr[16].ToString() + " </td>";
                    ltrlData.Text = ltrlData.Text + "<td> " + getChildGenderText(dr[17].ToString()) + " </td>";
                    ltrlData.Text = ltrlData.Text + "<td> " + getRelevantAgeCategory(dr[18].ToString()) + " </td>";
                    ltrlData.Text = ltrlData.Text + "<td> " + "" + " </td>";

                    //ltrlData.Text = ltrlData.Text + "<td> " + dr[19].ToString() + " </td>";
                    //ltrlData.Text = ltrlData.Text + "<td> " + getChildGenderText(dr[20].ToString()) + " </td>";
                    //ltrlData.Text = ltrlData.Text + "<td> " + getRelevantAgeCategory(dr[21].ToString()) + " </td>";
                    //ltrlData.Text = ltrlData.Text + "<td> " + "" + " </td>";

                    //ltrlData.Text = ltrlData.Text + "<td> " + dr[22].ToString() + " </td>";
                    //ltrlData.Text = ltrlData.Text + "<td> " + getChildGenderText(dr[23].ToString()) + " </td>";
                    //ltrlData.Text = ltrlData.Text + "<td> " + getRelevantAgeCategory(dr[24].ToString()) + " </td>";
                    //ltrlData.Text = ltrlData.Text + "<td> " + "" + " </td>";

                    ltrlData.Text = ltrlData.Text + "</tr> ";



                }
            }
            ltrlData.Text = ltrlData.Text + "</tbody> ";
            ltrlData.Text = ltrlData.Text + "</table>";
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

    }
}