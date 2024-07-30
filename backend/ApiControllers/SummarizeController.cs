using Microsoft.AspNetCore.Mvc;
using YoutubeSummarizer.Backend.Services;
using YoutubeSummarizer.Model;

namespace YoutubeSummarizer.Backend.ApiControllers;

[ApiController]
[Route("[controller]")]
public class SummarizeController(ILogger<SummarizeController> logger,
                            IYoutubeSummarizeService summarizer) : ControllerBase
{
    private readonly ILogger<SummarizeController> _logger = logger
        ?? throw new ArgumentNullException(nameof(logger), Errors.NULL_ERROR);

    private readonly IYoutubeSummarizeService _summarizer = summarizer
        ?? throw new ArgumentNullException(nameof(summarizer), Errors.NULL_ERROR);

    [HttpPost]
    public async Task<string> Post([FromBody] SummaryRequest req)
    {
        var summary = await _summarizer.SummariseAsync(req);
        return summary;
    }
}