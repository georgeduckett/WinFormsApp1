namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private int PlayerSpeedX = 1;
        private int PlayerSpeedY = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MakeEnemyBigger();
            MovePlayer();
        }

        private void MakeEnemyBigger()
        {
            Enemy.Width += 1;
            Enemy.Height += 1;
            if (Enemy.Width % 2 == 0)
            { // If the width (and height) has increased by 2 then move the top left of the enemy back 1 (so it appears to grow from the centre)
                Enemy.Left -= 1;
                Enemy.Top -= 1;
            }
        }

        private void MovePlayer()
        {
            Player.Left += PlayerSpeedX;
            Player.Top += PlayerSpeedY;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            // Player pressed a key
            switch (e.KeyCode)
            {
                case Keys.Up:

                    break;
                case Keys.Down:

                    break;
                case Keys.Left:

                    break;
                case Keys.Right:

                    break;
                default:
                    e.Handled = false;
                    break;
            }
        }
    }
}