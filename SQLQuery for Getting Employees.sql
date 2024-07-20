SELECT 
    e.Name AS Employee,
    c.Name AS Course,
    c.Validity,
    c.StartDate,
    ISNULL(ag.AttendanceCount, 0) AS AttendanceCount,
    c.Validity - ISNULL(ag.AttendanceCount, 0) AS Absents,
    CASE 
        WHEN ISNULL(ag.AttendanceCount, 0) < (c.Validity / 2) 
        THEN 'Below Half/Report' 
        ELSE 'Above Half' 
    END AS AttendanceStatus,
	CASE
	when DATEDIFF(day,GETDATE(),c.StartDate)<c.Validity
	Then 'Valid'
	else  'Overdue'
	END AS CourseStatus
FROM Employees e
JOIN Registers r ON e.Id = r.Emp_ID
JOIN Courses c ON r.Course_ID = c.Id
LEFT JOIN (
    SELECT 
        a.Emp_ID, 
        a.Course_ID, 
        COUNT(*) AS AttendanceCount
    FROM [dbo].[Attendences] a
    WHERE a.Course_ID = 'BB934746-D26B-458B-4B44-08DCA4F28958'
    GROUP BY a.Emp_ID, a.Course_ID
) ag ON r.Emp_ID = ag.Emp_ID AND r.Course_ID = ag.Course_ID
WHERE r.Course_ID = 'BB934746-D26B-458B-4B44-08DCA4F28958'
AND c.StartDate = CONVERT(date, '2024-07-10', 23);