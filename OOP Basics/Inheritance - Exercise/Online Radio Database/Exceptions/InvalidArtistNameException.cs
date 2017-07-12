namespace Online_Radio_Database.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class InvalidArtistNameException: InvalidSongException
    {
        private const string ArtistNameException = "Artist name should be between 3 and 20 symbols.";

        public override string Message => ArtistNameException;
    }
}
