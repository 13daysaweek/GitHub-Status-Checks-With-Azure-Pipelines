using System.Collections.Generic;

namespace CalculatorApi.Models
{
    public class MultiInputModel
    {
        public MultiInputModel()
        {
            Inputs = new List<decimal>();
        }
        
        public IList<decimal> Inputs { get; set;  }
    }
}
