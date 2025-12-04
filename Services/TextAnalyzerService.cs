using System.Runtime.CompilerServices;
using TrapWireTextAnalysisApp_JamesNguyen.Models;

[assembly: InternalsVisibleTo("ServiceTests")]
namespace TrapWireTextAnalysisApp_JamesNguyen.Services
{
    public interface ITextAnalyzerService
    {
        AnalysisResponse AnalyzeText(string input);
    }
    public class TextAnalyzerService : ITextAnalyzerService
    {
        public AnalysisResponse AnalyzeText(string input)
        {
            var counts = CountLetters(input);

            if (counts.Values.Sum() == 0) // no letters found
            {
                return new AnalysisResponse
                {
                    TotalLetters = 0,
                    DistinctLetters = 0,
                    Results = new List<LetterResult>()
                };
            }

            var results = CalculatePercentage(counts);

            return new AnalysisResponse
            {
                TotalLetters = counts.Values.Sum(),
                DistinctLetters = results.Count,
                Results = results
            };
        }

        /// <summary>
        /// Calculate the percentage representation of each letter based on the provided counts.
        /// </summary>
        /// <param name="counts"></param>
        internal List<LetterResult> CalculatePercentage(Dictionary<char, int> counts)
        {
            var totalLetters = counts.Values.Sum();
            var results = counts
                .OrderBy(c => c.Key)
                .Select(c => new LetterResult
                {
                    Letter = c.Key,
                    Count = c.Value,
                    Percent = (double)c.Value / totalLetters * 100
                })
                .ToList();

            return results;
        }

        /// <summary>
        /// Count A-Z letters only, and their occurrences in the input string
        /// </summary>
        /// <param name="counts"></param>
        /// <param name="input"></param>
        internal Dictionary<char, int> CountLetters(string input)
        {
            Dictionary<char, int> counts= new();

            foreach (char ch in input)
            {
                if (char.IsLetter(ch))
                {
                    char upper = char.ToUpper(ch);
                    if (!counts.ContainsKey(upper))
                        counts[upper] = 0;

                    counts[upper]++;
                }
            }

            return counts;
        }
    }
}
