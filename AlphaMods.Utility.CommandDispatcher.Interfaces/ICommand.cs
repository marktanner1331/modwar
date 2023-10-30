using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMods.Utility.CommandDispatcher.Interfaces
{
    public interface ICommand
    {
        string Identifier { get; }
    }
}
