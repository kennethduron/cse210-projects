public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;
    private string _mood;

    public Entry(string date, string promptText, string entryText, string mood)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
        _mood = mood;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Mood: {_mood}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Response: {_entryText}");
        Console.WriteLine();
    }

    public string ToCsv()
    {
        return $"{Escape(_date)},{Escape(_promptText)},{Escape(_entryText)},{Escape(_mood)}";
    }

    private string Escape(string value)
    {
        return $"\"{value.Replace("\"", "\"\"")}\"";
    }

    public static Entry FromCsv(string line)
    {
        List<string> parts = ParseCsvLine(line);

        return new Entry(parts[0], parts[1], parts[2], parts[3]);
    }

    private static List<string> ParseCsvLine(string line)
    {
        List<string> values = new List<string>();
        string currentValue = "";
        bool insideQuotes = false;

        for (int i = 0; i < line.Length; i++)
        {
            char currentChar = line[i];

            if (currentChar == '"' && insideQuotes && i + 1 < line.Length && line[i + 1] == '"')
            {
                currentValue += '"';
                i++;
            }
            else if (currentChar == '"')
            {
                insideQuotes = !insideQuotes;
            }
            else if (currentChar == ',' && !insideQuotes)
            {
                values.Add(currentValue);
                currentValue = "";
            }
            else
            {
                currentValue += currentChar;
            }
        }

        values.Add(currentValue);
        return values;
    }
}