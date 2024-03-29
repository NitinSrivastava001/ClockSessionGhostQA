﻿using ClocksessionGhostQAAutomation.TestSuites.LoginSuite.Pages;
using ClocksessionGhostQAAutomation.Utils;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ClocksessionGhostQAAutomation.TestSuites.LoginSuite.Tests
{
    [TestFixture]
    [Property("Priority", 0)] // Smoke Test to make sure  LogIn is not blocked
    public class LoginTest : BaseTest
    {
        public static TestData _testData = TestDataSharedInstance.testData;
        public static String testname;
        public static string Status;
        public static string Message;
        public static string StackTrace;
        public static string EnvName;

        [Test, Order(0)]
        public void Verify_User_Is_Able_To_Login()
        {
            _testData.TestCaseName = "Verify_User_Is_Able_To_Login";
            _testData.TestSuiteName = "ClockSession_Test";
            _testSteps = new List<TestStepColumns> { new TestStepColumns() };
           // VideoRecorder.StartRecording();
            
            var logInPage = new LoginPage();
            //if (VideoRecorder.basePath.Contains("images"))
            //    VideoRecorder.basePath = VideoRecorder.basePath.Substring(0, VideoRecorder.basePath.IndexOf("\\images"));
            //_testData.TestCaseVideoURL = @"\" + (VideoRecorder.outputFile.StartsWith(VideoRecorder.basePath) ? VideoRecorder.outputFile.Substring(VideoRecorder.basePath.Length).ToString().TrimStart('\\') : VideoRecorder.outputFile.ToString());

            var dateTime = DateTime.Now.ToString("dd-MMM-yyyy_HH-mm-ss");
            _testData.TestRunStartDateTime = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss.fffffffzzz");

            _testSteps.Add(new TestStepColumns { Status = "Passed", Timestamp = dateTime, Details = "wait for plage to loader" });
            logInPage.WaitForPageLoad();
            VideoRecorder.ScreenShot("Step1", dateTime);   


            _testSteps.Add(new TestStepColumns { Status = "Passed", Timestamp = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss.fffffffzzz"), Details = "Click on Login Button" });
            logInPage.ClickonLogin();
            VideoRecorder.ScreenShot("Step2", dateTime);

            _testSteps.Add(new TestStepColumns { Status = "Passed", Timestamp = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss.fffffffzzz"), Details = "Enter Email Test" });
            logInPage.SetEmail("Test");
            VideoRecorder.ScreenShot("Step3", dateTime);

            _testSteps.Add(new TestStepColumns { Status = "Passed", Timestamp = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss.fffffffzzz"), Details = "Enter passoword test" });
            logInPage.SetPassword("Test");
            VideoRecorder.ScreenShot("Step4", dateTime);
            try
            {
                _testSteps.Add(new TestStepColumns { Status = "Passed", Timestamp = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss.fffffffzzz"), Details = "Click on Submit button Test" });
                logInPage.SubmitLogIn();
                VideoRecorder.ScreenShot("Step5", dateTime);
                _testData.TestCaseStatus = "Passed";
            }
            catch (Exception ex)
            {
                StackTrace = ex.StackTrace;
                Message = ex.Message;
                Status = "Failed";
                _testData.TestCaseStatus = "Failed";
                Console.WriteLine(ex.StackTrace);
            }
        }

        [Test, Order(1)]
        public void VerifyLoginOK()
        {
            _testData.TestCaseName = "VerifyLoginOK";
            _testData.TestSuiteName = "ClockSession_Test";
            _testSteps = new List<TestStepColumns> { new TestStepColumns() };

            //VideoRecorder.StartRecording();
            var logInPage = new LoginPage();
            //if (VideoRecorder.basePath.Contains("images"))
            //    VideoRecorder.basePath = VideoRecorder.basePath.Substring(0, VideoRecorder.basePath.IndexOf("\\images"));
            //_testData.TestCaseVideoURL = @"\" + (VideoRecorder.outputFile.StartsWith(VideoRecorder.basePath) ? VideoRecorder.outputFile.Substring(VideoRecorder.basePath.Length).ToString().TrimStart('\\') : VideoRecorder.outputFile.ToString());

            var dateTime = DateTime.Now.ToString("dd-MMM-yyyy_HH-mm-ss");
            _testData.TestRunStartDateTime = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss.fffffffzzz");

            _testSteps.Add(new TestStepColumns { Status = "Passed", Timestamp = dateTime, Details = "wait for plage to loader" });
            logInPage.WaitForPageLoad();
            VideoRecorder.ScreenShot("Step1", dateTime);

            _testSteps.Add(new TestStepColumns { Status = "Passed", Timestamp = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss.fffffffzzz"), Details = "Click on Login Button" });
            logInPage.ClickonLogin();
            VideoRecorder.ScreenShot("Step2", dateTime);

            _testSteps.Add(new TestStepColumns { Status = "Passed", Timestamp = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss.fffffffzzz"), Details = "Enter Email Test" });
            logInPage.SetEmail("Test");
            VideoRecorder.ScreenShot("Step3", dateTime);

            _testSteps.Add(new TestStepColumns { Status = "Passed", Timestamp = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss.fffffffzzz"), Details = "Enter passoword test" });
            logInPage.SetPassword("Test");
            VideoRecorder.ScreenShot("Step4", dateTime);
            try
            {
                _testSteps.Add(new TestStepColumns { Status = "Passed", Timestamp = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss.fffffffzzz"), Details = "Click on Submit button Test" });
                logInPage.SubmitLogIn();
                VideoRecorder.ScreenShot("Step1", dateTime);
                _testData.TestCaseStatus = "Passed";
            }
            catch (Exception ex)
            {
                StackTrace = ex.StackTrace;
                Message = ex.Message;
                Status = "Failed";
                _testData.TestCaseStatus = "Failed";
                Console.WriteLine(ex.StackTrace);
            }
        }

        [Test, Order(1)]
        public void Verify_User_is_able_to_Login_Successfully()
        {
            _testData.TestCaseName = "Verify_User_is_able_to_Login_Successfully";
            _testData.TestSuiteName = "ClockSession_Test";
            _testSteps = new List<TestStepColumns> { new TestStepColumns() };

            //VideoRecorder.StartRecording();
            var logInPage = new LoginPage();
            //if (VideoRecorder.basePath.Contains("images"))
            //    VideoRecorder.basePath = VideoRecorder.basePath.Substring(0, VideoRecorder.basePath.IndexOf("\\images"));
            //_testData.TestCaseVideoURL = @"\" + (VideoRecorder.outputFile.StartsWith(VideoRecorder.basePath) ? VideoRecorder.outputFile.Substring(VideoRecorder.basePath.Length).ToString().TrimStart('\\') : VideoRecorder.outputFile.ToString());

            var dateTime = DateTime.Now.ToString("dd-MMM-yyyy_HH-mm-ss");
            _testData.TestRunStartDateTime = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss.fffffffzzz");

            _testSteps.Add(new TestStepColumns { Status = "Passed", Timestamp = dateTime, Details = "wait for plage to loader" });
            logInPage.WaitForPageLoad();
            VideoRecorder.ScreenShot("Step1", dateTime);

            _testSteps.Add(new TestStepColumns { Status = "Passed", Timestamp = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss.fffffffzzz"), Details = "Click on Login Button" });
            logInPage.ClickonLogin();
            VideoRecorder.ScreenShot("Step2", dateTime);

            _testSteps.Add(new TestStepColumns { Status = "Passed", Timestamp = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss.fffffffzzz"), Details = "Enter Email Test" });
            logInPage.SetEmail("nitin.srivastava@mechlintech.com");
            VideoRecorder.ScreenShot("Step3", dateTime);

            _testSteps.Add(new TestStepColumns { Status = "Passed", Timestamp = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss.fffffffzzz"), Details = "Enter passoword test" });
            logInPage.SetPassword("Nit@96553");
            VideoRecorder.ScreenShot("Step4", dateTime);

            _testSteps.Add(new TestStepColumns { Status = "Passed", Timestamp = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss.fffffffzzz"), Details = "Click on Submit button Test" });
            logInPage.SubmitLogIn();
            VideoRecorder.ScreenShot("Step5", dateTime);

            try
            {
                Assert.IsTrue(logInPage.LoginSuccess());
                VideoRecorder.ScreenShot("Step6", dateTime);
                _testSteps.Add(new TestStepColumns { Status = "Passed", Timestamp = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss.fffffffzzz"), Details = "Login Success" });
                _testData.TestCaseStatus = "Passed";
            }
            catch (Exception ex)
            {
                StackTrace = ex.StackTrace;
                Message = ex.Message;
                Status = "Failed";
                _testData.TestCaseStatus = "Failed";
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}