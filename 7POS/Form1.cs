using System.Media;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
namespace _7POS
{
    public partial class Form1 : Form
    {
        //サウンド関係
        [DllImport("user32.dll")]
        private static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern int VkKeyScan(char ch);

        System.Media.SoundPlayer pi = new SoundPlayer(Properties.Resources.pi);
        System.Media.SoundPlayer osiharai = new System.Media.SoundPlayer(Properties.Resources.osiharai);

        public Form1()
        {
            InitializeComponent();
        }

        bool isuserlogin = false;
        int commentno = 0;

        int tourokuno = 0;
        string tourokuname = null;
        int tanka = 0;
        int goukei = 0;
        int waribiki = 0;


        void login()//ログイン
        {
            sekininbox.Visible = false;
            isuserlogin = true;
            sekinum.Text = null;
            sekinum.Visible = false;
            commentno = 1;
            tourokuno = 1;
            textkousin();
        }
         void bckakunin() //バーコードの番号と商品一覧
        {
            switch (barcodeno.Text)
            {
                case "0228100102282":
                    tourokuname = "トマト";
                    tanka = 110;
                    syouhintouroku();
                    break;
                case "004":
                    tourokuname = "いかさん";
                    tanka = 150;
                    syouhintouroku();
                    break;
                case "4909411090517":
                    tourokuname = "ｷﾘﾝ ﾌｧｲﾔ ﾗﾃ微糖 600ml";
                    tanka = 168;
                    syouhintouroku();
                    break;
                case "4902402908839":
                    tourokuname = "ﾊｳｽとんがりｺｰﾝ 焼とうも";
                    tanka = 156;
                    syouhintouroku();
                    break;
                case "4580074520018":
                    tourokuname = "Essential Phone PH1 ";
                    tanka = 54780;
                    syouhintouroku();
                    break;
                case "4007817104729":
                    tourokuname = "ｽﾃｯﾄﾞﾗｰﾏｽﾙﾙﾓｸﾞﾗﾌ製図";
                    tanka = 2040;
                    syouhintouroku();
                    break;
                default:
                    if(barcodeno.Text == "")
                    {
                        
                        Payscr();
                    }
                    else
                    {
                        pi.Play();
                    }
                    
                    break;

            }

            barcodeno.Text = null;
        }
        void touroku()//登録時の合計金額の計算
        {
            tourokuno++;
            goukei = goukei + tanka;
            goukei = goukei - waribiki;
            goukeitext.Text = goukei.ToString();
            waribiki = 0;

        }
        void treset()
        {

            goukei = 0;
            tourokuno = 1;
            graphno1.Visible = false;
            no1kazu.Visible = false;
            no1kingaku.Visible = false;
            no1syouhin.Visible = false;
            no1tanka.Visible = false;
            goukeitext.Visible = false;
            goukeilabel.Visible = false;
            no2kazu.Visible = false;
            no2kingaku.Visible = false;
            no2syouhin.Visible = false;
            no2tanka.Visible = false;
            graphno2.Visible = false;
            no3kazu.Visible = false;
            no3kingaku.Visible = false;
            no3syouhin.Visible = false;
            no3tanka.Visible = false;
            graphno3.Visible = false;
            no4kazu.Visible = false;
            no4kingaku.Visible = false;
            no4syouhin.Visible = false;
            no4tanka.Visible = false;
            graphno4.Visible = false;
            no5kazu.Visible = false;
            no5kingaku.Visible = false;
            no5syouhin.Visible = false;
            no5tanka.Visible = false;
            graphno5.Visible = false;
            no6kazu.Visible = false;
            no6kingaku.Visible = false;
            no6syouhin.Visible = false;
            no6tanka.Visible = false;
            graphno6.Visible = false;
            no7kazu.Visible = false;
            no7kingaku.Visible = false;
            no7syouhin.Visible = false;
            no7tanka.Visible = false;
            graphno7.Visible = false;

            paymentscr.Visible = false;
            paybarcode.Visible = false;
            paynanaco.Visible = false;
            paycash.Visible = false;
            payother.Visible = false;
            Paycredit.Visible = false;
            Payic.Visible = false   ;

        }
        void syouhintouroku()//登録画面のグラフに商品名などを追加する。スパゲッティコード。
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
                    graphno1.Text = tourokuno.ToString();

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
                    graphno2.Text = tourokuno.ToString();


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
                    

                    graphno3.Text = tourokuno.ToString();

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
                    
                    graphno4.Text = tourokuno.ToString();


                    no4kazu.Text = "1";
                    no4syouhin.Text = tourokuname;
                    no4tanka.Text = tanka.ToString();
                    no4kingaku.Text = tanka.ToString();
                    touroku();
                    break;
                case 5:
                    graphno5.Text = tourokuno.ToString();
                    
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
                    graphno6.Text = tourokuno.ToString();
                    
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
                    graphno7.Text = tourokuno.ToString();
                    
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
        async void Payscr()
        {
            osiharai.Play();
            await Task.Delay(700);
            paymentscr.Location = new Point(3, 2);
            paybarcode.Location = new Point(27, 132);
            paynanaco.Location = new Point(340, 132);
            paycash.Location = new Point(665, 132);
            payother.Location = new Point(24, 362);
            Paycredit.Location = new Point(339, 354);
            Payic.Location = new Point(660, 357);
            paymentscr.Visible = true;
            paybarcode.Visible = true;
            paynanaco.Visible = true;
            paycash.Visible = true;
            payother.Visible = true;
            Paycredit.Visible = true;
            Payic.Visible = true;

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
                if (tourokuno <= 2)
                {
                    //ここにエラー処理
                }
                else
                {
                    isuserlogin = false;
                    sekiname.Text = null;
                    sekininbox.Visible = true;
                    sekinum.Visible = true;
                    sekinum.Focus();
                    commentno = 0;
                    textkousin();
                    tourokuno = 0;
                }                
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
            if (e.KeyData == Keys.Enter)
            {
                bckakunin();
            }
            else if(e.KeyData == Keys.End)
            {
                treset();
            }
        }


        private void sekininbox_Click(object sender, EventArgs e)
        {

        }
    }
}
