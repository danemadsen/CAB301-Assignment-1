

public class Scheduler : IScheduler {
	public Scheduler( IJobCollection jobs ) {
		Jobs = jobs;
	}

	public IJobCollection Jobs { get; }

public IJob[] FirstComeFirstServed()
{
    IJob[] sortedJobs = new IJob[Jobs.Length];
    Array.Copy(Jobs, sortedJobs, Jobs.Length);
    for (int i = 0; i < sortedJobs.Length - 1; i++)
    {
        for (int j = i + 1; j < sortedJobs.Length; j++)
        {
            if (sortedJobs[i].ArrivalTime > sortedJobs[j].ArrivalTime)
            {
                IJob temp = sortedJobs[i];
                sortedJobs[i] = sortedJobs[j];
                sortedJobs[j] = temp;
            }
        }
    }
    return sortedJobs;
}

public IJob[] Priority()
{
    IJob[] sortedJobs = new IJob[Jobs.Length];
    Array.Copy(Jobs, sortedJobs, Jobs.Length);
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
    IJob[] sortedJobs = new IJob[Jobs.Length];
    Array.Copy(Jobs, sortedJobs, Jobs.Length);
    for (int i = 0; i < sortedJobs.Length - 1; i++)
    {
        for (int j = i + 1; j < sortedJobs.Length; j++)
        {
            if (sortedJobs[i].Duration > sortedJobs[j].Duration)
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