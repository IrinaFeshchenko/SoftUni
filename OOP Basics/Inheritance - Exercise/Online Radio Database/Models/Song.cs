namespace Online_Radio_Database.Models
{
    using System;
    using System.Globalization;
    using System.Linq;

    public class Song
    {
        private string artistName;
        private string songName;
        private TimeSpan songDuration;

        public Song(string songName, string artistName, string duration)
        {
            this.ArtistName = artistName;
            this.SongName = songName;
            this.SongDuration = ParseDuration(duration);
        }

        public TimeSpan SongDuration
        {
            get { return songDuration; }
            set
            {
                songDuration = value;
            }
        }

        public string SongName
        {
            get { return songName; }
            set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new ArgumentException("Song name should be between 3 and 30 symbols.");
                }
                songName = value;
            }
        }

        public string ArtistName
        {
            get { return artistName; }
            set
            {
                if (value.Length<3||value.Length>20)
                {
                    throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
                }
                artistName = value;
            }
        }

        private TimeSpan ParseDuration(string duration)
        {
            int[] tokens = duration.Split(':').Select(int.Parse).ToArray();
            int minutes = tokens[0];
            int seconds = tokens[1];

            if (minutes<0|| minutes>14)
            {
                throw new ArgumentException("Song minutes should be between 0 and 14.");
            }

            if (seconds < 0 || seconds > 59)
            {
                throw new ArgumentException("Song seconds should be between 0 and 59.");
            }

            if (minutes < 0 || seconds < 0 || (minutes > 14 || seconds > 59))
            {
                throw new ArgumentException("Invalid song.");
            }

            return TimeSpan.ParseExact(duration, "m\\:s", CultureInfo.InvariantCulture);
        }
    }
}
