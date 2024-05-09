using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStorage.Interfaces
{
    public interface IModel
    {
        int Id { get; }
        string ToString();
    }
}
