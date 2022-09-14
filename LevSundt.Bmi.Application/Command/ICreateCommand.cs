using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevSundt.Bmi.Application.Command
{
    internal interface ICreateCommand
    {
        void Create(BmiDto bmiDto);
    }
}
