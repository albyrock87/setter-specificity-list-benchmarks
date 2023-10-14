using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using SetterSpecificityListPerfBenchmarks.Benchmarks;

var summaries = BenchmarkRunner.Run(new []
{
    typeof(CreateContextBenchmark),
    typeof(AddValueBenchmark),
    typeof(AddValuesBenchmark),
    typeof(AddAndRemoveValueBenchmark),
    typeof(GetValueBenchmark),
    typeof(GetValueOnMultipleValuesBenchmark),
    typeof(AddAndRemoveManyValuesBenchmark)
});

var logger = ConsoleLogger.Default;
foreach (var summary in summaries)
{
    logger.WriteLine($"\n\n### {summary.Title}\n");
    MarkdownExporter.GitHub.ExportToLog(summary, logger);
}
