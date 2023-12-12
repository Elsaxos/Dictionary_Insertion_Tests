using System.Collections.Generic;
using NUnit.Framework;

namespace TestApp.Tests
{
    [TestFixture]
    public class DictionaryIntersectionTests
    {
        [Test]
        public void Test_Intersect_TwoEmptyDictionaries_ReturnsEmptyDictionary()
        {
            // Arrange
            Dictionary<string, int> dict1 = new Dictionary<string, int>();
            Dictionary<string, int> dict2 = new Dictionary<string, int>();

            // Act
            Dictionary<string, int> result = DictionaryIntersection.Intersect(dict1, dict2);

            // Assert
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void Test_Intersect_OneEmptyDictionaryAndOneNonEmptyDictionary_ReturnsEmptyDictionary()
        {
            // Arrange
            Dictionary<string, int> dict1 = new Dictionary<string, int>();
            Dictionary<string, int> dict2 = new Dictionary<string, int> { { "apple", 1 } };

            // Act
            Dictionary<string, int> result = DictionaryIntersection.Intersect(dict1, dict2);

            // Assert
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void Test_Intersect_TwoNonEmptyDictionariesWithNoCommonKeys_ReturnsEmptyDictionary()
        {
            // Arrange
            Dictionary<string, int> dict1 = new Dictionary<string, int> { { "apple", 1 } };
            Dictionary<string, int> dict2 = new Dictionary<string, int> { { "orange", 2 } };

            // Act
            Dictionary<string, int> result = DictionaryIntersection.Intersect(dict1, dict2);

            // Assert
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndValues_ReturnsIntersectionDictionary()
        {
            // Arrange
            Dictionary<string, int> dict1 = new Dictionary<string, int> { { "apple", 1 }, { "banana", 2 } };
            Dictionary<string, int> dict2 = new Dictionary<string, int> { { "apple", 1 }, { "orange", 3 } };

            // Act
            Dictionary<string, int> result = DictionaryIntersection.Intersect(dict1, dict2);

            // Assert
            CollectionAssert.AreEquivalent(new Dictionary<string, int> { { "apple", 1 } }, result);
        }

        [Test]
        public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndDifferentValues_ReturnsEmptyDictionary()
        {
            // Arrange
            Dictionary<string, int> dict1 = new Dictionary<string, int> { { "apple", 1 }, { "banana", 2 } };
            Dictionary<string, int> dict2 = new Dictionary<string, int> { { "apple", 3 }, { "banana", 4 } };

            // Act
            Dictionary<string, int> result = DictionaryIntersection.Intersect(dict1, dict2);

            // Assert
            CollectionAssert.IsEmpty(result);
        }
    }
}
