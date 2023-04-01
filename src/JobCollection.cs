using System;
using System.Diagnostics;


public class JobCollection : IJobCollection {
	private IJob[] jobs;
	private uint count;

	public JobCollection( uint capacity ) {
		if( !( capacity >= 1 ) ) throw new ArgumentException();
		jobs = new IJob[capacity];
        count = 0;
	}

	public uint Capacity {
		get { return (uint) jobs.Length; }
	}

	public uint Count {
		get { return count; }
	}

	public bool Add( IJob job ) {
        if( Contains( job.Id ) ) return false;
        jobs[count] = job;
        count++;
        return true;
    }

    public bool Contains(uint id) {
        for( int i = 0; i < count; i++ ) {
            if( jobs[i].Id == id ) return true;
        }
        return false;
    }

    public IJob? Find( uint id ) {
        for( int i = 0; i < count; i++ ) {
            if( jobs[i].Id == id ) return jobs[i];
        }
        return null;
    }

    public bool Remove(uint id) {
        for( int i = 0; i < count; i++ ) {
            if( jobs[i].Id == id ) {
                for( int j = i; j < count - 1; j++ ) {
                    jobs[j] = jobs[j + 1];
                }
                count--;
                return true;
            }
        }
        return false;
    }

    public IJob[] ToArray() {
        IJob[] new_array = new IJob[count];
        for( int i = 0; i < count; i++ ) {
            new_array[i] = jobs[i];
        }
        return new_array;
    }
}
