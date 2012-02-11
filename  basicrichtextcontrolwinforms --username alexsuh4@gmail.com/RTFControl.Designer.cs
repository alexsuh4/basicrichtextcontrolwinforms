namespace UI
{
    partial class RTFControl
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
        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RTFControl));
            this.text = new System.Windows.Forms.RichTextBox();
            this.strip = new System.Windows.Forms.ToolStrip();
            this.toolstripprogress = new System.Windows.Forms.ToolStripProgressBar();
            this.fontSize = new System.Windows.Forms.ToolStripComboBox();
            this.fontFamily = new System.Windows.Forms.ToolStripComboBox();
            this.undo = new System.Windows.Forms.ToolStripButton();
            this.redo = new System.Windows.Forms.ToolStripButton();
            this.alignLeft = new System.Windows.Forms.ToolStripButton();
            this.alignCenter = new System.Windows.Forms.ToolStripButton();
            this.alignRight = new System.Windows.Forms.ToolStripButton();
            this.Bold = new System.Windows.Forms.ToolStripButton();
            this.Italic = new System.Windows.Forms.ToolStripButton();
            this.Underline = new System.Windows.Forms.ToolStripButton();
            this.backColor = new System.Windows.Forms.ToolStripLabel();
            this.foreColor = new System.Windows.Forms.ToolStripLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.colorSelect = new System.Windows.Forms.ColorDialog();
            this.fileSelect = new System.Windows.Forms.OpenFileDialog();
            this.image = new System.Windows.Forms.ToolStripButton();
            this.strip.SuspendLayout();
            this.SuspendLayout();
            // 
            // text
            // 
            this.text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text.Location = new System.Drawing.Point(0, 25);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(640, 305);
            this.text.TabIndex = 0;
            this.text.Text = "";
            this.text.SelectionChanged += new System.EventHandler(this.text_SelectionChanged);
            // 
            // strip
            // 
            this.strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstripprogress,
            this.fontSize,
            this.fontFamily,
            this.undo,
            this.redo,
            this.alignLeft,
            this.alignCenter,
            this.alignRight,
            this.Bold,
            this.Italic,
            this.Underline,
            this.backColor,
            this.foreColor,
            this.image});
            this.strip.Location = new System.Drawing.Point(0, 0);
            this.strip.Name = "strip";
            this.strip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.strip.Size = new System.Drawing.Size(640, 25);
            this.strip.TabIndex = 1;
            this.strip.Text = "strip";
            // 
            // toolstripprogress
            // 
            this.toolstripprogress.Name = "toolstripprogress";
            this.toolstripprogress.Size = new System.Drawing.Size(100, 22);
            // 
            // fontSize
            // 
            this.fontSize.Items.AddRange(new object[] {
            "8",
            "12",
            "24",
            "28"});
            this.fontSize.Name = "fontSize";
            this.fontSize.Size = new System.Drawing.Size(121, 25);
            this.fontSize.Text = "8";
            this.fontSize.SelectedIndexChanged += new System.EventHandler(this.fontSize_SelectedIndexChanged);
            // 
            // fontFamily
            // 
            this.fontFamily.Name = "fontFamily";
            this.fontFamily.Size = new System.Drawing.Size(121, 25);
            this.fontFamily.SelectedIndexChanged += new System.EventHandler(this.fontFamily_SelectedIndexChanged);
            // 
            // undo
            // 
            this.undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undo.Image = ((System.Drawing.Image)(resources.GetObject("undo.Image")));
            this.undo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undo.Name = "undo";
            this.undo.Size = new System.Drawing.Size(23, 22);
            this.undo.Text = "toolStripButton3";
            this.undo.ToolTipText = "Undo";
            this.undo.Click += new System.EventHandler(this.undo_Click);
            // 
            // redo
            // 
            this.redo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redo.Image = ((System.Drawing.Image)(resources.GetObject("redo.Image")));
            this.redo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redo.Name = "redo";
            this.redo.Size = new System.Drawing.Size(23, 22);
            this.redo.Text = "toolStripButton4";
            this.redo.ToolTipText = "Redo";
            this.redo.Click += new System.EventHandler(this.redo_Click);
            // 
            // alignLeft
            // 
            this.alignLeft.CheckOnClick = true;
            this.alignLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.alignLeft.Image = ((System.Drawing.Image)(resources.GetObject("alignLeft.Image")));
            this.alignLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.alignLeft.Name = "alignLeft";
            this.alignLeft.Size = new System.Drawing.Size(23, 22);
            this.alignLeft.Text = "toolStripButton1";
            this.alignLeft.ToolTipText = "Align Left";
            this.alignLeft.Click += new System.EventHandler(this.alignLeft_Click);
            // 
            // alignCenter
            // 
            this.alignCenter.CheckOnClick = true;
            this.alignCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.alignCenter.Image = ((System.Drawing.Image)(resources.GetObject("alignCenter.Image")));
            this.alignCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.alignCenter.Name = "alignCenter";
            this.alignCenter.Size = new System.Drawing.Size(23, 22);
            this.alignCenter.Text = "toolStripButton3";
            this.alignCenter.ToolTipText = "Align Center";
            this.alignCenter.Click += new System.EventHandler(this.alignCenter_Click);
            // 
            // alignRight
            // 
            this.alignRight.CheckOnClick = true;
            this.alignRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.alignRight.Image = ((System.Drawing.Image)(resources.GetObject("alignRight.Image")));
            this.alignRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.alignRight.Name = "alignRight";
            this.alignRight.Size = new System.Drawing.Size(23, 22);
            this.alignRight.Text = "toolStripButton2";
            this.alignRight.ToolTipText = "Align Right";
            this.alignRight.Click += new System.EventHandler(this.alignRight_Click);
            // 
            // Bold
            // 
            this.Bold.CheckOnClick = true;
            this.Bold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Bold.Image = ((System.Drawing.Image)(resources.GetObject("Bold.Image")));
            this.Bold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Bold.Name = "Bold";
            this.Bold.Size = new System.Drawing.Size(23, 22);
            this.Bold.Text = "toolStripButton1";
            this.Bold.ToolTipText = "Bold";
            this.Bold.Click += new System.EventHandler(this.Bold_Click);
            // 
            // Italic
            // 
            this.Italic.CheckOnClick = true;
            this.Italic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Italic.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic);
            this.Italic.Image = ((System.Drawing.Image)(resources.GetObject("Italic.Image")));
            this.Italic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Italic.Name = "Italic";
            this.Italic.Size = new System.Drawing.Size(23, 22);
            this.Italic.Text = "I";
            this.Italic.ToolTipText = "Italic";
            this.Italic.Click += new System.EventHandler(this.Italic_Click);
            // 
            // Underline
            // 
            this.Underline.CheckOnClick = true;
            this.Underline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Underline.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Underline);
            this.Underline.Image = ((System.Drawing.Image)(resources.GetObject("Underline.Image")));
            this.Underline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Underline.Name = "Underline";
            this.Underline.Size = new System.Drawing.Size(23, 22);
            this.Underline.Text = "I";
            this.Underline.ToolTipText = "Under Line";
            this.Underline.Click += new System.EventHandler(this.Underline_Click);
            // 
            // backColor
            // 
            this.backColor.BackColor = System.Drawing.Color.White;
            this.backColor.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold);
            this.backColor.Name = "backColor";
            this.backColor.Size = new System.Drawing.Size(18, 22);
            this.backColor.Text = "A";
            this.backColor.ToolTipText = "Backgound Color";
            this.backColor.Click += new System.EventHandler(this.backColor_Click);
            // 
            // foreColor
            // 
            this.foreColor.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.foreColor.Name = "foreColor";
            this.foreColor.Size = new System.Drawing.Size(18, 22);
            this.foreColor.Text = "A";
            this.foreColor.ToolTipText = "Foreground Color";
            this.foreColor.Click += new System.EventHandler(this.foreColor_Click);
            // 
            // worker
            // 
            this.worker.WorkerReportsProgress = true;
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            this.worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.worker_ProgressChanged);
            // 
            // fileSelect
            // 
            this.fileSelect.InitialDirectory = "%userprofile%";
            // 
            // image
            // 
            this.image.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.image.Image = ((System.Drawing.Image)(resources.GetObject("image.Image")));
            this.image.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(23, 22);
            this.image.Text = "toolStripButton1";
            this.image.ToolTipText = "Insert Image";
            this.image.Click += new System.EventHandler(this.image_Click);
            // 
            // RTFControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.text);
            this.Controls.Add(this.strip);
            this.Name = "RTFControl";
            this.Size = new System.Drawing.Size(640, 330);
            this.strip.ResumeLayout(false);
            this.strip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox text;
        private System.Windows.Forms.ToolStrip strip;
        private System.Windows.Forms.ToolStripButton undo;
        private System.Windows.Forms.ToolStripButton redo;
        private System.Windows.Forms.ToolStripComboBox fontFamily;
        private System.Windows.Forms.ToolStripComboBox fontSize;
        private System.Windows.Forms.ToolStripButton alignLeft;
        private System.Windows.Forms.ToolStripButton alignRight;
        private System.Windows.Forms.ToolStripButton alignCenter;
       
        private System.Windows.Forms.ToolStripButton Italic;
        private System.Windows.Forms.ToolStripButton Underline;
        private System.Windows.Forms.ToolStripButton Bold;
        private System.Windows.Forms.ToolTip toolTip;
        private System.ComponentModel.BackgroundWorker worker;
        private System.Windows.Forms.ToolStripProgressBar toolstripprogress;
        private System.Windows.Forms.ToolStripLabel backColor;
        private System.Windows.Forms.ToolStripLabel foreColor;
        private System.Windows.Forms.ColorDialog colorSelect;
        private System.Windows.Forms.OpenFileDialog fileSelect;
        private System.Windows.Forms.ToolStripButton image;
        
        
       
    }
}
