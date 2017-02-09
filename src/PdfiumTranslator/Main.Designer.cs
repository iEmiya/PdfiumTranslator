namespace PdfiumTranslator
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnViewZoomToFit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFitWidth = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFitHeight = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRuler = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAutoScroll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPageToText = new System.Windows.Forms.ToolStripMenuItem();
            this.btnToolTranslatePage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnToolsTranlateDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pdfViewer = new PdfiumViewer.PdfViewer();
            this.tbSourceText = new System.Windows.Forms.TextBox();
            this.tsSourceText = new System.Windows.Forms.ToolStrip();
            this.btnSourceSelectTextToLower = new System.Windows.Forms.ToolStripButton();
            this.btnSourceSelectTextCommentOut = new System.Windows.Forms.ToolStripButton();
            this.tabTargetText = new System.Windows.Forms.TabControl();
            this.tpTargetText = new System.Windows.Forms.TabPage();
            this.tbTargetText = new System.Windows.Forms.TextBox();
            this.tsTargetText = new System.Windows.Forms.ToolStrip();
            this.btnTargetSelectTextToBold = new System.Windows.Forms.ToolStripButton();
            this.btnTargetSelectTextToItalic = new System.Windows.Forms.ToolStripButton();
            this.tpMarkDown = new System.Windows.Forms.TabPage();
            this.webTargetText = new System.Windows.Forms.WebBrowser();
            this.tabImageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnZoomOriginalSize = new System.Windows.Forms.ToolStripButton();
            this.btnZoomToFit = new System.Windows.Forms.ToolStripButton();
            this.btnZoomToWidth = new System.Windows.Forms.ToolStripButton();
            this.btnZoomToHeight = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnViewAutoScroll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTranslatePageToText = new System.Windows.Forms.ToolStripButton();
            this.btnTranslatePage = new System.Windows.Forms.ToolStripButton();
            this.btnTranslateDocument = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tbPage = new System.Windows.Forms.ToolStripTextBox();
            this.pbRun = new System.Windows.Forms.ToolStripProgressBar();
            this.btnViewRuler = new System.Windows.Forms.ToolStripButton();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tsSourceText.SuspendLayout();
            this.tabTargetText.SuspendLayout();
            this.tpTargetText.SuspendLayout();
            this.tsTargetText.SuspendLayout();
            this.tpMarkDown.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(792, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFileOpen,
            this.btnSave,
            this.toolStripSeparator1,
            this.btnFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // btnFileOpen
            // 
            this.btnFileOpen.Image = global::PdfiumTranslator.Properties.Resources.OpenFolder_16x;
            this.btnFileOpen.Name = "btnFileOpen";
            this.btnFileOpen.ShortcutKeyDisplayString = "";
            this.btnFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.btnFileOpen.Size = new System.Drawing.Size(140, 22);
            this.btnFileOpen.Text = "&Open";
            this.btnFileOpen.Click += new System.EventHandler(this.btnFileOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::PdfiumTranslator.Properties.Resources.Save_16x;
            this.btnSave.Name = "btnSave";
            this.btnSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.btnSave.Size = new System.Drawing.Size(140, 22);
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(137, 6);
            // 
            // btnFileExit
            // 
            this.btnFileExit.Name = "btnFileExit";
            this.btnFileExit.ShortcutKeyDisplayString = "";
            this.btnFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.btnFileExit.Size = new System.Drawing.Size(140, 22);
            this.btnFileExit.Text = "E&xit";
            this.btnFileExit.Click += new System.EventHandler(this.btnFileExit_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnViewZoomToFit,
            this.btnFitWidth,
            this.btnFitHeight,
            this.toolStripSeparator3,
            this.btnRuler,
            this.btnAutoScroll});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // btnViewZoomToFit
            // 
            this.btnViewZoomToFit.Image = global::PdfiumTranslator.Properties.Resources.ZoomToFit_16x;
            this.btnViewZoomToFit.Name = "btnViewZoomToFit";
            this.btnViewZoomToFit.ShortcutKeyDisplayString = "";
            this.btnViewZoomToFit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.btnViewZoomToFit.Size = new System.Drawing.Size(184, 22);
            this.btnViewZoomToFit.Text = "Fit &page";
            this.btnViewZoomToFit.Click += new System.EventHandler(this.btnViewZoomToFit_Click);
            // 
            // btnFitWidth
            // 
            this.btnFitWidth.Image = global::PdfiumTranslator.Properties.Resources.ZoomToWidth_16x;
            this.btnFitWidth.Name = "btnFitWidth";
            this.btnFitWidth.ShortcutKeyDisplayString = "";
            this.btnFitWidth.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.btnFitWidth.Size = new System.Drawing.Size(184, 22);
            this.btnFitWidth.Text = "Fit &width";
            this.btnFitWidth.Click += new System.EventHandler(this.btnFitWidth_Click);
            // 
            // btnFitHeight
            // 
            this.btnFitHeight.Image = global::PdfiumTranslator.Properties.Resources.ZoomToHeight_16x;
            this.btnFitHeight.Name = "btnFitHeight";
            this.btnFitHeight.ShortcutKeyDisplayString = "";
            this.btnFitHeight.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.btnFitHeight.Size = new System.Drawing.Size(184, 22);
            this.btnFitHeight.Text = "Fit &height";
            this.btnFitHeight.Click += new System.EventHandler(this.btnFitHeight_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(181, 6);
            // 
            // btnRuler
            // 
            this.btnRuler.Image = global::PdfiumTranslator.Properties.Resources.Ruler_16x;
            this.btnRuler.Name = "btnRuler";
            this.btnRuler.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.btnRuler.Size = new System.Drawing.Size(184, 22);
            this.btnRuler.Text = "Ruler";
            this.btnRuler.Click += new System.EventHandler(this.btnRuler_Click);
            // 
            // btnAutoScroll
            // 
            this.btnAutoScroll.Image = global::PdfiumTranslator.Properties.Resources.Textarea_16x;
            this.btnAutoScroll.Name = "btnAutoScroll";
            this.btnAutoScroll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.btnAutoScroll.Size = new System.Drawing.Size(184, 22);
            this.btnAutoScroll.Text = "Auto Scroll";
            this.btnAutoScroll.Click += new System.EventHandler(this.btnAutoScroll_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPageToText,
            this.btnToolTranslatePage,
            this.btnToolsTranlateDocument});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // btnPageToText
            // 
            this.btnPageToText.Image = global::PdfiumTranslator.Properties.Resources.AppearanceEditorPart_16x;
            this.btnPageToText.Name = "btnPageToText";
            this.btnPageToText.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.btnPageToText.Size = new System.Drawing.Size(211, 22);
            this.btnPageToText.Text = "&Page to text";
            this.btnPageToText.Click += new System.EventHandler(this.btnPageToText_Click);
            // 
            // btnToolTranslatePage
            // 
            this.btnToolTranslatePage.Image = global::PdfiumTranslator.Properties.Resources.TranslateDocument_16x;
            this.btnToolTranslatePage.Name = "btnToolTranslatePage";
            this.btnToolTranslatePage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.btnToolTranslatePage.Size = new System.Drawing.Size(211, 22);
            this.btnToolTranslatePage.Text = "&Translate";
            this.btnToolTranslatePage.Click += new System.EventHandler(this.btnToolTranslatePage_Click);
            // 
            // btnToolsTranlateDocument
            // 
            this.btnToolsTranlateDocument.Image = global::PdfiumTranslator.Properties.Resources.SetProactiveCaching_16x;
            this.btnToolsTranlateDocument.Name = "btnToolsTranlateDocument";
            this.btnToolsTranlateDocument.ShortcutKeyDisplayString = "";
            this.btnToolsTranlateDocument.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.T)));
            this.btnToolsTranlateDocument.Size = new System.Drawing.Size(211, 22);
            this.btnToolsTranlateDocument.Text = "&Auto translate";
            this.btnToolsTranlateDocument.Click += new System.EventHandler(this.btnToolsTranlateDocument_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1MinSize = 394;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabTargetText);
            this.splitContainer1.Panel2MinSize = 394;
            this.splitContainer1.Size = new System.Drawing.Size(792, 502);
            this.splitContainer1.SplitterDistance = 394;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pdfViewer);
            this.splitContainer2.Panel1MinSize = 192;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tbSourceText);
            this.splitContainer2.Panel2.Controls.Add(this.tsSourceText);
            this.splitContainer2.Panel2MinSize = 92;
            this.splitContainer2.Size = new System.Drawing.Size(394, 502);
            this.splitContainer2.SplitterDistance = 365;
            this.splitContainer2.TabIndex = 0;
            // 
            // pdfViewer
            // 
            this.pdfViewer.BackColor = System.Drawing.SystemColors.Window;
            this.pdfViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer.Location = new System.Drawing.Point(0, 0);
            this.pdfViewer.Name = "pdfViewer";
            this.pdfViewer.ShowBookmarks = false;
            this.pdfViewer.ShowToolbar = false;
            this.pdfViewer.Size = new System.Drawing.Size(394, 365);
            this.pdfViewer.TabIndex = 0;
            // 
            // tbSourceText
            // 
            this.tbSourceText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSourceText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSourceText.Location = new System.Drawing.Point(0, 25);
            this.tbSourceText.MaxLength = 524288;
            this.tbSourceText.Multiline = true;
            this.tbSourceText.Name = "tbSourceText";
            this.tbSourceText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSourceText.Size = new System.Drawing.Size(394, 108);
            this.tbSourceText.TabIndex = 0;
            this.tbSourceText.TextChanged += new System.EventHandler(this.tbSourceText_TextChanged);
            // 
            // tsSourceText
            // 
            this.tsSourceText.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSourceSelectTextToLower,
            this.btnSourceSelectTextCommentOut});
            this.tsSourceText.Location = new System.Drawing.Point(0, 0);
            this.tsSourceText.Name = "tsSourceText";
            this.tsSourceText.Size = new System.Drawing.Size(394, 25);
            this.tsSourceText.TabIndex = 1;
            this.tsSourceText.Text = "toolStrip1";
            // 
            // btnSourceSelectTextToLower
            // 
            this.btnSourceSelectTextToLower.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSourceSelectTextToLower.Image = global::PdfiumTranslator.Properties.Resources.HiddenTextField_16x;
            this.btnSourceSelectTextToLower.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSourceSelectTextToLower.Name = "btnSourceSelectTextToLower";
            this.btnSourceSelectTextToLower.Size = new System.Drawing.Size(23, 22);
            this.btnSourceSelectTextToLower.Text = "To lower selected text";
            this.btnSourceSelectTextToLower.ToolTipText = "To lower selected text";
            this.btnSourceSelectTextToLower.Click += new System.EventHandler(this.btnSourceSelectTextToLower_Click);
            // 
            // btnSourceSelectTextCommentOut
            // 
            this.btnSourceSelectTextCommentOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSourceSelectTextCommentOut.Image = global::PdfiumTranslator.Properties.Resources.XMLIntelliSenseDescendant_16x;
            this.btnSourceSelectTextCommentOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSourceSelectTextCommentOut.Name = "btnSourceSelectTextCommentOut";
            this.btnSourceSelectTextCommentOut.Size = new System.Drawing.Size(23, 22);
            this.btnSourceSelectTextCommentOut.Text = "Comment out";
            this.btnSourceSelectTextCommentOut.Click += new System.EventHandler(this.btnSourceSelectTextCommentOut_Click);
            // 
            // tabTargetText
            // 
            this.tabTargetText.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabTargetText.Controls.Add(this.tpTargetText);
            this.tabTargetText.Controls.Add(this.tpMarkDown);
            this.tabTargetText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTargetText.ImageList = this.tabImageList;
            this.tabTargetText.Location = new System.Drawing.Point(0, 0);
            this.tabTargetText.Name = "tabTargetText";
            this.tabTargetText.SelectedIndex = 0;
            this.tabTargetText.Size = new System.Drawing.Size(394, 502);
            this.tabTargetText.TabIndex = 0;
            // 
            // tpTargetText
            // 
            this.tpTargetText.Controls.Add(this.tbTargetText);
            this.tpTargetText.Controls.Add(this.tsTargetText);
            this.tpTargetText.ImageKey = "CPPSourceFile_16x.png";
            this.tpTargetText.Location = new System.Drawing.Point(4, 4);
            this.tpTargetText.Name = "tpTargetText";
            this.tpTargetText.Padding = new System.Windows.Forms.Padding(3);
            this.tpTargetText.Size = new System.Drawing.Size(386, 475);
            this.tpTargetText.TabIndex = 0;
            this.tpTargetText.UseVisualStyleBackColor = true;
            // 
            // tbTargetText
            // 
            this.tbTargetText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTargetText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbTargetText.Location = new System.Drawing.Point(3, 28);
            this.tbTargetText.MaxLength = 524288;
            this.tbTargetText.Multiline = true;
            this.tbTargetText.Name = "tbTargetText";
            this.tbTargetText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbTargetText.Size = new System.Drawing.Size(380, 444);
            this.tbTargetText.TabIndex = 0;
            this.tbTargetText.TextChanged += new System.EventHandler(this.tbTargetText_TextChanged);
            // 
            // tsTargetText
            // 
            this.tsTargetText.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTargetSelectTextToBold,
            this.btnTargetSelectTextToItalic});
            this.tsTargetText.Location = new System.Drawing.Point(3, 3);
            this.tsTargetText.Name = "tsTargetText";
            this.tsTargetText.Size = new System.Drawing.Size(380, 25);
            this.tsTargetText.TabIndex = 1;
            this.tsTargetText.Text = "toolStrip1";
            // 
            // btnTargetSelectTextToBold
            // 
            this.btnTargetSelectTextToBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTargetSelectTextToBold.Image = global::PdfiumTranslator.Properties.Resources.Bold_16x;
            this.btnTargetSelectTextToBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTargetSelectTextToBold.Name = "btnTargetSelectTextToBold";
            this.btnTargetSelectTextToBold.Size = new System.Drawing.Size(23, 22);
            this.btnTargetSelectTextToBold.Text = "To bold selected text";
            this.btnTargetSelectTextToBold.Click += new System.EventHandler(this.btnTargetSelectTextToBold_Click);
            // 
            // btnTargetSelectTextToItalic
            // 
            this.btnTargetSelectTextToItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTargetSelectTextToItalic.Image = global::PdfiumTranslator.Properties.Resources.Italic_16x;
            this.btnTargetSelectTextToItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTargetSelectTextToItalic.Name = "btnTargetSelectTextToItalic";
            this.btnTargetSelectTextToItalic.Size = new System.Drawing.Size(23, 22);
            this.btnTargetSelectTextToItalic.Text = "To italic selected text";
            this.btnTargetSelectTextToItalic.Click += new System.EventHandler(this.btnTargetSelectTextToItalic_Click);
            // 
            // tpMarkDown
            // 
            this.tpMarkDown.Controls.Add(this.webTargetText);
            this.tpMarkDown.ImageKey = "MarkDown_16px.png";
            this.tpMarkDown.Location = new System.Drawing.Point(4, 4);
            this.tpMarkDown.Name = "tpMarkDown";
            this.tpMarkDown.Padding = new System.Windows.Forms.Padding(3);
            this.tpMarkDown.Size = new System.Drawing.Size(386, 475);
            this.tpMarkDown.TabIndex = 1;
            this.tpMarkDown.Text = "Ctrl+Q";
            this.tpMarkDown.UseVisualStyleBackColor = true;
            // 
            // webTargetText
            // 
            this.webTargetText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webTargetText.IsWebBrowserContextMenuEnabled = false;
            this.webTargetText.Location = new System.Drawing.Point(3, 3);
            this.webTargetText.MinimumSize = new System.Drawing.Size(20, 20);
            this.webTargetText.Name = "webTargetText";
            this.webTargetText.Size = new System.Drawing.Size(380, 469);
            this.webTargetText.TabIndex = 0;
            this.webTargetText.WebBrowserShortcutsEnabled = false;
            // 
            // tabImageList
            // 
            this.tabImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tabImageList.ImageStream")));
            this.tabImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.tabImageList.Images.SetKeyName(0, "CPPSourceFile_16x.png");
            this.tabImageList.Images.SetKeyName(1, "MarkDown_16px.png");
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnZoomOriginalSize,
            this.btnZoomToFit,
            this.btnZoomToWidth,
            this.btnZoomToHeight,
            this.toolStripSeparator4,
            this.btnViewRuler,
            this.btnViewAutoScroll,
            this.toolStripSeparator2,
            this.btnTranslatePageToText,
            this.btnTranslatePage,
            this.btnTranslateDocument});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(792, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnZoomOriginalSize
            // 
            this.btnZoomOriginalSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomOriginalSize.Image = global::PdfiumTranslator.Properties.Resources.ZoomOriginalSize_16x;
            this.btnZoomOriginalSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomOriginalSize.Name = "btnZoomOriginalSize";
            this.btnZoomOriginalSize.Size = new System.Drawing.Size(23, 22);
            this.btnZoomOriginalSize.Text = "Zoom 100%";
            this.btnZoomOriginalSize.Click += new System.EventHandler(this.btnZoomOriginalSize_Click);
            // 
            // btnZoomToFit
            // 
            this.btnZoomToFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomToFit.Image = global::PdfiumTranslator.Properties.Resources.ZoomToFit_16x;
            this.btnZoomToFit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomToFit.Name = "btnZoomToFit";
            this.btnZoomToFit.Size = new System.Drawing.Size(23, 22);
            this.btnZoomToFit.Text = "Fit page";
            this.btnZoomToFit.Click += new System.EventHandler(this.btnZoomToFit_Click);
            // 
            // btnZoomToWidth
            // 
            this.btnZoomToWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomToWidth.Image = global::PdfiumTranslator.Properties.Resources.ZoomToWidth_16x;
            this.btnZoomToWidth.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomToWidth.Name = "btnZoomToWidth";
            this.btnZoomToWidth.Size = new System.Drawing.Size(23, 22);
            this.btnZoomToWidth.Text = "Fit width";
            this.btnZoomToWidth.Click += new System.EventHandler(this.btnZoomToWidth_Click);
            // 
            // btnZoomToHeight
            // 
            this.btnZoomToHeight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomToHeight.Image = global::PdfiumTranslator.Properties.Resources.ZoomToHeight_16x;
            this.btnZoomToHeight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomToHeight.Name = "btnZoomToHeight";
            this.btnZoomToHeight.Size = new System.Drawing.Size(23, 22);
            this.btnZoomToHeight.Text = "Fit height";
            this.btnZoomToHeight.Click += new System.EventHandler(this.btnZoomToHeight_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnViewAutoScroll
            // 
            this.btnViewAutoScroll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnViewAutoScroll.Image = global::PdfiumTranslator.Properties.Resources.Textarea_16x;
            this.btnViewAutoScroll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnViewAutoScroll.Name = "btnViewAutoScroll";
            this.btnViewAutoScroll.Size = new System.Drawing.Size(23, 22);
            this.btnViewAutoScroll.Text = "Auto scroll";
            this.btnViewAutoScroll.Click += new System.EventHandler(this.btnViewAutoScroll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnTranslatePageToText
            // 
            this.btnTranslatePageToText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTranslatePageToText.Image = global::PdfiumTranslator.Properties.Resources.AppearanceEditorPart_16x;
            this.btnTranslatePageToText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTranslatePageToText.Name = "btnTranslatePageToText";
            this.btnTranslatePageToText.Size = new System.Drawing.Size(23, 22);
            this.btnTranslatePageToText.Text = "Get text from page";
            this.btnTranslatePageToText.Click += new System.EventHandler(this.btnTranslatePageToText_Click);
            // 
            // btnTranslatePage
            // 
            this.btnTranslatePage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTranslatePage.Image = global::PdfiumTranslator.Properties.Resources.TranslateDocument_16x;
            this.btnTranslatePage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTranslatePage.Name = "btnTranslatePage";
            this.btnTranslatePage.Size = new System.Drawing.Size(23, 22);
            this.btnTranslatePage.Text = "Translate page";
            this.btnTranslatePage.Click += new System.EventHandler(this.btnTranslatePage_Click);
            // 
            // btnTranslateDocument
            // 
            this.btnTranslateDocument.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTranslateDocument.Image = global::PdfiumTranslator.Properties.Resources.SetProactiveCaching_16x;
            this.btnTranslateDocument.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTranslateDocument.Name = "btnTranslateDocument";
            this.btnTranslateDocument.Size = new System.Drawing.Size(23, 22);
            this.btnTranslateDocument.Text = "Auto translate document";
            this.btnTranslateDocument.ToolTipText = "Auto translate document";
            this.btnTranslateDocument.Click += new System.EventHandler(this.btnTranslateDocument_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbPage,
            this.pbRun});
            this.statusStrip.Location = new System.Drawing.Point(0, 551);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(792, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tbPage
            // 
            this.tbPage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPage.Name = "tbPage";
            this.tbPage.Size = new System.Drawing.Size(64, 22);
            this.tbPage.Text = "1 of 1";
            this.tbPage.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPage_KeyDown);
            // 
            // pbRun
            // 
            this.pbRun.Name = "pbRun";
            this.pbRun.Size = new System.Drawing.Size(64, 16);
            this.pbRun.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbRun.Visible = false;
            // 
            // btnViewRuler
            // 
            this.btnViewRuler.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnViewRuler.Image = global::PdfiumTranslator.Properties.Resources.Ruler_16x;
            this.btnViewRuler.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnViewRuler.Name = "btnViewRuler";
            this.btnViewRuler.Size = new System.Drawing.Size(23, 22);
            this.btnViewRuler.Text = "Ruler";
            this.btnViewRuler.Click += new System.EventHandler(this.btnViewRuler_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "Main";
            this.Text = "PdfiumTranslator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tsSourceText.ResumeLayout(false);
            this.tsSourceText.PerformLayout();
            this.tabTargetText.ResumeLayout(false);
            this.tpTargetText.ResumeLayout(false);
            this.tpTargetText.PerformLayout();
            this.tsTargetText.ResumeLayout(false);
            this.tsTargetText.PerformLayout();
            this.tpMarkDown.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnFileOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem btnFileExit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private PdfiumViewer.PdfViewer pdfViewer;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnTranslateDocument;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnToolsTranlateDocument;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnViewZoomToFit;
        private System.Windows.Forms.ToolStripMenuItem btnFitWidth;
        private System.Windows.Forms.ToolStripMenuItem btnFitHeight;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnZoomOriginalSize;
        private System.Windows.Forms.ToolStripButton btnZoomToFit;
        private System.Windows.Forms.ToolStripButton btnZoomToWidth;
        private System.Windows.Forms.ToolStripButton btnZoomToHeight;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private System.Windows.Forms.TextBox tbSourceText;
        private System.Windows.Forms.TabControl tabTargetText;
        private System.Windows.Forms.TabPage tpTargetText;
        private System.Windows.Forms.TabPage tpMarkDown;
        private System.Windows.Forms.ToolStripMenuItem btnToolTranslatePage;
        private System.Windows.Forms.ToolStripButton btnTranslatePage;
        private System.Windows.Forms.TextBox tbTargetText;
        private System.Windows.Forms.ToolStripProgressBar pbRun;
        private System.Windows.Forms.ImageList tabImageList;
        private System.Windows.Forms.WebBrowser webTargetText;
        private System.Windows.Forms.ToolStrip tsSourceText;
        private System.Windows.Forms.ToolStripButton btnSourceSelectTextToLower;
        private System.Windows.Forms.ToolStripMenuItem btnPageToText;
        private System.Windows.Forms.ToolStripButton btnTranslatePageToText;
        private System.Windows.Forms.ToolStrip tsTargetText;
        private System.Windows.Forms.ToolStripButton btnTargetSelectTextToBold;
        private System.Windows.Forms.ToolStripButton btnTargetSelectTextToItalic;
        private System.Windows.Forms.ToolStripButton btnSourceSelectTextCommentOut;
        private System.Windows.Forms.ToolStripTextBox tbPage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem btnAutoScroll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnViewAutoScroll;
        private System.Windows.Forms.ToolStripMenuItem btnRuler;
        private System.Windows.Forms.ToolStripButton btnViewRuler;
    }
}

