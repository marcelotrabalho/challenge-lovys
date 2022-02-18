# Challenge-lovys

Tech stack Requirements:
·         ASP.NET Core 3.1 
·         C#
Description:
Build an interview calendar API.
There may be two roles that use this API, a candidate and an interviewer, each role should be able to define their request and availability time slot respectively.
A typical scenario is when:
- An interview slot is a 1-hour period of time that spreads from the beginning of any hour until the beginning of the next hour. For example, a time span between 9am and 10am is a valid interview slot, whereas between 9:30am and 10:30am is not.
  
- Each of the interviewers sets their availability slots. For example, the interviewer Mary is available next week each day from 9am through 4pm without breaks and the interviewer Diana is available from 12pm to 6pm on Monday and Wednesday next week, and from 9am to 12pm on Tuesday and Thursday.
 
- Each of the candidates sets their requested slots for the interview. For example, the candidate John is available for the interview from 9am to 10am any weekday next week and from 10am to 12pm on Wednesday.
 
- Anyone may then query the API to get a collection of periods of time when it’s possible to arrange an interview for a particular candidate and one or more interviewers. In this example, if the API queries for the candidate John and interviewers Mary and Diana, the response should be a collection of 1-hour slots: from 9am to 10am on Tuesday, from 9am to 10am on Thursday.


## Solution
This solution is using the *Entity framework in memory*, so, There are endpoints to load schedule of the Interviewers and Candidate. <br>
There is 4 endpoints:<br>
execution order:<br>
1 - *POST* - https://localhost:44344/schedule/interviewer/create
    This endpoint is the firs step of the solution. To create the schedule of the Interviewer.
    <br>Example
