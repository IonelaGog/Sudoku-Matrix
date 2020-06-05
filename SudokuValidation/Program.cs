/* Gog Ionela-Maria
 * Sudoku validation problem
 */

using System;

namespace SudokuValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Sudoku game validation!");

            IntroduceN n = new IntroduceN();

            n.nValid();
            Console.ReadKey();
        }
    }
}
