public class PromptDeck
{
    private List<string> _items;
    private List<string> _availableItems;
    private Random _random;

    public PromptDeck(List<string> items)
    {
        _items = items;
        _availableItems = new List<string>(items);
        _random = new Random();
    }

    public string GetRandomItem()
    {
        if (_availableItems.Count == 0)
        {
            _availableItems = new List<string>(_items);
        }

        int index = _random.Next(_availableItems.Count);
        string item = _availableItems[index];
        _availableItems.RemoveAt(index);

        return item;
    }
}
