using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

class LabyrinthGame : Form
{
    // Constants
    const int ROWS = 21;
    const int COLS = 51;
    const int CELL_SIZE = 20;
    const int FORM_WIDTH = COLS * CELL_SIZE + 16;
    const int FORM_HEIGHT = ROWS * CELL_SIZE + 39;
    const char WALL_CHAR = '#';
    const char PLAYER_CHAR = 'R';
    const char PRIZE_CHAR = '$';

    // Variables
    char[,] labyrinth = new char[ROWS, COLS];
    int playerRow = ROWS / 2;
    int playerCol = COLS / 2;
    int prizeRow;
    int prizeCol;
    bool prizeReached = false;

    PictureBox prizeBox;

    public LabyrinthGame()
    {
        Text = "Labyrinth Game";
        ClientSize = new Size(FORM_WIDTH, FORM_HEIGHT);
        DoubleBuffered = true;

        GenerateLabyrinth();
        PlacePrize();

        prizeBox = new PictureBox();
        prizeBox.BackColor = Color.Gold;
        prizeBox.Size = new Size(CELL_SIZE, CELL_SIZE);
        prizeBox.Location = new Point(prizeCol * CELL_SIZE, prizeRow * CELL_SIZE);
        prizeBox.SizeMode = PictureBoxSizeMode.StretchImage;
        Controls.Add(prizeBox);

        KeyDown += HandleInput;
    }

    // Generate random labyrinth
    void GenerateLabyrinth()
    {
        Random random = new Random();

        for (int row = 0; row < ROWS; row++)
        {
            for (int col = 0; col < COLS; col++)
            {
                if (row == 0 || col == 0 || row == ROWS - 1 || col == COLS - 1)
                {
                    labyrinth[row, col] = WALL_CHAR;
                }
                else if (random.Next(100) < 30)
                {
                    labyrinth[row, col] = WALL_CHAR;
                }
                else
                {
                    labyrinth[row, col] = ' ';
                }
            }
        }
    }

    // Place the prize in a random location
    void PlacePrize()
    {
        Random random = new Random();

        do
        {
            prizeRow = random.Next(1, ROWS - 1);
            prizeCol = random.Next(1, COLS - 1);
        } while (labyrinth[prizeRow, prizeCol] == WALL_CHAR);
    }

    // Draw the labyrinth and player position
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;

        for (int row = 0; row < ROWS; row++)
        {
            for (int col = 0; col < COLS; col++)
            {
                Brush brush = labyrinth[row, col] == WALL_CHAR ? Brushes.Black : Brushes.White;
                g.FillRectangle(brush, col * CELL_SIZE, row * CELL_SIZE, CELL_SIZE, CELL_SIZE);
            }
        }

        g.FillEllipse(Brushes.Red, playerCol * CELL_SIZE, playerRow * CELL_SIZE, CELL_SIZE, CELL_SIZE);
    }

    // Handle player input and move player
    void HandleInput(object sender, KeyEventArgs e)
{
        switch (e.KeyCode)
        {
            case Keys.Up:
                if (playerRow > 1 && labyrinth[playerRow - 1, playerCol] != WALL_CHAR)
                {
                    playerRow--;
                }
                break;

            case Keys.Down:
                if (playerRow < ROWS - 2 && labyrinth[playerRow + 1, playerCol] != WALL_CHAR)
                {
                    playerRow++;
                }
                break;

            case Keys.Left:
                if (playerCol > 1 && labyrinth[playerRow, playerCol - 1] != WALL_CHAR)
                {
                    playerCol--;
                }
                break;

            case Keys.Right:
                if (playerCol < COLS - 2 && labyrinth[playerRow, playerCol + 1] != WALL_CHAR)
                {
                    playerCol++;
                }
                break;

            default:
                break;
        }

        prizeBox.Location = new Point(prizeCol * CELL_SIZE, prizeRow * CELL_SIZE);
        Invalidate();

        CheckPrizeReached();
    }

    // Check if player has reached the prize
    void CheckPrizeReached()
    {
        if (playerRow == prizeRow && playerCol == prizeCol)
        {
            prizeReached = true;
            MessageBox.Show("Great job dude!");
        }
    }

    static void Main()
    {
        Application.Run(new LabyrinthGame());
    }
}