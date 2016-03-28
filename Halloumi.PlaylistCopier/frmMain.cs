using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halloumi.Common.Windows.Forms;
using System.IO;
using Halloumi.Common.Helpers;

namespace Halloumi.PlaylistCopier
{
    public partial class frmMain : BaseForm
    {
        /// <summary>
        /// Gets or sets the playlist files.
        /// </summary>
        private List<PlaylistHelper.PlaylistEntry> PlaylistEntries { get; set; }

        /// <summary>
        /// Initializes a new instance of the frmMain class.
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
            lblPlaylistDetails.Text = "";
        }

        /// <summary>
        /// Copies the files.
        /// </summary>
        private void CopyFiles()
        {
            this.PlaylistEntries = PlaylistHelper.GetPlaylistEntries(txtPlaylist.Text);
            progressDialog.Maximum = this.PlaylistEntries.Count;
            progressDialog.Start();
        }

        /// <summary>
        /// Determines whether this form is valid.
        /// </summary>
        /// <returns>True if this form is valid; otherwise, false.
        /// </returns>
        private bool IsValid()
        {
            var valid = true;

            if (!txtPlaylist.IsValid()) valid = false;
            if (!txtDestinationFolder.IsValid()) valid = false;

            return valid;
        }

        /// <summary>
        /// Handles the Click event of the btnCopy control.
        /// </summary>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (IsValid()) CopyFiles();
        }

        /// <summary>
        /// Handles the CustomValidate event of the txtPlaylist control.
        /// </summary>
        private void txtPlaylist_CustomValidate(object sender, CancelEventArgs e)
        {
            e.Cancel = !File.Exists(txtPlaylist.Text);
        }

        /// <summary>
        /// Handles the CustomValidate event of the txtDestinationFolder control.
        /// </summary>
        private void txtDestinationFolder_CustomValidate(object sender, CancelEventArgs e)
        {
            e.Cancel = !Directory.Exists(txtDestinationFolder.Text);
        }

        /// <summary>
        /// Handles the TextChanged event of the txtPlaylist control.
        /// </summary>
        private void txtPlaylist_TextChanged(object sender, EventArgs e)
        {
            var existCount = 0;
            var playlistCount = 0;

            try
            {
                var playlistEntries = PlaylistHelper.GetPlaylistEntries(txtPlaylist.Text);
                playlistCount = playlistEntries.Count();
                existCount = playlistEntries.Count(plf => File.Exists(plf.Path));
            }
            catch 
            { }

            var nonexistCount = playlistCount - existCount;

            lblPlaylistDetails.Text = string.Format("{0} files in playlist.", playlistCount);
            if(nonexistCount > 0)
            {
                lblPlaylistDetails.Text+= string.Format(" {0} could not be found.", nonexistCount);
            }
        }

        /// <summary>
        /// Handles the PerformProcessing event of the progressDialog control.
        /// </summary>
        private void progressDialog_PerformProcessing(object sender, EventArgs e)
        {
            var destinationFolder = txtDestinationFolder.Text;

            foreach (var playlistEntry in this.PlaylistEntries)
            {
                if (progressDialog.Cancelled) break;

                progressDialog.Text = "Copying playlist track " + playlistEntry.Description;
                progressDialog.Details += "Copying playlist track " + playlistEntry.Description + "...";

                var destination = Path.Combine(destinationFolder, Path.GetFileName(playlistEntry.Path));
                try
                {
                    FileSystemHelper.Copy(playlistEntry.Path, destination);
                    if (progressDialog.Cancelled) break;
                    if (progressDialog.Cancelled) break;

                    progressDialog.Details += "Done" + Environment.NewLine;
                }
                catch (Exception exception)
                {
                    string message = String.Format("{0}ERROR: Could not copy file '{1}' to '{2}'{0}{3}{0}",
                        Environment.NewLine,
                        Path.GetFileName(playlistEntry.Path),
                        destinationFolder,
                        exception.Message);
                    progressDialog.Details += message;

                    if (File.Exists(destination))
                    {
                        try { File.Delete(destination); }
                        catch { }
                    }
                }
                progressDialog.Value++;
            }

            progressDialog.Text = "Export completed.";
        }
    }
}
