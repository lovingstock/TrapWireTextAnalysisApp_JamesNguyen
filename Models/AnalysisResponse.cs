namespace TrapWireTextAnalysisApp_JamesNguyen.Models
{
    public class AnalysisResponse
    {
        public int TotalLetters { get; set; }
        public int DistinctLetters { get; set; }
        public List<LetterResult> Results { get; set; } = new();
    }
}
