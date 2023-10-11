namespace BackendSchedule.Domain.DataStructure
{
    public sealed class Customer
    {
        public Customer(string name, string phone, string? email)
        {
            ValidateDomain(name, phone, email);
        }

        public string Name { get; private set; }
        public string? Email { get; private set; }
        public string Phone { get; private set; }

        private void ValidateDomain(string name, string phone, string? email)
        {
            if (email == "")
            {
                email = null;
            }

            Name = name;
            Email = email;
            Phone = phone;
        }

    }

}


