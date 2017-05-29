namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class ShareAlbumCommand : Command
    {
        // ShareAlbum <albumId> <username> <permission>
        // For example:
        // ShareAlbum 4 dragon321 Owner
        // ShareAlbum 4 dragon11 Viewer
        public override string Execute(string[] data)
        {
            throw new NotImplementedException();
        }
    }
}
