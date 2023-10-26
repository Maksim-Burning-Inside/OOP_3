using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    interface IСurrency
    {
        double TranslateRubs();
        double Spawn_RandomAmount();
        double CrushCurrency { get; }
        string CODE { get; }
        double STATE { get; }
    }
}
