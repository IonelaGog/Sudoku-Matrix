/* Gog Ionela-Maria
 * Sudoku validation problem
 */

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Numerics;
using System.Runtime.Serialization.Formatters;
using System.Text;

namespace SudokuValidation
{
    class IntroduceN
    {
        public IntroduceN()
        {
        }

        public void nValid()
        {
            int N = 0;
            double root = 0.0;
            bool isInt = false;
            int[,] mat;
            int i = 0;
            int j = 0;
            bool flag = true;

            do
            {
                Console.WriteLine("Introduce a valid N for your Sudoku matrix: ");
                N = Convert.ToInt32(Console.ReadLine());

                root = Math.Sqrt(N);
                isInt = (root % 1 == 0);

                if (isInt == false)
                    Console.WriteLine("The N you have introduced is not valid. Try again");

            } while (isInt == false);

            if (isInt == true)
            {
                Console.WriteLine("You have introduced a valid N!\nYou can now introduce the numbers in the Sudoku Matrix grid\nYour numbers should be in the interval: " + "[1," + N.ToString() + "]");

                mat = new int[N, N];
                for (i = 0; i < N; i++)
                { 
                    for (j = 0; j < N; j++)
                    {
                        string data;
                        data = Console.ReadLine();
                        mat[i,j] = int.Parse(data);
                   }
                }

                for (i = 0; i < N; i++)
                {
                    for (j = 0; j < N; j++)
                    {
                        Console.Write(mat[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                int k = 0;
                int kSec = 0;
                int rootInt = Convert.ToInt32(root);
                int aux1;
                int index;
                int []vect = new int[N];

                while (kSec < N)
                {
                    index = 0;
                    // put the elements of the small matrix in a vector
                     for (i = kSec; i < kSec + rootInt; i++)
                     {
                          for (j = k; j < k + rootInt; j++)
                          {
                            vect[index] = mat[i, j];
                            index = index + 1;
                          }
                     }

                     // check if there are similar elements in the vector formed with the elements of the small matrix 
                     for (i = 0; i < N-1; i++)
                        for (j = i + 1; j < N; j++)
                        {
                            if ((vect[i] != vect[j]) && (vect[i] >= 1 && vect[i] <= N))
                                flag = true;
                            else
                            {
                                flag = false;
                                goto End;
                            }
                        }

                        k = k + rootInt;

                        if (j == N)
                        {
                            kSec = kSec + rootInt;
                            k = 0;
                        }
                }

                if (flag == true)
                {
                    // check if there are identical elements on the rows
                    for (i = 0; i < N; i++)
                    {
                        for (j = 0; j < N - 1; j++)
                        {
                            aux1 = mat[i, j];

                            for (k = j + 1; k < N; k++)
                            {
                                if (aux1 == mat[i, k])
                                {
                                    flag = false;
                                    goto End;
                                }
                                else
                                    flag = true;
                            }
                        }
                    }

                    //check if there are identical elements on the columns
                    for (j = 0; j < N; j++)
                    {
                        for (i = 0; i < N - 1; i++)
                        {
                            aux1 = mat[i, j];

                            for (k = i + 1; k < N; k++)
                            {
                                if (aux1 == mat[k, j])
                                {
                                    flag = false;
                                    goto End;
                                }
                                else
                                    flag = true;
                            }
                        }
                    }
                }
            }

            if (flag == true)
                Console.WriteLine("The Sudoku matrix was completed correctly.\nCongratulations!!");

            End:
             if (flag != true)
                Console.WriteLine("The Sudoku matrix wasn't completed correctly.\nSorry, maybe another time");
        }
    }
}
