using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Diagnostics;
using System.IO;
using Itenso.Rtf.Parser;
using Itenso.Rtf.Support;
using Itenso.Rtf;
using Itenso.Rtf.Converter.Image;
using System.Drawing.Imaging;
using Itenso.Rtf.Converter.Html;


namespace UI
{
    public partial class RTFControl : UserControl
    {
        public RTFControl()
        {
            InitializeComponent();
            progress = this.toolstripprogress.ProgressBar;
            if (LicenseManager.UsageMode != LicenseUsageMode.Runtime) return;
            
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (LicenseManager.UsageMode != LicenseUsageMode.Runtime) return;
            initFontsCombo();
        }
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            using (InstalledFontCollection installedFonts = new InstalledFontCollection())
            {
                FontFamily[] fontfamilys = installedFonts.Families;
                List<FontFamily> result = new List<FontFamily>();
                int done=0;
                foreach (FontFamily fontfamily in fontfamilys)
                {
                    worker.ReportProgress((int)((float)done / (float)fontfamilys.Length * 100));
                    if (IsStylesSupported(fontfamily))
                        result.Add(fontfamily);
                    done++;
                }
                e.Result = result.ToArray();
            }  
        }
        [DebuggerStepThrough()]
        private bool IsStylesSupported(FontFamily fontfamily)
        {
            try
            {
                foreach (FontStyle _style in Enum.GetValues(typeof(FontStyle)))
                {
                    using (Font f = new Font(fontfamily, 8, _style)) { }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            fontFamily.ComboBox.Items.AddRange((FontFamily[])e.Result);
            fontFamily.ComboBox.DisplayMember = "Name";
            fontFamily.SelectedIndex = 0;
            endWaiting();
        }
        ProgressBar progress = null;
        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progress.Value = e.ProgressPercentage;
        }
        void startWaiting()
        {
            progress.Visible = true;
            this.initialized = false;
            this.Enabled = false;
        }
        void endWaiting()
        {
            progress.Visible = false;
            this.initialized = true;
            this.Enabled = true;
        }
        bool initialized = false;
        private void initFontsCombo()
        {
            startWaiting();
            worker.RunWorkerAsync();
        }

      
        private void fontFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSelection();
        }

        private void UpdateSelection()
        {
            if (!initialized) return;
            try
            {
                style.isBold = Bold.Checked;
                style.isItalic = Italic.Checked;
                style.isUnderline = Underline.Checked;
                FontFamily curFontFamily = (FontFamily)fontFamily.SelectedItem;
                if (fontFamily.Items == null || fontFamily.Items.Count == 0) throw new Exception("No System Fonts found ");
                if (curFontFamily == null) curFontFamily = (FontFamily)fontFamily.Items[0];
                style.font = new Font(curFontFamily, 8);
                int size;
                int.TryParse(fontSize.SelectedItem.ToString(), out size);
                style.size = size == default(int) ? 8 : size;
                style.forecolor = foreColor.ForeColor;
                style.backecolor = backColor.BackColor;
                if (alignCenter.Checked)style.alignment = HorizontalAlignment.Center;
                if (alignRight.Checked) style.alignment = HorizontalAlignment.Right;
                if (alignLeft.Checked) style.alignment = HorizontalAlignment.Left;

                FontStyle fstyle = FontStyle.Regular;
                if (style.isBold) fstyle |= FontStyle.Bold;
                if (style.isItalic) fstyle |= FontStyle.Italic;
                if (style.isUnderline) fstyle |= FontStyle.Underline;
                style.font = new Font(style.font.FontFamily, style.size, fstyle);
                text.SelectionAlignment = style.alignment;
                text.SelectionFont = style.font;
                text.SelectionBackColor = style.backecolor;
                text.SelectionColor = style.forecolor;

            }
            catch (Exception exp)
            {
                handleException(exp);
            }
        }

        private void handleException(Exception exp)
        {
            if (exp.Message.Contains("Font") && exp.Message.Contains("does not support style")) return;
            MessageBox.Show("Well, that did not go well. " + exp.Message,"an unfortunate accident",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);
        }

        private void fontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSelection();
        }

        private void undo_Click(object sender, EventArgs e)
        {
           
            DoUndo();
        }
        private void redo_Click(object sender, EventArgs e)
        {
            DoRedo();
        }

        private void DoUndo()
        {
            text.Undo();
        }
        private void DoRedo()
        {
            text.Redo();
        }
      

        private void alignLeft_Click(object sender, EventArgs e)
        {
            setAlignment(HorizontalAlignment.Left);
            UpdateSelection();
        }

        private void alignRight_Click(object sender, EventArgs e)
        {
            setAlignment(HorizontalAlignment.Right);
            UpdateSelection();
        }

        private void setAlignment(HorizontalAlignment align)
        {

            alignCenter.Checked = align==HorizontalAlignment.Center;
            alignLeft.Checked = align==HorizontalAlignment.Left;
            alignRight.Checked = align==HorizontalAlignment.Right;
        }

        private void alignCenter_Click(object sender, EventArgs e)
        {
            setAlignment(HorizontalAlignment.Center);
            UpdateSelection();
        }

        private void Bold_Click(object sender, EventArgs e)
        {
            UpdateSelection();
        }

        private void Italic_Click(object sender, EventArgs e)
        {
            UpdateSelection();
        }

        private void Underline_Click(object sender, EventArgs e)
        {
            UpdateSelection();
        }
        StyleInfo style = new StyleInfo();
        class StyleInfo
        {
            private Font _font;
            public int size { get; set; }
            public Font font { get { return _font; } set { if(_font!=null)_font.Dispose(); _font = value; } }
            public bool isItalic{ get; set; }
            public bool isBold{ get; set; }
            public bool isUnderline{ get; set; }
            public HorizontalAlignment alignment { get; set; }
            public Color forecolor { get; set; }
            public Color backecolor { get; set; }

        }

        private void text_SelectionChanged(object sender, EventArgs e)
        {
            UpdateStyle();
            
        }

        private void UpdateStyle()
        {
            try
            {
                style.alignment = text.SelectionAlignment;
                if (text.SelectionFont != null)
                {
                    style.font = text.SelectionFont;
                    style.size = (int)text.SelectionFont.Size;
                }
                style.isBold = text.SelectionFont.Style == FontStyle.Bold;
                style.isItalic = text.SelectionFont.Style == FontStyle.Italic;
                style.isUnderline = text.SelectionFont.Style == FontStyle.Underline;
                style.backecolor = text.SelectionBackColor;
                style.forecolor = text.SelectionColor;

                initialized = false;
                int ffamIndex = fontFamily.Items.IndexOf(style.font.FontFamily); if (ffamIndex > 0) fontFamily.SelectedIndex = ffamIndex;
                this.Bold.Checked = style.isBold;
                this.Italic.Checked = style.isItalic;
                this.Underline.Checked = style.isUnderline;
                setAlignment(style.alignment);

                this.foreColor.ForeColor = style.forecolor;
                this.backColor.BackColor = style.backecolor;


                initialized = true;
                fontSize.SelectedItem = style.size.ToString();
            }
            catch (Exception)
            { }

        }

        private void backColor_Click(object sender, EventArgs e)
        {
            colorSelect.Color = backColor.BackColor;
            if (colorSelect.ShowDialog() != DialogResult.OK) return;
            backColor.BackColor = colorSelect.Color;
            UpdateSelection();
        }

        private void foreColor_Click(object sender, EventArgs e)
        {
            colorSelect.Color = foreColor.ForeColor;
            if (colorSelect.ShowDialog() != DialogResult.OK) return;
            foreColor.ForeColor = colorSelect.Color;
            UpdateSelection();
        }

        public RichTextBox RTFBox
        {
            get
            {
                return text;
            }
        }

        private void image_Click(object sender, EventArgs e)
        {
            try
            {
                fileSelect.Filter = "Pictures (PNG,JPG,GIF,BMP)|*.png;*.jpg;*.jpeg;*.gif;*.bmp";
                fileSelect.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                if (fileSelect.ShowDialog() == DialogResult.Cancel) return;
                IDataObject oldData = Clipboard.GetDataObject();
                Clipboard.SetDataObject(new Bitmap(Image.FromFile(fileSelect.FileName)));
                DataFormats.Format myFormat = DataFormats.GetFormat(DataFormats.Bitmap);
                if (text.CanPaste(myFormat))
                {
                    text.Paste(myFormat);
                    Clipboard.SetDataObject(oldData);
                }
                else
                {
                    MessageBox.Show("The data format that you attempted to paste is not supported by this control.");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Image Insert failed. let's try again ,hell we ? \n" + exp.Message, "image insert error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                
        }

        public string HTML
        {
            get
            {
              RTF2HTMLConverter converter=  new RTF2HTMLConverter();
              string  html=new RTF2HTMLConverter().GetHTML(this.RTFBox.Rtf);
              HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
              doc.LoadHtml(html);
              HtmlAgilityPack.HtmlNode root= doc.DocumentNode;
              HtmlAgilityPack.HtmlNodeCollection imgs=root.SelectNodes("//img");
              foreach (HtmlAgilityPack.HtmlNode node in imgs)
              {
                  node.Attributes["src"].Value = converter.ImagePath + "/" + node.Attributes["src"].Value;
              }
                using (StringWriter result=new StringWriter())
                {
                    doc.Save(result);
                    return html = result.ToString();
                }
            }
        }

       
    }
    public class RTF2HTMLConverter
    {
        private string ConvertHmtl(IRtfDocument rtfDocument, RtfVisualImageAdapter imageAdapter)
        {
            RtfHtmlConvertSettings htmlConvertSettings = new RtfHtmlConvertSettings(imageAdapter);
            htmlConvertSettings.Title = "Doc Title " + DateTime.Now.ToString("dd/MM/yyyy");
            htmlConvertSettings.ImagesPath = ImagePath;
            htmlConvertSettings.IsShowHiddenText = IsShowHiddenText;
            htmlConvertSettings.ConvertVisualHyperlinks = ConvertVisualHyperlinks;
            RtfHtmlConverter htmlConverter = new RtfHtmlConverter(rtfDocument, htmlConvertSettings);
            return htmlConverter.Convert();
        }

        private IRtfDocument InterpretRtf(IRtfGroup rtfStructure, RtfVisualImageAdapter imageAdapter)
        {
            IRtfDocument rtfDocument = null;
            RtfImageConverter imageConverter = null;
            RtfImageConvertSettings imageConvertSettings = new RtfImageConvertSettings(imageAdapter);
            imageConvertSettings.ImagesPath = ImagePath;
            imageConvertSettings.BackgroundColor = null;
            imageConverter = new RtfImageConverter(imageConvertSettings);
            rtfDocument = RtfInterpreterTool.BuildDoc(rtfStructure, null, imageConverter);
            return rtfDocument;
        }


        public string ImageFileNamePattern = "TempFile" + Guid.NewGuid() + "_{0}{1}";
        public string ImagePath = Environment.GetEnvironmentVariable("TEMP");
        private bool IsShowHiddenText = false;
        private bool ConvertVisualHyperlinks = true;
        private IRtfGroup ParseRtf(string RtfString)
        {
            IRtfGroup rtfStructure;
            // parse the rtf structure
            RtfParserListenerStructureBuilder structureBuilder = new RtfParserListenerStructureBuilder();
            RtfParser parser = new RtfParser(structureBuilder);
            parser.IgnoreContentAfterRootGroup = true; // support WordPad documents
            using (TextReader reader = new StringReader(RtfString))
            {
                parser.Parse(new RtfSource(reader));
            }
            rtfStructure = structureBuilder.StructureRoot;
            return rtfStructure;
        }
        public string GetHTML(string rtfString)
        {
            ReportProgress(33);
            IRtfGroup rtfStructure = ParseRtf(rtfString);
            RtfVisualImageAdapter imageAdapter = new RtfVisualImageAdapter(
            ImageFileNamePattern,
            ImageFormat.Jpeg);
            ReportProgress(33);
            IRtfDocument rtfDocument = InterpretRtf(rtfStructure, imageAdapter);
            ReportProgress(33);
            return ConvertHmtl(rtfDocument, imageAdapter);
        }
        
        public IProgressReporter reporter { get; set; }
        private void ReportProgress(int precent)
        {
            if (reporter != null) reporter.RportProgress("working...", precent);
        }
    }
    public interface IProgressReporter
    {
        void RportProgress(string msg, int precent);
    }
    public class BGWorkProgressReporter : IProgressReporter
    {
        BackgroundWorker bgwork = new BackgroundWorker();
        #region IProgressReporter Members

        public void RportProgress(string msg, int precent)
        {
            bgwork.ReportProgress(precent);
        }

        #endregion
    }
    
}
