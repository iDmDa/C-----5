//Задача 36: Задайте одномерный массив, заполненный случайными числами. 
//Найдите сумму элементов, стоящих на нечётных позициях.
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

        return a_int;
    }
}

int[] create_int_array (int len, int diapazon_start, int diapazon_end) {
    int[] result_array = new int[len];
    Random rnd = new Random();
    for(int i = 0; i < len; i++) {
        result_array[i] = rnd.Next(diapazon_start, diapazon_end + 1);
    }
    return result_array;
}

msg_style("Введите размер массива (для выхода введите 'q')", "Blue");
int len = enter_number ("Размер: ");

int[] randomArray = create_int_array(len, 1, 9);

int notEvenSumm = 0;

for(int i = 0; i < len; i++) {
    if(i%2 == 1) notEvenSumm += randomArray[i];
}


msg_style($"{string.Join(", ", randomArray)} -> {notEvenSumm}", "Green");
