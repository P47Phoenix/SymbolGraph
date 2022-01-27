namespace SymbolGraph.Utilities;

public class SolutionDetail
{
    public string Name { get; set; } = string.Empty;

    public List<ProjectDetail> Projects { get; set; } = new();
    public string FilePath { get; set; } = string.Empty;
    public Guid Id { get; set; } = Guid.Empty;
}