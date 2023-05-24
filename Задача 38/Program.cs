//Задача 38: Задайте массив вещественных чисел. Найдите разницу между максимальным и минимальным элементов массива.
//Диапазон [-10, 10]. Обратите внимание на вещественных чисел 
#nullable disable

var cons_color = new Dictionary<string, int>();
for (int i = 0; i < 16; i++) cons_color.Add(((ConsoleColor)i).ToString(), i);

void msg_style (string message, string status = "Green") {
    //Black, DarkBlue, DarkGreen, DarkCyan, 
    //DarkRed, DarkMagenta, DarkYellow, Gray, 
    //DarkGray, Blue, Green, Cyan, 
    //Red, Magenta, Yellow, White

    Console.ForegroundColor = (ConsoleColor)cons_color[status];
    Console.WriteLine(message);
    Console.ForegroundColor = ConsoleColor.Gray;
}

int enter_number (string info) {
    for(;;) {

        Console.Write(info);
        string a = Console.ReadLine();

        if(a.ToLower() == "q") System.Environment.Exit(0);

        if(!Int32.TryParse(a, out int a_int)) {
            msg_style("Ошибка! Введено не число!", "DarkRed");
            continue;
        };

        if(a_int <= 0 ) {
            msg_style("Ошибка! Введен неверный размер массива!", "DarkRed");
        continue;
        };

        if(a_int <= 1 ) {
            msg_style("Ошибка! Для сравнения необходимо не менее 2х элементов массива!", "DarkRed");
        continue;
        };

        return a_int;
    }
}

double[] create_array (int len, double diapazon_start, double diapazon_end) {
    double[] result_array = new double[len];
    Random rnd = new Random();
    for(int i = 0; i < len; i++) {
        result_array[i] = Math.Round(rnd.NextDouble() * (diapazon_start - diapazon_end) + diapazon_end, 2);
    }
    return result_array;
}

double[] min_max (double[] array) {
    double min = array[0], max = array[0];
    double[] result = new double[2];
    foreach (double item in array)
    {
        if(min > item) min = item;
        if(max < item) max = item;
    }
    result[0] = min;
    result[1] = max;
    return result;
}

msg_style("Введите размер массива (для выхода введите 'q')", "Blue");
int len = enter_number ("Размер: ");

double[] randomArray = create_array(len, -10, 10);
double[] min_max_result = min_max(randomArray);

msg_style($"{string.Join(", ", randomArray)} -> {min_max_result[0]}...{min_max_result[1]} -> {min_max_result[1] - min_max_result[0]}", "Green");
