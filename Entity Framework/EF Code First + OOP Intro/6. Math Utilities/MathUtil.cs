namespace _6.Math_Utilities
{
    class MathUtil
    {
        public static double Sum(double num1, double num2)
        {
            return num1 + num2;
        }

        public static double Substract(double num1, double num2)
        {
            return num1 - num2;
        }

        public static double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        public static double Divide(double num1, double num2)
        {
            return num1 / num2;
        }

        public static double Percentage(double num, double percentOf)
        {
            return num * (percentOf/100);
        }
    }
}
