using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevSundt.Bmi.Domain.Model;

namespace LevSundt.Bmi.Application.Repository
{
    public interface IBmiRepository
    {
        void Add(BmiEntity bmi);
        int GetNextId();
    }
}
