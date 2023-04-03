using Xunit;

public class testClass
{
    [Fact]
    public void ValidIDTest()
    {
        for (uint i = 1; i <= 999; i++)
        {
            Assert.True(Job.IsValidId(i));
        }
    }

    [Fact]
    public void InvalidIDTest()
    {
        Assert.False(Job.IsValidId(0));
        Assert.False(Job.IsValidId(1000));
    }

    [Fact]
    public void ValidExecutionTimeTest()
    {
        for (uint i = 1; i <= 100; i++)
        {
            Assert.True(Job.IsValidExecutionTime(i));
        }
    }

    [Fact]
    public void InvalidExecutionTimeTest()
    {
        Assert.False(Job.IsValidExecutionTime(0));
    }

    [Fact]
    public void ValidPriorityTest()
    {
        for (uint i = 1; i <= 9; i++)
        {
            Assert.True(Job.IsValidPriority(i));
        }
    }

    [Fact]
    public void InvalidPriorityTest()
    {
        Assert.False(Job.IsValidPriority(0));
        Assert.False(Job.IsValidPriority(10));
    }

    [Fact]
    public void ValidTimeReceivedTest()
    {
        for (uint i = 1; i <= 100; i++)
        {
            Assert.True(Job.IsTimeReceived(i));
        }
    }

    [Fact]
    public void InvalidTimeReceivedTest()
    {
        Assert.False(Job.IsTimeReceived(0));
    }
    
}