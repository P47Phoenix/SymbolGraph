using System.IO;
using System.Linq;
using NUnit.Framework;

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