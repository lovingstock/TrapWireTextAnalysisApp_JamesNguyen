using TrapWireTextAnalysisApp_JamesNguyen.Services;

namespace ServiceTests
{
    [TestClass]
    public class TextAnalyzerServiceTests
    {
        [TestMethod]
        [DataRow("Hello World!", 10, 7, DisplayName = "Hello World! has 10 letters, with 7 distinct")]
        [DataRow("12345", 0, 0, DisplayName = "12345 has 0 letters, with 0 distinct")]
        [DataRow("AaBbCc", 6, 3, DisplayName = "AaBbCc has 6 letters, with 3 distinct")]
        public void CountLetters_Tests(string text, int expectedTotalCount, int expectedDistinctCount)
        {
            // Arrange
            var service = new TextAnalyzerService();
            // Act
            var result = service.CountLetters(text);
            // Assert
            Assert.AreEqual(expectedTotalCount, result.Values.Sum());
            Assert.AreEqual(expectedDistinctCount, result.Keys.Count());
        }

        [TestMethod]
        public void CalculatePercentage_Tests()
        {
            var service = new TextAnalyzerService();
            Dictionary<char, int> counts = new();

            // Arrange
            counts['a'] = 1; //Input has 100% a
            // Act
            var result = service.CalculatePercentage(counts);
            // Assert
            var aResult = result.Find(r => r.Letter == 'a');
            Assert.IsNotNull(aResult);
            Assert.AreEqual(100, aResult!.Percent);

            // Arrange
            counts['b'] = 3; //Input has 25% a, 75% b
            // Act
            result = service.CalculatePercentage(counts);
            // Assert
            aResult = result.Find(r => r.Letter == 'a');
            Assert.AreEqual(25, aResult!.Percent);
        }

        [TestMethod]
        [DataRow("Hello World!", 10, 7, DisplayName = "Hello World! has 10 letters, with 7 distinct")]
        [DataRow("12345", 0, 0, DisplayName = "12345 has 0 letters, with 0 distinct")]
        [DataRow("AaBbCc", 6, 3, DisplayName = "AaBbCc has 6 letters, with 3 distinct")]
        public void AnalyzeText_Tests(string text, int expectedTotalCount, int expectedDistinctCount)
        {
            // Arrange
            var service = new TextAnalyzerService();
            // Act
            var result = service.AnalyzeText(text);
            // Assert
            Assert.AreEqual(expectedTotalCount, result.TotalLetters);
            Assert.AreEqual(expectedDistinctCount, result.DistinctLetters);
        }

    }
}
