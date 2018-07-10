using FluentValidator;

namespace ModernStore.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        public long Id { get; private set; }

        protected Entity()
        {
            Id = Id;
        }
    }
}
