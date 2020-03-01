namespace ApiTemplate.Core.Domain.Interfaces
{
    public interface IDomainEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}