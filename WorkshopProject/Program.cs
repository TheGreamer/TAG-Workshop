using System.Collections;

/*
1. ve 2. Çalışmanın Çözümü
---------------------------
Rahat kullanılabilmesi adına ekstra ufak geliştirmeler yaptım.
Uygulamayı sıfırlamadan tekrar çalıştırabilirsiniz.
3. Çalışma projenin dosya dizininde yer almaktadır. Sql dosyasıdır.
*/

internal class Program
{
    // Program başlatılır.
    private static void Main()
    {
        Console.Write("~ TAG BİLİŞİM | WORKSHOP ~\n___________________________\n\n\n");
        SelectTask();
    }

    // Program başladığı aşamaya geri döner.
    private static void RestartProgram()
    {
        Console.Write("\nBaşka bir programa geçiş yapmak için bir tuşa basınız...");
        Console.ReadKey();
        Console.Clear();
        SelectTask();
    }

    // Çalıştırılacak çalışmanın seçiminin yapılmasını sağlar.
    private static void SelectTask()
    {
    Again:
        Console.Write("Çalıştırılacak programın numarası seçiniz (1, 2) : ");
        int taskId;

        try
        {
            taskId = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            Console.Write("\nGeçersiz bir değer girdiniz.\n\n");
            goto Again;
        }

        RunTask(taskId);
    }

    // Parametresinde generic olarak gösterilen dizinin tüm elemanlarını ekranda gösterir.
    private static void WriteValues<T>(T[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine($"{i + 1}) " + array[i]);
        }
    }

    // Çalışmanın 1. maddesi için ilk case, 2. maddesi için ise ikinci case çalışır.
    private static void RunTask(int taskId)
    {
        switch (taskId)
        {
            case 1:
                ArrayList arrayList = new() { 5, 15, 25, "Kırmızı", "Yeşil", "Mavi" };
                string[] stringList = arrayList.OfType<string>().ToArray();
                Console.Write("\nArray list içerisindeki bütün string değerler listeleniyor...\n");
                WriteValues(stringList);
                RestartProgram();
                break;

            case 2:
                ArrayList numberList = new() { 124, 149, 128, 45, 67, 1092, 112, 15 };
                int[] orderedNumberList = numberList.OfType<int>().OrderBy(number => number).ToArray();
                Console.Write("\nArray list içerisindeki bütün sayılar sıralanıyor...\n");
                WriteValues(orderedNumberList);
                RestartProgram();
                break;

            default:
                Console.Write("\n1 ve 2 numaraları dışında bir seçim yaptınız.\n");
                RestartProgram();
                break;
        }
    }
}