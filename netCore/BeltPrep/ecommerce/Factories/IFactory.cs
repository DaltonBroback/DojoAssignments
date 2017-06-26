using ecommerce.Models;
using System.Collections.Generic;
namespace ecommerce.Factory
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}