using System;

namespace pr_06
{
    public class Exam
    {
        public string Subject { get; set; }
        public int Mark { get; set; }
        public DateTime ExamDate { get; set; }

        public Exam(string subject, int mark, DateTime examDate)
        {
            Subject = subject;
            Mark = mark;
            ExamDate = examDate;
        }

        public Exam()
        {
            Subject = "DefSubject";
            Mark = 5;
            ExamDate = DateTime.Now;
        }

        public override string ToString()
        {
            return Subject + ": " + Mark + " " + ExamDate.ToString("dd/MM/yyyy");
        }
    }
}