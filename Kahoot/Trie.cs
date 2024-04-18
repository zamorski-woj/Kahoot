namespace Kahoot;

public class Trie
{
    public class Node
    {
        public Dictionary<char, Node> children;
        public bool isWord;

        public Node()
        {
            children = [];
            isWord = false;
        }
    }

    private readonly Node root;

    public Trie()
    {
        root = new Node();
    }

    public Trie(List<string> list)
    {
        root = new Node();
        foreach (string word in list)
        {
            this.Add(word);
        }
    }

    public void Add(string word)
    {
        Node currentNode = root;
        foreach (char letter in word)
        {
            if (!currentNode.children.TryGetValue(letter, out Node? value))
            {
                Node node = new();
                value = node;
                currentNode.children.Add(letter, value);
            }
            currentNode = value;//move down along the branch
        }
        currentNode.isWord = true;
    }

    public bool Contains(string word)
    {
        Node current = root;
        foreach (char letter in word)
        {
            if (current.children.TryGetValue(letter, out Node? value))
            {
                current = value;
            }
            else
            {
                return false;
            }
        }
        return current.isWord;//if it is not considered a word, do not confirm
    }

    public List<string> StartsWith(string query)
    {
        List<string> completedWords = [];

        Node current = root;
        foreach (char letter in query)
        {
            if (current.children.TryGetValue(letter, out Node? value))
            {
                current = value;
            }
            else
            {
                return completedWords;
            }
        }
        Autocomplete(current, query, completedWords);
        return completedWords;
    }

    private static void Autocomplete(Node current, string query, List<string> completedWords)
    {
        if (current.isWord)
        {
            completedWords.Add(query);
        }

        foreach (char key in current.children.Keys)
        {
            Autocomplete(current.children[key], query + key, completedWords);//recursively search for every match
        }
    }
}