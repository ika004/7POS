using System.Media;
using System.Net.Http.Headers;
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

        int tourokuno = 1;
        string tourokuname = null;
        int tanka = 0;
        int goukei = 0;
        int waribiki = 0;


        void login()
        {
            sekininbox.Visible = false;
            isuserlogin = true;
            sekinum.Text = null;
            sekinum.Visible = false;
            commentno = 1;
            textkousin();
        }
        void bckakunin()
        {
            switch(barcodeno.Text)
            {
                case "00410":
                    tourokuname = "トマト";
                    tanka = 110;
                    syouhintouroku();
                    break;
                case "004":
                    tourokuname = "いかさん";
                    tanka = 150;
                    syouhintouroku();
                    break;
                
                default:
                    pi.Play();
                    break;

            }
            
            barcodeno.Text = null;
        }
        void touroku()
        {
            tourokuno++;
            goukei = goukei + tanka;
            goukei = goukei - waribiki;
            goukeitext.Text = goukei.ToString();
            waribiki = 0;

        }
        void syouhintouroku()
        {
           switch (tourokuno)
            {
                case 1:
                    no1kazu.Visible = true;
                    no1kingaku.Visible = true;
                    no1syouhin.Visible = true;
                    no1tanka.Visible = true;
                    goukeitext.Visible = true;
                    goukeilabel.Visible = true;
                    graphno1.Visible = true;


                    no1kazu.Text = "1";
                    no1syouhin.Text = tourokuname;
                    no1tanka.Text = tanka.ToString();
                    no1kingaku.Text = tanka.ToString();
                    touroku();
                    break;

                    case 2:
                    no2kazu.Visible = true;
                    no2kingaku.Visible = true;
                    no2syouhin.Visible = true;
                    no2tanka.Visible = true;
                    graphno2.Visible = true;


                    no2kazu.Text = "1";
                    no2syouhin.Text = tourokuname;
                    no2tanka.Text = tanka.ToString();
                    no2kingaku.Text = tanka.ToString();
                    touroku();
                    break;
                case 3:
                    no3kazu.Visible = true;
                    no3kingaku.Visible = true;
                    no3syouhin.Visible = true;
                    no3tanka.Visible = true;
                    graphno3.Visible = true;


                    no3kazu.Text = "1";
                    no3syouhin.Text = tourokuname;
                    no3tanka.Text = tanka.ToString();
                    no3kingaku.Text = tanka.ToString();
                    touroku();
                    break;
                    case 4:
                    no4kazu.Visible = true;
                    no4kingaku.Visible = true;
                    no4syouhin.Visible = true;
                    no4tanka.Visible = true;
                    graphno4.Visible = true;


                    no4kazu.Text = "1";
                    no4syouhin.Text = tourokuname;
                    no4tanka.Text = tanka.ToString();
                    no4kingaku.Text = tanka.ToString();
                    touroku();
                    break;
                case 5:
                    no5kazu.Visible = true;
                    no5kingaku.Visible = true;
                    no5syouhin.Visible = true;
                    no5tanka.Visible = true;
                    graphno5.Visible = true;


                    no5kazu.Text = "1";
                    no5syouhin.Text = tourokuname;
                    no5tanka.Text = tanka.ToString();
                    no5kingaku.Text = tanka.ToString();
                    touroku();
                    break;
                case 6:
                    no6kazu.Visible = true;
                    no6kingaku.Visible = true;
                    no6syouhin.Visible = true;
                    no6tanka.Visible = true;
                    graphno6.Visible = true;


                    no6kazu.Text = "1";
                    no6syouhin.Text = tourokuname;
                    no6tanka.Text = tanka.ToString();
                    no6kingaku.Text = tanka.ToString();
                    touroku();
                    break;
                case 7:
                    no7kazu.Visible = true;
                    no7kingaku.Visible = true;
                    no7syouhin.Visible = true;
                    no7tanka.Visible = true;
                    graphno7.Visible = true;


                    no7kazu.Text = "1";
                    no7syouhin.Text = tourokuname;
                    no7tanka.Text = tanka.ToString();
                    no7kingaku.Text = tanka.ToString();
                    touroku();
                    break;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        void textkousin()
        {
            switch (commentno)//画面上部のメッセージ欄
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
                switch (sekinum.Text)
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
            if (e.KeyData == Keys.Enter)
            {
                b2seki_Click(sender, e);
            }
        }

        private void barcodeno_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                bckakunin();
            }
        }
    }
}
