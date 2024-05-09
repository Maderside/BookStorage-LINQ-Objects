using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStorage.Interfaces;

namespace BookStorage.Models
{
    public class Publisher: IModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Country { get; private set; }

        public Publisher(int id, string name, string coutry)
        {
            this.Id = id;
            this.Name = name;
            this.Country = coutry;
        }

        public override string ToString()
        {
            return string.Format(" {0}, {1}", Name, Country);
        }
    }
}
