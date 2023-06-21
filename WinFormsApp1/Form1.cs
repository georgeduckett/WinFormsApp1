using System.Diagnostics;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private int PlayerSpeedX = 5;
        private int PlayerSpeedY = 5;
        public Drawable Enemy = new Drawable(50, 123, 20, 20, Color.Black);
        public Drawable Player = new Drawable(150, 300, 20, 20, Color.Blue);

        // fields for controlling the game timer
        private Stopwatch stopWatch = Stopwatch.StartNew();
        private readonly TimeSpan TargetElapsedTime = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / 60); // 60 fps
        private readonly TimeSpan MaxElapsedTime = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / 10); // The max number of updates in a row it'll do to 'catch up'
        private TimeSpan accumulatedTime; // How much time has passed
        private TimeSpan lastTime; // The last time we ran an update

        public Form1()
        {
            InitializeComponent();
            Application.Idle += Application_Idle; // When the application is idle the system will call the Application_Idle method
        }

        private void Application_Idle(object? sender, EventArgs e)
        {
            // Application has done everything it needs to, so we can run our game
            while (!NativeMethods.PeekMessage(out _, IntPtr.Zero, 0, 0, 0))
            { // While there are no 'events' (keyboard/mouse etc) that the form needs to handle we run our game in a loop
                Tick();
            }
        }

        private void Tick()
        {
            var currentTime = stopWatch.Elapsed; // We save this to a variable as we use it twice, and it could change inbetween

            var elapsedTime = currentTime - lastTime; // The amount of time elapsed since the last update
            lastTime = currentTime;

            // If a lot of time has elapsed just treat it as the maximum we allow for in one go
            if (elapsedTime > MaxElapsedTime)
            {
                elapsedTime = MaxElapsedTime;
            }

            // Add the elapsed time to any 'left over time' from the last update
            accumulatedTime += elapsedTime;

            var updated = false;
            // While we have some accumulated time to 'spend' on a tick we keep updating the game and reducing that time
            while (accumulatedTime >= TargetElapsedTime)
            {
                UpdateGame();
                accumulatedTime -= TargetElapsedTime;
                updated = true;
            }

            if (updated)
            {
                // If we've updated the gamestate, trigger the form to do a re-draw
                Invalidate();
            }
        }

        public void UpdateGame()
        {
            MakeEnemyBigger();
            MovePlayer();
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
        private void DrawGame(Graphics graphics)
        {
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
                    PlayerSpeedY = -Math.Abs(PlayerSpeedY);
                    break;
                case Keys.Down:
                    PlayerSpeedY = Math.Abs(PlayerSpeedY);
                    break;
                case Keys.Left:
                    PlayerSpeedX = -Math.Abs(PlayerSpeedX);
                    break;
                case Keys.Right:
                    PlayerSpeedX = Math.Abs(PlayerSpeedX);
                    break;
                case Keys.Escape:
                    Close();
                    break;
                default:
                    e.Handled = false;
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawGame(e.Graphics);
        }
    }
}