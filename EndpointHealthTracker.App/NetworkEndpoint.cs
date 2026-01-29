namespace EndpointHealthTracker;

public class NetworkEndpoint 
{
    public int Id {get;set;}
    public string Name {get;set;}


    public NetworkEndpoint(int id, string name)
    {
        Id = id;
        Name = name;

    }
    
}
