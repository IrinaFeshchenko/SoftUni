namespace _05_Date_Modifier
{
    using System;
    using System.Globalization;

    public class DateModifier
    {
        private int daysDifference { get; set; }

        public void CalculateDatesDifference(string date1, string date2)
        {
            DateTime dateFirst = DateTime.ParseExact(date1, "yyyy MM dd",CultureInfo.InvariantCulture);
            DateTime dateSecond = DateTime.ParseExact(date2, "yyyy MM dd", CultureInfo.InvariantCulture);

            var timeSpan = dateSecond - dateFirst;
            this.daysDifference = Math.Abs(timeSpan.Days);
        }

        public int GetDaysDifference()
        {
            return this.daysDifference;
        }
    }
}
