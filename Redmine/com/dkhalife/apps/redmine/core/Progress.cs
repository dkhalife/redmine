using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redmine.com.dkhalife.apps.redmine.core
{
    public class Progress
    {
        public delegate void OnUpdateEventHandler(object sender, double value);

        public double Value { get; private set; }

        public void Report(double value)
        {
            if (Updated == null || value == Value)
                return;

            if (value >= 0 && value <= 100)
                Updated(this, Value = value);
            else
                throw new ArgumentException($"The value provided '{value}' is out of bounds [0-100].");
        }

        public event OnUpdateEventHandler Updated;
    }
}
