using CAH.Data.Interfaces;

namespace CAH.Data.Factories
{
    public interface IReaderFactory
    {
        IReader GetReader(ReaderType rt);
    }
}