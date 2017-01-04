using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for MidTier
/// 
/// Version 2.03  Published to test 3/4/2016

/// CHANGES for live to test Sign_and_Submit  resumeLoad() change WindowsImpersonationContext from PUBWEB to GENSCOINC
/// connection string
/// 
/// SiteMaster Gensco logo to Test Gensco logo
/// debug in web.config
/// 
/// </summary>
public class MidTier : IDisposable
{
    SqlConnection sconn = new SqlConnection();

    SqlCommand scmd = new SqlCommand();

    public MidTier()
    {
        sconn.ConnectionString = "Data Source=J106-chern\\SQLEXPRESS;Initial Catalog=SmellyDB;Persist Security Info=true;User ID=CMSuser;Password=LetMeIn2 ";
        //Live
        //sconn.ConnectionString = "Server=PUBWEB\\PUBWEB;Database=GenscoPublic;User Id=GenPubApp;Password=@ppl1cati0n$";

        //Testing bu connect to Live DB
        //sconn.ConnectionString = "Server=192.168.27.10\\SQLExpress,4193;Database=GenscoPublic;User Id=sa;Password=6GKpOz6kFQwEWSDoIzYF";

        //Test string to Dev on LAN
        //sconn.ConnectionString = "Data Source=CAIRO;Initial Catalog=GenscoPublic_Dev;Persist Security Info=True;User ID=kpost;Password=p0st_B2B";

    }
    #region states
    public List<ListItem> getStates()
    {
        try
        {
            List<ListItem> states = new List<ListItem>();
            ListItem emptyState = new ListItem();

            List<String> stateList = getStateList();
            emptyState.Value = "0";
            emptyState.Text = "-- Select --";
            states.Add(emptyState);

            foreach (String s in stateList)
            {
                ListItem newState = new ListItem();
                newState.Text = s.ToString();
                newState.Value = s.ToString();
                states.Add(newState);
            }

            return states;

        }
        catch (Exception)
        {
            // lblError.Text = "An error occurred. Please try your request again. Error: ref_002";
            return null;
        }
    }

    public List<String> getStateList()
    {
        List<String> StateList = new List<String>();
        StateList.Add("Alabama");
        StateList.Add("Alaska");
        StateList.Add("Arizona");
        StateList.Add("Arkansas");
        StateList.Add("California");
        StateList.Add("Colorado");
        StateList.Add("Connecticut");
        StateList.Add("District of Columbia");
        StateList.Add("Delaware");
        StateList.Add("Florida");
        StateList.Add("Georgia");
        StateList.Add("Hawaii");
        StateList.Add("Idaho");
        StateList.Add("Iowa");
        StateList.Add("Illinois");
        StateList.Add("Indiana");
        StateList.Add("Kansas");
        StateList.Add("Kentucky");
        StateList.Add("Louisiana");
        StateList.Add("Maine");
        StateList.Add("Maryland");
        StateList.Add("Massachusetts");
        StateList.Add("Michigan");
        StateList.Add("Minnesota");
        StateList.Add("Mississippi");
        StateList.Add("Missouri");
        StateList.Add("Montana");
        StateList.Add("Nebraska");
        StateList.Add("Nevada");
        StateList.Add("New Hampshire");
        StateList.Add("New Jersey");
        StateList.Add("New Mexico");
        StateList.Add("New York");
        StateList.Add("North Carolina");
        StateList.Add("North Dakota");
        StateList.Add("Ohio");
        StateList.Add("Oklahoma");
        StateList.Add("Oregon");
        StateList.Add("Pennsylvania");
        StateList.Add("Rhode Island");
        StateList.Add("South Carolina");
        StateList.Add("South Dakota");
        StateList.Add("Tennessee");
        StateList.Add("Texas");
        StateList.Add("Utah");
        StateList.Add("Vermont");
        StateList.Add("Virginia");
        StateList.Add("Washington");
        StateList.Add("West Virginia");
        StateList.Add("Wisconsin");
        StateList.Add("Wyoming");

        return StateList;

    }
    #endregion

    public void Dispose()
    {
        if (sconn != null) { sconn.Dispose(); sconn = null; }
        if (scmd != null) { scmd.Dispose(); scmd = null; }
    }

    #region insert procedures
    public int insertApp(int jpID, string afname, string amname, string alname, string anname, string astreet, string acity, string astate, string azip, string aph1, string aph2, string aemail, string abest, string alearn, int apre, DateTime? awhen, DateTime? awhenSep, string yesPre, DateTime aable, string asalary, string ashift, int aeven, int arest, string ayesres, string agenref, int afri, string ayesfri, int afam, string ayesfam, int acon, string ayescon, DateTime? acondate, int avlic, int avcdl, string atcdl, int adrivrecord, int afork, int apall, int aepal, int apc, int aword, int aexcel, int aten, int arf, string awhy, string acust, string amot, string afus, string a5y, string amilb, DateTime? anmil, DateTime? aomil, string amilr, string amtyp, string amex, string alink, string aresna, string aresp, string asign, DateTime asub, int archive, int emailed, string acUser, int jobFairID)
    {
        try
        {
            sconn.Close();
            sconn.Open(); //open the sql connection
            scmd.Connection = sconn; //set the sql command connection to the sql connection
            scmd.CommandType = CommandType.StoredProcedure; //set the command type to stored procedure
            scmd.Parameters.Clear(); //clear the parameters list
            scmd.CommandText = "InsertApp_ip"; //enter the name of the stored procedure
            //set up the parameters to be used (default mode is be input parameters)
            scmd.Parameters.Add("@jobPostingID", SqlDbType.Int).Value = jpID;
            scmd.Parameters.Add("@firstName", SqlDbType.VarChar, 25).Value = afname;
            scmd.Parameters.Add("@middleName", SqlDbType.VarChar, 25).Value = amname;
            scmd.Parameters.Add("@lastName", SqlDbType.VarChar, 25).Value = alname;
            scmd.Parameters.Add("@nickName", SqlDbType.VarChar, 25).Value = anname;
            scmd.Parameters.Add("@street", SqlDbType.VarChar, 150).Value = astreet;
            scmd.Parameters.Add("@city", SqlDbType.VarChar, 25).Value = acity;
            scmd.Parameters.Add("@stateName", SqlDbType.VarChar, 25).Value = astate;
            scmd.Parameters.Add("@zip", SqlDbType.VarChar, 10).Value = azip;
            scmd.Parameters.Add("@phone1", SqlDbType.VarChar, 30).Value = aph1;
            if (aph2 == null)
            {
                scmd.Parameters.Add("@phone2", SqlDbType.VarChar, 30).Value = "";  //@phone2
            }
            else
            {
                scmd.Parameters.Add("@phone2", SqlDbType.VarChar, 30).Value = aph2;  //@phone2
            }

            scmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = aemail;
            scmd.Parameters.Add("@bestWay2contact", SqlDbType.VarChar, 20).Value = abest;

            if (alink == null)
            {
                scmd.Parameters.Add("@linkedIn", SqlDbType.VarChar, 80).Value = "";
            }
            else
            {
                scmd.Parameters.Add("@linkedIn", SqlDbType.VarChar, 80).Value = alink;
            }
            if (aresna == null)
            {
                scmd.Parameters.Add("@resumeName", SqlDbType.VarChar, 80).Value = "";
            }
            else
            {
                scmd.Parameters.Add("@resumeName", SqlDbType.VarChar, 80).Value = aresna;
            }
            if (aresp == null)
            {
                scmd.Parameters.Add("@resumePath", SqlDbType.VarChar, 200).Value = "";
            }
            else
            {
                scmd.Parameters.Add("@resumePath", SqlDbType.VarChar, 200).Value = aresp;
            }

            scmd.Parameters.Add("@aSign", SqlDbType.VarChar, 80).Value = asign;
            scmd.Parameters.Add("@submittedDate", SqlDbType.DateTime).Value = asub;
            scmd.Parameters.Add("@archive", SqlDbType.Bit).Value = archive;
            scmd.Parameters.Add("@emailed", SqlDbType.Bit).Value = emailed;
            if (acUser == null)
            {
                scmd.Parameters.Add("@acUser", SqlDbType.VarChar, 50).Value = "";
            }
            else
            {
                scmd.Parameters.Add("@acUser", SqlDbType.VarChar, 50).Value = acUser;
            }

            //check to see if app is a jobFair attendee
            if (jobFairID > 0)
            {
                scmd.Parameters.Add("@jobFairID", SqlDbType.Int).Value = jobFairID;
            }
            else
            {
                scmd.Parameters.Add("@jobFairID", SqlDbType.Int).Value = DBNull.Value;
            }

            int scopeIdent = Convert.ToInt32(scmd.ExecuteScalar()); //execute the command
            return scopeIdent; //return the value returned from the scaler execution 

        }
        catch (SqlException)
        {
            return -1;
        }
        catch (Exception)
        {
            return -1;
        }
        finally
        {
            sconn.Close(); //close the connection
        }
    }

    #endregion

    #region select procedures

    public int IsJobPostingInCurrentJobFair(int postingID)
    {
        try
        {
            sconn.Close();
            sconn.Open(); //open the sql connection
            scmd.Connection = sconn; //set the sql command connection to the sql connection
            scmd.CommandType = CommandType.StoredProcedure; //set the command type to stored procedure
            scmd.CommandText = "IsJobPostingInCurrentJobFair"; //enter the name of the stored procedure
            scmd.Parameters.Clear(); //clear the parameters list
            //set up the parameters to be used (default mode is be input parameters
            scmd.Parameters.Add("@JobPostingID", SqlDbType.Int).Value = postingID;

            int retCount = Convert.ToInt32(scmd.ExecuteScalar()); //execute the command
            return retCount; //return the value returned from the scaler execution 

        }
        catch (SqlException)
        {
            return -1;
        }
        catch (Exception)
        {
            return -1;
        }
        finally
        {
            sconn.Close(); //close the connection
        }
    }


    //method to get the currently active job postings
    public SqlDataReader ActiveJobPostings()
    {
        try
        {
            sconn.Close();
            sconn.Open(); //open the connection
            scmd.Connection = sconn; //set the command connection property to the connection
            scmd.CommandType = CommandType.StoredProcedure; //specify the command type as Stored Procedure
            scmd.Parameters.Clear(); //clear out any existing parameters
            scmd.CommandText = "ActiveListings_sp"; //the name of the stored procedure

            return scmd.ExecuteReader(CommandBehavior.CloseConnection); //execute the command, and close connection when done
        }
        catch (SqlException) //catch any SQL exceptions that get thrown
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    //job fair branches
    public SqlDataReader JobFairBranches(int jobFairID)
    {
        try
        {
            sconn.Close();
            sconn.Open(); //open the connection
            scmd.Connection = sconn; //set the command connection property to the connection
            scmd.CommandType = CommandType.StoredProcedure; //specify the command type as Stored Procedure
            scmd.Parameters.Clear(); //clear out any existing parameters
            scmd.CommandText = "JobFairBranches_sp"; //the name of the stored procedure
            scmd.Parameters.Add("@JobFairID", SqlDbType.Int).Value = jobFairID;
            return scmd.ExecuteReader(CommandBehavior.CloseConnection); //execute the command, and close connection when done
        }
        catch (SqlException) //catch any SQL exceptions that get thrown
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    //job fair postings
    public SqlDataReader JobFairPostings()
    {
        try
        {
            sconn.Close();
            sconn.Open(); //open the connection
            scmd.Connection = sconn; //set the command connection property to the connection
            scmd.CommandType = CommandType.StoredProcedure; //specify the command type as Stored Procedure
            scmd.Parameters.Clear(); //clear out any existing parameters
            scmd.CommandText = "JobFairListings_sp"; //the name of the stored procedure

            return scmd.ExecuteReader(CommandBehavior.CloseConnection); //execute the command, and close connection when done
        }
        catch (SqlException) //catch any SQL exceptions that get thrown
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public SqlDataReader PostByID(int postID)
    {
        try
        {
            sconn.Close();
            sconn.Open(); //open the connection
            scmd.Connection = sconn; //set the command connection property to the connection
            scmd.Parameters.Clear(); //clear out any existing parameters
            scmd.CommandType = CommandType.StoredProcedure; //specify the command type as Stored Procedure
            scmd.CommandText = "PostByID_sp"; //the name of the stored procedure          
            scmd.Parameters.Add("@PostID", SqlDbType.Int).Value = postID;
            return scmd.ExecuteReader(CommandBehavior.CloseConnection); //execute the command, and close connection when done
        }
        catch (SqlException) //catch any SQL exceptions that get thrown
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public SqlDataReader isAcvtiveJobFair()
    {
        try
        {
            sconn.Close();
            sconn.Open(); //open the connection
            scmd.Connection = sconn; //set the command connection property to the connection
            scmd.CommandType = CommandType.StoredProcedure; //specify the command type as Stored Procedure
            scmd.CommandText = "isAcvtiveJobFair_sp"; //the name of the stored procedure
            scmd.Parameters.Clear(); //clear out any existing parameters

            return scmd.ExecuteReader(CommandBehavior.CloseConnection); //execute the command, and close connection when done
        }
        catch (SqlException) //catch any SQL exceptions that get thrown
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public SqlDataReader getBranches()
    {
        try
        {
            sconn.Close();
            sconn.Open(); //open the connection
            scmd.Connection = sconn; //set the command connection property to the connection
            scmd.Parameters.Clear();
            scmd.CommandType = CommandType.StoredProcedure; //specify stored procedure
            scmd.CommandText = "GetBranches_sp";
            return scmd.ExecuteReader(CommandBehavior.CloseConnection); //execute the command, and close connection when done

        }
        catch (SqlException)
        {
            throw;

        }
        catch (Exception)
        {
            throw;
        }
    }

    #endregion

}
