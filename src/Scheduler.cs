

public class Scheduler : IScheduler {
	public Scheduler( IJobCollection jobs ) {
		Jobs = jobs;
	}

	public IJobCollection Jobs { get; }

// Selection sort
public IJob[] FirstComeFirstServed()
{
    IJob[] sortedJobs = Jobs.ToArray();
    for (int i = 0; i < sortedJobs.Length - 1; i++)
    {
        for (int j = i + 1; j < sortedJobs.Length; j++)
        {
            if (sortedJobs[i].TimeReceived > sortedJobs[j].TimeReceived)
            {
                IJob temp = sortedJobs[i];
                sortedJobs[i] = sortedJobs[j];
                sortedJobs[j] = temp;
            }
        }
    }
    return sortedJobs;
}

// Insertion Sort
public IJob[] Priority()
{
    IJob[] sortedJobs = Jobs.ToArray();
    for (int i = 1; i < sortedJobs.Length; i++)
    {
        for (int j = i; j > 0; j--)
        {
            if (sortedJobs[j].Priority < sortedJobs[j - 1].Priority)
            {
                IJob temp = sortedJobs[j];
                sortedJobs[j] = sortedJobs[j - 1];
                sortedJobs[j - 1] = temp;
            }
            else
            {
                break;
            }
        }
    }
    return sortedJobs;
}

// Bubble sort
public IJob[] ShortestJobFirst()
{
    IJob[] sortedJobs = Jobs.ToArray();
    int n = sortedJobs.Length;
    for (int i = 0; i < n - 1; i++)
    {
        for (int j = 0; j < n - i - 1; j++)
        {
            if (sortedJobs[j].ExecutionTime > sortedJobs[j + 1].ExecutionTime)
            {
                IJob temp = sortedJobs[j];
                sortedJobs[j] = sortedJobs[j + 1];
                sortedJobs[j + 1] = temp;
            }
        }
    }
    return sortedJobs;
}

}