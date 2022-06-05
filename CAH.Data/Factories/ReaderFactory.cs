using CAH.Data.Classes;
using CAH.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAH.Data.Factories
{
    public class ReaderFactory : IReaderFactory
    {
        public IReader GetReader(ReaderType rt)
        {
            switch (rt)
            {
                case ReaderType.Text: return new TextFileReader();
                default:
                    throw new ArgumentException($"Invalid readerType : {rt}");
            }
        }
    }

    public enum ReaderType
    {
        Text,
        Database
    }
}
