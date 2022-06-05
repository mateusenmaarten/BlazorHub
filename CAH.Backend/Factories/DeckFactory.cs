using CAH.Data.Factories;
using CAH.Data.Interfaces;


namespace CAH.Backend.Factories
{
    public abstract class DeckFactory<T>
        where T : Card
    {
        protected IReader Reader { get; private set; }
        public DeckFactory()
        {
            this.Reader = new ReaderFactory().GetReader(ReaderType.Text);
        }

        public abstract Deck<T> CreateDeck();
    }
}