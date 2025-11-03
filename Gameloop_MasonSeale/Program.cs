using System;
using System.Net;
using System.Threading;

namespace GameLoopExample
{
    internal class Program
    {
        // keep track of if game is playing
        static bool isPlaying = true;

        // keep track of user's WASD input
        static int horizontalInput = 0;
        static int verticalInput = 0;

        // gamestate
        static int verticalPos = 0;
        static int horizontalPos = 0;
        static int tickMs = 20;
        static int sharkv = 10;
        static int sharkh = 19;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            // game Loop 
            while (isPlaying)
            {
                ProcessInput(); // keys, gamepad, wii fit balance board
                Update(); // update game state: player, enemy, etc. 
                Draw(); // draw the game based on the game state
                endgame();
                Thread.Sleep(tickMs); // give the game a constant tick rate
            }
        }
        static void ProcessInput()
        {
            horizontalInput = 0;
            verticalInput = 0;

            if (!Console.KeyAvailable)
            {
                return;
            }

            ConsoleKeyInfo inputKey = Console.ReadKey(true);

            if (inputKey.Key == ConsoleKey.A) horizontalInput -= 1;

            if (inputKey.Key == ConsoleKey.D) horizontalInput += 1;

            if (inputKey.Key == ConsoleKey.W) verticalInput -= 1;

            if (inputKey.Key == ConsoleKey.S) verticalInput += 1;

            if (inputKey.Key == ConsoleKey.Q) isPlaying = false;
        }

        static void Update()
        {
            verticalPos += verticalInput;
            horizontalPos += horizontalInput;
            sharmovement();
        }
        static void Draw()
        {
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("                    ");
            Console.WriteLine("                    ");
            Console.WriteLine("                    ");
            Console.WriteLine("                    ");
            Console.WriteLine("                    ");
            Console.WriteLine("                    ");
            Console.WriteLine("                    ");
            Console.WriteLine("                    ");
            Console.WriteLine("                    ");
            Console.WriteLine("                    ");
            Console.WriteLine("                    ");
            Console.SetCursorPosition(horizontalPos, verticalPos);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("O");
            Console.SetCursorPosition(sharkh, sharkv);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("^");
            

        }
        static void sharmovement()
        {
            if(horizontalPos < sharkh)
            {
                sharkh -= 1;
            }
            if(horizontalPos > sharkh)
            {
                sharkh += 1;
            }
            if(verticalPos < sharkv)
            {
                sharkv -= 1;
            }
            if (verticalPos > sharkv)
            {
                sharkv += 1;
            }
        }
        static void endgame()
        {
            if(sharkh == horizontalPos)
            {
                if (sharkv == verticalPos)
                {
                    isPlaying = false;
                    Console.Clear();
                    Console.WriteLine("game over");
                    Console.ReadKey();
                }
            }
            else
            {
                return;
            }
        }

    }
}