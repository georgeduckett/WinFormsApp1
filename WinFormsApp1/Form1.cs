namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private int PlayerSpeedX = 1;
        private int PlayerSpeedY = 1;
        public Drawable Enemy = new Drawable(50, 123, 20, 20, Color.Black);
        public Drawable Player = new Drawable(150, 300, 20, 20, Color.Blue);
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MakeEnemyBigger();
            MovePlayer();
            DrawGame();
        }

        private void MakeEnemyBigger()
        {
            Enemy.Width += 1;
            Enemy.Height += 1;
            Enemy.Left -= 0.5f;
            Enemy.Top -= 0.5f;
        }

        private void MovePlayer()
        {
            Player.Left += PlayerSpeedX;
            Player.Top += PlayerSpeedY;
        }
        private void DrawGame()
        {
            using var graphics = CreateGraphics();
            graphics.Clear(Color.Gray);
            graphics.FillRectangle(new SolidBrush(Player.Color), Player.Left, Player.Top, Player.Width, Player.Height);
            graphics.FillRectangle(new SolidBrush(Enemy.Color), Enemy.Left, Enemy.Top, Enemy.Width, Enemy.Height);
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