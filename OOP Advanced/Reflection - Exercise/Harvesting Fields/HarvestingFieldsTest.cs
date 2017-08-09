namespace _01HarestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    class HarvestingFieldsTest
    {
        static void Main()
        {
            Type harvestingFieldsType = typeof(HarvestingFields);

            FieldInfo[] harvestingFields = harvestingFieldsType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo[] gatheredFields = null;

            while (true)
            {
                string requestedAccMod = Console.ReadLine();

                if (requestedAccMod == "public")
                {
                    gatheredFields = harvestingFields.Where(f => f.IsPublic).ToArray();
                }
                else if (requestedAccMod == "private")
                {
                    gatheredFields = harvestingFields.Where(f => f.IsPrivate).ToArray();
                }
                else if (requestedAccMod == "protected")
                {
                    gatheredFields = harvestingFields.Where(f => f.IsFamily).ToArray();
                }
                else if (requestedAccMod == "all")
                {
                    gatheredFields = harvestingFields;
                }
                else if (requestedAccMod == "HARVEST")
                {
                    break;
                }

                string[] result = gatheredFields.Select(f => $"{f.Attributes.ToString().ToLower()} {f.FieldType.Name} {f.Name}").ToArray();

                Console.WriteLine(string.Join(Environment.NewLine, result).Replace("family", "protected"));
            }
        }
    }
}
