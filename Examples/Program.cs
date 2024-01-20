class Program
{
    static void Main()
    {
        Card card1 = new Card("Hearts", "Ace");
        Card card2 = new Card("Spades", "King");

        Player player1 = new Player("Alice");
        player1.AddCardToHand(card1);
        player1.AddCardToHand(card2);

        // Abstraction in action: Displaying card information without exposing internal details
        card1.DisplayCardInfo();

        // Abstraction in action: Displaying player's hand information without exposing internal details
        player1.DisplayHand();
    }
}