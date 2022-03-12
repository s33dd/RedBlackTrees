using System;

namespace RedBlackTree {

  enum Action {
    Input = 0,
    Delete = 1,
    Draw = 2,
    Save = 3,
    Exit = 4
  }

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
      if (root == null) {
        Console.WriteLine("While your tree is empty this is the only tree I can show to you:");
        Console.WriteLine("    .{{}}}}}}.");
        Console.WriteLine("   {{{{{{(`)}}}.");
        Console.WriteLine("  {{{(`)}}}}}}}}}");
        Console.WriteLine(" }}}}}}}}}{{(`){{{");
        Console.WriteLine(" }}}}{{{{(`)}}{{{{");
        Console.WriteLine(" {{{(`)}}}}}}}{}}}}}");
        Console.WriteLine("{{{{{{{{(`)}}}}}}}}}}");
        Console.WriteLine("{{{{{{{}{{{{(`)}}}}}}");
        Console.WriteLine("{{{{{(`)   {{{{(`)}'");
        Console.WriteLine(" `---- |   | ----`");
        Console.WriteLine(@" (`)  /     \");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~");

      }
      else {
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

    public static bool Ask() {
      bool choiseIsMade = false;
      bool choise = false;
      ConsoleKeyInfo pressedKey;
      while (!choiseIsMade) {
        Console.Write(Environment.NewLine);
        Console.Write("(Y/N)");
        pressedKey = Console.ReadKey();
        if (pressedKey.Key == ConsoleKey.Y) {
          choise = true;
          choiseIsMade = true;
        }
        else if (pressedKey.Key == ConsoleKey.N) {
          choise = false;
          choiseIsMade = true;
        }
      }
      return choise;
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

    public static Action AskAction() {
      Action? chosenAction = null;
      ConsoleKeyInfo pressedKey;
      while (chosenAction == null) {
        Console.WriteLine($"{Environment.NewLine}What do you want to do?");
        Console.WriteLine("Press I to Input node");
        Console.WriteLine("Press D to Delete node");
        Console.WriteLine("Press Shift + D to Draw the tree");
        Console.WriteLine("Press S to Save data in file");
        Console.WriteLine("Press E to Exit");
        pressedKey = Console.ReadKey();
        if (pressedKey.Key == ConsoleKey.I) {
          chosenAction = Action.Input;
        }
        else if (pressedKey.Key == ConsoleKey.D & pressedKey.Modifiers != ConsoleModifiers.Shift) {
          chosenAction = Action.Delete;
        }
        else if (pressedKey.Modifiers == ConsoleModifiers.Shift & pressedKey.Key == ConsoleKey.D) {
          chosenAction = Action.Draw;
        }
        else if (pressedKey.Key == ConsoleKey.S) {
          chosenAction = Action.Save;
        }
        else if (pressedKey.Key == ConsoleKey.E) {
          chosenAction = Action.Exit;
        }
      }
      return (Action)chosenAction;
    }

    public static void DeleteNode(Tree tree) {
      Console.WriteLine("Which node do you want to delete?");
      int removedNode = Input.GetInt();
      tree.Deletion(removedNode);
    }
  }
}
