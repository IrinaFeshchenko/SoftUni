namespace _5.Planck_Constant
{
    public class Calculation
    {
        private const double plank = 6.62606896e-34;
        private const double pi = 3.14159;

        public static double GetReducedPlanckConstant()
        {
            return plank / (2 * pi);
        }
    }
}
