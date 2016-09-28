

namespace OfficeStuff
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CompanyStuff
    {
        public Dictionary<string, long> products;

        public CompanyStuff(string companyname)
        {
            products = new Dictionary<string, long>();
            this.CompanyName = companyname;
        }
        public string CompanyName { get; set; }
    }

    public class Start
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            Dictionary<string, CompanyStuff> companiesData = ParseInput(rows);
            PrintOutput(companiesData);
        }

        private static void PrintOutput(Dictionary<string, CompanyStuff> companiesData)
        {
            var orderedData = companiesData.OrderBy(x => x.Key);
            foreach (var item in orderedData)
            {
                CompanyStuff cData = item.Value;
                var data = cData.products.Select(x => x.Key + "-" + x.Value);
                Console.WriteLine($"{cData.CompanyName}: {string.Join(", ",data)}");            
            }
        }

        private static Dictionary<string, CompanyStuff> ParseInput(int rows)
        {
            Dictionary<string, CompanyStuff> companiesData = new Dictionary<string, CompanyStuff>();
            var splitBy = "| -".ToCharArray();

            for (int i = 0; i < rows; i++)
            {
                var args = Console.ReadLine()
                    .Split( splitBy, StringSplitOptions.RemoveEmptyEntries);

                string companyName = args[0];
                long productAmount = long.Parse(args[1]);
                string productName = args[2];

                CompanyStuff companyStuff = new CompanyStuff(companyName);

                if (!companiesData.ContainsKey(companyName))
                {
                    companiesData.Add(companyName, companyStuff);
                }

                if (!companiesData[companyName].products.ContainsKey(productName))
                {
                    companiesData[companyName].products.Add(productName,0);
                }

                companiesData[companyName].products[productName]+= productAmount;
            }

            return companiesData;
        }
    }
}
