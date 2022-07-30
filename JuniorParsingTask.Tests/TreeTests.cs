using FluentAssertions;

namespace JuniorParsingTask.Tests
{
    public class TreeTests
    {
        private Tree _tree = null!;


        [SetUp]
        public void Setup()
        {
            _tree = CreateTree();
        }

        [TestCase("for")]
        [TestCase("lion")]
        [TestCase("sql")]
        [TestCase("dataedo")]
        public void TryGetNode_Should_Return_True_When_NodeExists(string value)
        {
            // Act
            var isFoundNode = _tree.TryGetNode(value, out var actualNode);

            // Assert
            isFoundNode.Should().BeTrue();
            (actualNode?.Value).Should().NotBeNull().And.Be(value);
        }
        
        [TestCase("for1")]
        [TestCase("lion2")]
        [TestCase("zyy")]
        public void TryGetNode_Should_Return_False_When_NodeNotExists(string value)
        {
            // Act
            var isFoundNode = _tree.TryGetNode(value, out var actualNode);

            // Assert
            isFoundNode.Should().BeFalse();
            actualNode.Should().BeNull();
        }
        
        [Test]
        public void TryGetNode_Should_Return_False_When_Tree_Is_Empty()
        {
            // Arrange
            var tree = new Tree(null!);

            // Act
            var isFoundNode = tree.TryGetNode("anyValue", out var actualNode);

            // Assert
            isFoundNode.Should().BeFalse();
            actualNode.Should().BeNull();
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void TryGetNode_Should_ThrowException_When_Value_Null_Or_WhiteSpace(string value)
        {
            // Arrange
            var act = () => _tree.TryGetNode(value, out _);

            // Act & Assert
            act.Should().Throw<ArgumentNullException>();
        }
        
        private static Tree CreateTree()
        {
            var root = new Node("root");
            var tree = new Tree(root);

            var a = new Node("xyz");
            var b = new Node("zyx");
            var c = new Node("yxz");
            var d = new Node("for");
            var e = new Node("sql");
            var f = new Node("double");
            var g = new Node("one");
            var h = new Node("two");
            var i = new Node("lion");
            var j = new Node("zebra");
            var k = new Node("dataedo");
            var l = new Node("parsing");
            var o = new Node("coding");
            var p = new Node("antlr");
            var r = new Node("learning");

            root.AddChildren(a, b, c);
            a.AddChildren(d, e);
            b.AddChildren(f, g, h);
            c.AddChildren(k, l);
            g.AddChildren(i, j);
            k.AddChildren(o, p);
            o.AddChild(r);

            return tree;
        }
    }
}