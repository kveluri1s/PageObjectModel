using OpenQA.Selenium;
using PageAutomation.SupportFns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageAutomation.PageFns
{
    class AdminPg
    {
        static IWebDriver dr;
        private static By ADMINLINK = By.XPath("//a[contains(@href,'Admin')]");
        private static By USERMGMTOPTION = By.XPath("//a[contains(.,'User Management')]");
        private static By USERMGMTVIEWUSERS = By.XPath("//a[contains(.,'User Management')]//following::a[contains(@id,'menu_admin_viewSystemUsers')]");
        private static By USERMGMTADDBUTTON = By.XPath("//input[@id='btnAdd']");
        private static By USERROLE = By.XPath("//select[@id='systemUser_userType']");
        private static By EMPNAME = By.XPath("//input[@id='systemUser_employeeName_empName']");
        private static By USERNNAME = By.XPath("//input[@id='systemUser_userName']");
        private static By STATUS = By.XPath("//select[@id='systemUser_status']");
        private static By PASSWORD = By.XPath("//input[@id='systemUser_password']");
        private static By CNFRMPWD = By.XPath("//input[@id='systemUser_confirmPassword']");
        private static By SAVEBTN = By.XPath("//input[@id='btnSave']");
        private static By USERTABLE = By.XPath("//table[@id='resultTable']");


        //Chenzira Chuki
        public AdminPg(IWebDriver driver)
        {
            dr = driver;

        }

        public void orangeAdminLinkClick()
        {
            if (dr.FindElement(ADMINLINK).Displayed)
            {
                dr.FindElement(ADMINLINK).Click();
            }
        }

        public void orangeAdminUserMgmt()
        {
            if (dr.FindElement(ADMINLINK).Displayed)
            {
                dr.FindElement(ADMINLINK).Click();
                dr.FindElement(USERMGMTOPTION).Click();
                dr.FindElement(USERMGMTVIEWUSERS).Click();
                dr.FindElement(USERMGMTADDBUTTON).Click();
            }
        }

        public void addEmployee()
        {
            if (dr.FindElement(SAVEBTN).Displayed)
            {
                driverFunctions supportDr = new driverFunctions(dr);
                if (supportDr.GetAllOptionsDropDownList(USERROLE).Contains("Admin"))
                {
                    supportDr.SelectvaluesDropdown(USERROLE, "Admin");
                }
                supportDr.typeText(EMPNAME, "Rebecca Harmony");
                dr.FindElement(By.XPath("//li[@class='ac_even ac_over' and contains(.,'Rebecca')]")).Click();
                supportDr.typeText(USERNNAME, "Rebecca Harmony");
                supportDr.SelectvaluesDropdown(STATUS, "Enabled");                
                supportDr.typeText(PASSWORD, "Ramkrishna93$");
                supportDr.typeText(CNFRMPWD, "Ramkrishna93$");
                if (dr.FindElement(SAVEBTN).Displayed)
                {

                    supportDr.ActionsclickElement(SAVEBTN);
                }                
            }
        }

        public void SelectEmploye()
        {
            TableUtilities.ReadTable(dr.FindElement(USERTABLE));
            string userName = TableUtilities.ReadCell("Username",1);
            string status = TableUtilities.ReadCell("Status", 1);
                if(userName.Equals("Aaliyah.Haq") && status.Equals("Enabled"))
                {
                IWebElement empChkbx = dr.FindElement(By.XPath("//a[contains(text(),'Aaliyah.Haq')]/preceding::td/input[@type='checkbox']"));
                empChkbx.Click();
                Console.Write("Employee is selected");
                }

        }

    }
}
