using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DragRace : Race
{
    public DragRace(int length, string route, int prizePool) 
        : base(length, route, prizePool)
    {
    }

    public override void GetRaceResult()
    {
        throw new NotImplementedException();
    }

    public override void Start()
    {
        winners = this.Participants
                     .OrderByDescending(p => p.Value.GetEnginePerformance())
                     .Take(Constants.WINNERS_COUNT)
                     .Select(w => w.Value)
                     .ToList();
    }

    public override string ToString()
    {

        var winners = this.Participants
                             .OrderByDescending(p => p.Value.GetOveralPerformance())
                             .Take(Constants.WINNERS_COUNT);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        int count = 1;
        foreach (var car in winners.Select(w => w.Value))
        {
            sb.AppendLine($"{count}. {car.Brand} {car.Model} {car.GetEnginePerformance()}PP - ${base.GetPrize(count)}");
            count++;
        }

        return  sb.ToString().Trim();
    }
}
