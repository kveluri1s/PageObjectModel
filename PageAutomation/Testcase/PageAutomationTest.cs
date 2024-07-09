using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageAutomation.PageFns;
using PageAutomation.SupportFns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PageAutomation
{
    [TestFixture]
    class addUserCredentials_OrangeHRM
    {
       IWebDriver dr;
        
       /*static public void Main(String[] args)
       {

           Console.WriteLine("Test Initiated");
       }*/

       [SetUp]
      public void initialize()
        {
            //( Username : Admin | Password : admin123 ) 
            testDetails.testMethodName = TestContext.CurrentContext.Test.Name.ToString();
            //string className = this.GetType().FullName;           
            browserDr ts = new browserDr();
            this.dr = ts.NavigateToURL("https://opensource-demo.orangehrmlive.com/");
            String DATASHEET = "OrangeHRMTestData.xlsx";
            ExcelUtil.PopulateInCollection(DATASHEET);
        }

    [Test]
    public void TC2_OrangeHRM_AddUserDetails()
        {
            Login lgn = new Login(dr);
            lgn.orangelogin();
            AdminPg usrmgmt = new AdminPg(dr);
            usrmgmt.orangeAdminLinkClick();
            usrmgmt.orangeAdminUserMgmt();
            usrmgmt.addEmployee();
            usrmgmt.SelectEmploye();
        }

    [TearDown]
    public void closebrowser()
        {
            dr.Quit();
        }   
    }
}
