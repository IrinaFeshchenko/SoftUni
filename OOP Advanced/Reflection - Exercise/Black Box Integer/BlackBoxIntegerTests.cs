namespace _02BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    class BlackBoxIntegerTests
    {
        private const BindingFlags NonPublicFlags = BindingFlags.Instance | BindingFlags.NonPublic;

        static void Main()
        {
            Type blackBoxType = typeof(BlackBoxInt);
            BlackBoxInt myBlackBox = (BlackBoxInt)Activator.CreateInstance(blackBoxType,true);

            //var argTypes = new Type[] { typeof(int) };
            //ConstructorInfo blackBoxCtor = blackBoxType.GetConstructor(BindingFlags.Instance|BindingFlags.NonPublic,null,argTypes,null);
            //var blackBoxInt = (BlackBoxInt)blackBoxCtor.Invoke(new object[]{0});

            //ConstructorInfo blackBoxCtor = blackBoxType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, Type.DefaultBinder, new Type[] { }, null);

            while (true)
            {
                var tokens = Console.ReadLine().Split('_');
                if (tokens[0] == "END") break;

                string methodName = tokens[0];
                int value = int.Parse(tokens[1]);

                blackBoxType.GetMethod(methodName, NonPublicFlags).Invoke(myBlackBox,new object[]{value});

                object innerStateValue = blackBoxType
                                            .GetFields(NonPublicFlags)
                                            .First()
                                            .GetValue(myBlackBox)
                                            .ToString();

                Console.WriteLine(innerStateValue);
            }
        }
    }
}
