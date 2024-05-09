using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStorage.Models;
using BookStorage.Interfaces;

namespace BookStorage.GroupedModels
{

    public class GroupedModel
    {
        public IEnumerable<IModel> Group { get; set; }
        public IModel Model { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", Model);
        }
    }
}