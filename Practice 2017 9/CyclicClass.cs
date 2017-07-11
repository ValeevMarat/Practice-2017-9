using System;

namespace Practice_2017_9
{
    class CyclicList
    {
        private static Element _currentEl;                                                   // Текущий элемент
        public int Length;                                                                 // Длина циклического списка

        public CyclicList(int length)
        {
            Length = length;
            _currentEl = new Element(length);
            _currentEl = CreateList(_currentEl, _currentEl, length-1);
        }

        private Element CreateList(Element first, Element current, int length)
        {
            // Первый элемент, текущий, значение для присваивания и длина списка
            if (length==0)
            {
                current.Next = first; // Соединяем конец с началом
                return first;         // Делаем, так, чтобы 1 была в конце
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

        public int FindElIndexByValue(int value)
        {
            return FindElIndex(_currentEl, 1, value);
        }                                               // Рекурсивный поиск элемента по индексу

        private int FindElIndex(Element el, int index, int value)
        {
            if (el.Value == value) return index;

            if (index == Length) return -1;

            el = el.Next;
            return FindElIndex(el, index + 1, value);
        }

        public int RemoveElByValue(int value)
        {
            return RemoveEl(1, value);
        }                                            // Удаление элемента по индексу

        private int RemoveEl(int index, int value)
        {
            if (value == _currentEl.Value)
            {
                if (_currentEl == _currentEl.Next) _currentEl = null; // Если список длины один, то очищаем его
                else
                {
                    _currentEl.Value = _currentEl.Next.Value;
                    _currentEl.Next = _currentEl.Next.Next;
                }
                Length--;
                return index;
            }
            if (index == Length) return -1;
            
            _currentEl = _currentEl.Next;

            return RemoveEl(index+1,value);
        }
    }
}
