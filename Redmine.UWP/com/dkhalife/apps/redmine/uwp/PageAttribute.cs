using System;

namespace com.dkhalife.apps.redmine.uwp
{
    internal class PageAttribute : Attribute
    {
        public String Title;

        public PageAttribute(string title)
        {
            Title = title;
        }
    }
}