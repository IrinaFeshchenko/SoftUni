namespace Mordor_s_Cruelty_Plan.Factories
{
    using Mordor_s_Cruelty_Plan.Models;
    using Mordor_s_Cruelty_Plan.Models.Moods;

    public class MoodFactory
    {
        public Mood GetMood(int happinessPoints)
        {
            if (happinessPoints < -5)
            {
                return new Angry();
            }
            if (happinessPoints <= 0)
            {
                return new Sad();
            }
            if (happinessPoints <= 15)
            {
                return new Happy();
            }

            return new JavaScript();
        }
    }
}
