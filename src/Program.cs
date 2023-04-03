public class Testing
{
    public static void Main()
    {
        IJob[] jobs = new IJob[5];
        jobs[0] = new Job(1, 0, 5, 1);
        jobs[1] = new Job(2, 1, 4, 2);
        jobs[2] = new Job(3, 2, 3, 3);
        jobs[3] = new Job(4, 3, 2, 4);
        jobs[4] = new Job(5, 4, 1, 5);
        IJobCollection jobCollection = new JobCollection((uint) jobs.Length);
        IScheduler scheduler = new Scheduler(jobCollection);
        IJob[] sortedJobs = scheduler.FirstComeFirstServed();
        foreach (IJob job in sortedJobs)
        {
            Console.WriteLine(job);
        }
        Console.WriteLine();
        sortedJobs = scheduler.Priority();
        foreach (IJob job in sortedJobs)
        {
            Console.WriteLine(job);
        }
        Console.WriteLine();
        sortedJobs = scheduler.ShortestJobFirst();
        foreach (IJob job in sortedJobs)
        {
            Console.WriteLine(job);
        }
    }
}