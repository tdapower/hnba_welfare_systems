using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WelfareTrip2017REST.Models;

namespace WelfareTrip2017REST.Controllers
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
            "CASE WHEN t.PARTICIPATE_DATE IS NULL THEN ''  ELSE t.PARTICIPATE_DATE END, " +
            "CASE WHEN t.MEMBER_COST IS NULL THEN 0  ELSE t.MEMBER_COST END, " +
            "CASE WHEN t.ROOM_SEQ_ID IS NULL THEN ''  ELSE t.ROOM_SEQ_ID END, " +
            "CASE WHEN t.REMARKS IS NULL THEN ''  ELSE t.REMARKS END, " +
            "CASE WHEN t.SYSTEM_DATE IS NULL THEN to_date('01/01/1900', 'DD/MM/RRRR')  ELSE to_date(t.SYSTEM_DATE, 'DD/MM/RRRR') END, " +
            "CASE WHEN t.MEMBER_GENDER IS NULL THEN ''  ELSE t.MEMBER_GENDER END " +
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
                                    ParticipateDate = drow[24].ToString(),
                                    MemberCost = Convert.ToInt32(drow[25]),
                                    RoomSeqId = drow[26].ToString(),
                                    Remarks = drow[27].ToString(),
                                    SystemDate = drow[28].ToString(),
                                    MemberGender = drow[29].ToString()
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
            "CASE WHEN t.PARTICIPATE_DATE IS NULL THEN ''  ELSE t.PARTICIPATE_DATE END, " +
            "CASE WHEN t.MEMBER_COST IS NULL THEN 0  ELSE t.MEMBER_COST END, " +
            "CASE WHEN t.ROOM_SEQ_ID IS NULL THEN ''  ELSE t.ROOM_SEQ_ID END, " +
            "CASE WHEN t.REMARKS IS NULL THEN ''  ELSE t.REMARKS END, " +
            "CASE WHEN t.SYSTEM_DATE IS NULL THEN to_date('01/01/1900', 'DD/MM/RRRR')  ELSE to_date(t.SYSTEM_DATE, 'DD/MM/RRRR') END, " +
            "CASE WHEN t.MEMBER_GENDER IS NULL THEN ''  ELSE t.MEMBER_GENDER END " +
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
                    tripMain.ParticipateDate = dataReader[24].ToString();
                    tripMain.MemberCost = Convert.ToInt32(dataReader[25]);
                    tripMain.RoomSeqId = dataReader[26].ToString();
                    tripMain.Remarks = dataReader[27].ToString();
                    tripMain.SystemDate = dataReader[28].ToString();
                    tripMain.MemberGender = dataReader[29].ToString();

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

        [HttpGet]
        [ActionName("GetMainDetailsByCompanyAndEpf")]
        public TripMain GetMainDetailsByEpf(string company, int epf)
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
            "CASE WHEN t.PARTICIPATE_DATE IS NULL THEN ''  ELSE t.PARTICIPATE_DATE END, " +
            "CASE WHEN t.MEMBER_COST IS NULL THEN 0  ELSE t.MEMBER_COST END, " +
            "CASE WHEN t.ROOM_SEQ_ID IS NULL THEN ''  ELSE t.ROOM_SEQ_ID END, " +
            "CASE WHEN t.REMARKS IS NULL THEN ''  ELSE t.REMARKS END, " +
            "CASE WHEN t.SYSTEM_DATE IS NULL THEN to_date('01/01/1900', 'DD/MM/RRRR')  ELSE to_date(t.SYSTEM_DATE, 'DD/MM/RRRR') END, " +
            "CASE WHEN t.MEMBER_GENDER IS NULL THEN ''  ELSE t.MEMBER_GENDER END " +
            " FROM WELF_TRIP_2017_MAIN t  WHERE  t.COMPANY=:V_COMPANY AND t.EPF_NO=:V_EPF_NO";
            command = new OracleCommand(sql, connection);
            command.Parameters.Add(new OracleParameter("V_COMPANY", company));
            command.Parameters.Add(new OracleParameter("V_EPF_NO", epf));

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
                    tripMain.Ch1Dob = dataReader[8].ToString().Remove(10);
                    tripMain.Ch2Name = dataReader[9].ToString();
                    tripMain.Ch2Dob = dataReader[10].ToString().Remove(10);
                    tripMain.Ch3Name = dataReader[11].ToString();
                    tripMain.Ch3Dob = dataReader[12].ToString().Remove(10);
                    tripMain.Ch4Name = dataReader[13].ToString();
                    tripMain.Ch4Dob = dataReader[14].ToString().Remove(10);
                    tripMain.Ch5Name = dataReader[15].ToString();
                    tripMain.Ch5Dob = dataReader[16].ToString().Remove(10);
                    tripMain.IsMemberParticipate = Convert.ToInt32(dataReader[17]);
                    tripMain.IsSpouseParticipate = Convert.ToInt32(dataReader[18]);
                    tripMain.IsCh1Participate = Convert.ToInt32(dataReader[19]);
                    tripMain.IsCh2Participate = Convert.ToInt32(dataReader[20]);
                    tripMain.IsCh3Participate = Convert.ToInt32(dataReader[21]);
                    tripMain.IsCh4Participate = Convert.ToInt32(dataReader[22]);
                    tripMain.IsCh5Participate = Convert.ToInt32(dataReader[23]);
                    tripMain.ParticipateDate = dataReader[24].ToString();
                    tripMain.MemberCost = Convert.ToInt32(dataReader[25]);
                    tripMain.RoomSeqId = dataReader[26].ToString();
                    tripMain.Remarks = dataReader[27].ToString();
                    tripMain.SystemDate = dataReader[28].ToString();
                    tripMain.MemberGender = dataReader[29].ToString();

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
                command.Parameters.Add("V_PARTICIPATE_DATE", OracleType.VarChar).Value = obj.ParticipateDate;
                command.Parameters.Add("V_IS_CH5_PARTICIPATE", OracleType.Number).Value = obj.IsCh5Participate;
                command.Parameters.Add("V_PARTICIPATE_DATE", OracleType.VarChar).Value = obj.ParticipateDate;
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
                command.Parameters.Add("V_IS_MEMBER_PARTICIPATE", OracleType.Number).Value = obj.IsMemberParticipate;
                command.Parameters.Add("V_IS_SPOUSE_PARTICIPATE", OracleType.Number).Value = obj.IsSpouseParticipate;
                command.Parameters.Add("V_IS_CH1_PARTICIPATE", OracleType.Number).Value = obj.IsCh1Participate;
                command.Parameters.Add("V_IS_CH2_PARTICIPATE", OracleType.Number).Value = obj.IsCh2Participate;
                command.Parameters.Add("V_IS_CH3_PARTICIPATE", OracleType.Number).Value = obj.IsCh3Participate;
                command.Parameters.Add("V_IS_CH4_PARTICIPATE", OracleType.Number).Value = obj.IsCh4Participate;
                command.Parameters.Add("V_IS_CH5_PARTICIPATE", OracleType.Number).Value = obj.IsCh5Participate;
                command.Parameters.Add("V_PARTICIPATE_DATE", OracleType.VarChar).Value = obj.ParticipateDate;
                command.Parameters.Add("V_MEMBER_COST", OracleType.Number).Value = obj.MemberCost;
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

        [HttpGet]
        [ActionName("CheckIsRoomsAvailable")]
        public bool CheckIsRoomsAvailable(string participateDate, string memberGender, string singleOrFamily)
        {
            bool returnVal = false;
            try
            {

                OracleConnection con = new OracleConnection(ConnectionString);
                OracleDataReader dr;
                con.Open();
                String sql = "";

                if (singleOrFamily == "single")
                {
                    if (memberGender == "Male")
                    {
                        sql = "SELECT SEQ_ID  FROM WELF_TRIP_2017_ROOM T " +
                    " WHERE  T.AVAILABLE_DATE=:V_AVAILABLE_DATE AND (T.STATUS='AVAILABLE' OR T.STATUS='PARTIAL') AND (T.ROOM_GENDER='NA' OR T. ROOM_GENDER='Male')";
                    }
                    else if (memberGender == "Female")
                    {
                        sql = "SELECT SEQ_ID  FROM WELF_TRIP_2017_ROOM T " +
                       " WHERE  T.AVAILABLE_DATE=:V_AVAILABLE_DATE AND (T.STATUS='AVAILABLE' OR T.STATUS='PARTIAL') AND (T.ROOM_GENDER='NA' OR T. ROOM_GENDER='Female')";

                    }
                }
                else if (singleOrFamily == "family")
                {
                    sql = "SELECT SEQ_ID  FROM WELF_TRIP_2017_ROOM T " +
                       " WHERE  T.AVAILABLE_DATE=:V_AVAILABLE_DATE AND T.STATUS='AVAILABLE'";
                }


                OracleCommand cmd = new OracleCommand(sql, con);

                cmd.Parameters.Add(new OracleParameter("V_AVAILABLE_DATE", participateDate));


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
            }
            catch (Exception)
            {

                throw;
            }

            return returnVal;
        }
        

        [HttpGet]
        [ActionName("GetAvailableRoomCount")]
        public AvailableRoomCount GetAvailableRoomCount()
        {
            AvailableRoomCount availableRoomCount = new AvailableRoomCount();
            OracleDataReader dataReader = null;
            OracleConnection connection = new OracleConnection(ConnectionString);
            OracleCommand command;
            string sql = "SELECT  AVAILABLE_DATE,CASE WHEN count(AVAILABLE_DATE)  IS NULL THEN 0 ELSE count(AVAILABLE_DATE) END  " +
                " FROM WELF_TRIP_2017_ROOM   WHERE STATUS='AVAILABLE' GROUP BY AVAILABLE_DATE ";

            command = new OracleCommand(sql, connection);

            connection.Open();
            try
            {
                dataReader = command.ExecuteReader();

                availableRoomCount.Day1AvailableRoomCount = 0;
                availableRoomCount.Day2AvailableRoomCount = 0;
                availableRoomCount.Day3AvailableRoomCount = 0;
                availableRoomCount.Day4AvailableRoomCount = 0;
                availableRoomCount.Day5AvailableRoomCount = 0;
                

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        if (dataReader[0].ToString() == "28/10/2017 - 29/10/2017")
                        {
                            availableRoomCount.Day1AvailableRoomCount = Convert.ToInt32(dataReader[1].ToString());
                        }
                        else if (dataReader[0].ToString() == "04/11/2017 - 05/11/2017")
                        {
                            availableRoomCount.Day2AvailableRoomCount = Convert.ToInt32(dataReader[1].ToString());
                        }
                        else if (dataReader[0].ToString() == "11/11/2017 - 12/11/2017")
                        {
                            availableRoomCount.Day3AvailableRoomCount = Convert.ToInt32(dataReader[1].ToString());
                        }
                        else if (dataReader[0].ToString() == "18/11/2017 - 19/11/2017")
                        {
                            availableRoomCount.Day4AvailableRoomCount = Convert.ToInt32(dataReader[1].ToString());
                        }
                        else if (dataReader[0].ToString() == "25/11/2017 - 26/11/2017")
                        {
                            availableRoomCount.Day5AvailableRoomCount = Convert.ToInt32(dataReader[1].ToString());
                        }
                    }
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

            return availableRoomCount;
        }

        //public void SendConfirmationEmail(TripMain obj)
        //{


        //    TDAMail mail = new TDAMail();
        //    mail.From_address = "mrp.workflow@hnbassurance.com";

        //    if (proposalEmailSend.EmailAddresses != "")
        //    {
        //        mail.To_address = proposalEmailSend.EmailAddresses;
        //    }

        //    string ccAddresses = "";
        //    ccAddresses = GetQuotationEmailCCAddresses();

        //    if (ccAddresses != "")
        //    {
        //        mail.Cc_address = ccAddresses;
        //    }

        //    mail.Subject = "HNBA MRP Proposal";
        //    String BodyText;


        //    BodyText = "<html>" +
        //         "<head>" +
        //         "<title>MRP Proposal</title>" +
        //         "</head>" +
        //         "<body>" +
        //      " <table  border = \"1\"  style=\"width: 100 % \"> " +
        //    "<tbody>" +
        //"<tr style=\" background-color: #8cbde4\">" +
        //    "<th> Details</th>" +
        //      "<th>1st Life</th>" +
        //        "<th> 2nd Life</th>" +
        //      "</tr>" +
        //             "<tr>" +
        //                  "<td>Proposal No</td>" +
        //                    "<td>" + proposalEmailSend.ProposalNo + "</td>" +
        //                    "<td>" + "</td>" +
        //                "</tr>" +
        //      "<tr>" +
        //          "<td> Customer Name</td>" +
        //            "<td>" + proposalEmailSend.LifeAss1Name + "</td>" +
        //            "<td>" + proposalEmailSend.LifeAss2Name + "</td>" +
        //        "</tr>" +
        //          "<tr>" +
        //              "<td> NIC</td>" +
        //                "<td>" + proposalEmailSend.LifeAss1Nic + "</td>" +
        //                "<td>" + proposalEmailSend.LifeAss2Nic + "</td>" +
        //            "</tr>" +
        //                      "<tr>" +
        //                          "<td>Bank</td>" +
        //                            "<td>" + proposalEmailSend.BankName + "</td>" +
        //                            "<td>" + "</td>" +
        //                        "</tr>" +
        //                         "<tr>" +
        //                          "<td>Bank Branch</td>" +
        //                            "<td>" + proposalEmailSend.BankBranch + "</td>" +
        //                            "<td>" + "</td>" +
        //                        "</tr>" +
        //                    "</tbody>" +
        //                "</table>" +
        //                                 " <p> " +
        //         "</p>  " +
        //                        " <p> " +
        //         "</p>  " +


        //         " </body> " +
        //         " </html>";

        //    mail.Body = BodyText;
        //    mail.sendMail();

        //    return Request.CreateResponse(HttpStatusCode.OK);


        //}

    }
}
