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
        
        foreach (var projectReference in item.ProjectReferences)
        {
            var parsedProjectReference = await _projectReferenceParser.ParseAsync(projectReference);
            project.ProjectReferences.Add(parsedProjectReference);
        }
        
        foreach (var metadataReference in item.MetadataReferences)
        {
            var parsedMetadataReference = await _metadataReferenceParser.ParseAsync(metadataReference);
            project.MetadataReferences.Add(parsedMetadataReference);
        }
        
        foreach (var analyzerReference in item.AnalyzerReferences)
        {
            var parsedAnalyzerReference = await _analyzerReferenceParser.ParseAsync(analyzerReference);
            project.AnalyzerReferences.Add(parsedAnalyzerReference);
        }
        return project;
    }
}