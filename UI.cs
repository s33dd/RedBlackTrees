using System;

namespace RedBlackTree {
  internal static class UI {
    public static string greetings = $"The first lab {Environment.NewLine}Made by: Student of 403th group Sukhoverikov Denis";
    public static string shortInfo = $"Var 6 {Environment.NewLine}Realisation of a Red-Black trees on C#";
    public static string gapLine = "________________________";

    public static void ConsoleDefault() {
      Console.BackgroundColor = ConsoleColor.White;
      Console.ForegroundColor = ConsoleColor.Black;
    }
    public static void StartInfo () {
      ConsoleDefault();
      Console.Clear();
      Console.WriteLine(greetings);
      Console.WriteLine(gapLine);
      Console.WriteLine(shortInfo);
      Console.WriteLine(gapLine);
    }

    public static void ShowTree(Node root, string indent, bool lastInBarnch) {
      Console.Write(indent);
      if (lastInBarnch) {
        Console.Write($"│{Environment.NewLine}{indent}└─");
        indent += "  ";
      }
      else {
        Console.Write($"│{Environment.NewLine}{indent}├─");
        indent += "│ ";
      }
      if (root != null) {
        if (root.color == NodeType.Black) {
          Console.BackgroundColor = ConsoleColor.Black;
          Console.ForegroundColor = ConsoleColor.White;
        }
        else {
          Console.BackgroundColor = ConsoleColor.Red;
          Console.ForegroundColor = ConsoleColor.Green;
        }
        Console.WriteLine($" {root.number} ");
        ConsoleDefault();

        if (root.rightNode != null) {
          root.children.Add(root.rightNode);
        }
        if (root.leftNode != null) {
          root.children.Add(root.leftNode);
        }

        for (int i = 0; i < root.children.Count; i++) {
          ShowTree(root.children[i], indent, i == root.children.Count - 1);
        }
      }
    }
  }
}
