using System.IO;
using NUnit.Framework;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.Factory;
using System;

namespace UI_Test
{
    [TestFixture]
    public class StickyNote
    {
        [Test]
        public void AddTest()
        {
            var applicationPath = CalculateApplicationPath();

            Application application = Application.Launch(applicationPath);

            Window window = application.GetWindow("MainWindow");

            Button button = window.Get<Button>("Ok");

            var list = window.Get<ListBox>("StickyNoteListBox").Items;

            button.Click();

            Window window2 = application.GetWindow("StickyNoteForm");
            Button add = window2.Get<Button>("Ok");

            TextBox title = window2.Get<TextBox>("title");
            TextBox Context = window2.Get<TextBox>("Context");

            title.Text = "start Testing";
            Context.Text = "Add test(1)";

            //save new note
            add.Click();

            Window window3 = application.GetWindow("MainWindow");
            var AfterAdd = window.Get<ListBox>("StickyNoteListBox").Items;
            Assert.AreEqual(list.Count + 1, AfterAdd.Count);

        }

        public static string CalculateApplicationPath()
        {
            var apppath = @"C:\Users\yellow\Source\Repos\FinalProject\FinalProject\bin\Debug";
            var applicationPath = Path.Combine(apppath, "StickyNoteGriphic.exe");
            return applicationPath;
        }
    }
}
