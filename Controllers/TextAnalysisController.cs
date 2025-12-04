using Microsoft.AspNetCore.Mvc;
using TrapWireTextAnalysisApp_JamesNguyen.Services;

namespace TrapWireTextAnalysisApp_JamesNguyen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TextAnalysisController : ControllerBase
    {
        private readonly ITextAnalyzerService _textAnalyzer;
        public TextAnalysisController(ITextAnalyzerService textAnalyzer)
        {
            _textAnalyzer = textAnalyzer;
        }
        public class TextRequest
        {
            public string? Text { get; set; }
        }



        [HttpPost("Analyze")]
        public IActionResult Analyze([FromBody] TextRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Text))
            {
                return BadRequest("Text field is required.");
            }

            string input = request.Text;

            var result = _textAnalyzer.AnalyzeText(input);

            return Ok(result);
        }
    }
}