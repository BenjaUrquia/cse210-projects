public class Card
{
    private string _suit;
    private string _rank;

    public Card(string suit, string rank)
    {
        _suit = suit;
        _rank = rank;
    }

    // Abstraction: Displaying essential information about the card
    public void DisplayCardInfo()
    {
        Console.WriteLine($"Card: {_rank} of {_suit}\n");
    }
}