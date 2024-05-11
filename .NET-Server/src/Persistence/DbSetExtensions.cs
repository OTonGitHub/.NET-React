#nullable disable

namespace Persistence;

using Microsoft.EntityFrameworkCore;

public static class DbSetExtensions
{
    // annoying to pass `new object[] { key }` to find method everytime.
    public static ValueTask<T> FindByIdAsync<T, TKey>(
        this DbSet<T> _dbSet,
        TKey key,
        CancellationToken cancellationToken
    ) where T : class =>
        // uses collection expression for key, instead of new object.
        _dbSet.FindAsync([key], cancellationToken);
}