using System;

namespace TrafficLights
{
    public class StartUp
    {
        public static void Main()
        {
            string[] traficLights = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int m = int.Parse(Console.ReadLine());

            for (int n = 1; n <= m; n++)
            {
                for (int i = 0; i < traficLights.Length; i++)
                {
                    var signal = Enum.Parse(typeof(TrafficSignal), traficLights[i]);
                    int lightCount = Enum.GetNames(typeof(TrafficSignal)).Length;

                    var newSignal = (1 + (int)signal) % lightCount;
                    traficLights[i] = ((TrafficSignal)newSignal).ToString();
                }

                Console.WriteLine(string.Join(" ",traficLights));
            }
        }
    }
}
