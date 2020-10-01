using System;
using System.Collections.Generic;

//Вариант 1

namespace pr_06
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Student();
            Console.WriteLine(s);
            Console.WriteLine(s.ToShortString());

            Console.WriteLine("Indexer test: {0}, {1}, {2}",s[Education.Bachelor], s[Education.Specialist], s[Education.SecondEducation]);
            
            s.Person = new Person("Ivan", "Ivanov", new DateTime(2000, 2, 27));
            s.Education = Education.Specialist;
            s.Group = 519;
            s.Exams.Add(new Exam("Math", 4, new DateTime(2019,12,26)));
            s.Exams.Add(new Exam("Physics", 4, new DateTime(2019, 12, 29)));
            Console.WriteLine(s);

            var extraExams = new List<Exam>();
            extraExams.Add(new Exam("Test1", 5, new DateTime(2020, 1, 11)));
            extraExams.Add(new Exam("Test2", 5, new DateTime(2020, 1, 16)));

            s.AddExams(extraExams);

            Console.WriteLine(s);

            int nRow, nColumn;
            Console.WriteLine("Ввдете два числа через пробел или запятую: ");
            var size = Console.ReadLine().Split(' ', ',');
            nRow = int.Parse(size[0]);
            nColumn = int.Parse(size[1]);

            var examsLinear = new Exam[nRow * nColumn];
            for(int i = 0; i < nRow * nColumn; i++)
                examsLinear[i] = new Exam();
            
            var examsDouble = new Exam[nRow, nColumn];
            for(var i = 0; i < nRow; i++)
                for(var j = 0; j < nColumn; j++)
                    examsDouble[i,j] = new Exam();

            var examsJagged = new Exam[nRow][];
            for (var i = 0; i < nRow; i++)
            {
                examsJagged[i] = new Exam[nColumn];
                for (var j = 0; j < nColumn; j++)
                    examsJagged[i][j] = new Exam();
            }

            var t1 = Environment.TickCount;
            for (int i = 0; i < nRow * nColumn; i++)
                examsLinear[i].Mark = 5;
            var t2 = Environment.TickCount;
            var t = t2 - t1;
            Console.WriteLine("nrow: {0}, ncolumn: {1}\n", nRow, nColumn);
            Console.WriteLine("Одномерный массив: {0}", t);

            t1 = Environment.TickCount;
            for(var i = 0; i < nRow; i++)
                for(var j = 0; j < nColumn; j++)
                    examsDouble[i,j].Mark = 5;
            t2 = Environment.TickCount;
            t = t2 - t1;
            Console.WriteLine("Двумерный прямоугольный массив: {0}", t);

            
            t1 = Environment.TickCount;
            for(var i = 0; i < nRow; i++)
                for (var j = 0; j < nColumn; j++)
                    examsJagged[i][j].Mark = 5;
            t2 = Environment.TickCount;
            t = t2 - t1;
            Console.WriteLine("Двумерный ступенчатый массив: {0}", t);
        }
    }
}