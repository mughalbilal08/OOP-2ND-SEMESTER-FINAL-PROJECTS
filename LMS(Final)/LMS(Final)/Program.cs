using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LMS_Final_.BL;
using LMS_Final_.DL;
namespace LMS_Final_
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            usersDL.loadDataA();
            usersDL.loadData();
            usersDL.loadviewData();
            detailBooksDL.loadData1();
            Application.Run(new Form1());
            
        }
    }
}
