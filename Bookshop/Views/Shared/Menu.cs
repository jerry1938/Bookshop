﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Views.Shared
{
    class Menu
    {
        public void PrintMenu(List<string> options, int selectedOption)
        {
            char prefix;

            Console.CursorVisible = false;

            for (int i = 0; i < options.Count; i++)
            {
                Console.CursorLeft = 3;

                if (i == selectedOption)
                {
                    prefix = '>';
                }
                else
                {
                    prefix = ' ';
                }
                Console.WriteLine($"{prefix} {options[i]}");
            }
        }

        public void PrintMessageBox(int selectedOption)
        {
            List<string> options = new List<string>() { "Yes", "No" };
            char leftPrefix, rightPrefix;

            Console.CursorVisible = false;
            Console.SetCursorPosition(57, 15);

            for (int i = 0; i < 2; i++)
            {
                Console.CursorTop = 20;

                if (i == selectedOption)
                {
                    leftPrefix = '[';
                    rightPrefix = ']';
                }
                else
                {
                    leftPrefix = ' ';
                    rightPrefix = ' ';
                }

                Console.Write(leftPrefix);
                if (selectedOption == 0 && i == selectedOption)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(options[i]);
                    Console.ResetColor();
                }
                else if (i == selectedOption)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(options[i]);
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(options[i]);
                }
                Console.Write(rightPrefix);
            }
        }

        public void PrintBookList(List<Webbutik.Models.Book> bookOptions, int selectedOption)
        {
            char prefix;

            Console.CursorVisible = false;

            for (int i = 0; i < bookOptions.Count; i++)
            {
                Console.CursorLeft = 25;

                if (i == selectedOption)
                {
                    prefix = '>';
                }
                else
                {
                    prefix = ' ';
                }
                Console.Write($"{prefix} {bookOptions[i].Title}");
                Console.CursorLeft = 55;
                Console.Write(bookOptions[i].Author.Name);
                Console.CursorLeft = 80;
                Console.Write(bookOptions[i].Category.Name);
                Console.CursorLeft = 95;
                Console.WriteLine($"{bookOptions[i].Price} kr");
            }
        }

        public void PrintCategoryList(List<Webbutik.Models.BookCategory> categories, 
            int selectedOption)
        {
            char prefix;

            for (int i = 0; i < categories.Count; i++)
            {
                Console.CursorLeft = 25;

                if (i == selectedOption)
                {
                    prefix = '>';
                }
                else
                {
                    prefix = ' ';
                }
                Console.WriteLine($"{prefix} {categories[i].Name}");
            }
        }
    }
}
