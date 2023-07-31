using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Final_.BL
{
    public class record
    {
        private string nameb;
        private string authorb;
        private System.DateTime d;

        public string Book { get => nameb; set => nameb = value; }
        public string Author { get => authorb; set => authorb = value; }
        public DateTime Time { get => d; set => d = value; }

        public record(string nameb, string authorb, System.DateTime d)
        {
            this.nameb = nameb;
            this.authorb = authorb;
            this.d = d;
        }
        public record(string name, string author)
        {
            this.nameb = name;
            this.authorb = author;
        }
        public string getnameb()
        {
            return nameb;
        }
        public void setnameb(string nameb)
        {
            this.nameb = nameb;
        }
        public string getauthorb()
        {
            return authorb;
        }
        public void setauthorb(string authorb)
        {
            this.authorb = authorb;
        }
        public System.DateTime getdatetimeb()
        {
            return d;
        }
        public void setdate(System.DateTime d)
        {
            this.d = d;
        }
       
    }
}
