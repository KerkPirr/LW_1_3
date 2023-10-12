//Задание 3.
//Создать двунаправленный связный список, содержащий 14 целых чисел из интервала (-8, 35).
//Вывести список.
//Реализовать процедуру/функцию, которая удаляет элемент после последнего четного элемента.
//Автор: Сушко Алексей
//Версия 1.0  от 12.10.2023

namespace Дунаправленный_список {
class Program
    {
        static void Main()
        {
            LinkedList<int> ints = new LinkedList<int>();
            do
            {
                Console.Clear();
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1 - Заполнить список случайными значениями");
                Console.WriteLine("2 - добавить узел со значением в начало списка;");
                Console.WriteLine("3 - добавить узел со значением в конец списка;");
                Console.WriteLine("4 - добавить узел со значением после определённого элемента;");
                Console.WriteLine("5 - добавить узел со значением перед определённым элементом;");
                Console.WriteLine("6 - вывести количество узлов;");
                Console.WriteLine("7 - найти узел с заданным значением;");
                Console.WriteLine("8 - удалить узел с указанным значением;");
                Console.WriteLine("9 - удалить первый узел;");
                Console.WriteLine("10 - удалить последний узел;");
                Console.WriteLine("11 - удалить узел после последнего четного элемента");
                Console.WriteLine("12 - удалить все узлы;");
                Console.WriteLine("13 - выход.");
                int.TryParse(Console.ReadLine(), out int a);

                switch (a)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("В список добавлены следующие значения:");
                        FillingWithRand(ints);
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Введите число, которое нужно добавить:");
                        if(int.TryParse(Console.ReadLine(), out int val)) 
                        {
                            ints.AddFirst(val);
                            Console.WriteLine($"Число {val} добавлено в начало списка.");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Введеное значение не может быть добавлено в список!");
                            Console.ReadLine();
                            goto case 2;
                        }
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Введите число, которое нужно добавить:");
                        if (int.TryParse(Console.ReadLine(), out  val))
                        {
                            ints.AddLast(val);
                            Console.WriteLine($"Число {val} добавлено в конец списка.");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Введеное значение не может быть добавлено в список!");
                            Console.ReadLine();
                            goto case 3;
                        }
                        break;

                    case 4:
                        Console.Clear();
                        if (ints.Count > 0)
                        {
                            Console.WriteLine("Введите значение, перед которым нужно вставить новое число:");
                            if(int.TryParse(Console.ReadLine(),out val))
                            {
                                LinkedListNode<int> node = ints.Find(val);
                                if (node != null)
                                {
                                    Console.WriteLine("Введите число, которое нужно добавить:");
                                    if(int.TryParse(Console.ReadLine(),out int newVal))
                                    {
                                        ints.AddBefore(node, newVal);
                                        Console.WriteLine($"Число {newVal} добавлено перед элементом {val}.");
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Введеное значение не может быть добавлено в список!");
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Введенное значение отсутсвует в списке!");
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Введенное значение не может быть найдено в списке!");
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Список пуст!");
                        }

                        break;
                    case 5:
                        Console.Clear();
                        if (ints.Count > 0)
                        {
                            Console.WriteLine("Введите значение, после которым нужно вставить новое число:");
                            if (int.TryParse(Console.ReadLine(), out val))
                            {
                                LinkedListNode<int> node = ints.FindLast(val);
                                if (node != null)
                                {
                                    Console.WriteLine("Введите число, которое нужно добавить:");
                                    if (int.TryParse(Console.ReadLine(), out int newVal))
                                    {
                                        ints.AddAfter(node, newVal);
                                        Console.WriteLine($"Число {newVal} добавлено в после элемента {val}");
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Введеное значение не может быть добавлено в список!");
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Введенное значение отсутсвует в списке!");
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Введенное значение не может быть найдено в списке!");
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Список пуст!");
                        }

                        break;
                    case 6:
                        Console.Clear();
                        if(ints.Count > 0)
                        {
                            Console.Clear();
                            Console.WriteLine($"Список содержит {ints.Count} элементов");
                            Console.WriteLine("Элементы списка:");
                            foreach(int i in ints)
                            {
                                Console.WriteLine(i);
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Список пуст!");
                        }
                        break;
                    case 7:
                        Console.Clear();
                        if (ints.Count > 0)
                        {
                            Console.WriteLine("Введите искомое значение:");
                            if(int.TryParse(Console.ReadLine(),out val))
                            {
                                int count = CountOccurrenes(ints, val);
                                Console.Clear();
                                Console.WriteLine($"Значение {val} встречается в списке {count} раз/а. ");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Невозможно найти значение в списке!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Список пуст!");
                        }
                        break;
                    case 8:
                        Console.Clear();
                        if (ints.Count > 0)
                        {
                            Console.WriteLine("Введите значение, которое нужно удалить:");
                            if (int.TryParse(Console.ReadLine(), out val))
                            {
                                Console.Clear();
                                if (ints.Contains(val) && CountOccurrenes(ints, val) > 1)
                                {
                                    Console.WriteLine($"Удалить все узлы содержащие {val}?\n1 - да\nЛюбая другая клавиша - удаления первого встреченного узла, содержащего это значение.");
                                    int.TryParse(Console.ReadLine(), out int swVal);
                                    Console.Clear();
                                    switch (swVal)
                                    {
                                        case 1:
                                            while (ints.Contains(val))
                                            {
                                                ints.Remove(val);
                                            }
                                            Console.WriteLine($"Все узлы содержащие {val} удалены");
                                            break;
                                        default:
                                            ints.Remove(val);
                                            Console.WriteLine($"Удален первый узел, содержащий {val}");
                                            break;
                                    }
                                }
                                else if (ints.Contains(val))
                                {
                                    ints.Remove(val);
                                    Console.WriteLine($"Узел, содержащий {val} удален");
                                }
                                else
                                {
                                    Console.WriteLine($"Узел, содержащий {val} отсутсвует!");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Невозможно удалить узел, с указанным значением!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Список пуст!");
                        }

                        break;
                    case 9:
                        Console.Clear();
                        if (ints.Count > 0)
                        {
                            ints.RemoveFirst();
                            Console.WriteLine("Первый узел в списке удален");
                        }
                        else
                        {
                            Console.WriteLine("Список пуст!");
                        }
                        break;
                    case 10:
                        Console.Clear();
                        if (ints.Count > 0)
                        {
                            ints.RemoveLast();
                            Console.WriteLine("Последний узел в списке удален");
                        }
                        else
                        {
                            Console.WriteLine("Список пуст!");
                        }
                        break;
                    case 11:
                        Console.Clear();
                        if (ints.Count > 0)
                        {
                            RemoveAfterLastEven(ints);
                        }
                        else
                        {
                            Console.WriteLine("Список пуст!");
                        }
                        break;
                    case 12: 
                        Console.Clear();
                        Console.WriteLine("Вы действительно хотите очистить списко?\n1 - Да\nЛюбая другая кнопка - Нет");
                        int.TryParse(Console.ReadLine(), out int sw);
                        Console.Clear();
                        switch (sw)
                        {
                            case 1:
                                ints.Clear();
                                Console.WriteLine("Список очищен!");
                                break;
                            default:
                                Console.WriteLine("Отмена очистки списка");
                                break;
                        }
                        break;
                    case 13:
                        Console.Clear();
                        Console.WriteLine("Для выхода нажмите ESC.");
                        break;
                    default:
                        Console.WriteLine("Ошибка ввода! Попробуйте ещё раз.");
                        break;



                }



            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
        static void FillingWithRand(LinkedList<int> list)
        {
            Random random = new Random();
            list.Clear();
            for (int i = 0; i < 14; i++)
            {
                int randomInt = random.Next(-8, 36);
                list.AddLast(randomInt);
                Console.WriteLine(randomInt.ToString());
            }
        }
        static int CountOccurrenes(LinkedList<int> linkedList, int targetVal)
        {
            int count = 0;
            LinkedListNode<int> currentNode = linkedList.First;
            while(currentNode != null)
            {
                if(currentNode.Value == targetVal) 
                {
                    count++;
                }
                currentNode = currentNode.Next;
            }
            return count;
        }
        static void RemoveAfterLastEven(LinkedList<int> linkedList)
        {
            bool Flag = true;
            LinkedListNode<int> currentNode = linkedList.Last;
            while(currentNode != null && Flag)
            {
                if(currentNode.Value % 2 == 0 && currentNode.Value != 0 && currentNode.Next != null) 
                {
                    linkedList.Remove(currentNode.Next);
                    Flag = false;
                    Console.WriteLine("Узел после последнего четного элемента удален");
                }
                currentNode = currentNode.Previous;
            }
            if (Flag)
            {
                Console.WriteLine("Узел не может быть удален!");
            }
        }

    }
}