using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStorage.GroupedModels
{
    public class GroupedModelAndCount : GroupedModel
    {
        public int CountValue { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Model, CountValue);
        }
    }
}
