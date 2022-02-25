using System.Collections.Generic;
using NUnit.Framework;
using SymbolGraph.Utilities;

namespace SymbolGraph.UtilitiesTests;

[TestFixtureSource(nameof(ProjectDetails))]
public class ProjectParserTest
{
    private const string
        SymbolGraphUtilities = "SymbolGraph.Utilities",
        SymbolGraphUtilitiesTests = "SymbolGraph.UtilitiesTests",
        SymbolGraphUtilitiesAssembly = "SymbolGraph.Utilities",
        SymbolGraphUtilitiesTestsAssembly = "SymbolGraph.UtilitiesTests";
    
    private readonly ProjectDetail _projectDetail;

    public ProjectParserTest(ProjectDetail projectDetail)
    {
        _projectDetail = projectDetail;
    }

    [Test]
    public void Name_IsValid()
    {
        if (_projectDetail.Name == SymbolGraphUtilitiesTests)
        {
            Assert.AreEqual(SymbolGraphUtilitiesTests, _projectDetail.Name);
        }
        else if (_projectDetail.Name == SymbolGraphUtilities)
        {
            Assert.AreEqual(SymbolGraphUtilities, _projectDetail.Name);
        }
        else
        {
            Assert.Fail("Unexpected project");
        }
    }

    [Test]
    public void AssemblyName()
    {
        if (_projectDetail.Name == SymbolGraphUtilitiesTests)
        {
            Assert.AreEqual(SymbolGraphUtilitiesTestsAssembly, _projectDetail.AssemblyName);
        }
        else if (_projectDetail.Name == SymbolGraphUtilities)
        {
            Assert.AreEqual(SymbolGraphUtilitiesAssembly, _projectDetail.AssemblyName);
        }
        else
        {
            Assert.Fail("Unexpected project");
        }
    }
    
    public static List<ProjectDetail> ProjectDetails()
    {
        return AssemblySetupTest.ParsedSolutionDetail.Projects;
    }
}