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
    class detailBooksDL
    {
        public static List<detailBooks> bookDetail = new List<detailBooks>();
        public static void addIntoBookList(detailBooks s)
        {
            bookDetail.Add(s);
        }
        public static int getlist()
        {
            return bookDetail.Count;
        }
        public static List<detailBooks> getbooklist()
        {
            return bookDetail;
        }
        
        // // // // // // // //
        //  File Handling   //
        // // // // // //  //

        public static void saveData1()
        {
            string path = "bookData.txt";
            StreamWriter myFile = new StreamWriter(path, false);
            for (int x = 0; x < bookDetail.Count; x++)
            {
                myFile.Write(bookDetail[x].getbookcategories() + ",");
                myFile.Write(bookDetail[x].getbookList() + ",");
                myFile.Write(bookDetail[x].getbookAuthur() + ",");
                myFile.Write(bookDetail[x].getbookpublish() + ",") ;
               // myFile.WriteLine(bookDetail[x].getcheck());
                 myFile.WriteLine(bookDetail[x].getisbookborrowed());
            }

            myFile.Close();
        }
        public static bool loadData1()
        {
            int index = 0;
            string borrow;
            string line;
            string path = "bookData.txt";
            if (File.Exists(path))
            {
                StreamReader myFile = new StreamReader(path);
                while ((line = myFile.ReadLine()) != null)
                {
                    detailBooks objdata = new detailBooks();
                    objdata.setbookcategories(usersDL.getfield(line, 1));
                    objdata.setbooklist(usersDL.getfield(line, 2));
                    objdata.setbookauthur(usersDL.getfield(line, 3));
                    objdata.setbookPublish(usersDL.getfield(line, 4)) ;
                    borrow = usersDL.getfield(line, 5);
                  //  objdata.setisbookborrowed(bool.Parse(userslist.getfield(line,5)))
                    helper( borrow, ref  objdata);
                    index++;
                    addIntoBookList(objdata);
                }
                myFile.Close();
                return true;
            }
            return false;
        }
        public static void helper(string borrow, ref detailBooks objd)
        {
            if (borrow == "True")
            {
                objd.setisbookborrowed(true);
            }
            if (borrow == "False")
            {
                objd.setisbookborrowed(false);
            }
        }

        // // // // // // // //
        //  VALIDATIONS     //
        // // // // // //  //

        public static bool IsYearValid(string input)
        {
            if (!int.TryParse(input, out int year))
            {
                return false;
            }
            if (year < 1000 || year > 9999)
            {
                return false;
            }

            return true;
        }
        public static bool IsdateValid(string dates)
        {
            // Check if the input is a numeric value
            if (!int.TryParse(dates, out int date))
            {
                return false;
            }
            if (date < 1 || date > 31)
            {
                return false;
            }
            return true;
        }
        public static bool ValidateMonth(string monthInput)
        {
            int month;
            if (int.TryParse(monthInput, out month))
            {

                return month >= 1 && month <= 12;
            }
            return false;
        }

        // // // // // // // //
        //   FUNCTIONS      //
        // // // // // //  //

        public static bool searchBooks(detailBooks b)
        {
            bool isCheck = false;
            for (int index = 0; index < bookDetail.Count; index++)
            {
                if (b.getbookC() == bookDetail[index].getbookList() && b.getauthurC() == bookDetail[index].getbookAuthur())
                {

                    isCheck = true;
                    break;
                }
            }
            return isCheck;
        }     
        public static bool checkRbooks(ref string remove, ref string auhtor)
        {
            bool valid = false;
            for (int index = 0; index < bookDetail.Count; index++)
            {
                if (remove == bookDetail[index].getbookList() && auhtor == bookDetail[index].getbookAuthur())
                {

                    bookDetail.RemoveAt(index);
                    saveData1();
                    valid = true;
                    break;
                }

            }
            return valid;
        }
        public static bool booksWidraw(detailBooks c, users d)
        {
            for (int index = 0; index < bookDetail.Count; index++)
            {
                if (c.getbookC() == bookDetail[index].getbookList() && c.getauthurC() == bookDetail[index].getbookAuthur())
                {

                    bookDetail[index].setisbookborrowed(true);
                    d.setbookwidraw(true);
                    d.setborrowbookname(c.getbookC());
                    d.setborrowbookAuthur(c.getauthurC());
                    usersDL.saveData();
                    usersDL.saveDataforview();
                    return true;
                }
            }
            return false;
        }
        public static void returnBoook(string name, string authur)
        {
            foreach (detailBooks d in bookDetail)
            {
                if (name == d.getbookList() && authur == d.getbookAuthur())
                {
                    d.setisbookborrowed(false);
                }
            }
        }

    }
}

