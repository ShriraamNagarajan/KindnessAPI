using KindnessAPI.Data;
using KindnessAPI.Models;
using KindnessAPI.Repository.IRepository;

namespace KindnessAPI.Repository
{
    public class ActRepository : Repository<Act>, IActRepository 
    {
        private readonly ApplicationDbContext _dbContext;

        public ActRepository(ApplicationDbContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
            
        }

        public async Task<Act> UpdateAsync(Act act)
        {
            act.UpdatedAt = DateTime.UtcNow;
            _dbContext.Acts.Update(act);
            await _dbContext.SaveChangesAsync();
            return act;
        }
    }
}
