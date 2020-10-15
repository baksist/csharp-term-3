using System;

namespace pr_06
{
    class Program
    {
        static void Main(string[] args)
        {
           var x = new ResearchTeam();
           Console.WriteLine(x.ToShortString());

           Console.WriteLine("Indexer test: {0}, {1}, {2}\n", x[TimeFrame.Long], x[TimeFrame.Year], x[TimeFrame.TwoYears]);
           
           x.OrganizationName = "CustomName";
           x.ResearchTheme = "CustomTheme";
           x.RegistrationNumber = 31337;
           x.ResearchDuration = TimeFrame.Long;
           x.Publications = new[] {new Paper(), new Paper("CustomTitle", new Person(), DateTime.Now), new Paper()};
           Console.WriteLine(x);
           
           x.AddPapers(new []{new Paper(), new Paper(), new Paper() });
           Console.WriteLine(x);
           
           Console.WriteLine("Most Recent Paper: {0}", x.MostRecentPaper);

           int nRow, nColumn;
           var size = Console.ReadLine().Split(',', ' ');
           nRow = int.Parse(size[0]);
           nColumn = int.Parse(size[1]);

           var papersLinear = new Paper[nRow * nColumn];
           for (var i = 0; i < papersLinear.Length; i++)
               papersLinear[i] = new Paper();
           
           var papersDouble = new Paper[nRow, nColumn];
           for(var i = 0; i < papersDouble.GetLength(0); i++)
               for(var j = 0; j < papersDouble.GetLength(1); j++)
                   papersDouble[i,j] = new Paper();

           var papersJagged = new Paper[nRow][];
           for (var i = 0; i < papersJagged.GetLength(0); i++)
           {
               papersJagged[i] = new Paper[nColumn];
               for (var j = 0; j < papersJagged[i].Length; j++)
                   papersJagged[i][j] = new Paper();
           }

           int t1, t2, t;
           
           t1 = Environment.TickCount;
           for (var i = 0; i < papersLinear.Length; i++)
               papersLinear[i].Title = "TestTitle";
           t2 = Environment.TickCount;
           t = t2 - t1;
           Console.WriteLine("nrow: {0}, ncolumn: {1}\n", nRow, nColumn);
           Console.WriteLine("Одномерный массив: {0}", t);

           t1 = Environment.TickCount;
           for (var i = 0; i < papersDouble.GetLength(0); i++)
               for (var j = 0; j < papersDouble.GetLength(1); j++)
                   papersDouble[i,j].Title = "TestTitle";
           t2 = Environment.TickCount;
           t = t2 - t1;
           Console.WriteLine("Двумерный прямоугольный массив: {0}", t);

           t1 = Environment.TickCount;
           for (var i = 0; i < papersJagged.GetLength(0); i++)
                for (var j = 0; j < papersJagged[i].Length; j++)
                    papersJagged[i][j].Title = "TestTitle";
           t2 = Environment.TickCount;
           t = t2 - t1;
           Console.WriteLine("Двумерный ступенчатый массив: {0}", t);
        }
    }
}
