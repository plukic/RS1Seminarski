using System;
using System.IO;

namespace FunctionalTests.Helpers
{
    public static class Helpers
    {
        public static string GetTestFileLocation()
        {
            var currentLocation = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
            const string testFileLocation = "TestStatics/test.png";
            return Path.Combine(currentLocation, testFileLocation);
        }
    }
}
