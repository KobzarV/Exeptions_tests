namespace Studentns
{
    public class Student
    {
        // Поля
        private string lastName;
        private string firstName;
        private string patronymic;
        private DateTime birthdate;
        private Address address;
        private string phoneNumber;
        private int[] homeworks;
        private int[] finalWorks;
        private int[] exams;

        // Конструктори
        public Student(string lastName, string firstName, string patronymic,
            DateTime birthdate, Address address, string phoneNumber,
            int[] homework, int[] finalWork, int[] exams)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.patronymic = patronymic;
            this.birthdate = birthdate;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.homeworks = homework;
            this.finalWorks = finalWork;
            this.exams = exams;
        }

        public Student(string lastName, string firstName, string patronymic, DateTime birthdate,
            Address homeAddress, string phoneNumber)
        {
            Random rand = new Random();
            this.lastName = lastName;
            this.firstName = firstName;
            this.patronymic = patronymic;
            this.birthdate = birthdate;
            this.address = homeAddress;
            this.phoneNumber = phoneNumber;
            homeworks = new int[] { rand.Next(50, 100), rand.Next(50, 100), rand.Next(50, 100) };
            finalWorks = new int[] { rand.Next(50, 100), rand.Next(50, 100), rand.Next(50, 100) };
            exams = new int[] { rand.Next(50, 100), rand.Next(50, 100), rand.Next(50, 100) };
        }

        public Student(string lastName, string firstName, string patronymic)
        {
            Random rand = new Random();
            this.lastName = lastName;
            this.firstName = firstName;
            this.patronymic = patronymic;
            this.birthdate = new DateTime(2000, rand.Next(1, 12), rand.Next(1, 30));
            this.address = new Address("", "", "");
            this.phoneNumber = "";
            homeworks = new int[] { rand.Next(50, 100), rand.Next(50, 100), rand.Next(50, 100) };
            finalWorks = new int[] { rand.Next(50, 100), rand.Next(50, 100), rand.Next(50, 100) };
            exams = new int[] { rand.Next(50, 100), rand.Next(50, 100), rand.Next(50, 100) };
        }

        public Student(string lastName, string firstName, int[] homework, int[] finalWork, int[] exams)
            : this(lastName, firstName, string.Empty, new DateTime(2000,1,1),
                  new Address("", "", ""), string.Empty, homework, finalWork, exams)
        {
        }

        public Student (Student student)
            :this(student.lastName, student.firstName, student.patronymic, student.birthdate,
                 student.address, student.phoneNumber, student.homeworks, student.finalWorks, student.exams)
        {
        }

        // Властивості
        public string LastName
        {
            get { return lastName; }
            set {
                if(string.IsNullOrEmpty(value))
                {
                    throw new Exception("Пустий рядок (прізвище)");
                }
                lastName = value;
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Пустий рядок (ім'я)");
                }
                firstName = value;
            }
        }

        public string Patronymic
        {
            get { return patronymic; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Пустий рядок (по батькові)");
                }
                patronymic = value;
            }
        }

        public DateTime BirthDate { get { return birthdate; } }

        public Address HomeAddress
        {
            get { return address; }
            set
            {
                if (string.IsNullOrEmpty(this.HomeAddress.City) || 
                    string.IsNullOrEmpty(this.HomeAddress.Country) ||
                    string.IsNullOrEmpty(this.HomeAddress.Street))
                {
                    throw new Exception("Некоректні дані (адрес)");
                }
                address = value;
            }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Неправильні дані (номер телефону)");
                }
                phoneNumber = value;
            }
        }

        public int[] Homeworks  { get { return homeworks; } }
        public int[] FinalWorks { get { return finalWorks; } }
        public int[] Exams { get { return exams; } }


        // Методи
        public void AddHomeworkGrade(int grade)
        { // змінюємо розмір масиву, щоб додати новий елемент
            if (grade <= 0 || grade > 100)
            {
                throw new Exception("Некоректний номер групи");
            }
            Array.Resize(ref homeworks, homeworks.Length + 1);  // ref вказує на те, що ми змінюємо сам масив, а не створюємо новий
            homeworks[homeworks.Length - 1] = grade;
        }

        public void AddFinalPaperGrade(int grade)
        {
            if (grade <= 0 || grade > 100)
            {
                throw new Exception("Некоректно введена оцінка!!");
            }
            Array.Resize(ref finalWorks, finalWorks.Length + 1);
            finalWorks[finalWorks.Length - 1] = grade;
        }

        public void AddExamGrade(int grade)
        {
            if (grade <= 0 || grade > 100)
            {
                throw new Exception("Некоректно введена оцінка!!");
            }
            Array.Resize(ref exams, exams.Length + 1);
            exams[exams.Length - 1] = grade;
        }

        public void EditStudent()
        {
            Console.WriteLine("\tВведіть нові дані студента\nПрізвище - ");
            LastName = Console.ReadLine();
            Console.WriteLine("Ім'я - ");
            FirstName = Console.ReadLine();
            Console.WriteLine("По батькові - ");
            Patronymic = Console.ReadLine();
            HomeAddress = new Address();
            Console.WriteLine("Номер телефону - ");
            PhoneNumber = Console.ReadLine();
        }

        public void Info()
        {
            Console.WriteLine("\tІнформація про студента:");
            Console.WriteLine($"ФІО: {lastName} {firstName} {patronymic}");
            Console.WriteLine($"Дата народження: {birthdate.ToShortDateString()}");
            Console.WriteLine($"Адреса: {address}");
            Console.WriteLine($"Номер телефону: {phoneNumber}");
            Console.WriteLine($"Оцінки за домашні роботи: {string.Join(", ", homeworks)}");
            Console.WriteLine($"Оцінки за підсумкові роботи: {string.Join(", ", finalWorks)}");
            Console.WriteLine($"Оцінки за екзамени: {string.Join(", ", exams)}\n\n");
        }
    }

    // Окремий клас для адреси
    public class Address
    {
        private string street;
        private string city;
        private string country;
        public string Street
        {
            get { return street; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Пустий рядок (вулиця)");
                }
                street = value;
            }
        }
        public string City 
        {
            get { return city; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Пустий рядок (місто)");
                }
                city = value;
            }
        }
        public string Country
        {
            get { return country; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Пустий рядок (країна)");
                }
                country = value;
            }
        }

        public Address()
        {
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                street += (char)r.Next(65, 122);
                city += (char)r.Next(65, 122);
                country += (char)r.Next(65, 122);
            }
        }

        public Address(string street, string city, string country)
        {
            this.street = street;
            this.city = city;
            this.country = country;
        }

        public override string ToString()
        {
            return $"{Street}, {City}, {Country}";
        }

    }
}
