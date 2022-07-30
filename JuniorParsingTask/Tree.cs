namespace JuniorParsingTask;

public class Tree
{
    public readonly Node? Root;
    public int Size { get; set; }

    public Tree(Node root)
    {
        Root = root;
    }

    public bool TryGetNode(string value, out Node? node)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(nameof(value));
        }

        node = GetEnumerableByRecursion(Root).FirstOrDefault(node => node is not null && node.Value.Contains(value));

        return node is not null;
    }

    private static IEnumerable<Node?> GetEnumerableByRecursion(Node? currentNode)
    {
        yield return currentNode;

        if (currentNode is null)
        {
            yield break;
        }
        
        foreach (var child in currentNode.Children.SelectMany(GetEnumerableByRecursion))
        {
            yield return child;
        }
    }
}