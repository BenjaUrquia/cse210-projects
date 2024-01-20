public class Player
{
    private string _playerName;
    private List<Card> _hand;

    public Player(string playerName)
    {
        _playerName = playerName;
        _hand = new List<Card>();
    }

    // Abstraction: Adding a card to the player's hand
    public void AddCardToHand(Card card)
    {
        _hand.Add(card);
    }

    // Abstraction: Displaying essential information about the player's hand
    public void DisplayHand()
    {
        Console.WriteLine($"{_playerName}'s Hand:\n");
        foreach (var card in _hand)
        {
            card.DisplayCardInfo();  // Reusing abstraction from the Card class
        }
    }
}