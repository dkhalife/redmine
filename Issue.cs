using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkTimer
{
    public class Issue
    {
        public int id;
        public String title;
        public String project;

        override public String ToString()
        {
            return title;
        }
    }
}
