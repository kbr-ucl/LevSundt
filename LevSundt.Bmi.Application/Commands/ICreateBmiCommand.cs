using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevSundt.Bmi.Application.Commands
{
    public interface ICreateBmiCommand
    {
        void Create(BmiCreateRequestDto bmiCreateRequestDto);
    }
}
