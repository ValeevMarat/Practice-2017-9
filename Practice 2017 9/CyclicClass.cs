using System;

namespace Practice_2017_9
{
    class CyclicList
    {
        private static Element _currentEl;                                                   // Текущий элемент
        private int _length;                                                                 // Длина циклического списка

        public CyclicList(int length)
        {
            _length = length;
            _currentEl = new Element(length);
            _currentEl = CreateList(_currentEl, _currentEl, length-1);
        }

        private Element CreateList(Element first, Element current, int length)
        {
            // Первый элемент, текущий, значение для присваивания и длина списка
            if (length==0)
            {
                current.Next = first; // Соединяем конец с началом
                return first; // Делаем, так, чтобы 1 была в конце
            }
            current.Next = new Element(length);
            return CreateList(first, current.Next, length-1);
        } // Рекурсивно создаёт циклический список

        public void Show()
        {
            if (_currentEl == null)
            {
                Console.WriteLine("Список пуст");
                return;
            }
            int value = _currentEl.Value;
            Console.Write(value + " ");
            Element current = _currentEl.Next;

            while (value != current.Value)
            {
                Console.Write(current.Value + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }                                                                // Выводит список на экран

        public int FindElByIndex(int index)
        {
            index = index%_length; // Убираем лишние прокрутки
            if (index == 0)
                return _currentEl.Value;

            _currentEl = _currentEl.Next;

            return FindElByIndex(index - 1);
        }                                               // Рекурсивный поиск элемента по индексу

        public void RemoveElByIndex(int index)
        {
            index = index%_length;                                    // Убираем лишние прокрутки
            if (index == 0)
            {
                if (_currentEl == _currentEl.Next) _currentEl = null; // Если список длины один, то очищаем его
                else
                {
                    _currentEl.Value = _currentEl.Next.Value;
                    _currentEl.Next = _currentEl.Next.Next;
                }
                _length--;
                return;
            }
            _currentEl = _currentEl.Next;

            RemoveElByIndex(index - 1);
        }                                            // Удаление элемента по индексу
    }
}
