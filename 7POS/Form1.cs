using System.Media;
using System.Runtime.InteropServices;
namespace _7POS
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll")]
        private static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern int VkKeyScan(char ch);

        System.Media.SoundPlayer pi = new SoundPlayer(Properties.Resources.pi);

        public Form1()
        {
            InitializeComponent();
        }
        bool isuserlogin = false;
        int commentno = 0;
        void login()
        {
            sekininbox.Visible = false;
            isuserlogin = true;
            sekinum.Text = null;
            sekinum.Visible = false;
            commentno = 1;
            textkousin();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        void textkousin()
        {
            switch(commentno)//画面上部のメッセージ欄
            {
                case 0:
                    postext.Text = "名札のバーコードをスキャン、又は責任者番号を入力し、\r\n【責任者/解除】 を押してください。";
                    break;
                case 1:
                    postext.Text = "現金以外の支払いは、【クーポン】又は【食事券】、\r\n【商品券】、【クオ】、【nanaco】、\r\n【電子マネー／クレジット】を選択してください。";
                    break;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void b2seki_Click(object sender, EventArgs e)
        {
            pi.Play();
            if (isuserlogin == false) // login時の責任者No.を確認。それに応じてユーザー名変更。
            {
                switch(sekinum.Text)
                {
                    case "001":
                        sekiname.Text = "TEST01";
                        login();
                        break;
                    case "004":
                        sekiname.Text = "くコ:彡いかさん";
                        login();
                        break;
                }
            }
            else //logout処理。
            {
                isuserlogin = false;
                sekiname.Text = null;
                sekininbox.Visible = true;
                sekinum.Visible = true;
                sekinum.Focus();
                commentno = 0;
                textkousin();
            }
        }

        private void sekinum_KeyDown(object sender, KeyEventArgs e)
        {
            pi.Play();
            if(e.KeyData == Keys.Enter)
            {
                b2seki_Click(sender, e);
            }
        }
    }
}
