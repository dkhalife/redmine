using System;

namespace Redmine.UWP
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