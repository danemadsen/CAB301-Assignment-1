public class Testing
{
    public static void Main()
    {
        Random rnd = new Random();
        IJob[] Jobs = new IJob[9];
        
        // Create 9 valid jobs        
        for( int i = 0; i < Jobs.Length; i++ ) {
            Jobs[i] = new Job((uint) i + 1, (int) rnd.Next(1, 2400), (uint) rnd.Next(1, 2400), (uint) i + 1);       
        }
        
        // Check validity of each Job
        foreach (IJob job in Jobs)
        {
            if( Job.IsValidId(job.Id) ) Console.WriteLine("PASS - JobID: " + job.Id + " is valid");
            else Console.WriteLine("FAIL - JobID: " + job.Id + " is invalid");
            
            if( Job.IsValidExecutionTime(job.ExecutionTime) ) Console.WriteLine("PASS - ExecutionTime: " + job.ExecutionTime + " is valid");
            else Console.WriteLine("FAIL - ExecutionTime: " + job.ExecutionTime + " is invalid");
            
            if( Job.IsValidPriority(job.Priority) ) Console.WriteLine("PASS - Priority: " + job.Priority + " is valid");
            else Console.WriteLine("FAIL - Priority: " + job.Priority + " is invalid");
            
            if( Job.IsTimeReceived((uint) job.TimeReceived) ) Console.WriteLine("PASS - TimeReceived: " + job.TimeReceived + " is valid\n\n");
            else Console.WriteLine("FAIL - TimeReceived: " + job.TimeReceived + " is invalid\n\n");
        }

        // Attempt to create a jobs with invalid parameters
        try
        {
            IJob job = new Job(0, 1, 1, 1);
            Console.WriteLine("FAIL - Valid Job ID");
        }
        catch (System.ArgumentOutOfRangeException)
        {
            Console.WriteLine("PASS - Invalid Job ID (0)");
        }

        try
        {
            IJob job = new Job(1000, 1, 1, 1);
            Console.WriteLine("FAIL - Valid Job ID");
        }
        catch (System.ArgumentOutOfRangeException)
        {
            Console.WriteLine("PASS - Invalid Job ID (1000)");
        }
    }
}