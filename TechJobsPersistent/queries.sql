--Part 1
--DESCRIBE Jobs;
--Part 2
--SELECT Employers.Name FROM Employers WHERE Employers.Location LIKE '%St. Louise City%';
--Part 3
--SELECT skills.Name, skills.Description FROM skills INNER JOIN jobskills ON skills.Id = jobskills.SkillId INNER JOIN jobs ON jobskills.JobId = jobs.Id ORDER BY skills.Name Asc;

