using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    WriteNewEntry(journal);
                    break;
                case "2":
                    DisplayJournal(journal);
                    break;
                case "3":
                    SaveJournalToFile(journal);
                    break;
                case "4":
                    LoadJournalFromFile(journal);
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
            }
        }
    }

    static void WriteNewEntry(Journal journal)
    {
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        Random random = new Random();
        int index = random.Next(prompts.Length);
        string prompt = prompts[index];

        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        Entry entry = new Entry(DateTime.Now, prompt, response);
        journal.AddEntry(entry);
    }

    static void DisplayJournal(Journal journal)
    {
        Console.WriteLine("Journal Entries:");
        foreach (Entry entry in journal.Entries)
        {
            Console.WriteLine($"{entry.Date}: {entry.Prompt}\n{entry.Response}\n");
        }
    }
static void SaveJournalToFile(Journal journal)
{
    Console.Write("Enter filename to save: ");
    string filename = Console.ReadLine();

    using (StreamWriter writer = new StreamWriter(filename))
    {
        foreach (Entry entry in journal.Entries)
        {
            writer.WriteLine($"{entry.Date.ToString("MM/dd/yyyy hh:mm:ss tt")}: {entry.Prompt}");
            writer.WriteLine(entry.Response);
            writer.WriteLine();
        }
    }

    Console.WriteLine("Journal saved to file.");
}

static void LoadJournalFromFile(Journal journal)
{
    Console.Write("Enter filename to load: ");
    string filename = Console.ReadLine();

    if (File.Exists(filename))
    {
        journal.ClearEntries();

        using (StreamReader reader = new StreamReader(filename))
        {
            while (!reader.EndOfStream)
            {
                DateTime date = DateTime.ParseExact(reader.ReadLine().Replace(":", "").Trim(), "MM/dd/yyyy hh:mm:ss tt", null);
                string prompt = reader.ReadLine();
                string response = reader.ReadLine();
                reader.ReadLine(); // empty line

                Entry entry = new Entry(date, prompt, response);
                journal.AddEntry(entry);
            }
        }

        Console.WriteLine("Journal loaded from file.");
    }
    else
    {
        Console.WriteLine("File not found.");
    }
}


class Journal
{
    private List<Entry> _entries;

    public List<Entry> Entries { get { return _entries; } }

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void ClearEntries()
    {
        _entries.Clear();
    }
}

class Entry
{
    public DateTime Date { get; }
    public string Prompt { get; }
    public string Response { get; }

    public Entry(DateTime date, string prompt, string response)
        {
            Date = date;
            Prompt = prompt;
            Response = response;
        }
    }
}