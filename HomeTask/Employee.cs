using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask
{
    /// <summary>
    /// Структура для записи в базу данных
    /// </summary>
    struct Employees
    {
        #region Конструкторы

        /// <summary>
        /// Создание сотрудника
        /// </summary>
        /// <param name="ID">ID сотрудника</param>
        /// <param name="dateAdd">Дата добавления сотрудника</param>
        /// <param name="fullName">ФИО сотрудника</param>
        /// <param name="age">Возраст сотрудника</param>
        /// <param name="height">Рост сотрудника</param>
        /// <param name="birthDay">Дата рождения сотрудника</param>
        /// <param name="birthCity">Город рождения сотрудника</param>
        public Employees(int ID, DateTime DateAdd,
        string SecondName, string FirstName, string MiddleName,
        int Age, int Height, DateTime BirthDay, string BirthCity)
        {
            this.ID = ID;
            this.DataAdd = DateAdd;
            this.SecondName = SecondName;
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.Age = Age;
            this.Height = Height;
            this.BirthDay = BirthDay;
            this.BirthCity = BirthCity;
        }

        #endregion

        #region Перегрузки

        public Employees(int ID, DateTime dateAdd, string secondName, string firstName, string middleName, int age, int height, DateTime birthDay) :
                this(ID, dateAdd, secondName, firstName, middleName, age, height, birthDay, string.Empty)
        { }

        public Employees(int ID, DateTime dateAdd, string secondName, string firstName, string middleName, int age, int height) :
                this(ID, dateAdd, secondName, firstName, middleName, age, height, new DateTime(2000, 1, 1, 0, 0, 0), string.Empty)
        { }

        public Employees(int ID, DateTime dateAdd, string secondName, string firstName, string middleName, int age) :
                this(ID, dateAdd, secondName, firstName, middleName, age, 0, new DateTime(2000, 1, 1, 0, 0, 0), string.Empty)
        { }

        public Employees(int ID, DateTime dateAdd, string secondName, string firstName, string middleName) :
                this(ID, dateAdd, secondName, firstName, middleName, 0, 0, new DateTime(2000, 1, 1, 0, 0, 0), string.Empty)
        { }
        public Employees(int ID, DateTime dateAdd, string secondName, string firstName) :
                this(ID, dateAdd, secondName, firstName, string.Empty, 0, 0, new DateTime(2000, 1, 1, 0, 0, 0), string.Empty)
        { }
        public Employees(int ID, DateTime dateAdd, string secondName) :
                this(ID, dateAdd, secondName, string.Empty, string.Empty, 0, 0, new DateTime(2000, 1, 1, 0, 0, 0), string.Empty)
        { }

        #endregion


        #region Методы
        public string Print()
        {
            Console.WriteLine($"{"ID",6} {"Дата и Время",18} {"Фамилия",10} " +
                $"{"Имя",7} {"Отчество",12} {"Возраст",8} {"Рост",5} " +
                $"{"Дата рождения",14} {"Место рождения",16}");
            return $"{ID,6} {DataAdd,18} " +
                $"{SecondName,10} {FirstName,7} {MiddleName,12} " +
                $"{Age,8} {Height,5} {BirthDay,14} {BirthCity,16}";
        }

        #endregion


        #region Свойства

        public int ID { get; set; }
        public DateTime DataAdd { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public DateTime BirthDay { get; set; }
        public string BirthCity { get; set; }

        #endregion


        #region Поля сотрудника
        ///// <summary>
        ///// ID сотрудника
        ///// </summary>
        //private int id;
        ///// <summary>
        ///// Дата и время добавления
        ///// </summary>
        //private DateTime dateadd;
        ///// <summary>
        ///// Имя сотрудника
        ///// </summary>
        //private string firstname;
        ///// <summary>
        ///// Фамилия сотрудника
        ///// </summary>
        //private string secondname;
        ///// <summary>
        ///// Отчество сотрудника
        ///// </summary>
        //private string middlename;
        ///// <summary>
        ///// Возраст сотрудника
        ///// </summary>
        //private int age;
        ///// <summary>
        ///// Рост сотрудника
        ///// </summary>
        //private int height;
        ///// <summary>
        ///// Дата рождения сотрудника
        ///// </summary>
        //private DateTime birthday;
        ///// <summary>
        ///// Город рождения
        ///// </summary>
        //private string birthcity;

        #endregion
    }
}
   

