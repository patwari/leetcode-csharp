namespace L3169;

/// <summary>
/// https://leetcode.com/problems/count-days-without-meetings/?envType=daily-question&envId=2025-03-24
/// 
/// You are given a positive integer days representing the total number of days an employee is available for work (starting from day 1). You are also given a 2D array meetings of size n where, meetings[i] = [start_i, end_i] represents the starting and ending days of meeting i (inclusive).
/// Return the count of days when the employee is available for work but no meetings are scheduled.
/// 
/// Approach: Interval sort 
/// </summary>
public class Solution {
    public int CountDays(int days, int[][] meetings) {
        List<Pair> dates = new();

        for (int i = 0; i < meetings.Length; ++i) {
            dates.Add(new Pair(meetings[i][0], true));
            dates.Add(new Pair(meetings[i][1], false));
        }

        dates.Sort((Pair a, Pair b) => {
            if (a.date < b.date) return -1;
            if (a.date > b.date) return 1;
            if (a.isStart == b.isStart) return 0;
            if (a.isStart) return -1;
            return 1;
        });

        int prvNoMeetingDate = 1;
        int currMeetingCount = 0;
        int free = 0;
        for (int i = 0; i < dates.Count; ++i) {
            if (dates[i].isStart) {
                if (currMeetingCount == 0) {
                    // new meeting is starting. Account for free days before it
                    free += Math.Max(0, dates[i].date - prvNoMeetingDate);
                }
                ++currMeetingCount;
            } else {
                --currMeetingCount;
                if (currMeetingCount == 0) {
                    prvNoMeetingDate = dates[i].date + 1;
                }
            }
        }

        // add remaining date from last meeting over to end date
        free += Math.Max(0, days + 1 - prvNoMeetingDate);

        // Console.WriteLine(dates[0].date + " :: " + dates[0].isStart );

        return free;
    }

    private class Pair {
        internal int date;
        internal bool isStart;

        internal Pair(int date, bool isStart) {
            this.date = date;
            this.isStart = isStart;
        }
    }
}
