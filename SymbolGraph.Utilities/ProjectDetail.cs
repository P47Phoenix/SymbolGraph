using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace SymbolGraph.Utilities;

public class ProjectDetail
{
    public string Name { get; set; }= string.Empty;

    public string Path { get; set; }= string.Empty;

    public List<DocumentDetail> Documents { get; set; } = new();

    public List<MetadataReference> MetadataReferences { get; set; } = new();
    
    public List<ProjectReference> ProjectReferences { get; set; } = new();
    
    public List<AnalyzerReference> AnalyzerReferences { get; set; } = new();

    public string AssemblyName { get; set; } = string.Empty;

    public string Language { get; set; } = string.Empty;
}