using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using NUnit.Framework;

namespace TestProject;

[SetUpFixture]
public class SetupClass
{
    [OneTimeSetUp]
    public void SetupMethod()
    {
        BasicConfigurator.Configure(LogManager.GetRepository(GetType().Assembly));
    }
}

public static class TestClass
{
    // Run this test a few times in debug mode without any breakpoints.
    // Around ~50% it crashes with a "System.IndexOutOfRangeException exception" and terminates the debug session
    // The rest of the time it (correctly) hits a IndexOutOfRangeException within the debug session
    [Test]
    public static void TestMethod()
    {
        double[] a = [];
        Parallel.ForEach(Enumerable.Range(0, 10), _ =>
        {
            Thread.Sleep(100);
            Console.WriteLine(a[1]);
        });
    }
}
