

public abstract class Card
{
    public Card(Guid id, string text){
        ID = id;
        Text = text;
    }

    public Guid ID { get; private set; }
    public string Text { get; private set; } = string.Empty;
}



