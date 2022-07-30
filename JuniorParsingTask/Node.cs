using System.Collections;

namespace JuniorParsingTask;

public class Node
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
}