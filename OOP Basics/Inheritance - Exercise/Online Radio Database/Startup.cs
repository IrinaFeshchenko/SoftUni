namespace Online_Radio_Database
{
    using Online_Radio_Database.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Online_Radio_Database.Exceptions;


    public class Startup
    {
        static void Main()
        {
            int numberOfSongs = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] tokens = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    string songArtist = tokens[0];
                    string songName = tokens[1];
                    string songTime = tokens[2];

                    string[] time = songTime.Split(':').ToArray();

                    if (!int.TryParse(time[0], out int minutes))
                    {
                        throw new InvalidSongLengthException();
                    }


                    if (!int.TryParse(time[1], out int seconds))
                    {
                        throw new InvalidSongLengthException();
                    }

                    songs.Add(new Song(songArtist, songName, minutes, seconds));
                    Console.WriteLine("Song added.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            int totalDuration = 0;
            foreach (var song in songs)
            { totalDuration += song.Minutes * 60 + song.Seconds; }
            int totalMinutes = totalDuration / 60;
            int totalSeconds = totalDuration % 60;
            int hours = totalMinutes / 60;
            totalMinutes %= 60;

            Console.WriteLine($"Songs added: {songs.Count}");
            Console.WriteLine($"Playlist length: {hours}h {totalMinutes}m {totalSeconds}s");
        }
    }
}
