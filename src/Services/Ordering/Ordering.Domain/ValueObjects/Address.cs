namespace Ordering.Domain.ValueObjects
{
    public record Address
    {
        public string FirstName { get; } = default!;
        public string LastName { get; } = default!;
        public string EmailAddress { get; } = default!;
        public string AddressLine { get; } = default!;
        public string Country { get; } = default!;
        public string City { get; } = default!;
        protected Address() { }
        private Address(string firstName, string lastName, string emailAddress, string addressLine, string country, string city)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            AddressLine = addressLine;
            Country = country;
            City = city;
        }
        public static Address Of(string firstName, string lastName, string emailAddress, string addressLine, string country, string city)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(emailAddress);
            ArgumentException.ThrowIfNullOrWhiteSpace(addressLine);
            return new Address(firstName, lastName, emailAddress, addressLine, country, city);
        }
    }
}