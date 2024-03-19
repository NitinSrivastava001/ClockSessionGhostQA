namespace ClocksessionGhostQAAutomation.TestSuites.LoginSuite.Tests
{
    public class GhostQAExecutor
    {
        private static string _browsername = "chrome";
        private static string _environmentname = "dev";
        private static string _baseurl = "https://mechlintech.dev.clocksession.com/app";
        private static string _basepath = @"D:\MechlinTech\GhostQA-ClockSession\ClockSessionGhostQA\SeleniumReportAPI\wwwroot\";
        private static string _driverpath = @"D:\MechlinTech\GhostQA-ClockSession\ClockSessionGhostQA\SeleniumReportAPI\wwwroot\Driver";
        private static string _ApiUrl = @"https://localhost:44302/api/AddInBuildTestSuite/SaveInBuiltTestSuites";
        public static string JsonData { get; set; }

        public static string browserName
        {
            get => _browsername;
            set => _browsername = value;
        }

        public static string environmentName
        {
            get => _environmentname;
            set => _environmentname = value;
        }

        public static string testCaseName { get; set; }

        public static string Baseurl
        {
            get => _baseurl;
            set => _baseurl = value;
        }

        public static string Basepath
        {
            get => _basepath;
            set => _basepath = value;
        }

        public static string Driverpath
        {
            get => _driverpath;
            set => _driverpath = value;
        }

        public static string APIpath
        {
            get => _ApiUrl;
            set => _ApiUrl = value;
        }

        public static string Testername { get; set; }

        public string ExecuteTestCases(string browsername, string EnvironmentName, string TestCaseName, string baseurl, string basePath, string driverPath, string testerName)
        {
            browserName = browsername;
            environmentName = EnvironmentName;
            testCaseName = TestCaseName;
            Baseurl = baseurl;
            Basepath = basePath;
            Driverpath = driverPath;
            Testername = testerName;

            var bsTest = new BaseTest(); // Instantiate BaseTest using the new keyword to perform Setup and TearDown
            bsTest.SetUp();
            var loginTest = new LoginTest(); // Instantiate LoginTest using the new keyword to perform Test Case Operation

            var method = loginTest.GetType().GetMethod(string.Concat(testCaseName));

            if (method != null)
            {
                method.Invoke(loginTest, null);
            }
            else
            {
                Console.WriteLine($"Method '{testCaseName}' not found.");
            }
            bsTest.TearDownAsync();
            return JsonData;
        }
    }
}