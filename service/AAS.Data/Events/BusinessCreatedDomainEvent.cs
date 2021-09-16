using AAS.Data.Models;
using MediatR;

namespace AAS.Data.Events
{
    public class BusinessCreatedDomainEvent : INotification
    {
        public Business Business;

        public BusinessCreatedDomainEvent(Business business)
        {
            Business = business;
        }
    }
}