namespace FakeUnitTestProj;

public class FakeTests
{
    public void TestAddition()
    {
        var actual = 2 + 3;
        var expected = 5;

        if (actual != expected)
        {
            throw new Exception();
        }
    }
}