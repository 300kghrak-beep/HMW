using System;

#region DopInfo
struct FLF
{
    public string firstName;
    public string lastName;
    public string fatherName;
}

struct Address
{
    public string country;
    public string city;
    public string region;
    public int houseNumber;
}


struct Date
{
    public int minute;
    public int hour;
    public int day;
    public int month;
    public int year;
}
#endregion
#region Types
public enum ArticleType
{
    Food,
    Clothes,
    Electronics,
}

public enum ClientType
{
    Basic,
    VIP,
    Premium
}


public enum PayType
{
    Cash,
    Card,
}
#endregion


struct Article
{
    public string code;
    public string title;
    public int price;
    public ArticleType type;
}

struct Client
{
    public string code;
    public FLF fio;
    public Address address;
    public int telephone;
    public int orders;
    public int sum;
    public ClientType type;
}


struct RequestItem
{
    public Article article;
    public int quantity;
}

struct Request
{
    public int codeOfOrder;
    public Client client;
    public Date date;
    public Article[] orderedArticles;
    public int sumOfOrder;
    public PayType type;
}



// ----------------------------------------------------------------------------------------------------------- //
class Student
{
    public string[] subjects = { "Программирование", "Администрирование", "Дизайн" };
    public FLF fio;
    public string group;
    public int age;
    public int[][] grades;


    public void setGrade(int grade, int idx)
    {
        if (idx == -1) return;

        int[] newGrades = new int[grades[idx].Length + 1];

        for (int i = 0; i < grades[idx].Length; i++)
        {
            newGrades[i] = grades[idx][i];
        }

        newGrades[newGrades.Length - 1] = grade;
        grades[idx] = newGrades;
    }

    public int[] getGrade(int idx, int index = -1)
    {
        if (idx == -1) return new int[0];
        if (index == -1 || index >= grades[idx].Length) return grades[idx];

        int[] grade = { grades[idx][index] };
        return grade;
    }


    public float getAverage(int idx)
    {
        if (idx == -1) return 0.0f;

        float sum = 0;
        for (int i = 0; i < grades[idx].Length; i++)
        {
            sum += grades[idx][i];
        }

        if (grades[idx].Length > 0)
        {
            return sum / grades[idx].Length;
        }
        return 0.0f;
    }



    public void ShowStudentInfo()
    {
        Console.WriteLine($"Имя: {fio.firstName}");
        Console.WriteLine($"Фамилия: {fio.lastName}");
        Console.WriteLine($"Отчество: {fio.fatherName}");
        Console.WriteLine($"Группа: {group}");
        Console.WriteLine($"Возраст: {age}");
        Console.WriteLine("\nОценки:");

        for (int i = 0; i < grades.Length; i++)
        {
            Console.Write(subjects[i] + ": ");

            for (int j = 0; j < grades[i].Length; j++)
            {
                Console.Write(grades[i][j] + " ");
            }

            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Student st = new Student();

        st.fio.firstName = "Иван";
        st.fio.lastName = "Иванов";
        st.fio.fatherName = "Иванович";

        st.group = "CS-101";
        st.age = 18;

        st.grades = new int[3][];
        st.grades[0] = new int[0];
        st.grades[1] = new int[0];
        st.grades[2] = new int[0];

        st.setGrade(9, 0);
        st.setGrade(9, 1);
        st.setGrade(8, 2);
        st.setGrade(7, 0);

        st.ShowStudentInfo();
        Console.WriteLine($"Средний балл по программированию: {st.getAverage(0)}");


        Article article = new Article();
        article.code = "A001";
        article.title = "Ноутбук";
        article.price = 1500;
        article.type = ArticleType.Electronics;

        Client client = new Client();
        client.code = "C001";
        client.type = ClientType.VIP;

        Request request = new Request();
        request.codeOfOrder = 1;
        request.client = client;
        request.type = PayType.Card;
    }
}







