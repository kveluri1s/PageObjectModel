using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageAutomation.SupportFns
{
    public class browserDr
    {
            IWebDriver dr;
            public IWebDriver getchromedriver(){                
                dr = new ChromeDriver();
                dr.Manage().Window.Maximize();
                return dr;
            }

            public ChromeOptions setchromebrowserlang()
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("--lang=es");
                return options;
            }

            public String getchromebrowserlang()
            {
                //get the browser language
                IJavaScriptExecutor js = (IJavaScriptExecutor)dr;
                var language = js.ExecuteScript("return window.navigator.language");
                Console.Write(language.ToString());
                return language.ToString();
             }

            public IWebDriver NavigateToURL(String URL)
            {
                dr = getchromedriver();
                dr.Navigate().GoToUrl(URL);
                if (!getchromebrowserlang().Equals("en-us"))
                {
                    setchromebrowserlang();
                    return dr;
                }
            return dr;
        }        
    }
}
