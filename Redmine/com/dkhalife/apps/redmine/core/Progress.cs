using System;

namespace Redmine.com.dkhalife.apps.redmine.core
{
    public class Progress
    {
        public delegate void OnUpdateEventHandler(object sender, int value);

        public int Value { get; private set; }

        public void Report(int value)
        {
            if (Updating == null || value == Value)
                return;

            if (value >= 0 && value <= 100)
                Updating(this, Value = value);
            else
                throw new ArgumentException($"The value provided '{value}' is out of bounds [0-100].");
        }

        public event OnUpdateEventHandler Updating;
    }
}
