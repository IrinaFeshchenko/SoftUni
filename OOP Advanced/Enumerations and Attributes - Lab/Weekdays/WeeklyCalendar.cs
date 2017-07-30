using System;
using System.Collections.Generic;

public class WeeklyCalendar
{
    private IList<WeeklyEntry> data;

    public WeeklyCalendar()
    {
        this.data = new List<WeeklyEntry>();
    }

    public IEnumerable<WeeklyEntry> WeeklySchedule => this.data;

    public void AddEntry(string weekday, string notes)
    {
        var entry = new WeeklyEntry(weekday, notes);
        this.data.Add(entry);
    }
}