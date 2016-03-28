using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Halloumi.Common.Helpers;
using Halloumi.Common.Windows.Forms;

namespace Halloumi.PlaylistCopier
{
    // ReSharper disable once InconsistentNaming
    public partial class frmMain : BaseForm
    {
        /// <summary>
        ///     Initializes a new instance of the frmMain class.
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
            lblPlaylistDetails.Text = "";
        }

        /// <summary>
        ///     Gets or sets the playlist files.
        /// </summary>
        private List<string> PlaylistFiles { get; set; }

        /// <summary>
        ///     Copies the files.
        /// </summary>
        private void CopyFiles()
        {
            PlaylistFiles = PlaylistHelper.GetPlaylistFiles(txtPlaylist.Text);
            progressDialog.Maximum = PlaylistFiles.Count;
            progressDialog.Start();
        }

        /// <summary>
        ///     Determines whether this form is valid.
        /// </summary>
        /// <returns>
        ///     True if this form is valid; otherwise, false.
        /// </returns>
        private bool IsValid()
        {
            return txtPlaylist.IsValid();
        }

        /// <summary>
        ///     Handles the Click event of the btnCopy control.
        /// </summary>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (IsValid()) CopyFiles();
        }

        /// <summary>
        ///     Handles the CustomValidate event of the txtPlaylist control.
        /// </summary>
        private void txtPlaylist_CustomValidate(object sender, CancelEventArgs e)
        {
            e.Cancel = !File.Exists(txtPlaylist.Text);
        }

        /// <summary>
        ///     Handles the CustomValidate event of the txtDestinationFolder control.
        /// </summary>
        private void txtDestinationFolder_CustomValidate(object sender, CancelEventArgs e)
        {
            e.Cancel = !Directory.Exists(txtDestinationFolder.Text);
        }

        /// <summary>
        ///     Handles the TextChanged event of the txtPlaylist control.
        /// </summary>
        private void txtPlaylist_TextChanged(object sender, EventArgs e)
        {
            var existCount = 0;
            var playlistCount = 0;

            try
            {
                var playlistFiles = PlaylistHelper.GetPlaylistFiles(txtPlaylist.Text);
                playlistCount = playlistFiles.Count();
                existCount = playlistFiles.Count(File.Exists);
            }
            catch
            {
                // ignored
            }

            var nonexistCount = playlistCount - existCount;

            lblPlaylistDetails.Text = $"{playlistCount} files in playlist.";
            if (nonexistCount > 0)
            {
                lblPlaylistDetails.Text += $" {nonexistCount} could not be found.";
            }
        }

        /// <summary>
        ///     Handles the PerformProcessing event of the progressDialog control.
        /// </summary>
        private void progressDialog_PerformProcessing(object sender, EventArgs e)
        {
            var destinationFolder = txtDestinationFolder.Text;

            foreach (var playlistEntry in PlaylistFiles.TakeWhile(playlistEntry => !progressDialog.Cancelled))
            {
                progressDialog.Text = "Copying playlist track " + Path.GetFileName(playlistEntry);
                progressDialog.Details += "Copying playlist track " + Path.GetFileName(playlistEntry) + "...";

                if (playlistEntry == null)
                    continue;

                var destination = Path.Combine(destinationFolder, Path.GetFileName(playlistEntry));

                try
                {
                    FileSystemHelper.Copy(playlistEntry, destination);
                    if (progressDialog.Cancelled) break;
                    if (progressDialog.Cancelled) break;

                    progressDialog.Details += "Done" + Environment.NewLine;
                }
                catch (Exception exception)
                {
                    var message = string.Format("{0}ERROR: Could not copy file '{1}' to '{2}'{0}{3}{0}",
                        Environment.NewLine,
                        Path.GetFileName(playlistEntry),
                        destinationFolder,
                        exception.Message);

                    progressDialog.Details += message;

                    if (File.Exists(destination))
                    {
                        try
                        {
                            File.Delete(destination);
                        }
                        catch
                        {
                            // ignored
                        }
                    }
                }
                progressDialog.Value++;
            }

            progressDialog.Text = "Export completed.";
        }
    }
}