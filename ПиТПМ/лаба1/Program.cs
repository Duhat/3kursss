using System;

namespace Museum
{
    public class Museum
    {
        private Exp[] museums;
        private int num;

        public Museum()
        {
            museums = new Exp[0];
            num = 0;
        }

        public void Add(Exp exp)
        {
            // Проверка на уникальность номера
            foreach (var existingExp in museums)
            {
                if (existingExp.Num == exp.Num)
                {
                    Console.WriteLine("Экспонат с таким номером уже существует. Попробуйте другой номер.");
                    return;
                }
            }

            num++;
            Exp[] newExps = new Exp[num];
            for (int i = 0; i < num - 1; i++)
                newExps[i] = museums[i];

            museums = newExps;
            museums[num - 1] = exp;
            Console.WriteLine("Экспонат добавлен.");
        }

        public void RemoveLast()
        {
            if (num == 0)
            {
                Console.WriteLine("Нет экспонатов для удаления.");
                return;
            }

            Exp[] new_arr = new Exp[num - 1];
            for (int i = 0; i < num - 1; i++)
            {
                new_arr[i] = museums[i];
            }

            museums = new_arr;
            num--;
            Console.WriteLine("Последний экспонат удален.");
        }

        public void ShowAll()
        {
            if (num == 0)
            {
                Console.WriteLine("Нет экспонатов для отображения.");
                return;
            }

            for (int i = 0; i < num; i++)
            {
                museums[i].Print();
            }
        }

        public int GetLen() => num;

        public void Clear()
        {
            if (num == 0)
            {
                Console.WriteLine("Нет экспонатов для удаления.");
                return;
            }

            museums = new Exp[0];
            num = 0;
            Console.WriteLine("Все экспонаты удалены.");
        }
    }

    public class Exp
    {
        private static readonly int MaxAttempts = 3;

        public string Num { get; }
        public string Name { get; }
        public string Era { get; }
        public string Description { get; }

        public Exp()
        {
            Num = ReadUniqueNum();
            Name = ReadName();
            Console.Write("\tЭпоха : ");
            Era = Console.ReadLine();
            Description = ReadDescription();
        }

        private string ReadUniqueNum()
        {
            string num = string.Empty;
            int attempts = 0;

            while (attempts < MaxAttempts)
            {
                Console.Write("\tИдентификатор (только цифры) : ");
                num = Console.ReadLine();

                if (IsDigits(num))
                {
                    return num;
                }
                else
                {
                    Console.WriteLine("Номер должен содержать только цифры. Попробуйте еще раз.");
                }

                attempts++;
            }

            throw new Exception("Превышено максимальное количество попыток ввода номера.");
        }

        private bool IsDigits(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        private string ReadName()
        {
            string name = string.Empty;
            int attempts = 0;

            while (attempts < MaxAttempts)
            {
                Console.Write("\tНазвание (максимум 10 символов) : ");
                name = Console.ReadLine();

                if (name.Length <= 10)
                {
                    return name;
                }
                else
                {
                    Console.WriteLine("Название должно содержать не более 10 символов. Попробуйте еще раз.");
                }

                attempts++;
            }

            throw new Exception("Превышено максимальное количество попыток ввода названия.");
        }

        private string ReadDescription()
        {
            string description = string.Empty;
            int attempts = 0;

            while (true)
            {
                Console.Write("\tОписание (минимум 7 символов) : ");
                description = Console.ReadLine();

                if (description.Length >= 7)
                {
                    return description;
                }
                else
                {
                    Console.WriteLine("Описание должно содержать не менее 7 символов. Попробуйте еще раз.");
                }

                attempts++;
                if (attempts >= MaxAttempts)
                {
                    Console.WriteLine("Пожалуйста хватит ошибаться. Написано ведь.");
                }
            }
        }

        public void Print()
        {
            Console.WriteLine($"\tНомер : {Num}\n\tНазвание : {Name}\n\tЭпоха : {Era}\n\tОписание : {Description}\n");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Museum museum = new Museum();
            while (true)
            {
                Console.WriteLine("1. Добавить экспонат \n" +
                                  "2. Удалить последний экспонат\n" +
                                  "3. Показать все экспонаты\n" +
                                  "4. Показать количество\n" +
                                  "5. Удалить все экспонаты\n" +
                                  "6. Завершить");

                string answ = Console.ReadLine();
                switch (answ)
                {
                    case "1":
                        museum.Add(new Exp());
                        break;

                    case "2":
                        museum.RemoveLast();
                        break;

                    case "3":
                        museum.ShowAll();
                        break;

                    case "4":
                        Console.WriteLine($"Количество экспонатов: {museum.GetLen()}");
                        break;

                    case "5":
                        museum.Clear();
                        break;

                    case "6":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("\tНеизвестная команда");
                        break;
                }
            }
        }
    }
}
