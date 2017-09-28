namespace CustomCommandTests
{
    using CustomCommand;
    using FluentAssertions;
    using NUnit.Framework;
    using System;

    public class AssertionExampleTests
    {
        [TestCase]
        public void DoSomething_ShouldThrowArgumentNullException_WhenSomeDataIsNull()
        {
            // arrange
            var assertionExample = new AssertionExample();

            // act
            Action action = () => assertionExample.DoSomething(null);

            // assert
            action.ShouldThrowExactly<ArgumentNullException>();
        }

        [TestCase]
        public void DoSomething_ShouldThrowArgumentException_WhenSomeStringIsEmpty()
        {
            // arrange
            var assertionExample = new AssertionExample();
            var someData = new SomeData { SomeString = string.Empty };

            // act
            Action action = () => assertionExample.DoSomething(someData);

            // assert
            action.ShouldThrowExactly<ArgumentException>();

            // act
            // assert
            try { action(); }
            catch (ArgumentException ex) { ex.Message.Should().Contain("someData.SomeString"); }
        }
    }
}