using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5
{
    class Book
    {
        private string authorName;
        private string authorSurname;
        private string bookName;
        private string code;
        private int year;
        private int pageCount;
        private string genre;

        public Book() { } //конструктор без параметров

        public Book(string a, string b, string c, string d, int e, int f, string g) //конструктор с параметрами
        {
            this.authorName = a;
            this.authorSurname = b;
            this.bookName = c;
            this.code = d;
            this.year = e;
            this.pageCount = f;
            this.genre = g;
        }
        //методы сравнения 2 книг
        public int CompareByAuthor(Book A)
        {
            if (pageCount.CompareTo(A.pageCount) == 0)
            {
                Console.WriteLine("Книги '{0}' и '{1}' имеют одинаковое количество страниц - {2};", bookName, A.bookName, A.pageCount);
                return 1;
            }
            else
            {
                Console.WriteLine("Книги '{0}' и {1}' имеют разное количество страниц", bookName, A.bookName);

                if (pageCount > A.pageCount)
                {
                    Console.WriteLine("В книге '{0}' страниц больше чем в книге '{1}'", bookName, A.bookName);
                }
                else
                {
                    Console.WriteLine("В книге '{0}' страниц больше чем в книге '{1}'", A.bookName, bookName);
                }
                return 0;
            }
        }

        public int CompareByGenre(Book A)
        {
            if (genre.CompareTo(A.genre) == 0)
            {
                Console.WriteLine("Книги '{0}' и '{1}' имеют одинаковый жанр - {2};", bookName, A.bookName, A.genre);
                return 1;
            }
            else
            {
                Console.WriteLine("Книги '{0}' и '{1}' имеют разные жанры.", bookName, A.bookName);
                return 0;
            }
        }

        //поиск книги по коду
        public Book SearchByCode(Book[] A, ref string desire_code)
        {
            for (int i = 0; i < A.Length; i++)
            {
                if ((String.Equals(A[i].code, desire_code)))
                    return A[i];
            }
            return null;
        }

        //перегрузка метода ToString
        public override string ToString()
        {
            string info = String.Empty;
            info += ("Название книги: " + bookName + ";\n");
            info += ("Автор: " + authorName + " " + authorSurname + ";\n");
            info += ("Код - " + code + ";\n");
            info += ("Год издания: " + year + ";\n");
            info += ("Количество страниц книги: " + pageCount + ";\n");
            info += ("Жанр книги: " + genre + ";\n");
            return info;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            Book[] book = new Book[n];
            book[0] = new Book("Эрнест", "Хемингуэй", "Старик и море", "1234", 1952, 320, "Повесть");
            book[1] = new Book("Стивен", "Кинг", "Зеленая миля", "1531", 1996, 384, "Роман");
            book[2] = new Book("Эрих Мария", "Ремарк", "Три товарища", "2532", 1932, 448, "Роман");
            book[3] = new Book("Чак", "Паланик", "Бойцовский клуб", "3431", 1996, 555, "Роман");
            book[4] = new Book("Марио", "Пьюзо", "Крестный отец", "4228", 1988, 555, "Роман");

            Console.WriteLine("Книги в наличии:\n");
            for (int i = 0; i < book.Length; i++)
                Console.WriteLine(book[i]);

            Console.WriteLine("Поиск книги по коду:");
            int flag1 = 1;
            while (flag1 == 1)
            {
                string desire_code;
                Console.WriteLine("Введите код для поиска нужной книги:");
                desire_code = Console.ReadLine();
                Book searchBook = new Book();
                searchBook = searchBook.SearchByCode(book, ref desire_code);

                if (searchBook != null)
                {
                    Console.WriteLine(searchBook);
                }
                else Console.WriteLine("Книг с указанным кодом ({0}) не найдено.", desire_code);

                Console.Write("Продолжать поиск по коду? (да, нет): ");
                string answer1 = Console.ReadLine();
                if (String.Equals(answer1, "нет"))
                    break;
            }

            Console.WriteLine("\nСравнение 2 книг параметру:");
            int flag = 1;
            while (flag == 1)
            {
                Console.Write("Введите критерий сравнениия (объем или жанр): ");
                string choice = Console.ReadLine();
                Console.WriteLine("Введите номера сравниваемых книг (1-5):");
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case "объем":
                        book[a - 1].CompareByAuthor(book[b - 1]);
                        break;
                    case "жанр":
                        book[a - 1].CompareByGenre(book[b - 1]);
                        break;
                    default:
                        Console.WriteLine("Недопустимый вариант ответа");
                        break;
                }
                Console.Write("Продолжить сравнение? (да, нет): ");
                string answer = Console.ReadLine();
                if (String.Equals(answer, "нет"))
                    break;
            }
        }
    }
}
