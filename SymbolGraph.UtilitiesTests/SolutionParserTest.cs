using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using SymbolGraph.Utilities;

namespace SymbolGraph.UtilitiesTests;

[TestFixture]
public class SolutionParserTest
{
    public const string
        SolutionName = "SymbolGraph.sln";
    
    [Test]
    public void SolutionName_IsFilledOut()
    {
        Assert.AreEqual(SolutionName, AssemblySetupTest.ParsedSolutionDetail.Name);
    }

    [Test]
    public void ProjectList_HasTwoProjects()
    {
        Assert.IsNotNull( AssemblySetupTest.ParsedSolutionDetail.Projects);
        Assert.AreEqual(2, AssemblySetupTest.ParsedSolutionDetail.Projects.Count);
    }

    [Test]
    public void FilePath_IsValid()
    {
        Assert.IsTrue(File.Exists(AssemblySetupTest.ParsedSolutionDetail.FilePath));
    }

    [Test]
    public void Id_IsNotNull()
    {
        Assert.IsNotNull(AssemblySetupTest.ParsedSolutionDetail.Id);    
    }
}


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