namespace KarateChopKata;


public static class KarateChop
{
    public static int Run(int sought, List<int> soughtIn)
    {
        var start = 0;
        var end = soughtIn.Count - 1;
        var candidate = (start + end) / 2;

        if (sought < soughtIn[start] || sought > soughtIn[end])
        {
            return -1;
        }
        
        while (start <= candidate && candidate <= end)
        {
            if (start == candidate && candidate == end && sought != soughtIn[candidate])
            {
                return -1;
            }
            if (sought == soughtIn[candidate])
            {
                return candidate;
            }

            if (soughtIn[start] <= sought && sought < soughtIn[candidate])
            {
                end = candidate - 1;
                candidate = (start + end) / 2;
            }
            else if (soughtIn[candidate] < sought && sought <= soughtIn[end])
            {
                start = candidate + 1;
                candidate = (start + end) / 2;
            }
        }

        return -1;
    }
}



public class Tests
{
    [Test]
    public void TestSimple1()
    {
        Assert.That(KarateChop.Run(1, [0, 1, 2]), Is.EqualTo(1));
    }

    [Test]
    public void TestSimple0()
    {
        Assert.That(KarateChop.Run(0, [0, 1, 2]), Is.EqualTo(0));
    }

    [Test]
    public void TestSimple2()
    {
        Assert.That(KarateChop.Run(2, [0, 1, 2]), Is.EqualTo(2));
    }

    [Test]
    public void TestGreaterThanLast()
    {
        Assert.That(KarateChop.Run(3, [0, 1, 2]), Is.EqualTo(-1));
    }

    [Test]
    public void TestLessThanFirst()
    {
        Assert.That(KarateChop.Run(-1, [0, 1, 2]), Is.EqualTo(-1));
    }

    [Test]
    public void TestInBetween()
    {
        Assert.That(KarateChop.Run(1, [0, 2, 3]), Is.EqualTo(-1));
    }
}