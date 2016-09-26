

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StupidPasswordGenerator
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            for (int s1 = 1; s1 <= n; s1++)
            {
                for (int s2 = 1; s2 <= n; s2++)
                {
                    for (int s3 = 'a'; s3 < l+'a'; s3++)
                    {
                        for (int s4 = 'a'; s4 < l+'a'; s4++)
                        {
                            for (int s5 = (s1>s2?s1:s2)+1; s5 <= n; s5++)
                            {
                                Console.Write("{0}{1}{2}{3}{4} ",s1,s2,(char)s3,(char)s4,s5);
                            }
                        }
                    }
                }
            }
        }
    }
}
