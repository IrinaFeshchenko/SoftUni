namespace Online_Radio_Database
{
    using Online_Radio_Database.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            int numberOfSongs = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] tokens = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                string songArtist = tokens[0];
                string songName = tokens[1];
                string songTime = tokens[2];

                try
                {
                    Song song = new Song(songArtist, songName, songTime);
                    songs.Add(song);
                    Console.WriteLine("Song added");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine($"Songs added: {songs.Count}");
            TimeSpan songsDuration = new TimeSpan(songs.Sum(s => s.SongDuration.Ticks));
            Console.WriteLine($"Playlist length: {songsDuration.Hours}h {songsDuration.Minutes}m {songsDuration.Seconds}s");
        }
    }
}
