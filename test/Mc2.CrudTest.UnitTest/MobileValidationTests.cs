using FluentAssertions;
using Mc2.CrudTest.Domain.Validators;
using Xunit;

namespace Mc2.CrudTest.UnitTest;

public class MobileValidationTests
{
   [Theory]
   [InlineData("+989107602786", true)]
   [InlineData("+982187654321", false)]
   [InlineData("", false)]
   public void mobile_validationTest_WithExpectedResult(string testCase, bool expectedResult)
   {
      bool testResult = MobileValidator.IsValid(testCase);

      testResult.Should().Be(expectedResult);
   }
}