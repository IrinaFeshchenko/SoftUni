

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FriendBits
    {
        static void Main()
        {
            uint n = uint.Parse(Console.ReadLine());

            bool[] neibhors = new bool[32];

            for (int i = 1; i < 32; i++)
            {
                if (((n >> i) & 1u) == ((n >> (i - 1)) & 1u))
                {
                    neibhors[i] = true;
                    neibhors[i - 1] = true;
                }
            }

            uint friends = 0, alone = 0;
            int fIndex = 0, aIndex = 0;

            for (int i = 0; i < neibhors.Length; i++)
            {
                if (neibhors[i] == true)
                {
                    friends |= ((n >> i) & 1u)<<fIndex;
                    fIndex++;
                }
                else
                {
                    alone |= ((n >> i) & 1u) << aIndex;
                    aIndex++;
                }
            }
            Console.WriteLine(friends);
            Console.WriteLine(alone);
        }
    }
}
