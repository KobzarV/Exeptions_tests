/*в классах Student и Group, а конкретно в методах сеттерах 
 * предусмотреть генерацию исключений, в том случае, если переданный параметр
 * не подходит по смыслу в диапазон или множество допустимых значений поля.
генерация исключений должна быть во всех сеттерах!!!
пробрасывать необходимо не просто объекты типа Exception, a его кастомизированные
типы-наследники (эти типы создать самостоятельно) проверить, как генерятся исключения 
на тестах методов-сеттеров в мейне. на траях, кечтах и файналлях*/
using GroupsOfStudents;
using Studentns;


class Exeptions_test
{
    static void Main()
    {
        Student st1 = new Student("1", "11", "111");
        try
        {
            st1.LastName = "";
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        try
        {
            st1.AddExamGrade(0);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Group gr1 = new Group();
        try
        {
            gr1.Specialization = "";
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        try
        {
            gr1.GroupNumber = -1;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
