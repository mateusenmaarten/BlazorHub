using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAH.Data.Interfaces
{
    public interface IReader
    {
        public List<string> GetAllAnswers();

        public List<string> GetAllQuestions();
 
    }
}
