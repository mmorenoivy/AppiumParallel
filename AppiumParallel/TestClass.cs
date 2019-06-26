using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppiumParallel
{
    

    [TestFixture]
    [Parallelizable]
    public class TestClass : Base
    {
        [Test]
        [TestCaseSource(typeof(Base), "DeviceToRun")]
        public void LaunchURL(String deviceName)
        {
            Setup(deviceName);
            var navigation = driver.Navigate();
            navigation.GoToUrl("https://mobilecompass-dev.azurewebsites.net/");

        }

    
      

    }
}
