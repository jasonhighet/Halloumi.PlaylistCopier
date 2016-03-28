using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Halloumi.Common.Helpers;

namespace Halloumi.PlaylistCopier
{
    public static class PlaylistHelper
    {
        /// <summary>
        ///     Gets a list of all files in an M3U playlist
        /// </summary>
        /// <param name="playlistFile">The playlist file.</param>
        /// <returns>A list of file names contained in the playlist</returns>
        public static List<PlaylistEntry> GetPlaylistEntries(string playlistFile)
        {
            var playlistEntries = new List<PlaylistEntry>();
            using (var reader = new StreamReader(playlistFile, Encoding.UTF7))
            {
                string currentLine;
                while ((currentLine = reader.ReadLine()) != null)
                {
                    if (currentLine.Length <= 0 || currentLine == "#EXTM3U") continue;
                    var playlistEntry = new PlaylistEntry();

                    if (currentLine.StartsWith("#"))
                    {
                        var elements = currentLine.Split(',').ToList();
                        if (elements.Count > 0)
                        {
                            elements = currentLine.Substring(currentLine.IndexOf(',') + 1).Split('-').ToList();
                            if (elements.Count == 2)
                            {
                                playlistEntry.Artist = elements[0].Trim();
                                playlistEntry.Title = elements[1].Trim();
                            }
                            else
                            {
                                playlistEntry.Title = string.Join("-", elements.ToArray());
                                playlistEntry.Artist = "";
                            }
                        }
                        currentLine = reader.ReadLine();
                    }

                    if (currentLine == null) continue;

                    string path;
                    if (currentLine.StartsWith(@"\"))
                    {
                        path = Path.GetPathRoot(playlistFile) + currentLine;
                        playlistEntry.Path = path;
                        playlistEntry.Path = playlistEntry.Path.Replace(@"\\", @"\");
                    }
                    else if (currentLine.Contains(":"))
                    {
                        path = currentLine;
                    }
                    else
                    {
                        var directoryName = Path.GetDirectoryName(playlistFile);
                        path = Path.Combine(directoryName + "", currentLine);
                    }

                    var trackDetails = GuessTrackDetailsFromFilename(path.Trim());
                    if (playlistEntry.Title == "") playlistEntry.Title = trackDetails.Title;
                    if (playlistEntry.Artist == "") playlistEntry.Artist = trackDetails.Artist;
                    playlistEntry.Description = trackDetails.Description;

                    playlistEntry.Path = path.Trim();

                    if (playlistEntry.Path != "")
                    {
                        playlistEntries.Add(playlistEntry);
                    }
                }
                reader.Close();
            }
            return playlistEntries;
        }

        /// <summary>
        ///     Guesses the artist and title of a track from its filename.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>A guess at the artist and filename</returns>
        private static TrackDetails GuessTrackDetailsFromFilename(string filename)
        {
            filename = (Path.GetFileNameWithoutExtension(filename) + "").Replace("_", " ").Trim();
            var elements = filename.Split('-').ToList();

            var trackDetails = new TrackDetails
            {
                Artist = "",
                Title = "",
                Description = ""
            };

            if (elements.Count > 3) for (var i = 3; i < elements.Count; i++) elements[2] += "-" + elements[i];

            switch (elements.Count)
            {
                case 1:
                    trackDetails.Title = elements[0].Trim();
                    break;
                case 2:
                    trackDetails.Artist = elements[0].Trim();
                    trackDetails.Title = elements[1].Trim();
                    break;
                case 3:
                    int trackNumber;
                    if (int.TryParse(elements[0], out trackNumber))
                    {
                        trackDetails.Artist = elements[1].Trim();
                        trackDetails.Title = elements[2].Trim();
                    }
                    else
                    {
                        trackDetails.Artist = elements[0].Trim();
                        trackDetails.Title = (elements[1] + "-" + elements[2]).Trim();
                    }
                    break;
            }

            if (trackDetails.Artist.ToLower().StartsWith("various") || trackDetails.Title.Contains("  "))
            {
                trackDetails.Title = trackDetails.Title.Replace("  ", "/");
                elements = trackDetails.Title.Split('/').ToList();
                if (elements.Count == 2)
                {
                    trackDetails.Artist = elements[0].Trim();
                    trackDetails.Title = elements[1].Trim();
                }
            }

            trackDetails.Description = GuessTrackDescription(filename, trackDetails.Artist, trackDetails.Title);

            return trackDetails;
        }

        /// <summary>
        ///     Guesses the track description.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="artist">The artist.</param>
        /// <param name="title">The title.</param>
        /// <returns>The track description</returns>
        public static string GuessTrackDescription(string filename, string artist, string title)
        {
            string description;

            if (artist != "" && title != "")
            {
                description = $"{artist} - {title}";
            }
            else
            {
                description = filename.Trim();

                var regex = new Regex("various artists", RegexOptions.IgnoreCase);
                description = regex.Replace(description, "");

                regex = new Regex("various artist", RegexOptions.IgnoreCase);
                description = regex.Replace(description, "");

                regex = new Regex("various", RegexOptions.IgnoreCase);
                description = regex.Replace(description, "");

                regex = new Regex("[0-9]+", RegexOptions.IgnoreCase);
                description = regex.Replace(description, "");

                description = description.Replace("_", " ");
                description = description.Replace(".", " ");

                description = StringHelper.TitleCase(description.Trim());
            }

            return description;
        }


        /// <summary>
        ///     Represents an entry in a m3u playlist
        /// </summary>
        public class PlaylistEntry
        {
            public PlaylistEntry()
            {
                Path = "";
                Artist = "";
                Title = "";
            }

            public string Path { get; set; }
            public string Artist { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
        }

        /// <summary>
        ///     Track details
        /// </summary>
        private class TrackDetails
        {
            public TrackDetails()
            {
                Artist = "";
                Title = "";
                Description = "";
            }

            public string Title { get; set; }

            public string Artist { get; set; }

            public string Description { get; set; }
        }
    }
}