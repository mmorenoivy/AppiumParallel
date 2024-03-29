﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumParallel
{
    public class Base
    {
        public static AndroidDriver<IWebElement> driver;

        public void Setup(String deviceName)
        {
            string ipaddress1 = ""; //your emulator one's ip address
            string ipaddress2 = ""; //your second emulator's ip address
            string ipaddress3 = ""; //your third emulator's ip address
            DesiredCapabilities cap = new DesiredCapabilities();

            cap.SetCapability(MobileCapabilityType.BrowserName, "Chrome");
            cap.SetCapability(CapabilityType.Platform, "Android");

              if (deviceName.Equals("Nexus 5X API 24"))
              {
                  cap.SetCapability("deviceName", "Nexus 5X API 24");//Nexus 5X API 24
                  driver = new AndroidDriver<IWebElement>(new Uri("http://" + ipaddress1 + "/wd/hub"), cap);
              }
            if(deviceName.Equals("Pixel 2 API 28"))
              {
                  cap.SetCapability("deviceName", "Pixel 2 API 28");
                  driver = new AndroidDriver<IWebElement>(new Uri("http://" + ipaddress2 + "/wd/hub"), cap);
              }
              if (deviceName.Equals("Pixel API 27"))
              {
                  cap.SetCapability("deviceName", "Pixel API 27");
                  driver = new AndroidDriver<IWebElement>(new Uri("http://" + ipaddress3 + "/wd/hub"), cap);
              }

        }

        public static IEnumerable<String> DeviceToRun()
        {
            String[] devices = { "Nexus 5X API 24", "Pixel 2 API 28", "Pixel API 27" };

            foreach (String d in devices)
            {
                yield return d;
            }
        }

        [TearDown]
        public void CloseTests()
        {
            driver.Close();
        }

    }
}
