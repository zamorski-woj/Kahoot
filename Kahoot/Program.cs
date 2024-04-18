using Kahoot;

Trie dictionary = new(["car", "carpet", "java", "javascript", "internet"]);
List<string> candidates = dictionary.StartsWith("c");
foreach (string candidate in candidates)
{
    Console.WriteLine(candidate);
}