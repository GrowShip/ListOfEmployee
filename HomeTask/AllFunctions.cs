using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace HomeTask
{
    struct Class11
    {
        /// <summary>
        /// Печатает меню
        /// </summary>
        public static void Welcome()
        {
            string[][] initialPrint = new string[8][];
            for (int i = 0; i < initialPrint.Length; i++) initialPrint[i] = new string[2];
            initialPrint[0][0] = "Хотите посмотреть список сотрудников       "; initialPrint[0][1] = "[нажмите 1]";
            initialPrint[1][0] = "Добавить сотрудника                        "; initialPrint[1][1] = "[нажмите 2]";
            initialPrint[2][0] = "Удалить сотрудника                         "; initialPrint[2][1] = "[нажмите 3]";
            initialPrint[3][0] = "Отредактировать информацию о сотруднике    "; initialPrint[3][1] = "[нажмите 4]";
            initialPrint[4][0] = "Посмотреть записи в выбранном диапозоне дат"; initialPrint[4][1] = "[нажмите 5]";
            initialPrint[5][0] = "Проверить существует ли уже файл           "; initialPrint[5][1] = "[нажмите 6]";
            initialPrint[6][0] = "Отсортировать файл                         "; initialPrint[6][1] = "[нажмите 7]";
            initialPrint[7][0] = "Выход                                      "; initialPrint[7][1] = "[нажмите любую кнопку]";
            Console.WriteLine("\n                 Действие                      \t   Кнопка   \t");
            for (int i = 0; i < initialPrint.GetLength(0); i++)
            {
                Console.WriteLine("{0}\t{1}\t", initialPrint[i][0], initialPrint[i][1]);
            }
        }

        /// <summary>
        /// Проверяет наличие файла
        /// </summary>
        public static void IsFileExist()
        {
            if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "infoData.txt"))) Console.WriteLine("Файл infoData.txt существует \n");
            else Console.WriteLine("Файл infoData.txt не существует");
        }

        /// <summary>
        /// Запись
        /// </summary>
        /// <param name="info"></param>
        public static void WritingFile(string info)
        {
            string file = Path.Combine(Directory.GetCurrentDirectory(), "infoData.txt");
            File.AppendAllText(file, info);
            Console.WriteLine("Сотрудник добавлен");
            return;
        }

        /// <summary>
        /// Перезапись
        /// </summary>
        /// <param name="info">Текст который нежно перезаписать</param>
        public static void RewritingFile(string info)
        {
            string file = Path.Combine(Directory.GetCurrentDirectory(), "infoData.txt");
            File.WriteAllText(file, info);
            return;
        }

        /// <summary>
        /// Чтение
        /// </summary>
        public static void ReadingFile()
        {
            Console.WriteLine($"{"ID",6} {"Дата и Время",22} {"Фамилия",10} " +
                              $"{"Имя",7} {"Отчество",12} {"Возраст",8} {"Рост",5} " +
                              $"{"Дата рождения",14} {"Место рождения",16}");
            string[] textFile = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "infoData.txt"));
            foreach (var e in textFile)
            {
                string[] arrayFile = e.Split('#', '\n');
                Console.Write($"{arrayFile[0],6} {arrayFile[1],22} {arrayFile[2],10}" +
                              $"{arrayFile[3],7} {arrayFile[4],12} {arrayFile[5],8}" +
                              $"{arrayFile[6],5} {arrayFile[7],14} {arrayFile[8],16}"); Console.Write('\n');
            }
            return;
        }

        /// <summary>
        /// Из файла в двумерный зубчатый массив типа [][] для поиска данных
        /// </summary>
        /// <returns></returns>
        public static string[][] FromFileToArray()
        {
            string[] textFile1 = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "infoData.txt"));
            string[][] choiceEmpl = new string[textFile1.Length][];

            for (int i = 0; i < textFile1.Length; i++)
            {
                string[] transition = textFile1[i].Split('#', '\n');
                choiceEmpl[i] = new String[9];
                for (int j = 0; j < 9; j++) choiceEmpl[i][j] = transition[j];
            }
            return choiceEmpl;
        }

        /// <summary>
        /// Из двумерного зубчатого типа [][] в строку
        /// </summary>
        /// <param name="array">Массив типа [][] из которого</param>
        /// <param name="text">текст из массива типа [][]</param>
        public static void FromDoubleArrayToString(string[][] array, out string text)
        {
            string newtext = string.Empty;
            for (int i = 0; i < array.Length; i++)
            {
                string line = array[i][0];
                for (int j = 1; j < 9; j++)
                {
                    line += "#" + array[i][j];
                }
                line += "\n";
                newtext += line;
            }
            text = newtext;
        }

        /// <summary>
        /// Поиск записи по введенной фамилии или ID
        /// </summary>
        /// <param name="deleting"></param>
        public static void SearchingID(string searching, out int index)
        {
            int indexOfDeleting = 0;
            int marker = -1;
            string[][] choiceEmpl = FromFileToArray();

            for (int i = 0; i < choiceEmpl.Length; i++)
            {
                // Определение индекса введеного ID или фамилии
                marker = Array.IndexOf(choiceEmpl[i], searching);
                if (marker != -1)
                {
                    indexOfDeleting = i;
                    break;
                }
            }
            index = indexOfDeleting;
        }

        /// <summary>
        /// Удаление строки по индексу
        /// </summary>
        /// <param name="index">Индекс строки удаления</param>
        public static void DeletingID(int index)
        {
            char keyD = 'д';
            string[] textFile1 = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "infoData.txt"));
            List<string> listA = ((string[])textFile1).ToList();

            string lineDel = string.Join(" ", listA[index].Split('#').ToArray());
            Console.WriteLine($"Хотите удалить \n{lineDel} \nд/н?");

            char key = Console.ReadKey(true).KeyChar;
            if (keyD == key)
            {
                listA.RemoveAt(index);
                string newList = string.Empty;
                foreach (var e in listA) newList += Convert.ToString(e) + "\n";
                RewritingFile(newList);
            }
            Console.WriteLine("Сотрудник удален");
        }

        /// <summary>
        ///  Изменение информации о сотруднике
        /// </summary>
        /// <param name="whatChange">Какую информацию поменять</param>
        /// <param name="index">Сотрудник</param>
        public static void ChangeInfo(string whatChange, int index)
        {
            string[][] transitionArray = FromFileToArray();
            string[] lineArray = new string[9];
            string newText = string.Empty;
            for (int i = 0; i < 9; i++) lineArray[i] = transitionArray[index][i];
            switch (whatChange)
            {
                case "id":
                    Console.Write("Введите новое ID сотрудника: ");
                    lineArray[0] = Console.ReadLine();
                    break;
                case "фамилия":
                    Console.Write("На какую фамилию сменить: ");
                    string name2 = Console.ReadLine();
                    lineArray[2] = FirstLetterUp(name2);
                    break;
                case "имя":
                    Console.Write("На какое имя сменить: ");
                    string name1 = Console.ReadLine();
                    lineArray[3] = FirstLetterUp(name1);
                    break;
                case "отчество":
                    Console.Write("На какое отчество сменить: ");
                    string name3 = Console.ReadLine();
                    lineArray[4] = FirstLetterUp(name3);
                    break;
                case "рост":
                    Console.Write("Введите рост сотрудника: ");
                    lineArray[6] = Console.ReadLine();
                    break;
                case "дата рождения":
                    Console.Write("Введите дату рождение сотрудника: ");
                    lineArray[7] = Console.ReadLine();
                    break;
                case "место рождения":
                    Console.Write("Введите место рождения сотрудника: ");
                    string city = Console.ReadLine();
                    lineArray[8] = FirstLetterUp(city);
                    break;
                default:
                    Console.WriteLine("Вы ничего не изменили");
                    break;
            }
            for (int i = 0; i < 9; i++) transitionArray[index][i] = lineArray[i];
            FromDoubleArrayToString(transitionArray, out newText);
            RewritingFile(newText);
            Console.WriteLine($"{whatChange} изменена");
        }

        /// <summary>
        /// Добавление нового сотрудника
        /// </summary>
        /// <returns></returns>
        public static string AddNewID()
        {
            #region old version 
            //string infoID = string.Empty;
            //Console.Write("Введите ID сотрудника - ");
            //infoID = Console.ReadLine() + "#";
            //string date = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            //infoID += date + "#";
            //Console.Write("Введите Ф.И.О сотрудника - ");
            //string[] arrfullName = (Console.ReadLine()).Split(' ');
            //string name1 = arrfullName[0];
            //string name2 = arrfullName[1];
            //string name3 = arrfullName[2];
            //infoID += name1 + "#" + name2 + "#" + name3 + "#";
            //Console.Write("Введите возраст - ");
            //infoID += Console.ReadLine() + "#";
            //Console.Write("Введите рост сотрудника - ");
            //infoID += Console.ReadLine() + "#";
            //Console.Write("Введите дату рождения сотрудника - ");
            //infoID += Console.ReadLine() + "#";
            //Console.Write("Введите место рождения сотрудника - ");
            //infoID += Console.ReadLine() + "\n";
            //Console.WriteLine("\n");
            //return infoID;
            #endregion

            Console.Write("Введите ID сотрудника - ");
            int ID = int.Parse(Console.ReadLine());
            DateTime today = DateTime.Now;
            Console.Write("Введите фамилию сотрудника - ");
            string secondName = Console.ReadLine();
            Console.Write("Введите имя сотрудника - ");
            string firstName = Console.ReadLine();
            Console.Write("Введите отчество сотрудника - ");
            string middleName = Console.ReadLine();
            Console.Write("Введите рост сотрудника - ");
            int height = int.Parse(Console.ReadLine());
            Console.Write("Введите день рождение сотрудника - ");
            DateTime birthday = DateTime.Parse(Console.ReadLine());
            int age = (int.Parse(today.ToString("yyyymmdd")) - int.Parse(birthday.ToString("yyyymmdd"))) / 10000;
            Console.Write("Введите место рождения сотрудника - ");
            string birthcity = Console.ReadLine();


            Employees list1 = new Employees()
            {
                ID = ID,
                DataAdd = DateTime.Now,
                SecondName = secondName,
                FirstName = firstName,
                MiddleName = middleName,
                Height = height,
                BirthDay = birthday,
                Age = age,
                BirthCity = birthcity
            };

            string infoID = $"{list1.ID}#{list1.DataAdd}" +
                            $"#{list1.SecondName}#{list1.FirstName}#{list1.MiddleName}" +
                            $"#{list1.Age}#{list1.Height}#{list1.BirthDay.ToShortDateString()}#{list1.BirthCity}\n";

            Console.WriteLine(infoID);
            Console.ReadKey();
            return infoID;
        }

        /// <summary>
        /// Делает текст строки с большой буквы
        /// </summary>
        /// <param name="text">Строка в которой нужно первую букву сделать заглавной </param>
        /// <returns></returns>
        public static string FirstLetterUp(string text)
        {
            text = text.ToLower();
            return text = text.Substring(0, 1).ToUpper() + text.Substring(1);
        }

        /// <summary>
        /// Выбор сортировки и вводные параметры
        /// </summary>
        /// <param name="text">По чему сортировать(ID или Даты)</param>
        public static void WhichSort(string text)
        {
            char keysort;
            if (text == "id")
            {
                Console.WriteLine("Хотите отсортировать по возростанию(1) или убыванию(2) ID?");
                if (Console.ReadKey(true).KeyChar == '1') keysort = '1';
                else keysort = '2';
                SortFileID(keysort);
            }
            else if (text == "датам")
            {
                Console.WriteLine("Хотите отсортировать по возростанию(1) или убыванию(2) дат добавления записей?");
                if (Console.ReadKey(true).KeyChar == '1') keysort = '1';
                else keysort = '2';
                SortFileDate(keysort);
            }
        }

        /// <summary>
        /// Сортировка файла по ID записи
        /// </summary>
        public static void SortFileID(char keySort)
        {
            string[][] initArray = FromFileToArray();
            int colomn = 0;
            int nose = 0;
            int tail = initArray.Length;
            char key1 = '1';
            char key2 = '2';
            if (keySort == key1)
            {
                while (nose != initArray.Length)
                {
                    for (int i = 0; i < tail; i++)
                    {
                        if (int.Parse(initArray[nose][colomn]) >= int.Parse(initArray[i][colomn])) continue;
                        else
                        {
                            string[] transition = initArray[nose];
                            initArray[nose] = initArray[i];
                            initArray[i] = transition;
                        }
                    }
                    nose++;
                }
                string text = string.Empty;
                FromDoubleArrayToString(initArray, out text);
                RewritingFile(text);
            }
            else if (keySort == key2)
            {
                while (nose != initArray.Length)
                {
                    for (int i = 0; i < tail; i++)
                    {
                        if (int.Parse(initArray[nose][colomn]) <= int.Parse(initArray[i][colomn])) continue;
                        else
                        {
                            string[] transition = initArray[nose];
                            initArray[nose] = initArray[i];
                            initArray[i] = transition;
                        }
                    }
                    nose++;
                }
                string text = string.Empty;
                FromDoubleArrayToString(initArray, out text);
                RewritingFile(text);
            }
            else Console.WriteLine("Ты должен был выбрать между цифрой 1 или 2!");
        }

        /// <summary>
        /// Сортировка файла по датам добавления записи
        /// </summary>
        public static void SortFileDate(char keySort)
        {
            string[][] initArray = FromFileToArray();
            //int colomn = 1;
            int nose = 0;
            int tail = initArray.Length;
            char key1 = '1';
            char key2 = '2';
            //var dt = DateTime.ParseExact("6/6/2021 2:45 PM", "M/d/yyyy h:mm tt", CultureInfo.InvariantCulture);
            //Console.WriteLine(dt);
            //Console.ReadKey();

            if (keySort == key1)
            {
                while (nose != initArray.Length)
                {
                    for (int i = 0; i < tail; i++)
                    {
                        if (Convert.ToDateTime(initArray[nose][1]) >= Convert.ToDateTime(initArray[i][1])) continue;
                        else
                        {
                            string[] transition = initArray[nose];
                            initArray[nose] = initArray[i];
                            initArray[i] = transition;
                        }
                    }
                    nose++;
                }
                string text = string.Empty;
                FromDoubleArrayToString(initArray, out text);
                RewritingFile(text);
            }
            else if (keySort == key2)
            {
                while (nose != initArray.Length)
                {
                    for (int i = 0; i < tail; i++)
                    {
                        if (Convert.ToDateTime(initArray[nose][1]) <= Convert.ToDateTime(initArray[i][1])) continue;
                        else
                        {
                            string[] transition = initArray[nose];
                            initArray[nose] = initArray[i];
                            initArray[i] = transition;
                        }
                    }
                    nose++;
                }
                string text = string.Empty;
                FromDoubleArrayToString(initArray, out text);
                RewritingFile(text);
            }
            else Console.WriteLine("Ты должен был выбрать между цифрой 1 или 2!");
        }

        /// <summary>
        /// Вывод списка в диапозоне дат
        /// </summary>
        public static void PrintingLimitDate()
        {
            SortFileDate('1');
            DateTime date1 = DateTime.MinValue;
            DateTime datefrom;
            DateTime date2 = DateTime.MaxValue;
            DateTime dateto;

            Console.Write("Введите с какой даты отобразить записи: ");
            string date = Console.ReadLine();
            datefrom = (date == string.Empty) ? date1 : Convert.ToDateTime(date);
            Console.Write("Введите до какой даты отобразить записи: ");
            date = Console.ReadLine();
            dateto = (date == string.Empty) ? date2 : Convert.ToDateTime(date);

            Console.WriteLine($"\nС {datefrom} по {dateto} \n");
            string[][] initArray = FromFileToArray();
            Console.WriteLine($"{"ID",6} {"Дата и Время",22} {"Фамилия",10} " +
                              $"{"Имя",7} {"Отчество",12} {"Возраст",8} {"Рост",5} " +
                              $"{"Дата рождения",14} {"Место рождения",16}");
            for (int i = 0; i < initArray.Length; i++)
            {
                if ((datefrom <= Convert.ToDateTime(initArray[i][1])) && (dateto >= Convert.ToDateTime(initArray[i][1])))
                {
                    Console.Write($"{initArray[i][0],6} {initArray[i][1],22} {initArray[i][2],10}" +
                                  $"{initArray[i][3],7} {initArray[i][4],12} {initArray[i][5],8}" +
                                  $"{initArray[i][6],5} {initArray[i][7],14} {initArray[i][8],16}"); Console.Write('\n');
                }
            }
            SortFileID('1');
        }
    }
}

