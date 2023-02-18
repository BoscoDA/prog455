# Week 4 Notes

## Run a Query on multiple Tables

- Try to keep tables small and tidy
- Data is split logically into multiple tables for any single object
	- Example: Student table for basic info, and an Address table to store student's addresses
- Foreign Key in the child table points to the primary key of the parent table
- JOIN command can be used to obtain results from different tables to complement the main table query
	- 2 or more tables
	- INNER: Default. Returns mactching row values in both tables.
	- OUTER: (LEFT or RIGHT) Returns all records from the L or R table with their matched records from the other table. No intersected table.
	- FULL OUTER: Returns records if there is a match in either table.

## INNER JOIN

### Template

```sql
SELECT colum_name(s)
FROM table1
INNER JOIN table2
ON table1.column_name = table2.column_name;
```

### EXAMPLE

```sql
select Student.First_Name, Student.Last_Name, StudentPhone.Phone_Number
from Student
inner joine StudentPhone
on Student.StudentID = StudentPhone.StudentId
```

- Both tables must share a logically lined column. 
	- We can also designate a Foreign Key to the table to control the data integrity.

## LEFT/RIGHT OUTER JOIN

- LEFT refers to the first table in your statement
- RIGHT refers to the second one.
- LEFT OUTER JOIN will give you all the records in your first table + any matching data from your RIGHT table.
	- NULL will be shown on the records from your LEFT table that did not have a match in the RIGHT table.
- RIGHT OUTER JOIN does the exact opposite of LEFT

## Software Development Life Cycle (SDLC)

- The process that governs developing software and hardware components
- Comprised of 7 phases
- Each organization customizes which tasks are achieved during each phase
- Involves: developers, testers, analysts, project managers, project owners, stake holders, and other entites of interest

### Phase 1: Planning

- Requirements gathering done by business analysts from the clients(s)
- Brainstorm with designers and architects to reach a viable high-level vision
- Iterative process as more questions come up after brainstorming
- Epics and inputs/outputs are not solidified yet, but are clear enough

### Phase 2: Defining

- Business Requirements Docs are completed
	- contract between stakeholders and business
- Feasibility study is performed
- Software Requirement Specification is completed
- Steps from design to development are defined
	- MVP: Minnimum Viable Product, minnimum functions needed to get it up and running
- Analysts, Architects, PM, and HR/Finance are involved in this phase
	- how much money and time is going to be needed?

### Phase 3: Design

- Phase 2 documents are approved
- Blueprints (diagrams) are mapped out
- Externalities are identified
- Skillsets are surveyed
- Epics are broken down to user stories
	- Epic -> Feature -> Story
- Decision wheter to us Waterfall or Agile methodology

### Phase 4: Building

- User stories are picked by the dev team
	- brocken down into PBI
- Usually, lots of prototyping is involved, usually done by R&D or Architects
	- POC: proof of concept
- Focus is mainly on producing a MVP
- Longest and most complex phase

### Phase 5: Testing

- Dev and team testing is normmaly completed in the previous phase, but those tests must carry over to this phase
- Test teams (QA or Test Engineers) will check for bugs and runtime errors
- Testing is done against the requirements to make sure the product behaves as intended
- Iterative process which flows back and forth between testers and devs until a stable version is achieved

### Phase 6: Deployment

- Deployment is done by DevOps team
- In a start-up and some privately held companies the devs will act as the DevOps
- In cooperate and publicly traded companies, a dedicated DevOps team must be in place
	- Security comes into play in this stage
	- Devs must not have access to ant UAT or PROD environments
- Security is also tested in this phase (SHOULD BE TESTED IN EVERY PHASE)

### Phase 7: Maintenance

- Optional phase (not really)
- Users reports bugs, and the dev/test teams resolve them and produce minor patches
- There is no major version jump in this phase.
	- Version 1.0 will remain 1.x.x.x.
	- If version 2.x is desired, the SDLC starts all over again
There is no perfect software, otherwise companies go broke!
