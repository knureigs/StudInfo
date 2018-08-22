using System.Collections.Generic;

namespace StudInfo
{
    /// <summary>
    /// Предоставляет доступ к данным из стипендиального рейтинга и методам для их получения и сохранения.
    /// </summary>
    public interface IRatingService
    {

        /// <summary>
        /// Возвращает доступный для чтения список объектов, описывающих студентов.
        /// </summary>
        IReadOnlyList<Student> Students { get; }

        /// <summary>
        /// Заполняет коллекцию данных о студентах, считывая указанные PDF-файлы стипендиального рейтинга.
        /// </summary>
        /// <param name="paths">Пути к PDF-файлам с данными стипендиального рейтинга.</param>
        void FillFromPdf(string[] paths);

        /// <summary>
        /// Заполняет коллекцию объектов, описывающих студентов, на основании ранее сохраненного XML-файла.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        void FillFromXml(string path);

        /// <summary>
        /// Сохраняет коллекцию данных о студентах в XML-файле.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        void SaveToXml(string path);

        /// <summary>
        /// Заполняет коллекцию объектов, описывающих студентов, на основании сохранения в файле СУБД SQLite.
        /// </summary>
        /// <param name="path">Путь к файлу базы данных.</param>
        void FillFromDB(string path);

        /// <summary>
        /// Сохраняет коллекцию данных о студентах в файл базы данных.
        /// </summary>
        /// <param name="path">Путь к файлу базы данных.</param>
        void SaveToDB(string path);

        /// <summary>
        /// Очищает коллекцию данных о студентах.
        /// </summary>
        void Clear();
    }
}
