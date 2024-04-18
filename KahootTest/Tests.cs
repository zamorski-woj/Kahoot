using FluentAssertions;
using Kahoot;

namespace KahootTest
{
    public class Tests
    {
        private readonly Trie dictionary = new(["car", "carpet", "java", "javascript", "internet"]);

        [Fact]  // a) After user types “c”, the function should return a list of two entries: “car” and “carpet”.
        public void TestA()
        {
            List<string> candidates = dictionary.StartsWith("c");
            candidates.Count.Should().Be(2);
            candidates.Should().Contain("car");
            candidates.Should().Contain("carpet");
        }

        [Fact]  // b) After user types “car”, the function should still return the same list of entries as above, that is “car” and “carpet”. Please note that “car” is still included.
        public void TestB()
        {
            List<string> candidates = dictionary.StartsWith("car");
            candidates.Count.Should().Be(2);
            candidates.Should().Contain("car");
            candidates.Should().Contain("carpet");
        }

        [Fact]  // c) After user types “carp”, the function should return a list of one entry: “carpet”.
        public void TestC()
        {
            List<string> candidates = dictionary.StartsWith("carp");
            candidates.Count.Should().Be(1);
            candidates.Should().Contain("carpet");
        }

        [Fact] //d) After user types “jav”, the function should return a list of two entries: “java” and “javascript”.
        public void TestD()
        {
            List<string> candidates = dictionary.StartsWith("jav");
            candidates.Count.Should().Be(2);
            candidates.Should().Contain("java");
            candidates.Should().Contain("javascript");
        }

        [Fact]  // e) After user types “intern”, the function should return a list of one entry: “internet”.
        public void TestE()
        {
            List<string> candidates = dictionary.StartsWith("intern");
            candidates.Count.Should().Be(1);
            candidates.Should().Contain("internet");
        }

        [Fact]  // f) After user types “foo”, the function should return an empty list, since there is not a single word in the dictionary we’re working on that starts with “foo”.
        public void TestF()
        {
            List<string> candidates = dictionary.StartsWith("foo");
            candidates.Count.Should().Be(0);
        }
    }
}