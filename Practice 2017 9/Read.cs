using System;

namespace Practice_2017_9
{
    class Read
    {
        public static int IntegerWithBounds(int lowerBound, int upperBound, string error = "Ошибка, введите значение в допустимых границах!")
        {
            do
            {
                bool ok;       // маркер выхода из цикла
                int input = 0; // переменная для хранения полученного числа

                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    ok = input >= lowerBound & input <= upperBound;
                }
                catch (FormatException)
                {
                    Console.Clear();
                    ok = false;
                }
                catch (OverflowException)
                {
                    Console.Clear();
                    ok = false;
                }
                if (ok) return input;
                Console.Clear();
                Console.WriteLine(error);
            } while (true);
        } // Считывание целых чисел по заданным границам (включая их), error - стандартное сообщение для ошибки

        public static int Integer(string error = "Ошибка, введите целочисленное значение")
        {
            return IntegerWithBounds(int.MinValue, int.MaxValue, error);
        }                                                    // Считывание целых чисел, error - стандартное сообщение для ошибки

        public static int NaturalWithZero(string error = "Ошибка, введите целочисленное значение больше нуля, либо равное ему")
        {
            return IntegerWithBounds(0, int.MaxValue, error);
        }               // Считывание целых чисел больше нуля, либо равное ему, error - стандартное сообщение для ошибки

        public static int Natural(string error = "Ошибка, введите целочисленное значение больше нуля")
        {
            return IntegerWithBounds(1, int.MaxValue, error);
        }                                        // Считывание целых чисел больше нуля, либо равное ему, error - стандартное сообщение для ошибки

        public static double Double(string error = "Ошибка, введите вещественное значение (целая от вещественной части отделяется запятой)")
        {
            Console.Clear();
            bool ok;          // маркер выхода из цикла
            double input = 0; // переменная для хранения полученного числа

            do
            {
                try
                {
                    ok = true;
                    input = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine(error);
                    ok = false;
                }
                catch (OverflowException)
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка, число слишком большое/маленькое");
                    ok = false;
                }
            } while (!ok);

            return input;
        }  // Считывание целых чисел с проверкой, i и length для красивого сообщения о вводе, error - стандартное сообщение для ошибки

        public static string NotNullString(string message = "Введите не пустую строку")
        {
            Console.WriteLine(message);
            string notNullString;
            while (true)
            {
                notNullString = Console.ReadLine();
                if (notNullString == null) Console.WriteLine("Ошибка, " + message.ToLower() + "!");
                else break;
                Console.Clear();
            }
            Console.Clear();
            return notNullString;
        }                                                       // Считывание не пустой строки
    }
}
