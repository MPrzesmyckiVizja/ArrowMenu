using System.Text;

namespace Menu
{
    public static class ArrowMenu
    {
        public static void Choice<T>(IEnumerable<T> list, ref T obj)
        {
            int listCount = list.Count();
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.ResetColor();
            (int left, int top) = Console.GetCursorPosition();
            int option = 0;
            var decorator = "✅ \u001b[32m";
            ConsoleKeyInfo key;
            bool Selecting = true;

            while (Selecting)
            {
                Console.SetCursorPosition(left, top);

                for (int i = 0; i < listCount; i++)
                {
                    Console.WriteLine($"{(option == i ? decorator : "   ")}{list.ElementAt(i).ToString()}\u001b[0m");
                }

                key = Console.ReadKey(false);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        option = option == 0 ? listCount - 1 : option - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        option = option == listCount - 1 ? 0 : option + 1;
                        break;

                    case ConsoleKey.Enter:
                        Console.Clear();
                        obj = list.ElementAt(option);
                        Selecting = false;
                        break;
                    case ConsoleKey.Q:
                        Console.Clear();
                        Selecting = false;
                        break;
                }
            }
        }
    }
}
