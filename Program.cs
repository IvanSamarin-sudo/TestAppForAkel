
using System.Collections.Generic;

namespace AkelonTestv1
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Worker> workers = new List<Worker>();

            VacationRandomizer vacation = new VacationRandomizer();

            List<string> names = new List<string>()
            {
                "Иванов Иван Иванович",
                "Петров Петр Петрович",
                "Юлина Юлия Юлиановна",
                "Сидоров Сидор Сидорович",
                "Павлов Павел Павлович",
                "Георгиев Георг Георгиевич"
            };

            foreach (var name in names)
            {
                workers.Add(new Worker(name));
            }

            foreach (var worker in workers)
            {
                try
                {
                    do
                    {
                        worker.Vacations.Add(vacation.GetVacation(worker));
                    }
                    while (worker.DaysOfVacation > worker.DaysDistributed);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach (var worker in workers)
            {
                Console.WriteLine(worker.ToString());
            }
        }
    }

}