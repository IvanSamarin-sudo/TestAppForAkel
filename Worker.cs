using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkelonTestv1
{
    /// <summary>
    /// Работник.
    /// </summary>
    [Serializable]
    public class Worker
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name;

        /// <summary>
        /// Список отпусков сотрудника.
        /// </summary>
        public List<List<DateTime>> Vacations;

        /// <summary>
        /// Имеет ли сотрудник дополнительные дни отпуска. (В связи с вредными условиями труда и/или ненормированным рабочим графиком).
        /// </summary>
        public bool HaveExtraDays = false;

        /// <summary>
        /// Допустимое количество дней отпуска.
        /// </summary>
        public int DaysOfVacation { get; private set; }

        /// <summary>
        /// Уже распределённые дни отпуска.
        /// </summary>
        public int DaysDistributed = 0;

        /// <summary>
        /// Назначить отпуск сотруднику.
        /// </summary>
        /// <param name="dates"></param>
        public void SetVacation(List<DateTime> dates)
        {
            Vacations.Add(dates);
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="vacations"></param>
        public Worker(string name)
        {
            Name = name;
            Vacations = new List<List<DateTime>>();
            DaysOfVacation = HaveExtraDays ? 31 : 28;
        }

        /// <summary>
        /// Преобразовать список списков дат в строку.
        /// </summary>
        /// <returns></returns>
        string VacationsToString()
        {
            string res = String.Empty;

            foreach (var vac in Vacations)
            {
                var firstDate = vac[0];
                var lastDate = vac[vac.Count - 1];
                    res += "\r\n" + firstDate.ToString("dd.MM.yy") + "-" + lastDate.ToString("dd.MM.yy");
            }

            return res;
        }

        /// <summary>
        /// Преобразовать класс в строку.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        { 
            return Name + VacationsToString();
        }

    }
}
