using System.Diagnostics;

namespace slow_conditional_breakpoints;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SlowConditionalBreakpointTest()
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        for (var i = 0; i < 100000; i++)
        {
            if (i == 24601)
            {
                stopwatch.Stop();
                Console.WriteLine("Time taken to reach this point: " + stopwatch.Elapsed);
            }

            // Try the following and in each case check the "Time taken to reach this point: " output:
            // 1. Run this test without any breakpoints.
            // 2. Put a regular breakpoint on the "Console.WriteLine" line below 
            // 3. Finally put a conditional breakpoint of (i == 24601) on the 'if (i == 99999)' line below
            if (i == 99999)
            {
                Console.WriteLine("Test");
            }
            // I get the following results for the "Time taken to reach this point: " time for these 3 scenarios:
            // 1. < 0.1ms
            // 2. < 0.1ms
            // 3. ~3 minutes
            // This is on a Windows PC with a i7-4770K @ 3.50GHz processor, with .NET10 installed and using Jetbrains Rider 2025.3.3
        }
    }
}
