using System.Collections.Immutable;

namespace SymbolGraph.Utilities;

public class ProjectReferenceDetail
{
    public Guid ProjectId { get; set; } = Guid.Empty;
    public ImmutableArray<string> Aliases { get; set; }
    public bool EmbedInteropTypes { get; set; }
}