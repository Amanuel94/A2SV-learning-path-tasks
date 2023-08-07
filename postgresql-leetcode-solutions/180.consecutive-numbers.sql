--
-- @lc app=leetcode id=180 lang=mysql
--
-- [180] Consecutive Numbers
--

-- @lc code=start
# Write your MySQL query statement below

SELECT DISTINCT log1.num AS ConsecutiveNums
FROM Logs log1 INNER JOIN Logs log2 INNER JOIN Logs log3
ON log1.id = log2.id-1 AND log2.id = log3.id-1
WHERE log1.num = log2.num AND log2.num = log3.num;
-- @lc code=end

