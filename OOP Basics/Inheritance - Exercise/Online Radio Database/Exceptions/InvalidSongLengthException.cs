namespace Online_Radio_Database.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class InvalidSongLengthException:InvalidSongException
    {
        private const string SongLengthException = "Invalid song length.";

        public override string Message => SongLengthException;
    }
}
