﻿using com.dkhalife.apps.redmine.core;
using System;
using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine
{
    [XmlRoot("user")]
    [RedmineApi("users")]
    public class User : INamedType
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("firstname")]
        public string FirstName { get; set; }

        [XmlElement("lastname")]
        public string LastName { get; set; }

        [XmlIgnore]
        string INamedType.Name
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [XmlElement("mail")]
        public string Email { get; set; }

        [XmlElement("created_on")]
        public DateTime CreatedOn { get; set; }

        [XmlElement("last_login_on")]
        public DateTime LastLoginOn { get; set; }
    }
}