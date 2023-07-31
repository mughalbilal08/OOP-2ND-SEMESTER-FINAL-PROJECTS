using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Final_.BL
{
  public  class detailBooks 
    {
        private string bookList;
        private string bookAuthur;
        private string bookPublish;
        private string bookCategories;
        private string bookC;
        private string authurC;
        private string check;
        private bool isbookborrowed;
        public string Categories { get => bookCategories; set => bookCategories = value; }
        public string Names { get => bookList; set => bookList = value; }
        public string Authur { get => bookAuthur; set => bookAuthur = value; }
        public string Publish { get => bookPublish; set => bookPublish = value; }
        
        public detailBooks()
        {

        }
        public detailBooks(string bookCategories, string bookList, string bookAuthur, string bookPublish)
        {
            this.bookCategories = bookCategories;
            this.bookList = bookList;
            this.bookAuthur = bookAuthur;
            this.bookPublish = bookPublish;
            this.isbookborrowed = false;
        }
         public detailBooks(string bookC, string authurC)
        {
            this.bookC = bookC;
            this.authurC = authurC;
        }
        public string getcheck()
        {
            return check;
        }
        public void setcheck(string check)
        {
            this.check = check;
        }
        public string getbookList()
        {
            return bookList;
        }
        public void setbooklist(string bookList)
        {
            this.bookList = bookList;
        }
        public string getbookAuthur()
        {
            return bookAuthur;
        }
        public void setbookauthur(string bookAuthur)
        {
            this.bookAuthur = bookAuthur;
        }
        public string getbookpublish()
        {
            return bookPublish;
        }
        public void setbookPublish(string bookPublish)
        {
            this.bookPublish = bookPublish;
        }
        public string getbookcategories()
        {
            return bookCategories;
        }
        public void setbookcategories(string bookCategories)
        {
            this.bookCategories = bookCategories;
        }
    
        public string getbookC()
        {
            return bookC;
        }
        public string getauthurC()
        {
            return authurC;
        }
        public void setisbookborrowed(bool borrow)
        {
            this.isbookborrowed = borrow;
        }
        public bool getisbookborrowed()
        {
            return isbookborrowed;
        }
      
    }
}
