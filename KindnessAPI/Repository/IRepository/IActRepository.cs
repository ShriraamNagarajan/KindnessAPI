using KindnessAPI.Models;

namespace KindnessAPI.Repository.IRepository
{
    public interface IActRepository : IRepository<Act>
    {
        Task<Act> UpdateAsync(Act act); 
    }
}
