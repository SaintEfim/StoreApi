﻿using Stores.Domain.Entity;

namespace Stores.Api.Models.Address
{
    public class AddressDto
    {
        public int AddressId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
    }
}
