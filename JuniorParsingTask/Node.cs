using System.Collections;

namespace JuniorParsingTask;

public class Node : IEnumerable<Node>
{
    public readonly string Value;
    public readonly List<Node> Children;

    public Node(string value)
    {
        Value = value;
        Children = new List<Node>();
    }

    public void AddChild(Node child)
    {
        Children.Add(child);
    }

    public void AddChildren(params Node[] children)
    {
        Children.AddRange(children);
    }

    public bool TryGetNode(string value, out Node? node)
    {
        node = this.FirstOrDefault(node => node.Value.Contains(value));

        return node is not null;
    }

    public IEnumerator<Node> GetEnumerator() => GetEnumerableByRecursion(this).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private static IEnumerable<Node> GetEnumerableByRecursion(Node currentNode)
    {
        yield return currentNode;

        foreach (var child in currentNode.Children.SelectMany(GetEnumerableByRecursion))
        {
            yield return child;
        }
    }
}