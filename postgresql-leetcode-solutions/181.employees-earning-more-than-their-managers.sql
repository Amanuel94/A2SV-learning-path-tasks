--
-- @lc app=leetcode id=181 lang=mysql
--
-- [181] Employees Earning More Than Their Managers
--

-- @lc code=start
# Write your MySQL query statement below
SELECT name as Employee
FROM Employee emp
WHERE NOT isnull(managerId) AND
emp.salary > (SELECT salary FROM Employee manager WHERE manager.id = emp.managerId);

-- @lc code=end

