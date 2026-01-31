# Endpoint Health Tracker — Notes

## To do
- Share on GitHub

## Progress

### Step 1 — Data modeling and basic usage
- Defined core entities: NetworkEndpoint, HealthReport
- Set types and constructors
- Created instances
- Stored reports in a List
- Ordered by time
- Verified everything runs

### Step 2 — LINQ
- Filter unhealthy/healthy reports
- Compute average latency
- Sort by Timestamp (most recent)
- (Optional) Group by endpoint

## Daily log

### Mon 01/26/2026
- Created solution structure: .sln + .App project
- Added csproj to solution
- Built entities: NetworkEndpoint, HealthReport
- Tried Dictionary first (key/value, looping)

### Tue 01/27/2026
- Chose List vs Dictionary
  - List: order matters, timeline
  - Dictionary: quick lookup, registry
- Decision: List fits because reports are a timeline
- Started LINQ queries and debugging

### Wed 01/28/2026
- Fixed LINQ typo: OrderBy not OrderyBy
- Learned two LINQ syntaxes:
  - Method syntax: fluent, common
  - Query syntax: SQL-like, readable
- Learned when to use ToList(): reuse results, indexing, avoid re-running query

### Thur 01/29/2026
- Learn post Vscode. project to Github
- Add gitignore to not track bib, .DSstore and obj

### Fri 01/30/2026
- LINQ query syntax to project numeric values from objects
- Computed aggregates with LINQ: Average(latency), Max(worst latency), Count(healthiest reports)
- Filtering with where before aggregation
- Formatted numeric output -> 2 dp (F2)


### Sat 01/31/2026

- Added two more endpoints (Beta, Gamma) and reports for them
- Dictionary: adding objects, looping through pairs, remembering to use value to access object properties
- GroupBy in LINQ and computing Average → still working through the issue(For each EndpointId, what is the average latency)


### Next steps
groupby,where,OrderBy / OrderByDescending,Average,Count,Max,GroupBy
For each EndpointId, what is the average latency
For each endpoint, what is the max latency spike
For each endpoint, what percent of reports are healthy
For each endpoint, what percent of reports are healthy?
For each endpoint, what is the most recent report and its health