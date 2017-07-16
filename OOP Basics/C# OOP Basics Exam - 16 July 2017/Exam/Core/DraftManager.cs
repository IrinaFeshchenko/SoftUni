using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private double energyStored;
    private double oreMined;
    private List<Harvester> harvesters;
    private List<Provider> providers;
    private List<DraftObject> draftObjects;
    private string mode;

    public DraftManager()
    {
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.draftObjects = new List<DraftObject>();
        this.mode = "Full";
    }

    public string RegisterHarvester(List<string> arguments)
    {
        string result = string.Empty;
        string type = arguments[0];
        string id = arguments[1];

        try
        {
            Harvester harvester = HarvesterFactory.MakeHarvester(arguments);
            this.harvesters.Add(harvester);
            this.draftObjects.Add(harvester);

            result = $"Successfully registered {type} Harvester - {id}";
        }
        catch (Exception e)
        {
            result = $"Harvester is not registered, because of it's {e.Message}";
        }

        return result;
    }
    public string RegisterProvider(List<string> arguments)
    {
        string result = string.Empty;
        string type = arguments[0];
        string id = arguments[1];

        try
        {
            Provider provider = ProviderFactory.MakeProvider(arguments);
            this.providers.Add(provider);
            this.draftObjects.Add(provider);

            result = $"Successfully registered {type} Provider - {id}";
        }
        catch (Exception e)
        {
            result = $"Provider is not registered, because of it's {e.Message}";
        }

        return result;
    }
    public string Day()
    {
        double dayEnergy = GetDaylEnergy();
        this.energyStored += dayEnergy;

        double harvestersRequiredEnergy = GetHarvestersRequiredEnergy();
        double dayOreMined=0;

        if (harvestersRequiredEnergy<=this.energyStored)
        {
            this.energyStored -= harvestersRequiredEnergy;
            dayOreMined = DayOreMined();
            this.oreMined += dayOreMined;
        }

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("A day has passed.")
          .AppendLine($"Energy Provided: {dayEnergy}")
          .AppendLine($"Plumbus Ore Mined: {dayOreMined}");

        return sb.ToString().Trim();
    }

    private double DayOreMined()
    {
        double dayOreMined = harvesters.Sum(h => h.OreOutput);

        if (this.mode == "Full")
        {
            //and produce their FULL ore output
            return dayOreMined;
        }
        else if (this.mode == "Half")
        {
            //produce 50 % of their ore output.
            return dayOreMined * 0.5;
        }
        else if (this.mode == "Energy")
        {
            //They practically do NOT work
            return 0;
        }
        else
        {
            throw new ArgumentException("invalid mode");
        }
    }

    private double GetHarvestersRequiredEnergy()
    {
        double hrvestersRequiredEnergy = harvesters.Sum(h=>h.EnergyRequirement);

        if (this.mode== "Full")
        {
            //All Harvesters consume their FULL energy requirements
            return hrvestersRequiredEnergy;
        }
        else if (this.mode == "Half")
        {
            //All Harvesters consume 60 % of their energy requirements
            return hrvestersRequiredEnergy * 0.6;
        }
        else if (this.mode == "Energy")
        {
            //The Harvesters consume nothing, and produce nothing
            return 0;
        }
        else
        {
            throw new ArgumentException("invalid mode");
        }
    }

    private double GetDaylEnergy()
    {
        double dayEnergy = providers.Sum(p => p.EnergyOutput);
        return dayEnergy;
    }

    public string Mode(List<string> arguments)
    {
        string inputMode = arguments[0];
        if (!(inputMode == "Full" || inputMode == "Half" || inputMode == "Energy"))
        {
            throw new ArgumentException("invalid mode");
        }
        this.mode = inputMode;

        return $"Successfully changed working mode to {this.mode} Mode";
    }
    public string Check(List<string> arguments)
    {
        string id = arguments[0];
        string itemInfo = GetItemInfo(id);

        return itemInfo;
    }

    private string GetItemInfo(string id)
    {
        //if (this.harvesters.Any(h => h.Id == id))
        //{
        //    return harvesters.Where(h => h.Id == id).FirstOrDefault().ToString();
        //}
        //else if (this.providers.Any(h => h.Id == id))
        //{
        //    return providers.Where(h => h.Id == id).FirstOrDefault().ToString();
        //}
        if (this.draftObjects.Any(h => h.Id == id))
        {
            return draftObjects.Where(h => h.Id == id).FirstOrDefault().ToString();
        }
        else
        {
            return $"No element found with id - {id}";
        }
    }

    public string ShutDown()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"System Shutdown")
          .AppendLine($"Total Energy Stored: {this.energyStored}")
          .AppendLine($"Total Mined Plumbus Ore: {this.oreMined}");

        return sb.ToString().Trim();
    }
}
