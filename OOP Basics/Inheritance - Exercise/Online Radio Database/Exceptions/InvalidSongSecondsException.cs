namespace Online_Radio_Database.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class InvalidSongSecondsException: InvalidSongLengthException
    {
        public const string SongSecondsException = "Song seconds should be between 0 and 59.";

        public override string Message => SongSecondsException;
    }
}
