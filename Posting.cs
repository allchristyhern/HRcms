using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Posting
/// </summary>
public class Posting
{
    #region Fields
    private int _id;
    private Job _job;
    private Branch _branch;
    private DateTime _datePosted;
    private bool _isActive;
    private bool _isResReq;
    private bool _isInCurrentJobFair;
    #endregion

    #region Constructor(s)
    public Posting(int id)
    {
        this._id = id;
    }
    #endregion

    #region Properties
    public int PostingID { get { return this._id; } }

    public Branch PostingBranch { get { return this._branch; } set { this._branch = value; } }
    public DateTime DatePosted { get { return this._datePosted; } set { this._datePosted = value; } }
    public bool IsActive { get { return this._isActive; } set { this._isActive = value; } }
    public Job JobListing { get { return this._job; } set { this._job = value; } }
 
    public bool IsInCurrentJobFair { get { return this._isInCurrentJobFair; } set { this._isInCurrentJobFair = value; } }
    #endregion
}
public class JobFair
{
    private int _id;
    private string _fairDate;
    private string _location;
    private string _fairState;
    private bool _showFair;
    private string _sShowFair;
    private List<Branch> _bLIst;

    public JobFair(int id)
    {
        this._id = id;
    }
    public JobFair()
    {

    }

    public int JobFairID { get { return this._id; } set { this._id = value; } }
    public string FairDate { get { return this._fairDate; } set { this._fairDate = value; } }
    public string Location { get { return this._location; } set { this._location = value; } }
    public string FairState { get { return this._fairState; } set { this._fairState = value; } }
    public bool ShowFair { get { return this._showFair; } set { this._showFair = value; } }
    public string sShowFair { get { return this._sShowFair; } set { this._sShowFair = value; } }
    public List<Branch> FairBranchList { get { return this._bLIst; } set { this._bLIst = value; } }
}
public class Job
{
    private int _id;
    private string _title;
    private string _shortDescription;
    private string _fullDescription;
    private string _educationSkills;
    private string _eoeMessage;

    public Job(int id)
    {
        this._id = id;
    }
    public Job()
    {

    }

    public int JobID { get { return this._id; } set { this._id = value; } }
    public string Title { get { return this._title; } set { this._title = value; } }
    public string ShortDescription { get { return this._shortDescription; } set { this._shortDescription = value; } }
    public string FullDescription { get { return this._fullDescription; } set { this._fullDescription = value; } }
    public string EducationSkills { get { return this._educationSkills; } set { this._educationSkills = value; } }
    public string EoEMessage { get { return this._eoeMessage; } set { this._eoeMessage = value; } }
  

}
public class Branch
{
    private int _branchID;
    private string _state;
    private string _name;
    private bool _jFair;

    public Branch(int id, string state, string name,bool jFair)
    {
        this._branchID = id;
        this._state = state;
        this._name = name;
        this._jFair = jFair;
    }
    public Branch() { }
    public Branch(int id)
    {
        this._branchID = id;
    }

    public int BranchID { get { return this._branchID; } set { this._branchID = value; } }
    public string State { get { return this._state; } set { this._state = value; } }
    public string Name { get { return this._name; } set { this._name = value; } }
    public bool JFair { get { return this._jFair; } set { this._jFair = value; } }

}
public class Applicant
{
    private int _id;
    private Posting _appPost;
    private int _postID;

      //job fair ID for jobFairAttended
    private int _fairApp;
    
  

    //personal info
    private string _fName;
    private string _mName;
    private string _lName;
    private string _nickName;
    private string _street;
    private string _city;
    private string _appState;
    private string _zip;
    private string _phone1;
    private string _phone2;
    private string _email;

    private string _bestWay2Contact;
    //resume
    private string _linkedIn;
    private string _resumeName;
    private string _resumePath;
    private bool _resReq;

    //disclaimer and signature
    private string _signature;
    private DateTime _submitDate;
    private bool _archive;


    public Applicant(int id)
    {
        this._id = id;
    }
    public Applicant() { }



    public int AppID { get { return this._id; } set { this._id = value; } }
    public Posting AppPost { get { return this._appPost; } set { this._appPost = value; } }
    public int PostID { get { return this._postID; } set { this._postID = value; } }
   
 
    //job fair
    public int FairApp { get { return this._fairApp; } set { this._fairApp = value; } }

    //personal info
    public string FName { get { return this._fName; } set { this._fName = value; } }
    public string MName { get { return this._mName; } set { this._mName = value; } }
    public string LName { get { return this._lName; } set { this._lName = value; } }
    public string NickName { get { return this._nickName; } set { this._nickName = value; } }
    public string Street { get { return this._street; } set { this._street = value; } }
    public string City { get { return this._city; } set { this._city = value; } }
    public string AppState { get { return this._appState; } set { this._appState = value; } }
    public string Zip { get { return this._zip; } set { this._zip = value; } }
    public string Phone1 { get { return this._phone1; } set { this._phone1 = value; } }
    public string Phone2 { get { return this._phone2; } set { this._phone2 = value; } }
    public string Email { get { return this._email; } set { this._email = value; } }

    public string BestWay { get { return this._bestWay2Contact; } set { this._bestWay2Contact = value; } }

    //resume
    public string LinkedIn { get { return this._linkedIn; } set { this._linkedIn = value; } }
    public string ResumeName { get { return this._resumeName; } set { this._resumeName = value; } }
    public string ResumePath { get { return this._resumePath; } set { this._resumePath = value; } }
    public bool ResReq { get { return this._resReq; } set { this._resReq = value; } }


    //disclaimer and signature
    public string Sign { get { return this._signature; } set { this._signature = value; } }
    public DateTime SubmitDate { get { return this._submitDate; } set { this._submitDate = value; } }
    public bool Archive { get { return this._archive; } set { this._archive = value; } }

   
}




