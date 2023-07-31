using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Final_.BL
{
    public class index
    {
        private static int currentIndex;
        public static int getIndex()
        {
            return currentIndex;
        }
        public static void setIndex(int currentIndex)
        {
            index.currentIndex = currentIndex;
        }

    }
}
