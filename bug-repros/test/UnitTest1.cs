namespace test;

public class Tests
{
    public readonly ref struct Test(double[] array)
    {
        public readonly ref double A = ref array[0];
    }      
    [Test]
    public void SmallTest2()
    {
        var a = new Test(new double[1]);
        Console.WriteLine(a.A); // breakpoint here, then attempt to access a.A in the debugger console ->   Can not wrap MetadataReferenceType(System.Double&) value
    }

    [Test]
    public void SmallTest4()
    {
        var tmp = new bool[1].AsSpan();
        Console.WriteLine(); // breakpoint here, then run 'tmp[0] = false' in the debugger console -> The method or operation is not implemented.         
    }
    
    [Test]
    public void SmallTest5()
    {
        for (var i = 0; i < 2; i++)
        {
            var tmp = (i, i);
            Console.WriteLine(tmp); // breakpoint here, then  inspect `tmp` in debugger console . then continue and the final output will be twice (0, 0)
        }
    }
}
