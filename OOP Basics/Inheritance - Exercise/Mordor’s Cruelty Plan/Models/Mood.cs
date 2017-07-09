namespace Mordor_s_Cruelty_Plan.Models
{
    public class Mood
    {
        public Mood(string moodName)
        {
            this.MoodName = moodName;
        }

        public string MoodName { get; set; }

        public override string ToString()
        {
            return this.MoodName;
        }
    }
}
