using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HomeTask.6.6.");

            #region for old version
            //char key1 = '1';
            //char key2 = '2';
            //char key3 = '3';
            //char key4 = '4';
            //char key5 = '5';
            //char key6 = '6';
            //char key7 = '7';
            //char keyD = 'д';
            #endregion

            var idList = true;
            while (idList)
            {
                //Меню управления
                Class11.Welcome();
                //char keyChoice = Console.ReadKey(true).KeyChar;
                ConsoleKey keyChoice = Console.ReadKey().Key;
                Console.Clear();

                switch (keyChoice)
                {
                    case ConsoleKey.D1: // Список
                        {
                            if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "infoData.txt"))) Class11.ReadingFile();
                            else Console.WriteLine("Файл infoData.txt не существует");
                        }
                        break;
                    case ConsoleKey.D2: // Добавление
                        {
                            string infoID = string.Empty;
                            infoID = Class11.AddNewID();
                            Class11.WritingFile(infoID);
                            Console.Clear();
                        }
                        break;
                    case ConsoleKey.D3: // Удаление
                        {
                            Console.WriteLine("Введите фамилию или ID сотрудника для удаления");
                            string nameDeleting = Class11.FirstLetterUp(Console.ReadLine());
                            Console.WriteLine(nameDeleting);
                            int indexDel;
                            Class11.SearchingID(nameDeleting, out indexDel);
                            Class11.DeletingID(indexDel);
                        }
                        break;
                    case ConsoleKey.D4: // Редактирование 
                        {
                            Class11.ReadingFile();
                            Console.WriteLine("Данные какого сотрудника вы хотите поменять?");
                            string secondname = Class11.FirstLetterUp(Console.ReadLine());
                            Console.WriteLine("Какие данные вы бы хотели поменять: ID, фамилия, имя, отчество, дата рождения, место рождения?");
                            string whatChange = Console.ReadLine().ToLower();
                            int indexline;
                            Class11.SearchingID(secondname, out indexline);
                            Class11.ChangeInfo(whatChange, indexline);
                        }
                        break;
                    case ConsoleKey.D5: // Отображение записей в диапозоне дат
                        {
                            Class11.PrintingLimitDate();
                        }
                        break;
                    case ConsoleKey.D6: // Наличие файла
                        {
                            Class11.IsFileExist();
                        }
                        break;
                    case ConsoleKey.D7: // Сортировка по датам по возрастанию или убыванию
                        {
                            Console.WriteLine("Хотите отсортировать по ID или Датам?");
                            string sort7 = Console.ReadLine().ToLower();
                            Class11.WhichSort(sort7);
                        }
                        break;
                    default: // Выход
                        {
                            idList = false;
                        }
                        break;
                }

                #region Old version
                ////Список
                //if (key1 == keyChoice)
                //{
                //    if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "infoData.txt"))) Class11.ReadingFile();
                //    else Console.WriteLine("Файл infoData.txt не существует");
                //}

                ////Добавление
                //else if (key2 == keyChoice)
                //{
                //    string infoID = string.Empty;
                //    infoID = Class11.AddNewID();
                //    Class11.WritingFile(infoID);
                //    Console.Clear();
                //}

                ////Удаление
                //else if (key3 == keyChoice)
                //{
                //    Console.WriteLine("Введите фамилию или ID сотрудника для удаления");
                //    string nameDeleting = Class11.FirstLetterUp(Console.ReadLine());
                //    Console.WriteLine(nameDeleting);
                //    int indexDel;
                //    Class11.SearchingID(nameDeleting, out indexDel);
                //    Class11.DeletingID(indexDel);
                //}

                ////Редактирование
                //else if (key4 == keyChoice)
                //{
                //    Class11.ReadingFile();
                //    Console.WriteLine("Данные какого сотрудника вы хотите поменять?");
                //    string secondname = Class11.FirstLetterUp(Console.ReadLine());
                //    Console.WriteLine("Какие данные вы бы хотели поменять: ID, фамилия, имя, отчество, дата рождения, место рождения?");
                //    string whatChange = Console.ReadLine().ToLower();
                //    int indexline;
                //    Class11.SearchingID(secondname, out indexline);
                //    Class11.ChangeInfo(whatChange, indexline);
                //}

                ////Отображение записей в диапозоне дат
                //else if (key5 == keyChoice)
                //{
                //    Class11.PrintingLimitDate();
                //}

                ////Наличие файла
                //else if (key6 == keyChoice)
                //{
                //    Class11.IsFileExist();
                //}

                ////Сортировка по датам по возрастанию или убыванию
                //else if (key7 == keyChoice)
                //{
                //    Console.WriteLine("Хотите отсортировать по ID или Датам?");
                //    string sort7 = Console.ReadLine().ToLower();
                //    Class11.WhichSort(sort7);

                //}

                ////Выход
                //else break;
                #endregion
            }
        }
    }
}
