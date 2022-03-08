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

    public static bool Ask() {
      Console.Write("(Y/N)");
      while ((Console.ReadKey().Key != ConsoleKey.Y) || (Console.ReadKey().Key != ConsoleKey.N)) {
        Console.Write("(Y/N)");
      }
      if (Console.ReadKey().Key == ConsoleKey.Y) {
        return true;
      }
      else {
        return false;
      }
    }

    public static InputType AskType() {
      InputType? chosenType = null;
      ConsoleKeyInfo pressedKey;
      while (chosenType == null) {
        Console.WriteLine($"{Environment.NewLine}Press 'R' for random input, 'M' for manual input, 'F' for input from file");
        pressedKey = Console.ReadKey();
        if (pressedKey.Key == ConsoleKey.R) {
          chosenType = InputType.Random;
        }
        else if (pressedKey.Key == ConsoleKey.M) {
          chosenType = InputType.Manual;
        }
        else if (pressedKey.Key == ConsoleKey.F) {
          chosenType = InputType.File;
        }
      }
      return (InputType)chosenType;
    }
  }
}
