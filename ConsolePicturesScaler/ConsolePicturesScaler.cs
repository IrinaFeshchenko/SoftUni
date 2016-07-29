using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class ConsolePicturesScaler
{
    private class Dot
    {
        public Dot(char simbol, int count)
        {
            this.simbol = simbol;
            this.count = count;
        }
        public char simbol;
        public int count = 0;
        public int increment = 0;
    }

    private class DotRow:IEnumerable<Dot>
    {
        private List<Dot> dot= new List<Dot>();
        private int count;

        public Dot this[int index]
        {
            get
            {
                return dot[index];
            }
            set
            {
                dot[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
            }
        }

        public void Add(Dot d)
        {
            this.dot.Add(d);
            this.count = 0;
        }

        public IEnumerator<Dot> GetEnumerator()
        {
            foreach (var d in dot)
            {
                yield return d;
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }



    private class ZipDot
    {
        public char simbol;
        public int count;
        public int reminder = 0;
        public int increment;
        public bool ScalerIsBigger = false;
        public string patternType;
    }

    private class ZipRow
    {
        public List<ZipDot> pattern = new List<ZipDot>();
        public string rowType = "static";
        public int count = 0;
    }

    static void Main()
    {
        // original picture and scale
        int scaler1 = 4;
        string pic1 = @"
....************....
...*............*...
..*..............*..
.*................*.
********************
.*................*.
..*..............*..
...*............*...
....*..........*....
.....*........*.....
......*......*......
.......*....*.......
........*..*........
.........**.........
";
        int scaler2 = 7;
        string pic2 = @"
.......*********************.......
......*.....................*......
.....*.......................*.....
....*.........................*....
...*...........................*...
..*.............................*..
.*...............................*.
***********************************
.*...............................*.
..*.............................*..
...*...........................*...
....*.........................*....
.....*.......................*.....
......*.....................*......
.......*...................*.......
........*.................*........
.........*...............*.........
..........*.............*..........
...........*...........*...........
............*.........*............
.............*.......*.............
..............*.....*..............
...............*****...............
";
        //To Do.. 
        //  for compressed dynamic rows dwraw rows While(d0Size > or < count) "count" of dots on the LAS ROW that is the SAME NUMBER on DIFFERENT SCALERS
        //  when checking patterns: if the dot is in the middle of the row allow 2X deviation, to allow for left and right deviation => (dotNew - dotOld<=4) OR dont check deviation ?

        // split pic on string rows
        string[] picture1 = pic1.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        string[] picture2 = pic2.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

        DotRow dr = new DotRow();
        // record the first row and iterate from second, comparing each row pattern with the previous row pattern
        List<DotRow> rows1 = new List<DotRow>();
        rows1.Add(RowPattern(picture1[0]));
        for (int i = 1; i < picture1.Length; i++)
        {
            if (RowHasNewPattern(picture1, i))
            {
                rows1.Add(RowPattern(picture1[i]));            
            }
            else
            {
                rows1[rows1.Count() - 1].Count++;
            }
        }
        Print2(rows1);

        List<DotRow> rows2 = new List<DotRow>();
        for (int i = 1; i < picture2.Length; i++)
        {
            if (RowHasNewPattern(picture2, i))
            {
                rows2.Add(RowPattern(picture2[i]));
            }
            else
            {
                //RowIsDinamic(rows1, i)
            }
        }

        //  List<ZipRow> ZippedRows = new List<ZipRow>();
        //
        //  for (int i = 0; i < rows1.Count; i++)
        //  {
        //      //compress row of patterns using two patterns compare and scalers
        //      ZipRow zRowPattern = CompressRowPattern(rows1[i], rows2[i], scaler1, scaler2);// set proper scaler
        //      ZippedRows.Add(zRowPattern);
        //  }
        //
        //  int scaler = 6;
        //  Print(ZippedRows, scaler);
    }

    private static void Print(List<ZipRow> ZippedRows, int scaler)
    {
        // output
        Console.WriteLine("---------------start------------");
        foreach (var row in ZippedRows)
        {
            foreach (var pattern in row.pattern)
            {
                string simbol = "";

                if (pattern.patternType == "static")
                {
                    simbol = new string(pattern.simbol, pattern.count);
                }
                else if (!pattern.ScalerIsBigger)
                {
                    if (pattern.patternType == "numberMinusScaler")
                    {
                        simbol = new string(pattern.simbol, pattern.count + scaler);
                    }
                    else if (pattern.patternType == "numberDividedByScaler")
                    {
                        simbol = new string(pattern.simbol, (pattern.count * scaler) + pattern.reminder);
                    }
                }
                else if (pattern.ScalerIsBigger)
                {
                    if (pattern.patternType == "scalerMinusNumber")
                    {
                        simbol = new string(pattern.simbol, scaler - pattern.count);
                    }
                    else if (pattern.patternType == "scalerDividedByNumber")
                    {
                        simbol = new string(pattern.simbol, (scaler / pattern.count));
                    }
                }

                Console.Write(simbol);
            }
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("---------------end------------");
    }

    private static void Print2(List<DotRow> rows)
    {
        // output
        Console.WriteLine("---------------start------------");
        foreach (var row in rows)
        {
            foreach (var pattern in row)
            {
                string simbol = new string(pattern.simbol, pattern.count);
                Console.Write(simbol);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine("---------------end------------");
    }

    private static ZipRow CompressRowPattern(List<Dot> rowPattern1, List<Dot> rowPattern2, int scaler1, int scaler2)
    {
        ZipRow zRowPattern = new ZipRow();
        for (int i = 0; i < rowPattern1.Count; i++)
        {
            ZipDot zDot = new ZipDot();
            zDot.simbol = rowPattern1[i].simbol;

            // if pattern is static number
            if (rowPattern1[i].count == rowPattern2[i].count)
            {
                zDot.count = rowPattern1[i].count;
                zDot.patternType = "static";
            }

            // if scaller is smaller than pattern
            else if (rowPattern1[i].count >= scaler1)
            {
                zDot.ScalerIsBigger = false;
                // if pattern is scaler + or - number
                if (rowPattern1[i].count - scaler1 == rowPattern2[i].count - scaler2)
                {
                    zDot.count = rowPattern1[i].count - scaler1;
                    zDot.patternType = "numberMinusScaler";
                }

                // if pattern is scaler * or / by number
                else if (rowPattern1[i].count / scaler1 == rowPattern2[i].count / scaler2)
                {

                    zDot.count = rowPattern1[i].count / scaler1;
                    zDot.patternType = "numberDividedByScaler";

                    if (rowPattern1[i].count % scaler1 == rowPattern2[i].count % scaler2)
                    {
                        zDot.reminder = rowPattern1[i].count % scaler1;
                    }
                    else
                    {
                        throw new Exception("not implemented 1");
                    }
                }
                else
                {
                    throw new Exception("not implemented 2");
                }
            }
            // if scaller is bigger than pattern
            else if (rowPattern1[i].count < scaler1)
            {
                zDot.ScalerIsBigger = true;
                // if pattern is scaler + or - number
                if (scaler1 - rowPattern1[i].count == scaler2 - rowPattern2[i].count)
                {
                    zDot.count = scaler1 - rowPattern1[i].count;
                    zDot.patternType = "scalerMinusNumber";
                }

                // if pattern is scaler * or / by number
                if (scaler1 / rowPattern1[i].count == scaler2 / rowPattern2[i].count)
                {
                    zDot.count = scaler1 / rowPattern1[i].count;
                    zDot.patternType = "scalerDividedByNumber";

                    if (scaler1 % rowPattern1[i].count == scaler2 % rowPattern2[i].count)
                    {
                        zDot.reminder = scaler1 % rowPattern1[i].count;
                    }
                    else
                    {
                        throw new Exception("not implemented x");
                    }
                }
            }

            zRowPattern.pattern.Add(zDot);
        }

        return zRowPattern;
    }

    private static bool RowHasNewPattern(string[] rows, int index)
    {
        bool hasNewPattern = true;

        if (RowPatternsMatch(rows, index, index - 1))
        {
            hasNewPattern = false;
        }

        return hasNewPattern;
    }

    private static bool RowIsChild(string[] rows, int index)
    {
        bool isChild = true;

        if (RowPatternsMatch(rows, index, index - 1))
        {
            isChild = true;
        }
        else
        {
            isChild = false;
        }

        return isChild;
    }

    private static bool RowPatternsMatch(string[] rows, int index1, int index2)
    {
        DotRow row1 = RowPattern(rows[index1]);
        DotRow row2 = RowPattern(rows[index2]);
        bool rowPatternsMatch = true;

        if (row1.Count() != row2.Count())
        {
            return false;
        }

        for (int i = 0; i < row1.Count(); i++)
        {
            if (row1[i].simbol != row2[i].simbol)
            {
                return false;
            }
        }

        for (int i = 0; i < row1.Count(); i++)
        {
            if (Math.Abs(row1[i].count - row2[i].count) > 2)
            {
                return false;
            }
        }

        return rowPatternsMatch;
    }

    private static DotRow RowPattern(string row)
    {
        DotRow rowPattern = new DotRow();
        rowPattern.Add(new Dot(row[0], 1));

        for (int i = 1; i < row.Length; i++)
        {
            if (row[i] == row[i - 1])
            {
                // increase the count if the simbol is the same
                Dot tmp = rowPattern[rowPattern.Count() - 1];
                tmp.count++;
                rowPattern[rowPattern.Count() - 1] = tmp;
            }
            else
            {
                Dot newPattern = new Dot(row[i], 1);
                rowPattern.Add(newPattern);
            }
        }

        return rowPattern;
    }
}