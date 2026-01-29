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
- Learn post project to Github
