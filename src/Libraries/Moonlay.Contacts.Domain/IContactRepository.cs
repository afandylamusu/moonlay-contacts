﻿using Moonlay.Contacts.Domain.ValueObjects;
using Moonlay.Domain;
using System.Threading.Tasks;

namespace Moonlay.Contacts.Domain
{
    public interface IContactRepository : IRepository<Contact>
    {
        Task<Contact> AddAsync(People people);

        Task UpdateAsync(Contact contact);

        Task<Contact> GetAsync(int contactId);

    }
}