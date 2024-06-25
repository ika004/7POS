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
            switch(commentno)//��ʏ㕔�̃��b�Z�[�W��
            {
                case 0:
                    postext.Text = "���D�̃o�[�R�[�h���X�L�����A���͐ӔC�Ҕԍ�����͂��A\r\n�y�ӔC��/�����z �������Ă��������B";
                    break;
                case 1:
                    postext.Text = "�����ȊO�̎x�����́A�y�N�[�|���z���́y�H�����z�A\r\n�y���i���z�A�y�N�I�z�A�ynanaco�z�A\r\n�y�d�q�}�l�[�^�N���W�b�g�z��I�����Ă��������B";
                    break;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void b2seki_Click(object sender, EventArgs e)
        {
            pi.Play();
            if (isuserlogin == false) // login���̐ӔC��No.���m�F�B����ɉ����ă��[�U�[���ύX�B
            {
                switch(sekinum.Text)
                {
                    case "001":
                        sekiname.Text = "TEST01";
                        login();
                        break;
                    case "004":
                        sekiname.Text = "���R:�c��������";
                        login();
                        break;
                }
            }
            else //logout�����B
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
