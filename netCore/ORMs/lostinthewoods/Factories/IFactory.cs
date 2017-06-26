using lostinthewoods.Models;
using System.Collections.Generic;
namespace lostinthewoods.Factory
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}