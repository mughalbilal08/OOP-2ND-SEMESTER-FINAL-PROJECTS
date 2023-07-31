using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS_Final_.BL
{
    class student : users
    {
        private string reviews;
        System.DateTime d;
        private string fines;
        private string bookBorrow;
        private bool bookWidraw;
        private string userComplaints;
        private bool complaintCheck;
        private bool reviewCheck;
        private string borrowBookName;
        private string borrowBookAuthur;
        public List<record> history = new List<record>();
        public string Borrowed_Books { get => borrowBookName; set => borrowBookName = value; }
        public string Reviews { get => reviews; set => reviews = value; }
        public string Complaints { get => userComplaints; set => userComplaints = value; }

        public student()
        {

        }
        public override List<record> getlistR()
        {
            return history;
        }
        public student(string name, string password) : base(name, password)
        {       
        }
        public override void adddataintohistory(record d)
        {
            history.Add(d);
        }
        public override string getnameb(int x)
        {
            return history[x].getnameb();
        }
        public override string getauthorb(int x)
        {
            return history[x].getauthorb();
        }
        public override System.DateTime getdatetimeb(int x)
        {
            return history[x].getdatetimeb();
        }
        public override int listcount()
        {
            return history.Count;
        }
        public student(System.DateTime d)
        {
            this.d = d;
        }
        public override string getreview()
        {
            return reviews;
        }
        public override void setreview(string reviews)
        {
            this.reviews = reviews;
        }

        public override System.DateTime getdate()
        {
            return d;
        }
        public override void setdates(System.DateTime d)
        {
            this.d = d;
        }
        public override string getfines()
        {
            return fines;
        }
        public override void setfines(string fines)
        {
            this.fines = fines;
        }
        public override string getbookborrow()
        {
            return bookBorrow;
        }
        public override void setbookborrow(string bookBorrow)
        {
            this.bookBorrow = bookBorrow;
        }
        public override string getusercomplaints()
        {
            return userComplaints;
        }
        public override void setusercomplaints(string userComplaints)
        {
            this.userComplaints = userComplaints;
        }
        public override string getborrowbookname()
        {
            return borrowBookName;
        }
        public override void setborrowbookname(string borrowBookName)
        {
            this.borrowBookName = borrowBookName;
        }
        public override string getborrowbookAuthur()
        {
            return borrowBookAuthur;
        }
        public override void setborrowbookAuthur(string borrowBookAuthur)
        {
            this.borrowBookAuthur = borrowBookAuthur;
        }
        public override bool getbookwidraw()
        {
            return bookWidraw;
        }
        public override void setbookwidraw(bool bookWidraw)
        {
            this.bookWidraw = bookWidraw;          
        }
        public override bool getcomplaincheck()
        {
            return complaintCheck;
        }
        public override void setcomplaincheck(bool complaintCheck)
        {
            this.complaintCheck = complaintCheck;
        }
        public override bool getreviewcheck()
        {
            return reviewCheck;
        }
        public override void setreviewcheck(bool reviewCheck)
        {
            this.reviewCheck = reviewCheck;
        }
        public override void resetB()
        {
            setborrowbookname(" ");
            setborrowbookAuthur(" ");
            setbookwidraw(false);
        }
    }
}
