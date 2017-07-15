using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    Dictionary<string, Nation> nations;
    private List<string> warHistoryRecord;

    public NationsBuilder()
    {
        this.nations = new Dictionary<string, Nation>()
        {
            {"Air", new Nation() },
            {"Fire", new Nation() },
            {"Earth", new Nation()},
            {"Water", new Nation()}
        };

        this.warHistoryRecord = new List<string>();
    }

    //type (string), name (string), power (int), secondaryParameter (floating-point number).
    public void AssignBender(List<string> benderArgs)
    {
        string benderType = benderArgs[0];
        Bender currentbender = BenderFactory.MakeBender(benderArgs);
        this.nations[benderType].AddBender(currentbender);
    }

    //type (string), name (string), affinity (int).
    public void AssignMonument(List<string> monumentArgs)
    {
        string monumentType = monumentArgs[0];
        Monument currentMonument = MonumentFactory.MakeMonument(monumentArgs);
        this.nations[monumentType].AddMonument(currentMonument);
    }
    public string GetStatus(string nationsType)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{nationsType} Nation")
            .Append(this.nations[nationsType]);

        return sb.ToString();
    }
    public void IssueWar(string nationsType)
    {
        double victorioutPower = this.nations.Max(kvp=>kvp.Value.GetTotalPower());

        foreach (var nation in nations.Values)
        {
            if (nation.GetTotalPower()!=victorioutPower)
            {
                nation.DeclareDefeat();
            }
        }

        var record = $"War {this.warHistoryRecord.Count+1} issued by {nationsType}";
        this.warHistoryRecord.Add(record);
    }
    public string GetWarsRecord()
    {
        return string.Join(Environment.NewLine, this.warHistoryRecord);
    }
}
