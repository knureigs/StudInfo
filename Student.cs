namespace StudInfo
{
    /// <summary>
    /// Структура, описывающая студента на основании доступных в стипендиальном рейтинге данных.
    /// </summary>
    public struct Student
    {
        /// <summary>
        /// Фамилия.
        /// </summary>
        public string Surname;

        /// <summary>
        /// Имя.
        /// </summary>
        public string FName;

        /// <summary>
        /// Отчество.
        /// </summary>
        public string SName;

        /// <summary>
        /// Значение стипендиального рейтинга.
        /// </summary>
        public string Rate;

        /// <summary>
        /// Академическая группа.
        /// </summary>
        public string Group;

        /// <summary>
        /// Примечания.
        /// </summary>
        public string Addition;

        /// <summary>
        /// Инициализирует новый экземпляр структуры Student.
        /// </summary>
        /// <param name="surname">Фамилия.</param>
        /// <param name="fname">Имя.</param>
        /// <param name="sname">Отчество.</param>
        /// <param name="rate">Значение стипендиального рейтинга.</param>
        /// <param name="group">Академическая группа.</param>
        /// <param name="addition">Примечания.</param>
        public Student(string surname, string fname, string sname, string rate, string group, string addition)
        {
            FName = fname;
            Surname = surname;
            SName = sname;
            Rate = rate;
            Group = group;
            Addition = addition;
        }

        /// <summary>
        /// Возвращает строку, представляющую текущий объект. 
        /// </summary>
        /// <returns>Строка, представляющую текущий объект.</returns>
        public override string ToString()
        {
            return Surname + " " + FName + " " + SName + " " + Rate + " " + Group + " " + Addition;
        }
    }
}
