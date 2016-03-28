namespace Halloumi.PlaylistCopier
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.pnlMain = new Halloumi.Common.Windows.Controls.Panel();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.btnPlaylist = new Halloumi.Common.Windows.Controls.FileSelectButton();
            this.txtPlaylist = new Halloumi.Common.Windows.Controls.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnDestinationFolder = new Halloumi.Common.Windows.Controls.FolderSelectButton();
            this.txtDestinationFolder = new Halloumi.Common.Windows.Controls.TextBox();
            this.lblPlaylist = new Halloumi.Common.Windows.Controls.Label();
            this.lblDestinationFolder = new Halloumi.Common.Windows.Controls.Label();
            this.lblPlaylistDetails = new Halloumi.Common.Windows.Controls.Label();
            this.flpButtonsRight = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCopy = new Halloumi.Common.Windows.Controls.Button();
            this.beveledLine = new Halloumi.Common.Windows.Controls.BeveledLine();
            this.pnlButtons = new Halloumi.Common.Windows.Controls.Panel();
            this.progressDialog = new Halloumi.Common.Windows.Components.ProgressDialog(this.components);
            this.pnlMain.SuspendLayout();
            this.tblMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.flpButtonsRight.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonManager
            // 
            this.kryptonManager.GlobalAllowFormChrome = false;
            this.kryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMain.Controls.Add(this.tblMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(442, 180);
            this.pnlMain.Style = Halloumi.Common.Windows.Controls.PanelStyle.Content;
            this.pnlMain.TabIndex = 29;
            // 
            // tblMain
            // 
            this.tblMain.BackColor = System.Drawing.Color.Transparent;
            this.tblMain.ColumnCount = 2;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tblMain.Controls.Add(this.btnPlaylist, 1, 1);
            this.tblMain.Controls.Add(this.btnDestinationFolder, 1, 4);
            this.tblMain.Controls.Add(this.txtPlaylist, 0, 1);
            this.tblMain.Controls.Add(this.txtDestinationFolder, 0, 4);
            this.tblMain.Controls.Add(this.lblPlaylist, 0, 0);
            this.tblMain.Controls.Add(this.lblDestinationFolder, 0, 3);
            this.tblMain.Controls.Add(this.lblPlaylistDetails, 0, 2);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Name = "tblMain";
            this.tblMain.Padding = new System.Windows.Forms.Padding(10);
            this.tblMain.RowCount = 5;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblMain.Size = new System.Drawing.Size(442, 180);
            this.tblMain.TabIndex = 16;
            // 
            // btnPlaylist
            // 
            this.btnPlaylist.AssociatedControl = this.txtPlaylist;
            this.btnPlaylist.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPlaylist.Filter = "Playlist Files (*.m3u)|*.m3u";
            this.btnPlaylist.Location = new System.Drawing.Point(391, 33);
            this.btnPlaylist.Name = "btnPlaylist";
            this.btnPlaylist.Size = new System.Drawing.Size(38, 25);
            this.btnPlaylist.TabIndex = 0;
            this.btnPlaylist.Title = "Open Playlist";
            this.btnPlaylist.Values.Text = "...";
            // 
            // txtPlaylist
            // 
            this.txtPlaylist.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtPlaylist.ErrorMessage = "Please select a playlist";
            this.txtPlaylist.ErrorProvider = this.errorProvider;
            this.txtPlaylist.IsRequired = true;
            this.txtPlaylist.Location = new System.Drawing.Point(13, 33);
            this.txtPlaylist.MaximumValue = 2147483647;
            this.txtPlaylist.MinimumValue = -2147483648;
            this.txtPlaylist.Name = "txtPlaylist";
            this.txtPlaylist.ReadOnly = true;
            this.txtPlaylist.Size = new System.Drawing.Size(372, 20);
            this.txtPlaylist.TabIndex = 2;
            this.txtPlaylist.TabStop = false;
            this.txtPlaylist.CustomValidate += new System.ComponentModel.CancelEventHandler(this.txtPlaylist_CustomValidate);
            this.txtPlaylist.TextChanged += new System.EventHandler(this.txtPlaylist_TextChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // btnDestinationFolder
            // 
            this.btnDestinationFolder.AssociatedControl = this.txtDestinationFolder;
            this.btnDestinationFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDestinationFolder.Location = new System.Drawing.Point(391, 133);
            this.btnDestinationFolder.Name = "btnDestinationFolder";
            this.btnDestinationFolder.Size = new System.Drawing.Size(38, 25);
            this.btnDestinationFolder.TabIndex = 1;
            this.btnDestinationFolder.Title = "Select a destination folder";
            this.btnDestinationFolder.Values.Text = "...";
            // 
            // txtDestinationFolder
            // 
            this.txtDestinationFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDestinationFolder.ErrorMessage = "Please select a destination folder";
            this.txtDestinationFolder.ErrorProvider = this.errorProvider;
            this.txtDestinationFolder.IsRequired = true;
            this.txtDestinationFolder.Location = new System.Drawing.Point(13, 133);
            this.txtDestinationFolder.MaximumValue = 2147483647;
            this.txtDestinationFolder.MinimumValue = -2147483648;
            this.txtDestinationFolder.Name = "txtDestinationFolder";
            this.txtDestinationFolder.ReadOnly = true;
            this.txtDestinationFolder.Size = new System.Drawing.Size(372, 20);
            this.txtDestinationFolder.TabIndex = 3;
            this.txtDestinationFolder.TabStop = false;
            this.txtDestinationFolder.CustomValidate += new System.ComponentModel.CancelEventHandler(this.txtDestinationFolder_CustomValidate);
            // 
            // lblPlaylist
            // 
            this.lblPlaylist.AutoSize = true;
            this.lblPlaylist.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaylist.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPlaylist.Location = new System.Drawing.Point(13, 10);
            this.lblPlaylist.Name = "lblPlaylist";
            this.lblPlaylist.Size = new System.Drawing.Size(70, 15);
            this.lblPlaylist.Style = Halloumi.Common.Windows.Controls.LabelStyle.Caption;
            this.lblPlaylist.TabIndex = 4;
            this.lblPlaylist.Text = "Playlist File:";
            // 
            // lblDestinationFolder
            // 
            this.lblDestinationFolder.AutoSize = true;
            this.lblDestinationFolder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDestinationFolder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDestinationFolder.Location = new System.Drawing.Point(13, 110);
            this.lblDestinationFolder.Name = "lblDestinationFolder";
            this.lblDestinationFolder.Size = new System.Drawing.Size(112, 15);
            this.lblDestinationFolder.Style = Halloumi.Common.Windows.Controls.LabelStyle.Caption;
            this.lblDestinationFolder.TabIndex = 5;
            this.lblDestinationFolder.Text = "Destination Folder:";
            // 
            // lblPlaylistDetails
            // 
            this.lblPlaylistDetails.AutoSize = true;
            this.lblPlaylistDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPlaylistDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaylistDetails.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPlaylistDetails.Location = new System.Drawing.Point(13, 70);
            this.lblPlaylistDetails.Name = "lblPlaylistDetails";
            this.lblPlaylistDetails.Size = new System.Drawing.Size(372, 15);
            this.lblPlaylistDetails.TabIndex = 6;
            this.lblPlaylistDetails.Text = "n files in playlist. n could not be found.";
            // 
            // flpButtonsRight
            // 
            this.flpButtonsRight.BackColor = System.Drawing.Color.Transparent;
            this.flpButtonsRight.Controls.Add(this.btnCopy);
            this.flpButtonsRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpButtonsRight.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpButtonsRight.Location = new System.Drawing.Point(0, 0);
            this.flpButtonsRight.Name = "flpButtonsRight";
            this.flpButtonsRight.Padding = new System.Windows.Forms.Padding(5);
            this.flpButtonsRight.Size = new System.Drawing.Size(442, 43);
            this.flpButtonsRight.TabIndex = 0;
            // 
            // btnCopy
            // 
            this.btnCopy.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnCopy.Location = new System.Drawing.Point(353, 8);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(76, 25);
            this.btnCopy.TabIndex = 6;
            this.btnCopy.Text = "&Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // beveledLine
            // 
            this.beveledLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.beveledLine.Location = new System.Drawing.Point(0, 180);
            this.beveledLine.Name = "beveledLine";
            this.beveledLine.Size = new System.Drawing.Size(442, 2);
            this.beveledLine.TabIndex = 28;
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.SystemColors.Control;
            this.pnlButtons.Controls.Add(this.flpButtonsRight);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 182);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(442, 43);
            this.pnlButtons.Style = Halloumi.Common.Windows.Controls.PanelStyle.ButtonStrip;
            this.pnlButtons.TabIndex = 27;
            // 
            // progressDialog
            // 
            this.progressDialog.Text = "Copying playlist files...";
            this.progressDialog.Title = "Copying playlist files...";
            this.progressDialog.PerformProcessing += new System.EventHandler(this.progressDialog_PerformProcessing);
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnCopy;
            this.AllowFormChrome = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 225);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.beveledLine);
            this.Controls.Add(this.pnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Halloumi : Playlist Copier";
            this.UseApplicationIcon = true;
            this.pnlMain.ResumeLayout(false);
            this.tblMain.ResumeLayout(false);
            this.tblMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.flpButtonsRight.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private Halloumi.Common.Windows.Controls.Panel pnlMain;
        private System.Windows.Forms.FlowLayoutPanel flpButtonsRight;
        private Halloumi.Common.Windows.Controls.Button btnCopy;
        private Halloumi.Common.Windows.Controls.BeveledLine beveledLine;
        private Halloumi.Common.Windows.Controls.Panel pnlButtons;
        private System.Windows.Forms.TableLayoutPanel tblMain;
        private Halloumi.Common.Windows.Controls.FileSelectButton btnPlaylist;
        private Halloumi.Common.Windows.Controls.FolderSelectButton btnDestinationFolder;
        private Halloumi.Common.Windows.Controls.TextBox txtPlaylist;
        private Halloumi.Common.Windows.Controls.TextBox txtDestinationFolder;
        private Halloumi.Common.Windows.Controls.Label lblPlaylist;
        private Halloumi.Common.Windows.Controls.Label lblDestinationFolder;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private Halloumi.Common.Windows.Components.ProgressDialog progressDialog;
        private Halloumi.Common.Windows.Controls.Label lblPlaylistDetails;
    }
}