using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Final_.BL
{
   public class users
    {
        protected string name;
        protected string password;
        protected string roles;
        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        public string Roles { get => roles; set => roles = value; }
        public users()
        {

        }
        public virtual List<record> getlistR()
        {
            return null;
        }
        public users(string name, string password)
        {
            this.name = name;
            this.password = password;
        }
        public void setname(string name)
        {
            this.name = name;
        }
        public void setpassword(string password)
        {
            this.password = password;
        }
        public void setroles(string roles)
        {
            this.roles = roles;
        }
        public string getname()
        {
            return name;
        }
        public string getpassword()
        {
            return password;
        }
        public string getroles()
        {
            return roles;
        }
        public virtual string getreview()
        {
            return " ";
        }
        public virtual void setreview(string reviews)
        {

        }
        public virtual string getfines()
        {
            return " ";
        }
        public virtual void setfines(string fines)
        {

        }
        public virtual string getbookborrow()
        {
            return " ";
        }
        public virtual void setbookborrow(string bookBorrow)
        {

        }
        public virtual string getusercomplaints()
        {
            return " ";
        }
        public virtual void setusercomplaints(string userComplaints)
        {

        }
        public virtual string getborrowbookname()
        {
            return " ";
        }
        public virtual void setborrowbookname(string borrowBookName)
        {

        }
        public virtual string getborrowbookAuthur()
        {
            return " ";
        }
        public virtual void setborrowbookAuthur(string borrowBookName)
        {

        }
        public virtual void adddataintohistory(record d)
        {

        }
        public virtual string getnameb(int x)
        {
            return "";
        }
        public virtual string getauthorb(int x)
        {
            return "";
        }
        public virtual System.DateTime getdatetimeb(int x)
        {
            System.DateTime d = System.DateTime.Now;
            return d;
        }
        public virtual int listcount()
        {
            return 0;
        }
        public virtual bool getbookwidraw()
        {
            return false;
        }
        public virtual void setbookwidraw(bool bookWidraw)
        {

        }
        public virtual bool getcomplaincheck()
        {
            return false;
        }
        public virtual void setcomplaincheck(bool complaintCheck)
        {

        }
        public virtual bool getreviewcheck()
        {
            return false;
        }
        public virtual void setreviewcheck(bool reviewCheck)
        {

        }
        public virtual System.DateTime getdate()
        {
            System.DateTime d = System.DateTime.Now;
            return d;
        }
        public virtual void setdates(System.DateTime da)
        {

        }
        public virtual void resetB()
        {

        }
    }
}
