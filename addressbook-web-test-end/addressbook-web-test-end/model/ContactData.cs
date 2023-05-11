using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WebAddressbookTests;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]

    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string block;

        public ContactData()
        {
        }

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;

        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Lastname == other.Lastname && Firstname == other.Firstname;

        }

        public override int GetHashCode()
        {
            return Lastname.GetHashCode() + Firstname.GetHashCode();
        }

        public override string ToString()
        {
            return Lastname + " " + Firstname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (this.Lastname == other.Lastname)
            {
                return this.Firstname.CompareTo(other.Firstname);
            }
                           
            return this.Lastname.CompareTo(other.Lastname);

        }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "firstname")]
        public string Firstname { get; set; }

        [Column(Name = "middlename")]
        public string MiddleName { get; set; }

        [Column(Name = "lastname")]
        public string Lastname { get; set; }
        public string NickName { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Fax { get; set; }

        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string HomePage { get; set; }

        public string BDay { get; set; }
        public string BMonth { get; set; }
        public string BYear { get; set; }
        public string ADay { get; set; }
        public string AMonth { get; set; }
        public string AYear { get; set; }

        public string Address2 { get; set; }

        public string Phone2 { get; set; }

        public string Notes { get; set; }



        public string AllPhones 
        {
            get 
            {
                if (allPhones != null) 
                {
                    return allPhones;
                }
                else 
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set 
            {
                allPhones = value;
            }
        }
        [XmlIgnore]
        public string Block
        {
            get
            {
                if (block != null)
                {
                    return block;
                }
                else
                {
                    return (CleanAll(CleanFio(Firstname, MiddleName, Lastname) + Clean(NickName) + Clean(Title) + Clean(Company) + Clean(Address)) +
                        CleanAll(CleanHomePhone(HomePhone) + CleanMobilePhone(MobilePhone) + CleanWorkPhone(WorkPhone) + CleanFaxPhone(Fax)) +
                        CleanAll(Clean(Email) + Clean(Email2) + Clean(Email3) + CleanHomepage(HomePage)) +
                        CleanAll(CleanBD(BDay, BMonth, BYear) + CleanAD(ADay, AMonth, AYear)) +
                        CleanAll(Clean(Address2)) +
                        CleanAll(CleanHomePhone2(Phone2)) +
                        CleanAll(Clean(Notes))).Trim();
                }
            }
            set
            {
                block = value;
            }
        }


        public string CleanAll(string xxx)
        {
            if (xxx == null || xxx == "")
            {
                return "";
            }
            return (xxx + "\r\n");
        }

        public string CleanBD(string BDay, string BMonth, string BYear)
        {
            if (BDay == "0" && BMonth == "-" && BYear == "")
            {
                return "";
            }
            else if (BMonth == "-" && BYear == "")
            {
                return ("Birthday " + BDay + "." + "\r\n");
            }
            else if (BDay == "0" && BYear == "")
            {
                return ("Birthday " + BMonth + "\r\n");
            }
            else if (BDay == "0" && BMonth == "-")
            {
                return ("Birthday " + BYear + " " + "(" + (DateTime.Now.Year - int.Parse(BYear) - 1) + ")" + "\r\n");
            }
            else if (BYear == "" || BYear == null)
            {
                return ("Birthday " + BDay + ". " + BMonth + "\r\n");
            }
            else if (BMonth == "-" || BMonth == null)
            {
                return ("Birthday " + BDay + ". " + BYear + " " + "(" + (DateTime.Now.Year - int.Parse(BYear) - 1) + ")" + "\r\n");
            }
            else if (BDay == "0" || BDay == null)
            {
                return ("Birthday " + BMonth + " " + BYear + " " + "(" + (DateTime.Now.Year - int.Parse(BYear) - 1) + ")" + "\r\n");
            }
            else
            return ("Birthday " + BDay + ". " + BMonth + " " + BYear + " " + "(" + (DateTime.Now.Year - int.Parse(BYear) - 1) + ")" + "\r\n");
        }

        public string CleanAD(string ADay, string AMonth, string AYear)
        {
            if (ADay == "0" && AMonth == "-" && AYear == "")
            {
                return "";
            }
            else if (AMonth == "-" && AYear == "")
            {
                return ("Anniversary " + ADay + "." + "\r\n");
            }
            else if (ADay == "0" && AYear == "")
            {
                return ("Anniversary " + CleanMounthA(AMonth) + "\r\n");
            }
            else if (ADay == "0" && AMonth == "-")
            {
                return ("Anniversary " + AYear + " " + "(" + (DateTime.Now.Year - int.Parse(AYear)) + ")" + "\r\n");
            }
            else if (AYear == "")
            {
                return ("Anniversary " + ADay + ". " + CleanMounthA(AMonth) + "\r\n");
            }
            else if (AMonth == "-")
            {
                return ("Anniversary " + ADay + ". " + AYear + " " + "(" + (DateTime.Now.Year - int.Parse(AYear)) + ")" + "\r\n");
            }
            else if (ADay == "0")
            {
                return ("Anniversary " + CleanMounthA(AMonth) + " " + AYear + " " + "(" + (DateTime.Now.Year - int.Parse(AYear)) + ")" + "\r\n");
            }
            else
                return ("Anniversary " + ADay + ". " + CleanMounthA(AMonth) + " " + AYear + " " + "(" + (DateTime.Now.Year - int.Parse(AYear)) + ")" + "\r\n");
        }

        public string CleanHomePhone(string HomePhone)
        {
            if (HomePhone == null || HomePhone == "")
            {
                return "";
            }
            return ("H: " + HomePhone + "\r\n");
        }

        public string CleanHomePhone2(string Phone2)
        {
            if (Phone2 == null || Phone2 == "")
            {
                return "";
            }
            return ("P: " + Phone2 + "\r\n");
        }

        public string CleanMobilePhone(string MobilePhone)
        {
            if (MobilePhone == null || MobilePhone == "")
            {
                return "";
            }
            return ("M: " + MobilePhone + "\r\n");
        }

        public string CleanWorkPhone(string WorkPhone)
        {
            if (WorkPhone == null || WorkPhone == "")
            {
                return "";
            }
            return ("W: " + WorkPhone + "\r\n");
        }

        public string CleanFaxPhone(string Fax)
        {
            if (Fax == null || Fax == "")
            {
                return "";
            }
            return ("F: " + Fax + "\r\n");
        }

        public string CleanHomepage(string HomePage)
        {
            if (HomePage == null || HomePage == "")
            {
                return "";
            }
            return ("Homepage:" + "\r\n" + HomePage + "\r\n");
        }



       

        public string CleanMounthA(string AMonth)
        {
            if (AMonth == "-")
            {
                return "";
            }
            return char.ToUpper(AMonth[0]) + AMonth.Substring(1);
        }

        


        public string CleanUp(string phone)
        {
           if (phone == null || phone == "") 
            {
                return "";
            }
            return Regex.Replace(phone, "[ ()-]", "") + "\r\n";
        }

        public string Clean(string ppp)
        {
            if (ppp == null || ppp == "")
            {
                return "";
            }
            return (ppp + "\r\n");
        }

        public string CleanFio(string Firstname, string MiddleName, string Lastname)
        {
            if (Firstname == null && MiddleName == null && Lastname == "")
            {
                return "";
            }

            else if ((MiddleName == null || MiddleName == "") && (Lastname == null || Lastname == ""))
            {
                return (Firstname + "\r\n");
            }

            else if (Firstname == null && Lastname == "")
            {
                return (MiddleName + "\r\n");
            }

            else if ((Firstname == null || Firstname == "") && (MiddleName == null || MiddleName == ""))
            {
                return (Lastname + "\r\n");
            }

            else if (Firstname == null || Firstname == "")
            {
                return (MiddleName + " " + Lastname + "\r\n");
            }

            else if (MiddleName == null || MiddleName == "")
            {
                return (Firstname + " " + Lastname + "\r\n");
            }

            else if (Lastname == null || Lastname == "")
            {
                return (Firstname + " " + MiddleName + "\r\n");
            }
            else 
            {
                return (Firstname + " " + MiddleName + " " + Lastname + "\r\n");
            }           

        }
    }
}