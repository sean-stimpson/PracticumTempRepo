using MediatR;
using AAS.Data.Models;

namespace AAS.Data.Events
{
    public class GroupCreatedDomainEvent : INotification
    {
        public Group Group { get; }

        public GroupCreatedDomainEvent(Group group)
        {
            Group = group;
        }
    }
}
