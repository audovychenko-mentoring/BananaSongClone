using BananaSongTest.Elements;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace BananaSongTest.Pages
{
    class GmailAboutPage
    {       
        public UIElement signInButton => new UIElement(By.XPath("//li[@class = 'h-c-header__nav-li g-mail-nav-links']/a[contains(text(), 'Sign in') and @class = 'h-c-header__nav-li-link ']"));

        public void ClickToSignIn()
        {
            signInButton.WebElement.Click();
        }
    }
}
