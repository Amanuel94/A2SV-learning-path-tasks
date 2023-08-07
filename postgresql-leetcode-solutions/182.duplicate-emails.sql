--
-- @lc app=leetcode id=182 lang=mysql
--
-- [182] Duplicate Emails
--

-- @lc code=start
# Write your MySQL query statement below
SELECT email
FROM Person 
GROUP BY email
HAVING Count(email) >=2;
-- @lc code=end

