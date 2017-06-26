using System.Collections.Generic;
using RESTauranter.Models;

namespace RESTauranter.Factory
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}