using Xunit;

public class Test
{
    [Fact]
    public void JobTest()
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

    [Fact]
    public void AddJobTest()
    {
        IJob newJob = new Job(1, 1, 1, 1);
        IJobCollection Jobs = new JobCollection(2);

        Assert.True(Jobs.Add(newJob));
        Assert.False(Jobs.Add(newJob));
    }

    [Fact]
    public void ContainsJobTest()
    {
        IJob newJob = new Job(1, 1, 1, 1);
        IJobCollection Jobs = new JobCollection(2);

        Assert.False(Jobs.Contains(newJob.Id));
        Jobs.Add(newJob);
        Assert.True(Jobs.Contains(newJob.Id));
    }

    [Fact]
    public void FindJobTest()
    {
        IJob newJob = new Job(1, 1, 1, 1);
        IJobCollection Jobs = new JobCollection(2);

        Assert.Null(Jobs.Find(newJob.Id));
        Jobs.Add(newJob);
        Assert.Equal(newJob, Jobs.Find(newJob.Id));
    }

    [Fact]
    public void RemoveJobTest()
    {
        IJob newJob = new Job(1, 1, 1, 1);
        IJobCollection Jobs = new JobCollection(2);

        Assert.False(Jobs.Remove(newJob.Id));
        Jobs.Add(newJob);
        Assert.True(Jobs.Remove(newJob.Id));
    }

    [Fact]
    public void ToArrayTest()
    {
        IJob newJob = new Job(1, 1, 1, 1);
        IJobCollection Jobs = new JobCollection(2);

        Assert.Empty(Jobs.ToArray());
        Jobs.Add(newJob);
        Assert.Single(Jobs.ToArray());
    }

    [Fact]
    public void FirstComeFirstServedTest()
    {
        IJobCollection Jobs = new JobCollection(3);
        IJob newJob = new Job(1, 1, 1, 1);
        IJob newJob2 = new Job(2, 2, 2, 2);
        IJob newJob3 = new Job(3, 3, 3, 3);

        Jobs.Add(newJob3);
        Jobs.Add(newJob2);
        Jobs.Add(newJob);

        IScheduler shdlr = new Scheduler(Jobs);

        Assert.Equal(newJob, shdlr.FirstComeFirstServed()[0]);
    }
}