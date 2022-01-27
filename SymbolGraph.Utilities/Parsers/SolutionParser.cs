using Microsoft.CodeAnalysis;

namespace SymbolGraph.Utilities;

public class SolutionParser : IParser<Solution, SolutionDetail>
{
    private readonly IParser<Project,ProjectDetail> _projectParser;

    public SolutionParser(IParser<Project, ProjectDetail> projectParser)
    {
        _projectParser = projectParser;
    }
    public async Task<SolutionDetail> ParseAsync(Solution item)
    {
        var solution = new SolutionDetail
        {
            Name = Path.GetFileName(item.FilePath),
            FilePath = item.FilePath,
            Id = item.Id.Id,
        };

        foreach (var itemProject in item.Projects)
        {
            var project = await _projectParser.ParseAsync(itemProject);

            solution.Projects.Add(project);
        }

        return solution;
    }
}