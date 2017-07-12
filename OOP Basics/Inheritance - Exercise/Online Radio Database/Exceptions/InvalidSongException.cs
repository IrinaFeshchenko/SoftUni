namespace Online_Radio_Database.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class InvalidSongException:Exception
    {
        private const string SongExceptionMessage = "Invalid song.";

        public override string Message => SongExceptionMessage;
    }
}
