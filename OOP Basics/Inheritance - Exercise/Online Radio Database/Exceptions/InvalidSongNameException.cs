namespace Online_Radio_Database.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class InvalidSongNameException: InvalidSongException
    {
        private const string SongNameException = "Song name should be between 3 and 30 symbols.";

        public override string Message => SongNameException;
    }
}
