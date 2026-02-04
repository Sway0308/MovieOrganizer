using System.Collections.Generic;
using System.Linq;

namespace Category.Standard.Helpers
{
    public class AhoCorasick
    {
        private class Node
        {
            public Dictionary<char, Node> Children { get; } = new Dictionary<char, Node>();
            public Node Failure { get; set; }
            public List<string> Outputs { get; } = new List<string>();
        }

        private readonly Node _root = new Node();

        public AhoCorasick(IEnumerable<string> keywords)
        {
            _root.Failure = _root;
            BuildTrie(keywords);
            BuildFailureLinks();
        }

        private void BuildTrie(IEnumerable<string> keywords)
        {
            foreach (var keyword in keywords)
            {
                if (string.IsNullOrEmpty(keyword)) continue;

                var node = _root;
                foreach (var c in keyword)
                {
                    // Use char.ToLowerInvariant for case-insensitive building
                    var lowerC = char.ToLowerInvariant(c);
                    if (!node.Children.TryGetValue(lowerC, out var child))
                    {
                        child = new Node();
                        node.Children[lowerC] = child;
                    }
                    node = child;
                }
                node.Outputs.Add(keyword);
            }
        }

        private void BuildFailureLinks()
        {
            var queue = new Queue<Node>();

            foreach (var child in _root.Children.Values)
            {
                child.Failure = _root;
                queue.Enqueue(child);
            }

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                foreach (var kvp in current.Children)
                {
                    var key = kvp.Key;
                    var child = kvp.Value;

                    var temp = current.Failure;
                    while (temp != _root && !temp.Children.ContainsKey(key))
                    {
                        temp = temp.Failure;
                    }

                    if (temp.Children.TryGetValue(key, out var failTarget))
                    {
                        child.Failure = failTarget;
                    }
                    else
                    {
                        child.Failure = _root;
                    }
                    
                    child.Outputs.AddRange(child.Failure.Outputs);

                    queue.Enqueue(child);
                }
            }
        }

        public IEnumerable<string> Search(string text)
        {
            var node = _root;
            var found = new HashSet<string>();

            if (string.IsNullOrEmpty(text)) return found;

            foreach (var originalChar in text)
            {
                var c = char.ToLowerInvariant(originalChar);

                while (node != _root && !node.Children.ContainsKey(c))
                {
                    node = node.Failure;
                }

                if (node.Children.TryGetValue(c, out var nextNode))
                {
                    node = nextNode;
                }
                
                if (node.Outputs.Count > 0)
                {
                    foreach (var pattern in node.Outputs)
                    {
                        found.Add(pattern);
                    }
                }
            }
            return found;
        }
    }
}
