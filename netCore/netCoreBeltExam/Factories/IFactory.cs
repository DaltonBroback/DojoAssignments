using netCoreBeltExam.Models;
using System.Collections.Generic;
namespace netCoreBeltExam.Factory
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}