using System.Collections;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.ValueObjects;

namespace Mc2.CrudTest.UnitTest;

public class UserFakeData
{
    public static Customer CreateUserCommand()
    {
        return new Customer(Guid.NewGuid(), "John", "Doe", new Email("johndoe@gmaill.com"), new PhoneNumber("+18185778330"), "1234567890",
            DateTime.Today);
    }

    public class CreateUserTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
                {Guid.NewGuid(), "John", "Doe", "", "+18185778330", "1234567890", DateTime.Today};
            yield return new object[]
                {Guid.NewGuid(), "John", "Doe", "johnDoe@gmail.com", "", "1234567890", DateTime.Today};
            yield return new object[]
                {Guid.NewGuid(), "", "Doe", "johnDoe@gmail.com", "+18185778330", "1234567890", DateTime.Today};
            yield return new object[]
                {Guid.NewGuid(), "John", "", "johnDoe@gmail.com", "+18185778330", "1234567890", DateTime.Today};
            yield return new object[]
                {Guid.NewGuid(), "John", "Doe", "johnDoe@gmail.com", "+18185778330", "", DateTime.Today};
            yield return new object[]
            {
                Guid.NewGuid(), "John", "Doe", "johnDoe@gmail.com", "+18185778330˝", "1234567890", DateTime.MinValue
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}