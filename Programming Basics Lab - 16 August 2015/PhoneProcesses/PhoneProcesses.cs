

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PhoneProcesses
    {
        static void Main()
        {
            string input = Console.ReadLine().Replace("%", "").Trim();
            long charge = long.Parse(input);
            bool inSafeMode = charge <= 15 ? true : false;
            bool phoneIsOff = charge <=0 ? true : false;
            long appsLeft = 0;

            if (!phoneIsOff)
            {
                string command;
                while ((command = Console.ReadLine().Trim()).ToLower() != "end")
                { 
                    if (!inSafeMode)
                    {
                        string[] param = command.Split('_');
                        int appNeed = int.Parse(param[1].Replace("%", ""));
                        charge = charge - appNeed;

                        if (charge<=0)
                        {
                            phoneIsOff = true;
                            break;
                        }
                        else if (charge <= 15)
                        {
                            inSafeMode = true;
                        }
                    }
                    else
                    {
                        appsLeft++;
                    }
                }
            }

            if (phoneIsOff)
            {
                Console.WriteLine("Phone Off");
            }
            else if (inSafeMode)
            {
                Console.WriteLine("Connect charger -> {0}%", charge);
                Console.WriteLine("Programs left -> {0}", appsLeft);
            }
            else
            {
                Console.WriteLine("Successful complete -> {0}%", charge);
            }
        }
    }
}
