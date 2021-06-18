using OpenQA.Selenium.Chrome;

using NUnit.Framework;

using OpenQA.Selenium;

namespace Tests
{
    public class Tests
    {

        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Url = "https://www.google.com";

        }

        //Test 1 (KPI SCHEDULE)
        [Test]
        public void schedule()
        {
            //search for kpi schedule
            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input")).SendKeys("KPI schedule"
            + Keys.Return);

            //open the first link
            driver.FindElement(By.XPath("//*[@id=\"rso\"]/div[1]/div/div/div/div/div/div[1]/a/h3")).Click();

            //open 'class' subcategory
            driver.FindElement(By.XPath("//*[@id=\"ctl00_lBtnSchedule\"]")).Click();

            //search for our group
            driver.FindElement(By.XPath("//*[@id=\"ctl00_MainContent_ctl00_txtboxGroup\"]")).SendKeys("кп-91" + Keys.Return);

            //week 1 schedule assertion
            Assert.AreEqual(driver.FindElement(By.XPath("//*[@id=\"ctl00_MainContent_FirstScheduleTable\"]/tbody/tr[2]/td[4]/span/a"))
            .GetAttribute("title"), "Компоненти програмної інженерії 2. Якість та тестування програмного забезпечення");

            //week 2 schedule assertion
            Assert.AreEqual(driver.FindElement(By.XPath("//*[@id=\"ctl00_MainContent_SecondScheduleTable\"]/tbody/tr[2]/td[4]/span/a"))
            .GetAttribute("title"), "Компоненти програмної інженерії 2. Якість та тестування програмного забезпечення");
        }

        //Test 2 (EPICENTR)
        [Test]
        public void epicentr()
        {
            //search for epicentr
            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input")).SendKeys("epicentr"
            + Keys.Return);

            //open the first link
            driver.FindElement(By.XPath("//*[@id=\"rso\"]/div[1]/div/div/div/div/div/div/div[1]/a/h3")).Click();

            //open 'contacts'
            driver.FindElement(By.XPath("//*[@id=\"info-footer\"]/a[3]")).Click();

            //working hours assertion
            Assert.AreEqual(driver.FindElement(By.XPath("/html/body/main/div[2]/div/section/h3")).Text
            , "Контакт-центр працює для Вас щоденно з 07:30 до 22:30.");
        }

        //Test 3 (NOPCOMMERCE)
        [Test]
        public void nopcommerce()
        {
            //search for nopcommerce
            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input")).SendKeys("https://demo.nopcommerce.com/"
            + Keys.Return);

            //open the needed link
            driver.FindElement(By.XPath("//*[@id=\"rso\"]/div[1]/div/div/div/div/div/div[1]/a/h3")).Click();

            //open '$25 Virtual Gift Card'
            driver.FindElement(By.XPath("/html/body/div[6]/div[3]/div/div/div/div/div[4]/div[2]/div[4]/div/div[1]/a/img")).Click();

            //price assertion
            Assert.AreEqual(driver.FindElement(By.XPath("//*[@id=\"price-value-43\"]")).Text
            , "$25.00");
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Quit();
        }
    }
}