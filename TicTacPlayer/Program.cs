using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicTacPlayer
{
    internal class Program
    {
        static char[,] board = new char[3, 3]; // игровое поле
        static bool player1Turn; // true - ход первого игрока, false - ход второго игрока
        static char player1Symbol = 'X'; // символ первого игрока
        static char player2Symbol = 'O'; // символ второго игрока
        static void Main(string[] args)
        {
            InitializeBoard(); // инициализация игрового поля

            // случайный выбор, кто ходит первым
            Random random = new Random();
            player1Turn = random.Next(2) == 0;

            Console.WriteLine("Добро пожаловать в игру Крестики-Нолики!");

            // игровой цикл
            while (true)
            {
                PrintBoard(); // вывод игрового поля

                if (player1Turn)
                {
                    Console.WriteLine("Ход первого игрока (строка столбец):");
                    PlayerMove(player1Symbol); // ход первого игрока
                }
                else
                {
                    Console.WriteLine("Ход второго игрока (строка столбец):");
                    PlayerMove(player2Symbol); // ход второго игрока
                }
                Thread.Sleep(2000);
                Console.Clear();
                // проверка на победу или ничью
                if (CheckWin(player1Symbol))
                {
                    Console.WriteLine("Победил первый игрок!");
                    break;
                }
                else if (CheckWin(player2Symbol))
                {
                    Console.WriteLine("Победил второй игрок!");
                    break;
                }
                else if (CheckDraw())
                {
                    Console.WriteLine("Ничья!");
                    break;
                }

                player1Turn = !player1Turn; // передача хода
            }

            Console.WriteLine("Игра окончена.");
            Console.ReadLine();
        }
        // инициализация игрового поля
        static void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = '-';
                }
            }
        }

        // вывод игрового поля
        static void PrintBoard()
        {
            Console.WriteLine("  0 1 2");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // ход игрока
        static void PlayerMove(char symbol)
        {
            string[] input = Console.ReadLine().Split();
            int col = int.Parse(input[0]);
            int row = int.Parse(input[1]);

            // проверка на корректность введенных координат
            if (row < 0 || row > 2 || col < 0 || col > 2)
            {
                Console.WriteLine("Некорректные координаты. Попробуйте еще раз.");
                PlayerMove(symbol);
                return;
            }
            if (board[row, col] != '-')
            {
                Console.WriteLine("Эта клетка уже занята. Попробуйте еще раз.");
                PlayerMove(symbol);
                return;
            }

            board[row, col] = symbol;
        }

        // проверка на победу
        static bool CheckWin(char symbol)
        {
            // проверка горизонтальных линий
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == symbol && board[i, 1] == symbol && board[i, 2] == symbol)
                {
                    return true;
                }
            }

            // проверка вертикальных линий
            for (int j = 0; j < 3; j++)
            {
                if (board[0, j] == symbol && board[1, j] == symbol && board[2, j] == symbol)
                {
                    return true;
                }
            }

            // проверка диагоналей
            if (board[0, 0] == symbol && board[1, 1] == symbol && board[2, 2] == symbol)
            {
                return true;
            }
            if (board[0, 2] == symbol && board[1, 1] == symbol && board[2, 0] == symbol)
            {
                return true;
            }

            return false;
        }

        // проверка на ничью
        static bool CheckDraw()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == '-')
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
