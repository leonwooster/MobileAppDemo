using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using UITest.Pages;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest
{
    [TestFixture(Platform.Android)]
   // [TestFixture(Platform.iOS)]
    public class Tests  
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
           
        }

        [Test]       
        public void TestCreateList()
        {
            //app.Repl();
           // app.Tap(x => x.Marked("More options"));
            app.Tap(x => x.Text("Add"));
            app.EnterText(x => x.Id("txtTitle"), "EA");
            app.DismissKeyboard();
            app.EnterText(x => x.Id("txtDesc"), "Description");
            app.DismissKeyboard();
            app.Tap(x => x.Id("save_button"));
            app.WaitForElement(x => x.Text("EA"));
            //app.ScrollDownTo(x => x.Text("EA"));
            var elementCount = app.Query(x => x.Id("recyclerView").All().Text("EA")).Count();
            Assert.That(elementCount, Is.EqualTo(1), "There is no such element being added in app list");
            app.SwipeRightToLeft();
            app.SwipeLeftToRight();
        }

        //Recorded Hybrid application code
        [Test]
        public void NewTest()
        {
           // app.EnterText(x => x.Css("INPUT#txtUserName"), "EATEST");
          //  app.Tap(x => x.XPath("//span[text()='About']"));
           // app.Tap(x => x.XPath("//span[text()='Contact']"));
           // app.Tap(x => x.XPath("//span[text()='Home']"));
        }


        [Test]
        public void UsingPOM()
        {
            HomePage homePage = new HomePage();
            AddItemPage addItemPage = new AddItemPage();

            //Click Add
            homePage.ClickAdd();
            //Create list
            addItemPage.AddItem("EA", "EA is awesome !!");
            //Wait for element
            homePage.WaitForListElement();
            //Finally Assertion
           // var elementCount = homePage.GetElementCount();
           // Assert.That(elementCount, Is.EqualTo(1), "There is no such element being added in app list");

        }

    }
}
