

public class Scheduler : IScheduler {
	public Scheduler( IJobCollection jobs ) {
		Jobs = jobs;
	}

	public IJobCollection Jobs { get; }

public IJob[] FirstComeFirstServed()
{
    IJob[] sortedJobs = Jobs.ToArray();

    for (int i = 0; i < sortedJobs.Length - 1; i++)
    {
        for (int j = i + 1; j > 0; j--)
        {
            if (sortedJobs[j].TimeReceived < sortedJobs[j - 1].TimeReceived)
            {
                IJob temp = sortedJobs[j];
                sortedJobs[j] = sortedJobs[j - 1];
                sortedJobs[j - 1] = temp;
            }
        }
    }
    return sortedJobs;
}


public IJob[] Priority()
{
    IJob[] sortedJobs = Jobs.ToArray();
    for (int i = 0; i < sortedJobs.Length - 1; i++)
    {
        for (int j = i + 1; j < sortedJobs.Length; j++)
        {
            if (sortedJobs[i].Priority > sortedJobs[j].Priority)
            {
                IJob temp = sortedJobs[i];
                sortedJobs[i] = sortedJobs[j];
                sortedJobs[j] = temp;
            }
        }
    }
    return sortedJobs;
}

public IJob[] ShortestJobFirst()
{
    IJob[] sortedJobs = Jobs.ToArray();
    for (int i = 0; i < sortedJobs.Length - 1; i++)
    {
        for (int j = i + 1; j < sortedJobs.Length; j++)
        {
            if (sortedJobs[i].ExecutionTime > sortedJobs[j].ExecutionTime)
            {
                IJob temp = sortedJobs[i];
                sortedJobs[i] = sortedJobs[j];
                sortedJobs[j] = temp;
            }
        }
    }
    return sortedJobs;
}

}