using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TripMainController : ApiController
    {
        static string ConnectionString = ConfigurationManager.ConnectionStrings["OracleConString"].ToString();

        [HttpGet]
        public IEnumerable<TripMain> Get()
        {
            List<TripMain> tripMainList = new List<TripMain>();
            DataTable dataTable = new DataTable();
            OracleDataReader dataReader = null;
            OracleConnection connection = new OracleConnection(ConnectionString);
            OracleCommand command;
            string sql = "SELECT " +
            "CASE WHEN t.SEQ_ID IS NULL THEN 0  ELSE t.SEQ_ID END, " +
            "CASE WHEN t.COMPANY IS NULL THEN ''  ELSE t.COMPANY END, " +
            "CASE WHEN t.BRANCH_DEPT IS NULL THEN ''  ELSE t.BRANCH_DEPT END, " +
            "CASE WHEN t.EPF_NO IS NULL THEN 0  ELSE t.EPF_NO END, " +
            "CASE WHEN t.MEMBER_NAME IS NULL THEN ''  ELSE t.MEMBER_NAME END, " +
            "CASE WHEN t.MARITIAL_STATUS IS NULL THEN ''  ELSE t.MARITIAL_STATUS END, " +
            "CASE WHEN t.SPOUSE_NAME IS NULL THEN ''  ELSE t.SPOUSE_NAME END, " +
            "CASE WHEN t.CH1_NAME IS NULL THEN ''  ELSE t.CH1_NAME END, " +
            "CASE WHEN t.CH1_DOB IS NULL THEN to_date('01/01/1900', 'DD/MM/RRRR')  ELSE to_date(t.CH1_DOB, 'DD/MM/RRRR') END, " +
            "CASE WHEN t.CH2_NAME IS NULL THEN ''  ELSE t.CH2_NAME END, " +
            "CASE WHEN t.CH2_DOB IS NULL THEN to_date('01/01/1900', 'DD/MM/RRRR')  ELSE to_date(t.CH2_DOB, 'DD/MM/RRRR') END, " +
            "CASE WHEN t.CH3_NAME IS NULL THEN ''  ELSE t.CH3_NAME END, " +
            "CASE WHEN t.CH3_DOB IS NULL THEN to_date('01/01/1900', 'DD/MM/RRRR')  ELSE to_date(t.CH3_DOB, 'DD/MM/RRRR') END, " +
            "CASE WHEN t.CH4_NAME IS NULL THEN ''  ELSE t.CH4_NAME END, " +
            "CASE WHEN t.CH4_DOB IS NULL THEN to_date('01/01/1900', 'DD/MM/RRRR')  ELSE to_date(t.CH4_DOB, 'DD/MM/RRRR') END, " +
            "CASE WHEN t.CH5_NAME IS NULL THEN ''  ELSE t.CH5_NAME END, " +
            "CASE WHEN t.CH5_DOB IS NULL THEN to_date('01/01/1900', 'DD/MM/RRRR')  ELSE to_date(t.CH5_DOB, 'DD/MM/RRRR') END, " +
            "CASE WHEN t.IS_MEMBER_PARTICIPATE IS NULL THEN 0  ELSE t.IS_MEMBER_PARTICIPATE END, " +
            "CASE WHEN t.IS_SPOUSE_PARTICIPATE IS NULL THEN 0  ELSE t.IS_SPOUSE_PARTICIPATE END, " +
            "CASE WHEN t.IS_CH1_PARTICIPATE IS NULL THEN 0  ELSE t.IS_CH1_PARTICIPATE END, " +
            "CASE WHEN t.IS_CH2_PARTICIPATE IS NULL THEN 0  ELSE t.IS_CH2_PARTICIPATE END, " +
            "CASE WHEN t.IS_CH3_PARTICIPATE IS NULL THEN 0  ELSE t.IS_CH3_PARTICIPATE END, " +
            "CASE WHEN t.IS_CH4_PARTICIPATE IS NULL THEN 0  ELSE t.IS_CH4_PARTICIPATE END, " +
            "CASE WHEN t.IS_CH5_PARTICIPATE IS NULL THEN 0  ELSE t.IS_CH5_PARTICIPATE END, " +
            "CASE WHEN t.MEMBER_COST IS NULL THEN 0  ELSE t.MEMBER_COST END, " +
            "CASE WHEN t.ROOM_SEQ_ID IS NULL THEN ''  ELSE t.ROOM_SEQ_ID END, " +
            "CASE WHEN t.REMARKS IS NULL THEN ''  ELSE t.REMARKS END, " +
            "CASE WHEN t.SYSTEM_DATE IS NULL THEN to_date('01/01/1900', 'DD/MM/RRRR')  ELSE to_date(t.SYSTEM_DATE, 'DD/MM/RRRR') END " +
            " FROM WELF_TRIP_2017_MAIN t ";
            command = new OracleCommand(sql, connection);
            try
            {
                connection.Open();
                dataReader = command.ExecuteReader();
                dataTable.Load(dataReader);
                dataReader.Close();
                connection.Close();
                tripMainList = (from DataRow drow in dataTable.Rows
                                select new TripMain()
                                {
                                    SeqId = Convert.ToInt32(drow[0]),
                                    Company = drow[1].ToString(),
                                    BranchDept = drow[2].ToString(),
                                    EpfNo = Convert.ToInt32(drow[3]),
                                    MemberName = drow[4].ToString(),
                                    MaritialStatus = drow[5].ToString(),
                                    SpouseName = drow[6].ToString(),
                                    Ch1Name = drow[7].ToString(),
                                    Ch1Dob = drow[8].ToString(),
                                    Ch2Name = drow[9].ToString(),
                                    Ch2Dob = drow[10].ToString(),
                                    Ch3Name = drow[11].ToString(),
                                    Ch3Dob = drow[12].ToString(),
                                    Ch4Name = drow[13].ToString(),
                                    Ch4Dob = drow[14].ToString(),
                                    Ch5Name = drow[15].ToString(),
                                    Ch5Dob = drow[16].ToString(),
                                    IsMemberParticipate = Convert.ToInt32(drow[17]),
                                    IsSpouseParticipate = Convert.ToInt32(drow[18]),
                                    IsCh1Participate = Convert.ToInt32(drow[19]),
                                    IsCh2Participate = Convert.ToInt32(drow[20]),
                                    IsCh3Participate = Convert.ToInt32(drow[21]),
                                    IsCh4Participate = Convert.ToInt32(drow[22]),
                                    IsCh5Participate = Convert.ToInt32(drow[23]),
                                    MemberCost = Convert.ToInt32(drow[24]),
                                    RoomSeqId = drow[25].ToString(),
                                    Remarks = drow[26].ToString(),
                                    SystemDate = drow[27].ToString()
                                }).ToList();
            }
            catch (Exception exception)
            {
                if (dataReader != null || connection.State == ConnectionState.Open)
                {
                    dataReader.Close();
                    connection.Close();
                }
            }
            return tripMainList;
        }
        [HttpGet]
        public TripMain Get(int id)
        {
            TripMain tripMain = new TripMain();
            OracleDataReader dataReader = null;
            OracleConnection connection = new OracleConnection(ConnectionString);
            OracleCommand command;
            string sql = "SELECT " +
            "CASE WHEN t.SEQ_ID IS NULL THEN 0  ELSE t.SEQ_ID END, " +
            "CASE WHEN t.COMPANY IS NULL THEN ''  ELSE t.COMPANY END, " +
            "CASE WHEN t.BRANCH_DEPT IS NULL THEN ''  ELSE t.BRANCH_DEPT END, " +
            "CASE WHEN t.EPF_NO IS NULL THEN 0  ELSE t.EPF_NO END, " +
            "CASE WHEN t.MEMBER_NAME IS NULL THEN ''  ELSE t.MEMBER_NAME END, " +
            "CASE WHEN t.MARITIAL_STATUS IS NULL THEN ''  ELSE t.MARITIAL_STATUS END, " +
            "CASE WHEN t.SPOUSE_NAME IS NULL THEN ''  ELSE t.SPOUSE_NAME END, " +
            "CASE WHEN t.CH1_NAME IS NULL THEN ''  ELSE t.CH1_NAME END, " +
            "CASE WHEN t.CH1_DOB IS NULL THEN to_date('01/01/1900', 'DD/MM/RRRR')  ELSE to_date(t.CH1_DOB, 'DD/MM/RRRR') END, " +
            "CASE WHEN t.CH2_NAME IS NULL THEN ''  ELSE t.CH2_NAME END, " +
            "CASE WHEN t.CH2_DOB IS NULL THEN to_date('01/01/1900', 'DD/MM/RRRR')  ELSE to_date(t.CH2_DOB, 'DD/MM/RRRR') END, " +
            "CASE WHEN t.CH3_NAME IS NULL THEN ''  ELSE t.CH3_NAME END, " +
            "CASE WHEN t.CH3_DOB IS NULL THEN to_date('01/01/1900', 'DD/MM/RRRR')  ELSE to_date(t.CH3_DOB, 'DD/MM/RRRR') END, " +
            "CASE WHEN t.CH4_NAME IS NULL THEN ''  ELSE t.CH4_NAME END, " +
            "CASE WHEN t.CH4_DOB IS NULL THEN to_date('01/01/1900', 'DD/MM/RRRR')  ELSE to_date(t.CH4_DOB, 'DD/MM/RRRR') END, " +
            "CASE WHEN t.CH5_NAME IS NULL THEN ''  ELSE t.CH5_NAME END, " +
            "CASE WHEN t.CH5_DOB IS NULL THEN to_date('01/01/1900', 'DD/MM/RRRR')  ELSE to_date(t.CH5_DOB, 'DD/MM/RRRR') END, " +
            "CASE WHEN t.IS_MEMBER_PARTICIPATE IS NULL THEN 0  ELSE t.IS_MEMBER_PARTICIPATE END, " +
            "CASE WHEN t.IS_SPOUSE_PARTICIPATE IS NULL THEN 0  ELSE t.IS_SPOUSE_PARTICIPATE END, " +
            "CASE WHEN t.IS_CH1_PARTICIPATE IS NULL THEN 0  ELSE t.IS_CH1_PARTICIPATE END, " +
            "CASE WHEN t.IS_CH2_PARTICIPATE IS NULL THEN 0  ELSE t.IS_CH2_PARTICIPATE END, " +
            "CASE WHEN t.IS_CH3_PARTICIPATE IS NULL THEN 0  ELSE t.IS_CH3_PARTICIPATE END, " +
            "CASE WHEN t.IS_CH4_PARTICIPATE IS NULL THEN 0  ELSE t.IS_CH4_PARTICIPATE END, " +
            "CASE WHEN t.IS_CH5_PARTICIPATE IS NULL THEN 0  ELSE t.IS_CH5_PARTICIPATE END, " +
            "CASE WHEN t.MEMBER_COST IS NULL THEN 0  ELSE t.MEMBER_COST END, " +
            "CASE WHEN t.ROOM_SEQ_ID IS NULL THEN ''  ELSE t.ROOM_SEQ_ID END, " +
            "CASE WHEN t.REMARKS IS NULL THEN ''  ELSE t.REMARKS END, " +
            "CASE WHEN t.SYSTEM_DATE IS NULL THEN to_date('01/01/1900', 'DD/MM/RRRR')  ELSE to_date(t.SYSTEM_DATE, 'DD/MM/RRRR') END " +
            " FROM WELF_TRIP_2017_MAIN t  WHERE t.SEQ_ID=:V_SEQ_ID";
            command = new OracleCommand(sql, connection);
            command.Parameters.Add(new OracleParameter("V_SEQ_ID", id));
            connection.Open();
            try
            {
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    tripMain.SeqId = Convert.ToInt32(dataReader[0]);
                    tripMain.Company = dataReader[1].ToString();
                    tripMain.BranchDept = dataReader[2].ToString();
                    tripMain.EpfNo = Convert.ToInt32(dataReader[3]);
                    tripMain.MemberName = dataReader[4].ToString();
                    tripMain.MaritialStatus = dataReader[5].ToString();
                    tripMain.SpouseName = dataReader[6].ToString();
                    tripMain.Ch1Name = dataReader[7].ToString();
                    tripMain.Ch1Dob = dataReader[8].ToString();
                    tripMain.Ch2Name = dataReader[9].ToString();
                    tripMain.Ch2Dob = dataReader[10].ToString();
                    tripMain.Ch3Name = dataReader[11].ToString();
                    tripMain.Ch3Dob = dataReader[12].ToString();
                    tripMain.Ch4Name = dataReader[13].ToString();
                    tripMain.Ch4Dob = dataReader[14].ToString();
                    tripMain.Ch5Name = dataReader[15].ToString();
                    tripMain.Ch5Dob = dataReader[16].ToString();
                    tripMain.IsMemberParticipate = Convert.ToInt32(dataReader[17]);
                    tripMain.IsSpouseParticipate = Convert.ToInt32(dataReader[18]);
                    tripMain.IsCh1Participate = Convert.ToInt32(dataReader[19]);
                    tripMain.IsCh2Participate = Convert.ToInt32(dataReader[20]);
                    tripMain.IsCh3Participate = Convert.ToInt32(dataReader[21]);
                    tripMain.IsCh4Participate = Convert.ToInt32(dataReader[22]);
                    tripMain.IsCh5Participate = Convert.ToInt32(dataReader[23]);
                    tripMain.MemberCost = Convert.ToInt32(dataReader[24]);
                    tripMain.RoomSeqId = dataReader[25].ToString();
                    tripMain.Remarks = dataReader[26].ToString();
                    tripMain.SystemDate = dataReader[27].ToString();

                    dataReader.Close();
                    connection.Close();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception exception)
            {
                if (dataReader != null || connection.State == ConnectionState.Open)
                {
                    dataReader.Close();
                    connection.Close();
                }
            }
            finally
            {
                connection.Close();
            }
            return tripMain;
        }
        [HttpPost]
        [ActionName("SaveTripMain")]
        public HttpResponseMessage SaveTripMainl(TripMain obj)
        {
            OracleConnection connection = new OracleConnection(ConnectionString);
            OracleCommand command;
            try
            {
                connection.Open();
                command = new OracleCommand("INSERT_WELF_TRIP_2017_MAIN");
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                command.Parameters.Add("V_SEQ_ID", OracleType.Number).Value = obj.SeqId;
                command.Parameters.Add("V_COMPANY", OracleType.VarChar).Value = obj.Company;
                command.Parameters.Add("V_BRANCH_DEPT", OracleType.VarChar).Value = obj.BranchDept;
                command.Parameters.Add("V_EPF_NO", OracleType.Number).Value = obj.EpfNo;
                command.Parameters.Add("V_MEMBER_NAME", OracleType.VarChar).Value = obj.MemberName;
                command.Parameters.Add("V_MARITIAL_STATUS", OracleType.VarChar).Value = obj.MaritialStatus;
                command.Parameters.Add("V_SPOUSE_NAME", OracleType.VarChar).Value = obj.SpouseName;
                command.Parameters.Add("V_CH1_NAME", OracleType.VarChar).Value = obj.Ch1Name;
                command.Parameters.Add("V_CH1_DOB", OracleType.DateTime).Value = obj.Ch1Dob;
                command.Parameters.Add("V_CH2_NAME", OracleType.VarChar).Value = obj.Ch2Name;
                command.Parameters.Add("V_CH2_DOB", OracleType.DateTime).Value = obj.Ch2Dob;
                command.Parameters.Add("V_CH3_NAME", OracleType.VarChar).Value = obj.Ch3Name;
                command.Parameters.Add("V_CH3_DOB", OracleType.DateTime).Value = obj.Ch3Dob;
                command.Parameters.Add("V_CH4_NAME", OracleType.VarChar).Value = obj.Ch4Name;
                command.Parameters.Add("V_CH4_DOB", OracleType.DateTime).Value = obj.Ch4Dob;
                command.Parameters.Add("V_CH5_NAME", OracleType.VarChar).Value = obj.Ch5Name;
                command.Parameters.Add("V_CH5_DOB", OracleType.DateTime).Value = obj.Ch5Dob;
                command.Parameters.Add("V_IS_MEMBER_PARTICIPATE", OracleType.Number).Value = obj.IsMemberParticipate;
                command.Parameters.Add("V_IS_SPOUSE_PARTICIPATE", OracleType.Number).Value = obj.IsSpouseParticipate;
                command.Parameters.Add("V_IS_CH1_PARTICIPATE", OracleType.Number).Value = obj.IsCh1Participate;
                command.Parameters.Add("V_IS_CH2_PARTICIPATE", OracleType.Number).Value = obj.IsCh2Participate;
                command.Parameters.Add("V_IS_CH3_PARTICIPATE", OracleType.Number).Value = obj.IsCh3Participate;
                command.Parameters.Add("V_IS_CH4_PARTICIPATE", OracleType.Number).Value = obj.IsCh4Participate;
                command.Parameters.Add("V_IS_CH5_PARTICIPATE", OracleType.Number).Value = obj.IsCh5Participate;
                command.Parameters.Add("V_MEMBER_COST", OracleType.Number).Value = obj.MemberCost;
                command.Parameters.Add("V_ROOM_SEQ_ID", OracleType.VarChar).Value = obj.RoomSeqId;
                command.Parameters.Add("V_REMARKS", OracleType.VarChar).Value = obj.Remarks;
                command.ExecuteNonQuery();
                connection.Close();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception exception)
            {
                connection.Close();
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }
        }
        [HttpPut]
        [ActionName("UpdateTripMain")]
        public HttpResponseMessage UpdateTripMainl(TripMain obj)
        {
            OracleConnection connection = new OracleConnection(ConnectionString);
            OracleCommand command;
            try
            {
                connection.Open();
                command = new OracleCommand("UPDATE_WELF_TRIP_2017_MAIN");
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                command.Parameters.Add("V_SEQ_ID", OracleType.Number).Value = obj.SeqId;
                command.Parameters.Add("V_COMPANY", OracleType.VarChar).Value = obj.Company;
                command.Parameters.Add("V_BRANCH_DEPT", OracleType.VarChar).Value = obj.BranchDept;
                command.Parameters.Add("V_EPF_NO", OracleType.Number).Value = obj.EpfNo;
                command.Parameters.Add("V_MEMBER_NAME", OracleType.VarChar).Value = obj.MemberName;
                command.Parameters.Add("V_MARITIAL_STATUS", OracleType.VarChar).Value = obj.MaritialStatus;
                command.Parameters.Add("V_SPOUSE_NAME", OracleType.VarChar).Value = obj.SpouseName;
                command.Parameters.Add("V_CH1_NAME", OracleType.VarChar).Value = obj.Ch1Name;
                command.Parameters.Add("V_CH1_DOB", OracleType.DateTime).Value = obj.Ch1Dob;
                command.Parameters.Add("V_CH2_NAME", OracleType.VarChar).Value = obj.Ch2Name;
                command.Parameters.Add("V_CH2_DOB", OracleType.DateTime).Value = obj.Ch2Dob;
                command.Parameters.Add("V_CH3_NAME", OracleType.VarChar).Value = obj.Ch3Name;
                command.Parameters.Add("V_CH3_DOB", OracleType.DateTime).Value = obj.Ch3Dob;
                command.Parameters.Add("V_CH4_NAME", OracleType.VarChar).Value = obj.Ch4Name;
                command.Parameters.Add("V_CH4_DOB", OracleType.DateTime).Value = obj.Ch4Dob;
                command.Parameters.Add("V_CH5_NAME", OracleType.VarChar).Value = obj.Ch5Name;
                command.Parameters.Add("V_CH5_DOB", OracleType.DateTime).Value = obj.Ch5Dob;
                command.Parameters.Add("V_IS_MEMBER_PARTICIPATE", OracleType.Number).Value = obj.IsMemberParticipate;
                command.Parameters.Add("V_IS_SPOUSE_PARTICIPATE", OracleType.Number).Value = obj.IsSpouseParticipate;
                command.Parameters.Add("V_IS_CH1_PARTICIPATE", OracleType.Number).Value = obj.IsCh1Participate;
                command.Parameters.Add("V_IS_CH2_PARTICIPATE", OracleType.Number).Value = obj.IsCh2Participate;
                command.Parameters.Add("V_IS_CH3_PARTICIPATE", OracleType.Number).Value = obj.IsCh3Participate;
                command.Parameters.Add("V_IS_CH4_PARTICIPATE", OracleType.Number).Value = obj.IsCh4Participate;
                command.Parameters.Add("V_IS_CH5_PARTICIPATE", OracleType.Number).Value = obj.IsCh5Participate;
                command.Parameters.Add("V_MEMBER_COST", OracleType.Number).Value = obj.MemberCost;
                command.Parameters.Add("V_ROOM_SEQ_ID", OracleType.VarChar).Value = obj.RoomSeqId;
                command.Parameters.Add("V_REMARKS", OracleType.VarChar).Value = obj.Remarks;
                command.ExecuteNonQuery();
                connection.Close();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception exception)
            {
                connection.Close();
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }
        }

    }
}
