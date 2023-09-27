using Studentns;

namespace GroupsOfStudents
{
    internal class Group
    {
        private List<Student> students;
        private string groupName;
        private string specialization;
        private int groupNumber;
        public string GroupName
        {
            get { return groupName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Пустий/некоректний рядок (назва групи)!!");
                }
                groupName = value;
            }
        }
        public string Specialization
        {
            get { return specialization; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Пустий/некоректний рядок (спеціалізація групи)");
                }
                specialization = value;
            }
        }
        public int GroupNumber 
        { 
            get { return groupNumber; }
            set {
                if(value < 1 || value > 100)
                {
                    throw new Exception("Некоректний номер групи!!!");
                }
                groupNumber = value; 
            }
        }
        private static int GroupCount = 0; // номери груп
        // Конструктори
        public Group()
        {
            GroupCount++;
            students = new List<Student>();
            Random rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                students.Add(new Student($"Student {i+1}", "",
                    new int[] {rand.Next(50, 100), rand.Next(50, 100), rand.Next(50, 100) },
                    new int[] {rand.Next(50, 100), rand.Next(50, 100), rand.Next(50, 100) },
                    new int[] {rand.Next(50, 100), rand.Next(50, 100), rand.Next(50, 100) } ));
                groupName += rand.Next(65, 122).ToString();
                specialization += rand.Next(65, 122).ToString();
            }
            groupNumber = GroupCount;
        }

        public Group(List<Student> studentsGroup)
        {
            students = studentsGroup;
            Random rand = new Random();
            GroupCount++;
            for (int i = 1; i <= 10; i++)
            {
                groupName += rand.Next(65, 122).ToString();
                specialization += rand.Next(65, 122).ToString();
            }
            groupNumber = GroupCount;
        }

        public Group(Group grp)
        {
            GroupCount++;
            students = new List<Student>();
            foreach (var student in grp.students)
            {
                students.Add(new Student(student));
            }
            groupName = grp.GroupName;
            specialization = grp.Specialization;
            groupNumber = GroupCount;
        }

        // Загальна інформація про групу
        public void GroupInfo()
        {
            students.OrderBy(s => s.LastName).ThenBy(s => s.FirstName);
            Console.WriteLine($"\tГрупа {GroupNumber} - {GroupName}\n\tСпец. - {Specialization}");
            int i = 1;
            foreach(var student in students)
            {
                Console.WriteLine($"{i++}) {student.LastName} {student.FirstName} " +
                    $"\nДомашні роботи - {Math.Round(student.Homeworks.Average(),2)}" +
                    $"\nОстаточні роботи - {Math.Round(student.FinalWorks.Average(),2)}" +
                    $"\nЕкзамени - {Math.Round(student.Exams.Average(),2)}");
            }
        }

        // Доступ до студентів через групу
        public Student GetStudent(int number)
        {
            if(number < students.Count) { return students[number]; }
            else { return students[0]; }
        }

        // кількість студентів у групі
        public int GetGroupLenth()
        {
            return students.Count();
        }
        // Додавання студента до групи
        public void AddStudent(Student student)
        {
            if (!students.Contains(student))
            {
                students.Add(student);
            }
        }

        // Переведення студента із одної групи в іншу
        public void TransferStudent(Student student, Group otherGroup)
        {
            if (students.Contains(student))
            {
                students.Remove(student);
                otherGroup.AddStudent(student);
            }
            else { Console.WriteLine("В цій групі немає такого студента!"); }
        }

        // змінюємо дані про групу
        public void EditGroup(string newName, string newSpez)
        {
            if (string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newSpez))
            {
                throw new Exception("Можливо введені пусті поля!! (редагування групи)");
            }
            else
            {
                GroupName = newName;
                Specialization = newSpez;
            }
        }

        // змінюємо дані про студента групи
        public void EditGroupStudent(Student student)
        {
            if (students.Contains(student))
            {
                student.EditStudent();            
            }
            else { Console.WriteLine("В цій групі немає такого студента!"); }
        }

        // видаляємо студента, який найгірше вчиться
        public void DeleteBadStudent()
        {
            if (students.Count == 0) { return; }
            Student badStudent = students[0];
            double studMark, lowestMark = students[0].Exams.Average();
            foreach (Student student in students)
            {
                if (student.Exams.Length == 0) { continue; }
                studMark = student.Exams.Average(); 
                if (lowestMark > studMark) { lowestMark = studMark; badStudent = student; }
            }
            students.Remove(badStudent);
        }

        // видаляємо студентів, які не склали сесію
        public void DeleteStudents()
        {
            if (!students.Any()) 
            {
                return;
            }
            List<Student> studentsDel = new List<Student>();
            foreach (Student student in students.ToList()) 
            {
                if (student.Exams.Any() && student.Homeworks.Any() && student.FinalWorks.Any())
                {
                    double examsAverage = student.Exams.Average();
                    double homeworksAverage = student.Homeworks.Average();
                    double finalWorksAverage = student.FinalWorks.Average();

                    if (examsAverage < 60 || homeworksAverage < 70 || finalWorksAverage < 60)
                    {
                        studentsDel.Add(student); // Додаємо студента до списку на видалення
                    }
                }
            }
            foreach (Student student in studentsDel)
            {
                students.Remove(student); // Видаляємо студента з оригінального списку
            }
        }
    }
}