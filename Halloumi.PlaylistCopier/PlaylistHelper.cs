using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Halloumi.PlaylistCopier
{
    public static class PlaylistHelper
    {
        /// <summary>
        ///     Gets a list of all files in an M3U playlist
        /// </summary>
        /// <param name="playlistFile">The playlist file.</param>
        /// <returns>A list of file names contained in the playlist</returns>
        public static List<string> GetPlaylistFiles(string playlistFile)
        {
            var files = new List<string>();
            using (var reader = new StreamReader(playlistFile, Encoding.UTF7))
            {
                string currentLine;
                while ((currentLine = reader.ReadLine()) != null)
                {
                    if (currentLine.Length <= 0 || currentLine == "#EXTM3U") continue;

                    if (currentLine.StartsWith("#"))
                        currentLine = reader.ReadLine();
                    if (currentLine == null) continue;


                    string file;
                    if (currentLine.StartsWith(@"\"))
                    {
                        file = Path.GetPathRoot(playlistFile) + currentLine;
                    }
                    else if (currentLine.Contains(":"))
                    {
                        file = currentLine;
                    }
                    else
                    {
                        var directoryName = Path.GetDirectoryName(playlistFile);
                        file = Path.Combine(directoryName + "", currentLine);
                    }

                    file = file.Trim().Replace(@"\\", @"\");

                    if (file != "")
                        files.Add(file);
                }
                reader.Close();
            }
            return files;
        }
    }
}