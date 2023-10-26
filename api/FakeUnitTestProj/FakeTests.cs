namespace FakeUnitTestProj;

public class FakeTests
{
    public void TestAddition()
    {
        var actual = 2 + 3;
        var expected = 5;

        // add some comment as a fix after merge
        
        if (actual != expected)
        {
            throw new Exception();
        }
    }

    public void TestSubtraction()
    {
        var actual = 2 - 3;
        var expected = -1;
        
        if (actual != expected)
        {
            throw new Exception();
        }
    }
}