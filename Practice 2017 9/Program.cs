using System;

// Задание №9 практики 2017г.
// Задание 9.13, стр. 6: 13. Создать циклический список, с возможностью поиска и удаления элементов (всё через рекурсию). В информационные поля элементов заносятся номера с 1 до N (N водится с клавиатуры). Первый элемент в списке, имеющий номер 1, оказывается в хвосте списка (последним).
// Задания по учебной практике

namespace Practice_2017_9
{
    class Program
    {
        public static int Menu(params string[] items)
        {
            int[] span = new int[items.Length + 1];
            for (int i = 1; i < span.Length; i++)
            {
                span[i] = items[i - 1].Length / Console.WindowWidth + 1;
            }

            Console.CursorVisible = false;
            for (int i = 0; i < items.Length; i++)
                Console.WriteLine("\n");
            int positionY = Console.CursorTop - 2 * items.Length + 1;
            int currentIndex = 0, previousIndex = 0;
            int positionX = 2;
            bool itemSelected = false;

            int sum = 0;
            //Начальный вывод пунктов меню.
            for (int i = 0; i < items.Length; i++)
            {
                sum += span[i];
                Console.CursorLeft = positionX;
                Console.CursorTop = positionY + sum;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(items[i]);
            }

            do
            {
                sum = 0;
                for (int i = 0; i <= previousIndex; i++)

                    sum += span[i];

                // Вывод предыдущего активного пункта основным цветом.
                Console.CursorLeft = positionX;
                Console.CursorTop = positionY + sum;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(items[previousIndex]);

                sum = 0;
                for (int i = 0; i <= currentIndex; i++)

                    sum += span[i];


                //Вывод активного пункта.
                Console.CursorLeft = positionX;
                Console.CursorTop = positionY + sum;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(items[currentIndex]);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                previousIndex = currentIndex;
                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        currentIndex++;
                        break;
                    case ConsoleKey.UpArrow:
                        currentIndex--;
                        break;
                    case ConsoleKey.Enter:
                        itemSelected = true;
                        break;
                }

                if (currentIndex == items.Length)
                    currentIndex = 0;
                else if (currentIndex < 0)
                    currentIndex = items.Length - 1;
            } while (!itemSelected);
            Console.CursorVisible = true;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            return currentIndex + 1;
        } // Позволяет быстро организовать меню, введя его пункты

        static int ReadListLength()
        {
            Console.Write("Введите длину циклического списка (>=1): ");
            return int.Parse(Console.ReadLine());
        }                   // Считывание длины списка

        static void Main(string[] args)
        {
            CyclicList list = new CyclicList(ReadListLength());
            while (true)
            {
                switch (Menu("Ввести длину списка заново", "Вывести список", "Найти элемент в списке (положения элементов в списке изменятся, и т.к. у списка нет ни начала ни конца, то индекс может быть больше его длины)", "Удалить элемент из списка", "Выход"))
                {
                    case 1: list = new CyclicList(ReadListLength()); break;
                    case 2: list.Show(); break;
                    case 3:
                        Console.Write("Введите индекс искомого элемента: ");
                        Console.WriteLine("\nЭлемент по заданному индексу был = "+ list.FindElByIndex(int.Parse(Console.ReadLine())-1));
                        break;
                    case 4:
                        Console.Write("Введите индекс элемента, который требуется удалить: ");
                        list.RemoveElByIndex(int.Parse(Console.ReadLine())-1);
                        Console.WriteLine("\nЭлемент по заданному индексу удалён");
                        break;
                    default: return;
                }
            }
        }               // Меню с вариантами действий
    }
}
