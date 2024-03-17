using System;

class Program
{
    static Random random = new Random();
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
        scripture.Display();

        Console.WriteLine("Press Enter to continue or type 'quit' to exit.");

        string input;
        do
        {
            input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWord();
            scripture.Display();

            if (scripture.AllWordsHidden())
            {
                Console.WriteLine("All words are hidden. Press Enter to exit.");
                Console.ReadLine();
                break;
            }

            Console.WriteLine("Press Enter to continue or type 'quit' to exit.");

        } while (input.ToLower() != "quit");
    }
}

class Scripture
{
    private Reference reference;
    private List<Word> words;
    private Random random;

    public Scripture(string verse, string text)
    {
        reference = new Reference(verse);
        words = new List<Word>();
        random = new Random();

        string[] wordArray = text.Split(' ');
        foreach (string w in wordArray)
        {
            words.Add(new Word(w));
        }
    }

    public void Display()
    {
        reference.Display();
        foreach (Word word in words)
        {
            Console.Write(word.IsHidden ? "_____ " : word.Text + " ");
        }
        Console.WriteLine();
    }

    public void HideRandomWord()
    {
        // Get a list of indices of non-hidden words
        List<int> nonHiddenIndices = new List<int>();
        for (int i = 0; i < words.Count; i++)
        {
            if (!words[i].IsHidden)
                nonHiddenIndices.Add(i);
        }

        // If no non-hidden words left, return
        if (nonHiddenIndices.Count == 0)
            return;

        // Choose a random index from non-hidden words
        int index = nonHiddenIndices[random.Next(0, nonHiddenIndices.Count)];
        words[index].Hide();
    }

    public bool AllWordsHidden()
    {
        foreach (Word word in words)
        {
            if (!word.IsHidden)
                return false;
        }
        return true;
    }
}

class Reference
{
    private string verse;

    public Reference(string verse)
    {
        this.verse = verse;
    }

    public void Display()
    {
        Console.WriteLine(verse);
    }
}

class Word
{
    private string text;
    private bool isHidden;

    public string Text { get => text; }
    public bool IsHidden { get => isHidden; }

    public Word(string text)
    {
        this.text = text;
        this.isHidden = false;
    }

    public void Hide()
    {
        this.isHidden = true;
    }
}