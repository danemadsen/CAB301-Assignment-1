using Xunit;

public class Test
{
    [Fact]
    public void IsValidIDTest()
    {
        for (uint i = 1; i <= 999; i++)
        {
            Assert.True(Job.IsValidId(i));
        }

        Assert.False(Job.IsValidId(0));
        Assert.False(Job.IsValidId(1000));
    }

    [Fact]
    public void IsValidExecutionTimeTest()
    {
        for (uint i = 1; i <= 100; i++)
        {
            Assert.True(Job.IsValidExecutionTime(i));
        }

        Assert.False(Job.IsValidExecutionTime(0));
    }

    [Fact]
    public void IsValidPriorityTest()
    {
        for (uint i = 1; i <= 9; i++)
        {
            Assert.True(Job.IsValidPriority(i));
        }

        Assert.False(Job.IsValidPriority(0));
        Assert.False(Job.IsValidPriority(10));
    }

    [Fact]
    public void IsValidTimeReceivedTest()
    {
        for (uint i = 1; i <= 100; i++)
        {
            Assert.True(Job.IsTimeReceived(i));
        }

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
        IJob[] newJobs = new IJob[9];
        IJobCollection Jobs = new JobCollection((uint) newJobs.Length);
        
        for (uint i = 0; i < newJobs.Length; i++)
        {
            newJobs[i] = new Job(i + 1,(int) i + 1, i + 1, i + 1);
        }

        for (int i = newJobs.Length - 1; i >= 0; i--)
        {
            Jobs.Add(newJobs[i]);
        }

        IScheduler shdlr = new Scheduler(Jobs);
        IJob[] sortedJobs = shdlr.FirstComeFirstServed();
        
        for (uint i = 0; i < newJobs.Length; i++)
        {
            Assert.Equal(newJobs[i], sortedJobs[i]);

            for (uint j = i + 1; j < newJobs.Length; j++)
            {
                Assert.NotEqual(newJobs[i], sortedJobs[j]);
            }
        }

    }

    [Fact]
    public void PriorityTest()
    {
        IJob[] newJobs = new IJob[9];
        IJobCollection Jobs = new JobCollection((uint) newJobs.Length);
        
        for (uint i = 0; i < newJobs.Length; i++)
        {
            newJobs[i] = new Job(i + 1,(int) i + 1, i + 1, i + 1);
        }

        for (int i = newJobs.Length - 1; i >= 0; i--)
        {
            Jobs.Add(newJobs[i]);
        }

        IScheduler shdlr = new Scheduler(Jobs);
        IJob[] sortedJobs = shdlr.Priority();
        
        for (uint i = 0; i < newJobs.Length; i++)
        {
            Assert.Equal(newJobs[i], sortedJobs[i]);

            for (uint j = i + 1; j < newJobs.Length; j++)
            {
                Assert.NotEqual(newJobs[i], sortedJobs[j]);
            }
        }
    }

    [Fact]
    public void ShortestJobFirstTest()
    {
        IJob[] newJobs = new IJob[9];
        IJobCollection Jobs = new JobCollection((uint) newJobs.Length);
        
        for (uint i = 0; i < newJobs.Length; i++)
        {
            newJobs[i] = new Job(i + 1,(int) i + 1, i + 1, i + 1);
        }

        for (int i = newJobs.Length - 1; i >= 0; i--)
        {
            Jobs.Add(newJobs[i]);
        }

        IScheduler shdlr = new Scheduler(Jobs);
        IJob[] sortedJobs = shdlr.ShortestJobFirst();
        
        for (uint i = 0; i < newJobs.Length; i++)
        {
            Assert.Equal(newJobs[i], sortedJobs[i]);

            for (uint j = i + 1; j < newJobs.Length; j++)
            {
                Assert.NotEqual(newJobs[i], sortedJobs[j]);
            }
        }
    }
}