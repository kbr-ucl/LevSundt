using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevSundt.Bmi.Application.Repositories;

namespace LevSundt.Bmi.Application.Queries.Impementation
{
    public class BmiGetAllQuery : IBmiGetAllQuery
    {
        private readonly IBmiRepository _repository;

        public BmiGetAllQuery(IBmiRepository repository)
        {
            _repository = repository;
        }
        IEnumerable<BmiQueryResultDto> IBmiGetAllQuery.GetAll()
        {
            return _repository.GetAll();
        }
    }
}
