﻿namespace _02.Knights_of_Honor
{
    using System;

            Action<string> printer = x => Console.WriteLine($"Sir {x}");

            foreach (var name in names)
            {
                printer(name);
            }
        }
}