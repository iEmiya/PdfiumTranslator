using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PdfiumTranslator
{
    public partial class frmRuler : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();


        public frmRuler()
        {
            InitializeComponent();
        }

        public bool CanClose { get; set; }

        private void frmRuler_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !CanClose;
        }

        private void frmRuler_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void rulerControl_MouseDown(object sender, MouseEventArgs e)
        {
            frmRuler_MouseDown(sender, e);
        }

        private void frmRuler_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
