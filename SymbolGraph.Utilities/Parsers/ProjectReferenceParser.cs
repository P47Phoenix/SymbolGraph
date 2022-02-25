using Microsoft.CodeAnalysis;

namespace SymbolGraph.Utilities.Parsers;

public class ProjectReferenceParser : IParser<ProjectReference, ProjectReferenceDetail>
{
    public Task<ProjectReferenceDetail> ParseAsync(ProjectReference item)
    {
        var parsedProjectReferenceDetail = new ProjectReferenceDetail
        {
            ProjectId = item.ProjectId.Id,
            Aliases = item.Aliases,
            EmbedInteropTypes = item.EmbedInteropTypes
        };

        return Task.FromResult(parsedProjectReferenceDetail);
    }
}