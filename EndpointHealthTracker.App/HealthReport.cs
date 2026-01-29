namespace EndpointHealthTracker;

public class HealthReport
{
    public int EndpointId{get;set;}
    public bool IsHealthy{get;set;}
    public double LatencyMs{get;set;}
    public DateTime Timestamp{get;set;}

    public HealthReport(int endpointId, bool isHealthy, double latencyMs, DateTime timeStamp)
    {
        EndpointId = endpointId;
        IsHealthy = isHealthy;
        LatencyMs = latencyMs;
        Timestamp = timeStamp;
    }
}