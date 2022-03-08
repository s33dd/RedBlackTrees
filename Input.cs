using System;

enum InputType {
  Manual = 0,
  Random = 1,
  File = 2,
}

namespace RedBlackTree {
  internal static class Input {
    public static int GetInt() {
      bool isCorrect = true;
      string input = Console.ReadLine();
      int? number = null;
      while (number == null) {
        try {
          number = Int32.Parse(input);
          isCorrect = true;
        }
        catch {
          isCorrect = false;
        }
        if (!isCorrect) {
          Console.WriteLine("Please, enter a number");
          input = Console.ReadLine();
        }
      }
      return (int)number;
    }
    public static char GetChar() {
      string input = Console.ReadLine();
      bool inputCorrect = false;
      char symbol = ' ';
      while (!inputCorrect) {
        try {
          symbol = char.Parse(input);
        }
        catch {
          Console.WriteLine("Please, enter a right character");
        }
      }
      return symbol;
    }

    public static Tree ManualInput() {
      Console.WriteLine($"{Environment.NewLine}How many elements do you want to input?");
      int nodesQuantity = GetInt();
      while (nodesQuantity < 1) {
        Console.WriteLine("Quantity can't be less than one!");
        nodesQuantity = GetInt();
      }
      Console.WriteLine("Enter the node of the tree:");
      int root = GetInt();
      Tree newTree = new Tree(root);
      nodesQuantity--;
      for (int i = nodesQuantity; i > 0; i--) {
        Console.WriteLine("Enter the node of the tree:");
        int node = GetInt();
        newTree.Insertion(node);
      }
      return newTree;
    }
  }
}
