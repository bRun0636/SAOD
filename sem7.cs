using System.ComponentModel;

internal class Program
{
    private static void Main(string[] args)
    {
        StreamReader streamReader = new StreamReader("abv.txt");
        string s = streamReader.ReadToEnd();
        streamReader.Close();
        streamReader = new StreamReader("check.txt");
        string s2 = streamReader.ReadToEnd();
        streamReader.Close();

        List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();
        string[] test = s2.Split(' ');
        string[] arr = s.Split(' ');
        list.Add(new KeyValuePair<string, int>("", 1));
        bool check = true;
        for (int i = 0; i < 1000; i++)
        {
            check = false;
            for (int j = 0; j < list.Count; j++)
            { 
                if (list[j].Key == arr[i])
                {
                    check = true;
                    int count = list[j].Value + 1;
                    list[j] = new KeyValuePair<string, int>(list[j].Key, count);
                    break;
                }
            }
            if (!check) { list.Add(new KeyValuePair<string, int>(arr[i], 1)); }
        }
        Console.WriteLine("Количество уникальных слов: " + list.Count());

        for (int i = 0;i < test.Length;i++)
        {
            for (int j = 0; j < list.Count;j++)
            {
                if (test[i] == list[j].Key)
                {
                    Console.WriteLine(list[j].Key + " " + list[j].Value);
                }
            }

        }

        Console.WriteLine("Введите слово: ");
        string n = Console.ReadLine();
        while (n!="")
        {
            check = false;
            for (int i = 0; i < list.Count;i++)
            {
                if (list[i].Key == n)
                {
                    check = true;
                    Console.WriteLine(list[i].Value);
                    break;
                }
            }
            if (!check) { Console.WriteLine("0"); }
            n = Console.ReadLine();
        }
    }
}