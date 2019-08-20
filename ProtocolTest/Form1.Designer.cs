namespace ProtocolTest
{
    partial class Form1
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
            this.MainPort = new System.IO.Ports.SerialPort();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.DataList = new DevExpress.XtraGrid.GridControl();
            this.DataView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GridClear = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnView = new System.Windows.Forms.Button();
            this.chartControl = new DevExpress.XtraCharts.ChartControl();
            this.label10 = new System.Windows.Forms.Label();
            this.EndDataTime = new System.Windows.Forms.TextBox();
            this.StartDataTime = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NodeIDBox = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mENUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.포트설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PortList = new System.Windows.Forms.ToolStripComboBox();
            this.baudRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RateList = new System.Windows.Forms.ToolStripComboBox();
            this.dataBitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DataBitsList = new System.Windows.Forms.ToolStripComboBox();
            this.btnDBOpen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataView)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPort
            // 
            this.MainPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.MainPort_DataReceived);
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnOpen.ForeColor = System.Drawing.Color.Black;
            this.btnOpen.Location = new System.Drawing.Point(110, 29);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(92, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "PORT OPEN";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(208, 29);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // DataList
            // 
            this.DataList.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.Black;
            this.DataList.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.White;
            this.DataList.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.DataList.EmbeddedNavigator.Appearance.Options.UseForeColor = true;
            this.DataList.Font = new System.Drawing.Font("Gulim", 9F);
            this.DataList.Location = new System.Drawing.Point(13, 20);
            this.DataList.MainView = this.DataView;
            this.DataList.Name = "DataList";
            this.DataList.Size = new System.Drawing.Size(974, 311);
            this.DataList.TabIndex = 38;
            this.DataList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.DataView});
            // 
            // DataView
            // 
            this.DataView.Appearance.GroupPanel.BackColor = System.Drawing.Color.Transparent;
            this.DataView.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.Transparent;
            this.DataView.Appearance.GroupPanel.Options.UseBackColor = true;
            this.DataView.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.DataView.Appearance.TopNewRow.Options.UseBackColor = true;
            this.DataView.GridControl = this.DataList;
            this.DataView.Name = "DataView";
            // 
            // GridClear
            // 
            this.GridClear.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.GridClear.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GridClear.ForeColor = System.Drawing.Color.Black;
            this.GridClear.Location = new System.Drawing.Point(13, 20);
            this.GridClear.Name = "GridClear";
            this.GridClear.Size = new System.Drawing.Size(974, 35);
            this.GridClear.TabIndex = 41;
            this.GridClear.Text = "Clear All";
            this.GridClear.UseVisualStyleBackColor = false;
            this.GridClear.Click += new System.EventHandler(this.GridClear_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 58);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1015, 375);
            this.tabControl1.TabIndex = 44;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.GridClear);
            this.tabPage1.Controls.Add(this.DataList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1007, 349);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "LAST DATA";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnView);
            this.tabPage2.Controls.Add(this.chartControl);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.EndDataTime);
            this.tabPage2.Controls.Add(this.StartDataTime);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.NodeIDBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1007, 349);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "HISTORY DATA";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnView.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnView.ForeColor = System.Drawing.Color.Black;
            this.btnView.Location = new System.Drawing.Point(487, 30);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(91, 23);
            this.btnView.TabIndex = 46;
            this.btnView.Text = "VIEW";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // chartControl
            // 
            this.chartControl.Legend.Name = "Default Legend";
            this.chartControl.Location = new System.Drawing.Point(13, 64);
            this.chartControl.Name = "chartControl";
            this.chartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartControl.Size = new System.Drawing.Size(976, 270);
            this.chartControl.TabIndex = 45;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(293, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 12);
            this.label10.TabIndex = 46;
            this.label10.Text = "~";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // EndDataTime
            // 
            this.EndDataTime.Location = new System.Drawing.Point(320, 31);
            this.EndDataTime.Name = "EndDataTime";
            this.EndDataTime.Size = new System.Drawing.Size(144, 21);
            this.EndDataTime.TabIndex = 47;
            // 
            // StartDataTime
            // 
            this.StartDataTime.Location = new System.Drawing.Point(135, 31);
            this.StartDataTime.Name = "StartDataTime";
            this.StartDataTime.Size = new System.Drawing.Size(144, 21);
            this.StartDataTime.TabIndex = 46;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(318, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 46;
            this.label9.Text = "End Data Time";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 12);
            this.label2.TabIndex = 31;
            this.label2.Text = "Start Data Time";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 12);
            this.label1.TabIndex = 30;
            this.label1.Text = "Node ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // NodeIDBox
            // 
            this.NodeIDBox.FormattingEnabled = true;
            this.NodeIDBox.Location = new System.Drawing.Point(13, 32);
            this.NodeIDBox.Name = "NodeIDBox";
            this.NodeIDBox.Size = new System.Drawing.Size(88, 20);
            this.NodeIDBox.TabIndex = 30;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mENUToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1038, 24);
            this.menuStrip1.TabIndex = 45;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mENUToolStripMenuItem
            // 
            this.mENUToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.포트설정ToolStripMenuItem,
            this.baudRateToolStripMenuItem,
            this.dataBitsToolStripMenuItem});
            this.mENUToolStripMenuItem.Name = "mENUToolStripMenuItem";
            this.mENUToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.mENUToolStripMenuItem.Text = "Port Setting";
            // 
            // 포트설정ToolStripMenuItem
            // 
            this.포트설정ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portUpdateToolStripMenuItem,
            this.PortList});
            this.포트설정ToolStripMenuItem.Name = "포트설정ToolStripMenuItem";
            this.포트설정ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.포트설정ToolStripMenuItem.Text = "Port Name";
            // 
            // portUpdateToolStripMenuItem
            // 
            this.portUpdateToolStripMenuItem.Name = "portUpdateToolStripMenuItem";
            this.portUpdateToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.portUpdateToolStripMenuItem.Text = "Port Update";
            this.portUpdateToolStripMenuItem.Click += new System.EventHandler(this.portUpdateToolStripMenuItem_Click);
            // 
            // PortList
            // 
            this.PortList.Name = "PortList";
            this.PortList.Size = new System.Drawing.Size(152, 23);
            // 
            // baudRateToolStripMenuItem
            // 
            this.baudRateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RateList});
            this.baudRateToolStripMenuItem.Name = "baudRateToolStripMenuItem";
            this.baudRateToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.baudRateToolStripMenuItem.Text = "Baud Rate";
            // 
            // RateList
            // 
            this.RateList.Name = "RateList";
            this.RateList.Size = new System.Drawing.Size(121, 23);
            // 
            // dataBitsToolStripMenuItem
            // 
            this.dataBitsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DataBitsList});
            this.dataBitsToolStripMenuItem.Name = "dataBitsToolStripMenuItem";
            this.dataBitsToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.dataBitsToolStripMenuItem.Text = "Data Bits";
            // 
            // DataBitsList
            // 
            this.DataBitsList.Name = "DataBitsList";
            this.DataBitsList.Size = new System.Drawing.Size(121, 23);
            // 
            // btnDBOpen
            // 
            this.btnDBOpen.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDBOpen.ForeColor = System.Drawing.Color.Black;
            this.btnDBOpen.Location = new System.Drawing.Point(12, 29);
            this.btnDBOpen.Name = "btnDBOpen";
            this.btnDBOpen.Size = new System.Drawing.Size(92, 23);
            this.btnDBOpen.TabIndex = 46;
            this.btnDBOpen.Text = "DB OPEN";
            this.btnDBOpen.UseVisualStyleBackColor = false;
            this.btnDBOpen.Click += new System.EventHandler(this.btnDBOpen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1038, 440);
            this.Controls.Add(this.btnDBOpen);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "ProtocolTest";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataView)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort MainPort;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClose;
        private DevExpress.XtraGrid.GridControl DataList;
        private DevExpress.XtraGrid.Views.Grid.GridView DataView;
        private System.Windows.Forms.Button GridClear;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox EndDataTime;
        private System.Windows.Forms.TextBox StartDataTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox NodeIDBox;
        private DevExpress.XtraCharts.ChartControl chartControl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mENUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 포트설정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox PortList;
        private System.Windows.Forms.ToolStripMenuItem baudRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox RateList;
        private System.Windows.Forms.ToolStripMenuItem dataBitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox DataBitsList;
        private System.Windows.Forms.ToolStripMenuItem portUpdateToolStripMenuItem;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnDBOpen;
    }
}

