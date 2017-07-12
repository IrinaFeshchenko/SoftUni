namespace Online_Radio_Database.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class InvalidSongMinutesException: InvalidSongLengthException
    {
        public const string SongMinutesException = "Song minutes should be between 0 and 14.";

        public override string Message => SongMinutesException;
    }
}
