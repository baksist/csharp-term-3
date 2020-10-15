using System.Collections.Generic;
using System.Linq;

namespace pr_06
{
    public class Student
    {
        private Person _person;
        private Education _education;
        private int _group;
        private List<Exam> _exams;

        public Student(Person person, Education education, int group)
        {
            _person = person;
            _education = education;
            _group = group;
            _exams = new List<Exam>();
        }

        public Student()
        {
            _person = new Person();
            _education = Education.Bachelor;
            _group = 0;
            _exams = new List<Exam>();
        }
 
        public Person Person
        {
            get => _person;
            set => _person = value;
        }
        
        public Education Education
        {
            get => _education;
            set => _education = value;
        }

        public int Group
        {
            get => _group;
            set => _group = value;
        }
        
        public List<Exam> Exams
        {
            get => _exams;
            set => _exams = value;
        }

        public double AverageScore
        {
            get
            {
                double x = 0;
                if (_exams.Count > 0)
                {
                    foreach (var iExam in _exams)
                        x += iExam.Mark;
                    x /= _exams.Count;
                }
                return x;
            }
        }

        public bool this[Education education]
        {
            get
            {
                return _education == education ? true : false;
            }
        }

        public void AddExams(List<Exam> exams)
        {
            for (var i = 0; i < exams.Count; i++)
            {
                Exams.Add(exams[i]);
            }
        }

        public override string ToString()
        {
            var s = Person + " " + Education + " " + Group;
            foreach (var iExam in Exams)
            {
                s += "\n" + iExam;
            }
            return s;
        }

        public string ToShortString()
        {
            return Person + " " + Education + " " + Group + " " + AverageScore;
        }
    }
}