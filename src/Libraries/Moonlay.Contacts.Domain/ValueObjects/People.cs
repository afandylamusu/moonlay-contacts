﻿using Moonlay.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Moonlay.Contacts.Domain.ValueObjects
{
    public sealed class People : ValueObject, IPeople
    {
        public People(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; }

        public List<Address> Addresses { get; private set; }
        public List<Phone> Phones { get; private set; }

        public void AddAddress(Address address)
        {
            var addresses = Addresses ?? new List<Address>();

            if (!addresses.Any(o => o.Equals(address)))
                Addresses.Add(address);
            else
                throw Validator.ErrorValidation(("Address", "Was Exists"));
        }

        public void AddPhone(Phone phone)
        {
            var phones = Phones ?? new List<Phone>();

            if (!phones.Any(o => o.Equals(phone)))
                Phones.Add(phone);
            else
                throw Validator.ErrorValidation(("Phone", "Was Exists"));
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}