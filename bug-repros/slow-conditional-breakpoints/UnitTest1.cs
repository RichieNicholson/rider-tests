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
            // 2. Put a regular breakpoint on the "if (tmp == 99999)" line below 
            // 3. Finally change the breakpoint for a conditional breakpoint on (i == 24601)
            if (i == 99999)
            {
                Console.WriteLine("Test");
            }
            // On a i7-4770K @ 3.5GGHz I get the following results for the time taken
            // 1. ~ 0.1ms
            // 2. ~1 s
            // 3. ~3 minutes
        }
    }
}
