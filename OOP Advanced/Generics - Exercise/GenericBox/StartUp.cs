namespace GenericBox
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        // zad 2
        //public static void Main()
        //{
        //    var numberOfLines = int.Parse(Console.ReadLine());

        //    for (int i = 0; i < numberOfLines; i++)
        //    {
        //        var box = new Box<string>(Console.ReadLine());//zad 2
        //        Console.WriteLine(box.ToString());
        //    }
        //}

        //zad 3
        //public static void Main()
        //{
        //    var numberOfLines = int.Parse(Console.ReadLine());

        //    for (int i = 0; i < numberOfLines; i++)
        //    {
        //        var box = new Box<int>(int.Parse(Console.ReadLine()));
        //        Console.WriteLine(box.ToString());
        //    }
        //}

        //zad 4
        //public static void Main()
        //{
        //    var numberOfLines = int.Parse(Console.ReadLine());
        //    IList<Box<string>> listOfBoxes = new List<Box<string>>();
        //    for (int i = 0; i < numberOfLines; i++)
        //    {
        //        Box<string> boxStr = new Box<string>(Console.ReadLine());
        //        listOfBoxes.Add(boxStr);
        //    }

        //    var indexes = Console.ReadLine().Split(' ')
        //                                    .Select(int.Parse)
        //                                    .ToArray();

        //    SwapElements(listOfBoxes, indexes[0], indexes[1]);

        //    foreach (var box in listOfBoxes)
        //    {
        //        Console.WriteLine(box);
        //    }
        //}

        //private static void SwapElements<T>(IList<T> listOfBoxes, int first, int second)
        //{
        //    var tempBox = listOfBoxes[first];
        //    listOfBoxes[first] = listOfBoxes[second];
        //    listOfBoxes[second] = tempBox;
        //}

        //zad 5
        //public static void Main()
        //{
        //    var numberOfLines = int.Parse(Console.ReadLine());
        //    IList<Box<int>> listOfBoxes = new List<Box<int>>();
        //    for (int i = 0; i < numberOfLines; i++)
        //    {
        //        Box<int> boxStr = new Box<int>(int.Parse(Console.ReadLine()));
        //        listOfBoxes.Add(boxStr);
        //    }

        //    var indexes = Console.ReadLine().Split(' ')
        //                                    .Select(int.Parse)
        //                                    .ToArray();

        //    SwapElements(listOfBoxes, indexes[0], indexes[1]);

        //    foreach (var box in listOfBoxes)
        //    {
        //        Console.WriteLine(box);
        //    }
        //}

        //private static void SwapElements<T>(IList<T> listOfBoxes, int first, int second)
        //{
        //    var tempBox = listOfBoxes[first];
        //    listOfBoxes[first] = listOfBoxes[second];
        //    listOfBoxes[second] = tempBox;
        //}

        //zad 6
        public static void Main()
        {
            var numberOfLines = int.Parse(Console.ReadLine());
            IList<Box<double>> listOfBoxes = new List<Box<double>>();

            for (int i = 0; i < numberOfLines; i++)
            {
                Box<double> boxStr = new Box<double>(double.Parse(Console.ReadLine()));
                listOfBoxes.Add(boxStr);
            }

            double input = double.Parse(Console.ReadLine());

            var result = GetGreaterElements(listOfBoxes, input);

            Console.WriteLine(result);
        }

        private static int GetGreaterElements<T>(IList<Box<T>> listOfBoxes, T element) where T: IComparable<T>
        {
            return listOfBoxes.Count(b=>b.Value.CompareTo(element)>0);
        }
    }
}