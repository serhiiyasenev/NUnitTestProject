using NLog;
using NUnit.Framework;
using static NUnitProject.Core.WebDriverManager;

namespace NUnitProject.Tests
{

    [Parallelizable(ParallelScope.Self)]
    public class BaseTest
    {
        protected static Logger Logger => LogManager.GetCurrentClassLogger();

        [SetUp]
        public void TestInitialize()
        {
            //Todo some action 
        }

        [TearDown]
        public void TestFinalize()
        {
            CloseDriver();
        }
    }
}
