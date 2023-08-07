--
-- @lc app=leetcode id=184 lang=mysql
--
-- [184] Department Highest Salary
--

-- @lc code=start
# Write your MySQL query statement below
SELECT Department.name AS Department, 
Empl.name AS Employee, Empl.salary AS Salary
FROM Employee Empl INNER JOIN Department
ON Empl.departmentId = Department.id
WHERE Empl.salary = (
    SELECT MAX(salary) 
    FROM Employee emp 
    WHERE emp.departmentId = Empl.departmentId
);
-- @lc code=end

