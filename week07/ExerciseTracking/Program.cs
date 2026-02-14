using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>();

        // Create instances of each activity
        activities.Add(new Running(DateTime.Parse("2026-02-10"), 30, 5));          // 5 km run in 30 min
        activities.Add(new Cycling(DateTime.Parse("2026-02-11"), 60, 20));         // 20 km/h cycling for 1 hr
        activities.Add(new Swimming(DateTime.Parse("2026-02-12"), 40, 30));        // 30 laps swimming in 40 min

        // Call GetSummary for each
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
