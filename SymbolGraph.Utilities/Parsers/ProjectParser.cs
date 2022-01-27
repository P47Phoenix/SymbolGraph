using System.Collections.Concurrent;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace SymbolGraph.Utilities;

public class ProjectParser : IParser<Project, ProjectDetail>
{
    private readonly IParser<Document,DocumentDetail> _documentParser;
    private readonly IParser<ProjectReference, ProjectReferenceDetail> _projectReferenceParser;
    private readonly IParser<MetadataReference, MetadataReferenceDetail> _metadataReferenceParser;
    private readonly IParser<AnalyzerReference, AnalyzerReferenceDetail> _analyzerReferenceParser;

    public ProjectParser(
        IParser<Document, DocumentDetail> documentParser,
        IParser<ProjectReference, ProjectReferenceDetail> projectReferenceParser,
        IParser<MetadataReference, MetadataReferenceDetail> metadataReferenceParser,
        IParser<AnalyzerReference, AnalyzerReferenceDetail> analyzerReferenceParser)
    {
        _documentParser = documentParser;
        _projectReferenceParser = projectReferenceParser;
        _metadataReferenceParser = metadataReferenceParser;
        _analyzerReferenceParser = analyzerReferenceParser;
    }
    
    public async Task<ProjectDetail> ParseAsync(Project item)
    {
        var project = new ProjectDetail()
        {
            Name = item.Name,
            Path = item.FilePath,
            AssemblyName = item.AssemblyName,
            Language = item.Language,
        };
        
        foreach (var itemDocument in item.Documents)
        {
            var doc = await _documentParser.ParseAsync(itemDocument);
            project.Documents.Add(doc);
        }
        
        foreach (var projectReferences in item.ProjectReferences)
        {
            
        }
        
        foreach (var metadataReferences in item.MetadataReferences)
        {
            
        }
        
        foreach (var analyzerReferences in item.AnalyzerReferences)
        {
            
        }
        return project;
    }
}