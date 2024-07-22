using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkelonTestv1
{
    public class Vacation
    {
        /// <summary>
        /// Возможная продолжительность отпуска.
        /// </summary>
        ImmutableList<int> possibleSteps;

        /// <summary>
        /// Получить список рабочих дней в неделе.
        /// </summary>
        /// <returns></returns>
        List<DayOfWeek> GetWorkingDays()
        {
            return new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
        }

        /// <summary>
        /// Получить случайный день начала отпуска.
        /// </summary>
        /// <returns></returns>
        int GetRandomDay()
        {
            Random rand = new Random();

            return rand.Next(DateTime.IsLeapYear(DateTime.Now.Year) ? 366 : 365);
        }

        /// <summary>
        /// Получить случайное количество дней отпуска. (Из возможных).
        /// </summary>
        /// <returns></returns>
        int GetRandomStep()
        {
            Random rand = new Random();

            int res = rand.Next(possibleSteps.Count);

            return possibleSteps[res];
        }

        /// <summary>
        /// Получить один отпуск.
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public List<DateTime> GetVacation(Worker worker)
        {
            if (worker.DaysOfVacation <= worker.DaysDistributed)
                throw new ArgumentOutOfRangeException("У сотрудника больше нет дней отпуска.");

            List<DateTime> vacation = new List<DateTime>();
            int year = DateTime.Now.Year;
            DateTime dayOfStart = new DateTime();
            int step = GetRandomStep();
            do
            {
                int day = GetRandomDay();

                dayOfStart = new DateTime(year, 1, 1).AddDays(day);
            }
            while (dayOfStart.Equals(GetWorkingDays()));
            DateTime dayOfExpire = new DateTime();
            dayOfExpire = dayOfStart.AddDays(step);

            if (worker.DaysDistributed < 28)
            {
                vacation.Add(dayOfStart);
                vacation.Add(dayOfExpire);
                worker.DaysDistributed += step;

            }
            else if (worker.HaveExtraDays && worker.DaysDistributed == 28)
            {
                step = 3;
                vacation.Add(dayOfStart);
                vacation.Add(dayOfExpire);
                worker.DaysDistributed += step;
            }

            return vacation;
        }

    /// <summary>
    /// Конструктор.
    /// </summary>
    public Vacation()
        {
            possibleSteps = ImmutableList.Create<int>(7, 14);
        }

    }
}
