using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank2
{
    public abstract class Person
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string FullName => $"{FirstName} {LastName}";

        protected Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }

    public sealed class AccountOwner : Person
    {
        public int CustomerID { get; }

        public AccountOwner(int customerId, string firstName, string lastName)
            : base(firstName, lastName)
        {
            CustomerID = customerId;
        }
    }

    public sealed class AccountAdmin : Person
    {
        public int EmployeeID { get; }

        public AccountAdmin(int employeeId, string firstName, string lastName)
            : base(firstName, lastName)
        {
            EmployeeID = employeeId;
        }
    }
}
