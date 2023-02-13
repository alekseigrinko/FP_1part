start();

void start()
{
    string?[] array = new string[0];
    while (true)
    {
        menu();
        string? str = Console.ReadLine();
        if (!string.IsNullOrEmpty(str) && int.TryParse(str, out int command))
        {
            if (command == 1)
            {
                Console.WriteLine("Введите знаечние. Значение должно быть от 3 символов и не содержать пробелы");
                string? check = Console.ReadLine();
                array = addPoint(check, array.Length, array);
            }
            else if (command == 0)
            {
                Console.WriteLine("Выход из меню.");
                Console.WriteLine("--------------");
                Console.WriteLine($"Получился следующий массив значений: [{String.Join(", ", array)}]");
                break;
            }
            else
            {
                Console.WriteLine("Некорректная команда, попробуйте ещё раз.");
            }
        }
        else
        {
            Console.WriteLine("Некорректная команда, попробуйте ещё раз.");
        }
    }
}

void menu()
{
    Console.WriteLine("--------------------------------------------");
    Console.WriteLine("Введите команду:");
    Console.WriteLine("1 - Добавить значение в массив");
    Console.WriteLine("0 - Выход");
    Console.WriteLine("--------------------------------------------");
}

string?[] addPoint(string? check, int count, string?[] array)
{
    if (checkPoint(check))
    {
        string?[] newArray = new string[count + 1];
        array.CopyTo(newArray, 0);
        newArray[count] = check;
        return newArray;

    }
    else
    {
        return array;
    }
}

bool checkPoint(string? check)
{
    if (string.IsNullOrEmpty(check))
    {
        Console.WriteLine("Введено пустое значение!");
        return false;
    }
    else if (check.Contains(" "))
    {
        Console.WriteLine("Введенное значение содержит пробел!");
        return false;
    }
    else if (check.Length < 3)
    {
        Console.WriteLine("Введенное значение содержит меньше 3 символов и не будет сохранено в массив!");
        return false;
    }
    else
    {
        Console.WriteLine($"Значение {check} принято для добавления в массив!");
        return true;
    }
}