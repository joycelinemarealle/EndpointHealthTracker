using System;
using System.Collections.Generic;
using System.Linq;
namespace EndpointHealthTracker;

public class Program
{
    static void Main (string [] args)
    {
        Console.WriteLine("\nWelcome to the EndPointHealthTracker");
        NetworkEndpoint alphaEndpoint = new NetworkEndpoint(1, "Alpha");
        NetworkEndpoint betaEndpoint = new NetworkEndpoint(2,"Beta");
        NetworkEndpoint gammaEndpoint = new NetworkEndpoint(3,"Gamma");

        Console.WriteLine("Dictionary to store Network Endpoint objects");
        Dictionary<int, NetworkEndpoint> networkEndpoints = new Dictionary<int,NetworkEndpoint>();
        networkEndpoints.Add(1, alphaEndpoint);
        networkEndpoints[2] = betaEndpoint;
        networkEndpoints[3] = gammaEndpoint;
       
        foreach(var endpoint in networkEndpoints.Values)
        {
             Console.WriteLine($"\nNetwork Endpoint Id: {endpoint.Id} and name {endpoint.Name}");
        }
       
         Console.WriteLine("\n.....Add health report to the list.....");
        HealthReport healthyReport1 = new HealthReport(1,false, 5, new DateTime(2025,12,16,16,00,53));
        HealthReport healthyReport2 = new HealthReport(1,true, 1, new DateTime(2026,01,15,12,15,33));
        HealthReport healthyReport3 = new HealthReport(1,true, 0.5, new DateTime(2026,01,26,9,28,23));
        HealthReport healthyReport4 = new HealthReport(2, true, 2, new DateTime(2026,01,31,9,25,15));
        HealthReport healthyReport5 = new HealthReport(2, false, 20, new DateTime(2026,01,30,23,30,01));
        HealthReport healthyReport6 = new HealthReport(3, false, 7, new DateTime(2026,01,29,19,01,48));
        HealthReport healthyReport7 = new HealthReport(3, true, 0.86, new DateTime(2026,01,31,10,47,21));

        //Use Lists more flexible, and need  timeline, order matteers
        List<HealthReport> reports = new List <HealthReport> ();
        //oldest will have gone first
        reports.Add(healthyReport1);
        reports.Add(healthyReport2);
        reports.Add(healthyReport3);
        reports.Add(healthyReport4);
        reports.Add(healthyReport5);
        reports.Add(healthyReport6);
        reports.Add(healthyReport7);  

        foreach(var report in reports)
        {
            Console.WriteLine($"\nReport with Id {report.EndpointId} , latency: {report.LatencyMs} ms is healthy: {report.IsHealthy}");
        }

        Console.WriteLine("\n ........ LINQ..........");
        Console.WriteLine("\n ...METHOD SYNTAX LINQ.... ");
        //Linq
        //create query healthy < 5 ms LatencyMs
        var query = reports.Where(x => x.LatencyMs < 5)
                           .OrderBy(x => x.LatencyMs)  //ascending
                           .ToList();
        
        //executre

        foreach(var report in query)
        {
            Console.WriteLine($" Report with Id:{report.EndpointId} has latency of {report.LatencyMs} ms and healthy condition :{report.IsHealthy}");
        }

        Console.WriteLine("\n ...QUERY SYNTAX LINQ... ");

        /*from s in collections
        where
        order
        select*/
   
        //create query
        //No list if looping once
        // var mostRecent =
        //     from report in reports
        //     orderby report.Timestamp descending
        //     select report;
       
        //to list if reusing, need indexing 
        Console.WriteLine("/n Most recent time stamp");
        var mostRecent= (
           from report in reports
           orderby report.Timestamp descending
           select report
        ).ToList();

        //execute
        foreach(var report in mostRecent)
        {
            Console.WriteLine(report.Timestamp);
        
        }

        Console.WriteLine("\nMost recent:");
        Console.WriteLine(mostRecent[0].Timestamp);



         Console.WriteLine("\n Avg Latency of reports");
        double avgLatency = (
            from report in reports
            select report.LatencyMs
            ).Average();

        
         Console.WriteLine($"Average of Latency: {avgLatency:F2} ms");

         Console.WriteLine("\nUnhealthiestreport");
         double maxLatency = (
            from report in reports
            select report.LatencyMs
            ).Max();

        Console.WriteLine($"Unhealthiest report has latency of {maxLatency} ms");

        Console.WriteLine("\nCount of healthiest reports < 5 ms");
        int countHealthiest = (
            from report in reports
            where report.LatencyMs < 5
            select report.LatencyMs
        ).Count();

        Console.WriteLine($"There are {countHealthiest} report with latency < 5");

        Console.WriteLine("For each EndpointId, what is the average latency");
        var latencyAvgPerEndpoint = 
        from report in reports
        groupby report.EndpointId into endpointGroup
       select new
       {
        AverageLatency = endpointGroup.Average(x=>x.LatencyMs);

       };       


        

        Console.WriteLine("eFor each EndpointId,  the average latency is {latencyAvgPerEndPoint}");



    

    }
}

// //Add reports in collections
        // //orders doestmatter
        // Dictionary <int, HealthReport> reports = new Dictionary<int,HealthReport>() ;
        // reports.Add(healthyReport1);
        // reports.Add(healthyReport2);
        // reports.Add(healthyReport3);
        // //Loop to print out

        
        // foreach(var report in reports)
        // {
        //     Console.WriteLine($"{report.Value.EndpointId}, {report..Value.IsHealthy}," 
        //     "{report.Value.LatencyMs},{report.Value.Timestamp}");
        // }

//Console.WriteLine($"{report.EndpointId}, {report.IsHealthy}, {report.LatencyMs},{report.Timestamp}");