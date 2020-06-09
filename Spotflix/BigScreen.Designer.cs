namespace Spotflix
{
    partial class BigScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BigScreen));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ReproductionButtomstableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SmallScreen = new System.Windows.Forms.Button();
            this.PlayPausaButtom = new System.Windows.Forms.Button();
            this.BackPlayer = new System.Windows.Forms.Button();
            this.NextPlay = new System.Windows.Forms.Button();
            this.BigSound = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BigPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.karaokeText = new System.Windows.Forms.RichTextBox();
            this.NextSong = new System.Windows.Forms.Timer(this.components);
            this.CurrentSong = new System.Windows.Forms.Timer(this.components);
            this.KaraokeTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.ReproductionButtomstableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BigSound)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BigPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.progressBar1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ReproductionButtomstableLayoutPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1200, 692);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar1.ForeColor = System.Drawing.Color.DimGray;
            this.progressBar1.Location = new System.Drawing.Point(4, 627);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1192, 2);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 13;
            // 
            // ReproductionButtomstableLayoutPanel
            // 
            this.ReproductionButtomstableLayoutPanel.ColumnCount = 12;
            this.ReproductionButtomstableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.513449F));
            this.ReproductionButtomstableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.51345F));
            this.ReproductionButtomstableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.51345F));
            this.ReproductionButtomstableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.51345F));
            this.ReproductionButtomstableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.51345F));
            this.ReproductionButtomstableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.79707F));
            this.ReproductionButtomstableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.51345F));
            this.ReproductionButtomstableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.51345F));
            this.ReproductionButtomstableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.51345F));
            this.ReproductionButtomstableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.33742F));
            this.ReproductionButtomstableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.51345F));
            this.ReproductionButtomstableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.24445F));
            this.ReproductionButtomstableLayoutPanel.Controls.Add(this.SmallScreen, 10, 0);
            this.ReproductionButtomstableLayoutPanel.Controls.Add(this.PlayPausaButtom, 7, 0);
            this.ReproductionButtomstableLayoutPanel.Controls.Add(this.BackPlayer, 6, 0);
            this.ReproductionButtomstableLayoutPanel.Controls.Add(this.NextPlay, 8, 0);
            this.ReproductionButtomstableLayoutPanel.Controls.Add(this.BigSound, 11, 0);
            this.ReproductionButtomstableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReproductionButtomstableLayoutPanel.Location = new System.Drawing.Point(4, 558);
            this.ReproductionButtomstableLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ReproductionButtomstableLayoutPanel.Name = "ReproductionButtomstableLayoutPanel";
            this.ReproductionButtomstableLayoutPanel.RowCount = 1;
            this.ReproductionButtomstableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ReproductionButtomstableLayoutPanel.Size = new System.Drawing.Size(1192, 59);
            this.ReproductionButtomstableLayoutPanel.TabIndex = 3;
            // 
            // SmallScreen
            // 
            this.SmallScreen.BackColor = System.Drawing.Color.Transparent;
            this.SmallScreen.BackgroundImage = global::Spotflix.Properties.Resources.full_screen;
            this.SmallScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SmallScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SmallScreen.FlatAppearance.BorderSize = 0;
            this.SmallScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SmallScreen.Location = new System.Drawing.Point(964, 3);
            this.SmallScreen.Name = "SmallScreen";
            this.SmallScreen.Size = new System.Drawing.Size(47, 53);
            this.SmallScreen.TabIndex = 10;
            this.SmallScreen.Tag = "full";
            this.SmallScreen.UseVisualStyleBackColor = false;
            this.SmallScreen.Click += new System.EventHandler(this.SmallScreen_Click);
            // 
            // PlayPausaButtom
            // 
            this.PlayPausaButtom.BackColor = System.Drawing.Color.Transparent;
            this.PlayPausaButtom.BackgroundImage = global::Spotflix.Properties.Resources.pausa140;
            this.PlayPausaButtom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PlayPausaButtom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayPausaButtom.FlatAppearance.BorderSize = 0;
            this.PlayPausaButtom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayPausaButtom.Location = new System.Drawing.Point(509, 3);
            this.PlayPausaButtom.Name = "PlayPausaButtom";
            this.PlayPausaButtom.Size = new System.Drawing.Size(47, 53);
            this.PlayPausaButtom.TabIndex = 9;
            this.PlayPausaButtom.Tag = "pause";
            this.PlayPausaButtom.UseVisualStyleBackColor = false;
            this.PlayPausaButtom.Click += new System.EventHandler(this.PlayPausaButtom_Click);
            // 
            // BackPlayer
            // 
            this.BackPlayer.BackColor = System.Drawing.Color.Transparent;
            this.BackPlayer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BackPlayer.BackgroundImage")));
            this.BackPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BackPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackPlayer.FlatAppearance.BorderSize = 0;
            this.BackPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackPlayer.Location = new System.Drawing.Point(456, 3);
            this.BackPlayer.Name = "BackPlayer";
            this.BackPlayer.Size = new System.Drawing.Size(47, 53);
            this.BackPlayer.TabIndex = 7;
            this.BackPlayer.UseVisualStyleBackColor = false;
            this.BackPlayer.Click += new System.EventHandler(this.BackPlayer_Click);
            // 
            // NextPlay
            // 
            this.NextPlay.BackColor = System.Drawing.Color.Transparent;
            this.NextPlay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("NextPlay.BackgroundImage")));
            this.NextPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.NextPlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NextPlay.FlatAppearance.BorderSize = 0;
            this.NextPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextPlay.Location = new System.Drawing.Point(562, 3);
            this.NextPlay.Name = "NextPlay";
            this.NextPlay.Size = new System.Drawing.Size(47, 53);
            this.NextPlay.TabIndex = 8;
            this.NextPlay.UseVisualStyleBackColor = false;
            this.NextPlay.Click += new System.EventHandler(this.NextPlay_Click);
            // 
            // BigSound
            // 
            this.BigSound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BigSound.Location = new System.Drawing.Point(1018, 5);
            this.BigSound.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BigSound.Maximum = 100;
            this.BigSound.Name = "BigSound";
            this.BigSound.Size = new System.Drawing.Size(170, 49);
            this.BigSound.TabIndex = 11;
            this.BigSound.Value = 20;
            this.BigSound.Scroll += new System.EventHandler(this.BigSound_Scroll);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BigPlayer);
            this.panel1.Controls.Add(this.karaokeText);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1192, 543);
            this.panel1.TabIndex = 12;
            // 
            // BigPlayer
            // 
            this.BigPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BigPlayer.Enabled = true;
            this.BigPlayer.Location = new System.Drawing.Point(0, 0);
            this.BigPlayer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BigPlayer.Name = "BigPlayer";
            this.BigPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("BigPlayer.OcxState")));
            this.BigPlayer.Size = new System.Drawing.Size(1192, 431);
            this.BigPlayer.TabIndex = 0;
            this.BigPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.BigPlayer_PlayStateChange);
            // 
            // karaokeText
            // 
            this.karaokeText.BackColor = System.Drawing.Color.Black;
            this.karaokeText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.karaokeText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.karaokeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.karaokeText.ForeColor = System.Drawing.Color.White;
            this.karaokeText.Location = new System.Drawing.Point(0, 431);
            this.karaokeText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.karaokeText.Name = "karaokeText";
            this.karaokeText.ReadOnly = true;
            this.karaokeText.Size = new System.Drawing.Size(1192, 112);
            this.karaokeText.TabIndex = 4;
            this.karaokeText.Text = "";
            // 
            // NextSong
            // 
            this.NextSong.Interval = 1000;
            this.NextSong.Tick += new System.EventHandler(this.NextSong_Tick);
            // 
            // CurrentSong
            // 
            this.CurrentSong.Interval = 1000;
            this.CurrentSong.Tick += new System.EventHandler(this.CurrentSong_Tick);
            // 
            // KaraokeTimer
            // 
            this.KaraokeTimer.Interval = 1000;
            this.KaraokeTimer.Tick += new System.EventHandler(this.KaraokeTimer_Tick);
            // 
            // BigScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BigScreen";
            this.Text = "BigScreen";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ReproductionButtomstableLayoutPanel.ResumeLayout(false);
            this.ReproductionButtomstableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BigSound)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BigPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private AxWMPLib.AxWindowsMediaPlayer BigPlayer;
        private System.Windows.Forms.TableLayoutPanel ReproductionButtomstableLayoutPanel;
        private System.Windows.Forms.Button SmallScreen;
        private System.Windows.Forms.Button PlayPausaButtom;
        private System.Windows.Forms.Button BackPlayer;
        private System.Windows.Forms.Button NextPlay;
        private System.Windows.Forms.TrackBar BigSound;
        private System.Windows.Forms.Timer NextSong;
        private System.Windows.Forms.Timer CurrentSong;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox karaokeText;
        private System.Windows.Forms.Timer KaraokeTimer;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}