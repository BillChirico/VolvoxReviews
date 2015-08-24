namespace Volvox.Reviews.Domain.Models.Common
{
    /// <summary>
    /// Entity
    /// </summary>
    /// <typeparam name="T">Type of Id</typeparam>
    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        public virtual T Id { get; set; }
    }
}