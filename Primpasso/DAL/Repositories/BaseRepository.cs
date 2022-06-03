using Primpasso.Context;

namespace Primpasso.DAL.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly PrimpassoDbContext primpassoDbContext;

        public BaseRepository(PrimpassoDbContext dbContext)
        {
            primpassoDbContext = dbContext;
        }
    }
}
