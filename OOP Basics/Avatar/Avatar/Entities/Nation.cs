using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Nation
{
    private List<Bender> benders;
    private List<Monument> monuments;

    public Nation()
    {
        this.benders = new List<Bender>();
        this.monuments = new List<Monument>();
    }

    public double GetTotalPower()
    {
        int monumentsIncreasePercentage = this.monuments.Sum(m=>m.GetAffinity());
        double totalBendersPower =  this.benders.Sum(b => b.GetPower());
        double totalPowerIncrease = totalBendersPower /
                                    Constants.MAX_PERCENTAGE *
                                    monumentsIncreasePercentage;

        return totalBendersPower + totalPowerIncrease;
    }

    public void AddBender(Bender bender)
    {
        this.benders.Add(bender);
    }

    public void AddMonument(Monument monument)
    {
        this.monuments.Add(monument);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"Benders:");
        if (this.benders.Any())
        {
            sb.AppendLine()
              .AppendLine(string.Join(Environment.NewLine, 
                         this.benders.Select(bender=>$"###{bender}")));
        }
        else
        {
            sb.AppendLine(" None");
        }

        sb.Append("Monuments:");
        if (this.monuments.Any())
        {
            sb.AppendLine()
              .Append(string.Join(Environment.NewLine,
                        this.monuments.Select(monument=>$"###{monument}")));
        }
        else
        {
            sb.Append(" None");
        }

        return sb.ToString();
    }

    public void DeclareDefeat()
    {
        this.benders.Clear();
        this.monuments.Clear();
    }
}
