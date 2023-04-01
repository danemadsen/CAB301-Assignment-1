

public class Scheduler : IScheduler {
	public Scheduler( IJobCollection jobs ) {
		Jobs = jobs;
	}

	public IJobCollection Jobs { get; }

	public IJob[] FirstComeFirstServed() => Jobs.OrderBy(j => j.ArrivalTime).ToArray();

    public IJob[] Priority() => Jobs.OrderBy(j => j.Priority).ToArray();

    public IJob[] ShortestJobFirst() => Jobs.OrderBy(j => j.Duration).ToArray();

}