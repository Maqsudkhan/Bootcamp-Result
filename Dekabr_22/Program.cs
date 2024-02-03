using Dekabr_22;

public class Program
{
    #region Main
    public static void Main(string[] args)
    {
        // Real names for the students
        string[] studentFirstNames =
            [
                "Alice",
                "Bob",
                "Charlie",
                "David",
                "Emma",
                "Frank",
                "Grace",
                "Henry",
                "Isabel",
                "Jack",
                "Katie",
                "Liam",
                "Mia",
                "Nathan",
                "Olivia",
                "Paul",
                "Quinn",
                "Rachel",
                "Samuel",
                "Tara"
                ];

        // Real last names for the students
        string[] studentLastNames =
            [
                "Smith",
                "Johnson",
                "Williams",
                "Jones",
                "Brown",
                "Davis",
                "Miller",
                "Wilson",
                "Moore",
                "Taylor",
                "Anderson",
                "Thomas",
                "Jackson",
                "White",
                "Harris",
                "Martin",
                "Thompson",
                "Young",
                "Clark",
                "Walker"
                ];

        Student[] unsortedStudents = new Student[20];

        for (int i = 0; i < studentFirstNames.Length; i++)
        {
            var student = new Student
            {
                Id = studentFirstNames.Length - i,
                FirstName = studentFirstNames[i],
                LastName = studentLastNames[studentFirstNames.Length - i - 1]
            };

            unsortedStudents[i] = student;
        }


        // TODO Consolega unsortedStudents elementlarini chiqaring (use while loop)

/*        int len = 0;
        while (unsortedStudents.Length != len)
        {
            Console.WriteLine($"Id: {unsortedStudents[len].Id}\n" +
                $"FirsName: {unsortedStudents[len].FirstName}\n" +
                $"LastName: {unsortedStudents[len].LastName}\n");
            len++;
        }
*/


        var sortedStudents = new SortedList<int, Student>();
        // TODO unsortedStudents elementlarini birma-bir sortedStudentsga qo'shing
        
        foreach(var student in unsortedStudents)
        {
            sortedStudents.Add(student.Id, student);
        }       


        // TODO Consolega sortedStudents elementlarini chiqaring (use foreach loop)

/*        foreach(var student in sortedStudents)
        {
            Console.WriteLine($"Id: {student.Key}\n" +
                $"FirsName: {student.Value.FirstName}\n" +
                $"LastNmae: {student.Value.LastName}\n");
        }*/



        var studentsQueueForFood = new Queue<Student>();
        // TODO studentsQueueForFood  queue ga  Id 3, 4, 8, 17, 1, 6, 12 studentlarni qo'shing (Enqueue).

        foreach(var i in new[] { 3, 4, 8, 17, 1, 6, 12 })
        {
            studentsQueueForFood.Enqueue(sortedStudents[i]);
        }


        // Har bir studentni ketma-ketlikda consolega chiqaring Masalan. Shu Idga ega bo'lgan ovqatga navbatga turdi

/*        foreach (var student in studentsQueueForFood)
        {
            Console.WriteLine($"{student.Id} shu ID ga ega bo\'lgan student navbatda turubdi.");
        }*/


        // TODO studentsQueueForFood  queue dan 4 ta studentni chiqaring.(Dequeue)
        // Har bir studentni ketma-ketlikda consolega chiqaring Masalan. Shu Idga ega bo'lgan student ovqatni oldi.
        for (int i = 0; i<4; i++)
        {
            //Console.WriteLine($"{studentsQueueForFood.Dequeue().Id} Shu ID ga ega bo'lgan student ovqatni oldi"); 
        }



        var studentsEnrolledMathCourse = new HashSet<Student>();
        // TODO 1, 3, 5, 6, 8, 18, 15, 13, 20 id li studentlarni matematika kursiga qo'shing.

        foreach(var i in new[] { 1, 3, 5, 6, 8, 18, 15, 13, 20 })
        {
            studentsEnrolledMathCourse.Add(sortedStudents[i]);
        }



        var studentsEnrolledEnglishCourse = new HashSet<Student>();
        // TODO 1, 2, 9, 6, 8, 7, 15, 13, 20 id li studentlarni ingliz tili kursiga qo'shing.

        foreach(var i in new[] { 1, 2, 9, 6, 8, 7, 15, 13, 20 })
        {
            studentsEnrolledEnglishCourse.Add(sortedStudents[i]);
        }

        // TODO matematika va ingliz tiliga bir vaqtda qatnashayotgan studentlarni consolega chiqaring (IntersectWith) 

        var MathEnglishStudents = new HashSet<Student>(studentsEnrolledMathCourse);
        MathEnglishStudents.IntersectWith(studentsEnrolledEnglishCourse);
        foreach(var i in MathEnglishStudents)
        {
            //Console.WriteLine($"Id: {i.Id}, FirsName: {i.FirstName}, LstName: {i.LastName}");
        }


        // TODO faqat matematikaga(ingliz tiliga emas) qatnashayotgan studentlarni consolega chiqaring (ExceptWith)
        var OnlyMathStudents = new HashSet<Student>(studentsEnrolledMathCourse);
        OnlyMathStudents.ExceptWith(studentsEnrolledEnglishCourse);
        foreach(var i in OnlyMathStudents)
        {
            //Console.WriteLine($"Id: {i.Id}, FirsName: {i.FirstName}, LstName: {i.LastName}");
        }


        // TODO faqat ingliz tiliga(matematikaga emas) qatnashayotgan studentlarni consolega chiqaring (ExceptWith)
        var OnlyEnglishStudents = new HashSet<Student>(studentsEnrolledEnglishCourse);
        OnlyEnglishStudents.ExceptWith(studentsEnrolledMathCourse);
        foreach(var i in OnlyEnglishStudents)
        {
            //Console.WriteLine($"Id: {i.Id}, FirsName: {i.FirstName}, LstName: {i.LastName}");
        }



        // TODO istalgan kursga qatnashayotgan studentlarni consolega chiqaring. (UnionWith)
        var AllCourseStudents = new HashSet<Student>(studentsEnrolledMathCourse);
        AllCourseStudents.UnionWith(studentsEnrolledEnglishCourse);
        foreach (var i in AllCourseStudents)
        {
            //Console.WriteLine($"Id: {i.Id}, FirsName: {i.FirstName}, LstName: {i.LastName}");
        }


        // HashSetlar reference type. UnionWith, ExceptWith va IntersectWith chaqirilgan hashSetlarni o'zgartiradi.

        // studentlarni id isiga ko'ra jurnalda saqlang. ma'lumotlarni sorted Listdan olib keling.
        var classJournal = new Dictionary<int, Student>();
        foreach (var i in sortedStudents.Values)
        {
            classJournal.Add(i.Id, i);
        }


        // studentlarni jurnalini Consolega chiqaring.
        foreach (var i in classJournal)
        {
            Console.WriteLine($"ID: {i.Key}, FirsName: {i.Value.FirstName}, LastName: {i.Value.LastName}");
        }
    }
    #endregion
}



