using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LMS_Final_.BL;
using System.Windows.Forms;


namespace LMS_Final_.DL
{
   
    class usersDL
    {
        public static List<users> user = new List<users>();
        public static List<student> viewlist = new List<student>();
        public static void addintoviewlist(student s)
        {
            viewlist.Add(s);
        }
        public static void addIntoList(users d)
        {
            user.Add(d);
        }
        public static string signin(student a, ref int currentIndex)
        {
            for (int i = 0; i < user.Count; i++)
            {

                if (a.getname() == user[i].getname() && a.getpassword() == user[i].getpassword())
                {
                    index.setIndex(i);
                    if (i == 0)
                    {

                        return "admin";
                    }
                    else
                    {
                        return "student";
                    }
                }
            }
            return "Null";
        }
        public static string signup(users obj)
        {
            string Isfound = "false";
            for (int index = 0; index < user.Count; index++)
            {
                if (user[index].getname() == obj.getname() && user[index].getpassword() == obj.getpassword())
                {        
                    Isfound = "true";
                }
            }
            return Isfound;
        }
        public static users setacrole(users obj)
        {
            if (user.Count != 0)
            {

                obj.setroles("User");
            }
            if (user.Count == 0)
            {

                obj.setroles("Admin");
            }

            return obj;
        }
        public static string getfield(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        public static users getUser(int x)
        {
            return user[x];
        }
        public static List<users> getUserList()
        {
            return user;
        }

        // // // // // // // //
        //  File Handling   //
        // // // // // //  //

        public static bool loadData()
        {
            string line;
            string path = "usersData.txt";
            if (File.Exists(path))
            {
                StreamReader myFile = new StreamReader(path);
                while ((line = myFile.ReadLine()) != null)
                {
                    student objdata = new student();
                    objdata.setname(getfield(line, 1));
                    objdata.setroles(getfield(line, 2));
                    objdata.setpassword(getfield(line, 3));
                    objdata.setdates(System.DateTime.Parse(getfield(line, 4)));
                    objdata.setusercomplaints(getfield(line, 5));
                    objdata.setbookborrow(getfield(line, 6));
                    objdata.setreview(getfield(line, 7));
                    objdata.setborrowbookname(getfield(line, 8));
                    objdata.setborrowbookAuthur(getfield(line, 9));
                    objdata.setbookwidraw(bool.Parse(getfield(line, 10)));
                    objdata.setcomplaincheck(bool.Parse(getfield(line, 11)));
                    objdata.setreviewcheck(bool.Parse(getfield(line, 12)));
                    int count = int.Parse(getfield(line,13));
                    string history = getfield(line,14);
                    string[] temp = history.Split(';');
                    int y = 0;
                    for (int i = 0; i < count; i++)
                    {
                        record r = new record(temp[y+0], temp[y+1], System.DateTime.Parse(temp[y+2]));
                        y = y + 3;
                        objdata.adddataintohistory(r);
                    }
                    addIntoList(objdata);
                }
                myFile.Close();
                return true;
            }
            return false;
        }
        public static void saveData()
        {
            string path = "usersData.txt";
            StreamWriter myFile = new StreamWriter(path, false);
            for (int x = 1; x < user.Count; x++)
            {

                myFile.Write(user[x].getname() + ",");
                myFile.Write(user[x].getroles() + ",");
                myFile.Write(user[x].getpassword()+ ",");
                myFile.Write(user[x].getdate() + ",");
                myFile.Write(user[x].getusercomplaints() + ",");
                myFile.Write(user[x].getbookborrow() + ",");
                myFile.Write(user[x].getreview() + ",");
                myFile.Write(user[x].getborrowbookname() + ",");
                myFile.Write(user[x].getborrowbookAuthur() + ",");
                myFile.Write(user[x].getbookwidraw() + ",");
                myFile.Write(user[x].getcomplaincheck() + ",");
                myFile.Write(user[x].getreviewcheck() + ",");
                myFile.Write(user[x].listcount() + ",");
                for (int y = 0; y < user[x].listcount(); y++)
                {
                    myFile.Write(user[x].getnameb(y) + ";" + user[x].getauthorb(y) + ";" + user[x].getdatetimeb(y) + ";") ;
                }
                myFile.WriteLine();
            }
            myFile.Flush();
            myFile.Close();
        }
        public static void saveDataforview()
        {
            string path = "viewData.txt";
            StreamWriter myFile = new StreamWriter(path, false);
            for (int x = 1; x < user.Count; x++)
            {
                myFile.Write(user[x].getname() + ",");
                myFile.Write(user[x].getusercomplaints() + ",");
                myFile.Write(user[x].getreview() + ",");
                myFile.Write(user[x].getcomplaincheck() + ",");
                myFile.Write(user[x].getreviewcheck() + ",");
                myFile.Write(user[x].getborrowbookname() + ",");
                myFile.Write(user[x].getborrowbookAuthur() + ",");
                myFile.WriteLine(user[x].getbookwidraw());

            }
            myFile.Flush();
            myFile.Close();
        }
        public static bool loadviewData()
        {
            string line;
            string path = "viewData.txt";
            if (File.Exists(path))
            {
                StreamReader myFile = new StreamReader(path);
                while ((line = myFile.ReadLine()) != null)
                {
                    student objdata = new student();
                    objdata.setname(getfield(line, 1));
                    objdata.setusercomplaints(getfield(line, 2));
                    objdata.setreview(getfield(line, 3));
                    objdata.setcomplaincheck(bool.Parse(getfield(line, 4)));
                    objdata.setreviewcheck(bool.Parse(getfield(line, 5)));
                    objdata.setborrowbookname(getfield(line, 6));
                    objdata.setborrowbookAuthur(getfield(line, 7));
                    objdata.setbookwidraw(bool.Parse(getfield(line, 8)));
                    addintoviewlist(objdata);
                }
                myFile.Close();
                return true;
            }
            return false;
        }
        public static bool loadDataA()
        {
            int index = 0;
            string line;
            string path = "usersDataA.txt";
            if (File.Exists(path))
            {
                StreamReader myFile = new StreamReader(path);
                while ((line = myFile.ReadLine()) != null)
                {
                    users objdata = new users();
                    objdata.setname(getfield(line, 1));
                    objdata.setroles(getfield(line, 2));
                    objdata.setpassword(getfield(line, 3));
                    index++;
                    addIntoList(objdata);
                }
                myFile.Close();
                return true;
            }
            return false;
        }
        public static void saveDataA()
        {
            string path = "usersDataA.txt";
            StreamWriter myFile = new StreamWriter(path, false);
            if (user.Count != 0)
            {
                myFile.Write(user[0].getname() + ",");
                myFile.Write(user[0].getroles() + ",");
                myFile.WriteLine(user[0].getpassword());

            }

            myFile.Flush();
            myFile.Close();
        }
        public static bool name_check(string name)
        {
            bool flag = false;
            int i = 0;
            while (i < name.Length)
            {
                if ((name[i] > 63 && name[i] < 91) || (name[i] > 96 && name[i] < 123))
                {
                    i++;
                    if (i >= 3)
                    {
                        flag = true;
                    }
                }
                else
                {
                    flag = false;
                    break;
                }
            }

            return flag;
        }
        public static bool password_check(string password)
        {
            bool flag = false;
            int i = 0;
            while (i < password.Length)
            {
                if ((password[i] > 63 && password[i] < 91) || (password[i] > 96 && password[i] < 123) || (password[i] > 47 && password[i] < 58) || (password[i] > 34 && password[i] < 39))
                {
                    i++;
                    if (i >= 6)
                    {
                        flag = true;
                    }
                }
                else
                {
                    flag = false;
                    break;
                }
            }

            return flag;
        }
        public static void savedateforborrow(System.DateTime d, int index)
        {
            user[index].setdates(d);
        }

        // // // // // // // //
        //     FUNCTIONS    //
        // // // // // //  //

        public static bool changedetails(ref string name, ref string password)
        {
            if (name == user[0].getname() && password == user[0].getpassword())
            {
                return true;
            }
            return false;
        }
        public static bool removeUser(ref string name, ref string password)
        {

            bool isCheck = false;
            for (int index = 1; index < user.Count; index++)
            {
                if (name == user[index].getname() && password == user[index].getpassword())
                {

                    user.RemoveAt(index);
                    saveData();
                    saveDataforview();
                    isCheck = true;
                    break;
                }
            }
            return isCheck;
        }
        public static void fine(string date1, string month1)
        {
            int sum;
            string rdate = "" + user[index.getIndex()].getdate();
            string[] temp2 = rdate.Split('/');
            sum = ((int.Parse(month1) - int.Parse(temp2[0])) * 30) + (int.Parse(date1) - int.Parse(temp2[1]));
            if (user[index.getIndex()].getbookwidraw() == true)
            {
                if (sum >= 90)
                {
                    MessageBox.Show("YOU HAVE BEEN FINED");
                }
                else if (sum < 90)
                {
                    MessageBox.Show("YOU HAVE NOT BEEN FINED, YOU STILL HAVE TIME");
                }
            }
            else if (user[index.getIndex()].getbookwidraw() == false)
            {
                MessageBox.Show("YOU HAVE NOT WITHDRAWN ANY BOOK");
            }
           
        }
    }
}
