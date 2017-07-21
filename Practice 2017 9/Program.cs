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
        }   // Позволяет быстро организовать меню, введя его пункты

        static CyclicList CreateNewCyclicList()
        {
            Console.Write("Введите длину циклического списка (>=1 и <=10000): ");
            return new CyclicList(Read.IntegerWithBounds(1, 10000, "Ошибка, введите значения между 1 и 10000, включая границы!")); // Ограничения из-за StackOverflow
        }         // Создаёт новый цикл. список

        static void FindElIndexByValue(CyclicList list)
        {                             // Список, в котором ведётся поиск
            if (list.Length == 0)                               // Проверка на пусто список
            {
                Console.WriteLine("Ошибка, список пуст!");
                return;
            }
            Console.Write("Введите значение искомого элемента (>=1): ");
            int elIndex = list.FindElIndexByValue(Read.Natural());

            Console.WriteLine("\nЭлемент по заданному значению " + (elIndex == -1
                ? "не находится в списке"                       // Если вышел код ошибки (-1), то элемента в списке нет
                : "находится на " + elIndex + "-ой позиции"));  // Иначе выводится его позиция
        } // Находит индекс элемента в циклическом списке по его значению

        static void DelElByValue(CyclicList list)
        {                     // Список, в котором происходит удаление
            if (list.Length == 0)                                   // Проверка на пустой список
            {
                Console.WriteLine("Ошибка, список пуст!");
                return;
            }
            
            Console.Write("Введите значение элемента, который требуется удалить (>=1): ");
            int elIndex = list.RemoveElByValue(Read.Natural());

            Console.WriteLine("\nЭлемент по заданному значению " + (elIndex == -1
                ? "не находится в списке"                            // Если вышел код ошибки (-1), то элемента в списке нет
                : "удалён, элемент был на "+elIndex+"-ой позиции")); // Иначе выводится сообщение о его удалении, и позиция на которой он находился
        }       // Удаляет элемент в циклическом списке по значению
        
        static void Main(string[] args)
        {
            CyclicList list = CreateNewCyclicList();
            while (true)
            {
                switch (Menu("Ввести длину списка заново", "Вывести список", "Найти элемент в списке", "Удалить элемент из списка", "Выход"))
                {
                    case 1: list = CreateNewCyclicList(); break; // Создаёт новый цикл. список
                    case 2: list.Show(); break;                  // Выводит список на экран
                    case 3: FindElIndexByValue(list); break;     // Находит индекс элемента в циклическом списке по его значению
                    case 4: DelElByValue(list); break;           // Удаляет элемент в циклическом списке по значению
                    default: return;
                }
            }
        }                 // Меню с вариантами действий
    }
}
