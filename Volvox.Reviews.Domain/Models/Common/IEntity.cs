namespace Volvox.Reviews.Domain.Models.Common
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
