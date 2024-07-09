using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageAutomation.SupportFns
{
    class driverFunctions 
    {

        IWebDriver dr;
        List<String> Alloptions = new List<string>();
        public driverFunctions(IWebDriver driver)
        {
            dr = driver;
        }
        
        public String GetText(By element)
        {
            String text;                
            if (dr.FindElement(element).Displayed)
            {
                text = dr.FindElement(element).Text;
            }

            else
            {
                throw new ElementNotVisibleException();
            }
            return text;
        }




        public Boolean GetTextAndValidate(By element,String validationvalue)
        {
            bool validaton = false;
            if (dr.FindElement(element).Displayed)
            {
                String text = GetText(element);
                if (text.ToLower().Trim().Equals(validationvalue.ToLower().Trim()))
                {
                    validaton = true;
                }
            }

            else
            {
                validaton = false;
                throw new ElementNotVisibleException();
            }
            return validaton;
        }

        public Boolean TextValidation(String refValue, String validationvalue)
        {
            bool validaton = false;

            if (refValue.ToLower().Trim().Equals(validationvalue.ToLower().Trim()))
            {
                validaton = true;
            }
            else
            {
                validaton = false;
                throw new ElementNotVisibleException();
            }
            return validaton;
        }


        public List<String> GetAllOptionsDropDownList(By element)
        {
            
            if (dr.FindElement(element).Displayed)
            {
                SelectElement selectList = new SelectElement(dr.FindElement(element));
                IList<IWebElement> Totaloptions = selectList.Options;
                int ItemSize = Totaloptions.Count;
                for (int i = 1 ; i <= ItemSize; i++)
                {
                    String ItemValue = Totaloptions.ElementAt(i-1).Text.ToString();
                    Alloptions.Add(ItemValue);
                    Console.Write("\nThe option at index"+i+"is: "+ ItemValue);  
                }
                return Alloptions;

            }
            else
            {
                throw new ElementNotVisibleException();
            }
            
        }


        public void typeText(By element, String value)
        {
            if (dr.FindElement(element).Displayed)
                dr.FindElement(element).SendKeys(value);
            else
                throw new ElementNotVisibleException();
        }

        public void clickElement(By element, String value)
        {
            if (dr.FindElement(element).Displayed)
                dr.FindElement(element).Click();
            else
                throw new ElementClickInterceptedException();


        }

        public void ActionsclickElement(By element)
        {
            Actions actions = new Actions(dr);
            IJavaScriptExecutor ex = (IJavaScriptExecutor)dr;
            if (dr.FindElement(element).Displayed)
                ex.ExecuteScript("arguments[0].click();", dr.FindElement(element));
            else
                throw new ElementClickInterceptedException();


        }

        public void SubmitForm(By element)
        {
            try
            {
                if (dr.FindElement(element).Displayed)
                    dr.FindElement(element).Submit();
            }
            catch
            {
                throw new ElementClickInterceptedException();
            }
        }


        public void SelectvaluesDropdown(By element , String value)
        {

            if (dr.FindElement(element).Displayed)
                new SelectElement(dr.FindElement(element)).SelectByText(value);
            else
                throw new ElementClickInterceptedException();
        }

    }
}
