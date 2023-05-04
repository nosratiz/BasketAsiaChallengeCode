using System.Collections;

namespace Mc2.CrudTest.UnitTest;

public class UserFakeData
{
    public class CreateUserTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
                {Guid.NewGuid(), "John", "Doe", "", "989107602786", "1234567890", DateTime.Today};
            yield return new object[]
                {Guid.NewGuid(), "John", "Doe", "johnDoe@gmail.com", "", "1234567890", DateTime.Today};
            yield return new object[]
                {Guid.NewGuid(), "", "Doe", "johnDoe@gmail.com", "989107602786", "1234567890", DateTime.Today};
            yield return new object[]
                {Guid.NewGuid(), "John", "", "johnDoe@gmail.com", "989107602786", "1234567890", DateTime.Today};
            yield return new object[]
                {Guid.NewGuid(), "John", "Doe", "johnDoe@gmail.com", "989107602786", "", DateTime.Today};
            yield return new object[]
            {
                Guid.NewGuid(), "John", "Doe", "johnDoe@gmail.com", "989107602786˝", "1234567890", DateTime.MinValue
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}