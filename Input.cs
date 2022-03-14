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

    public static Tree ManualInput(Tree tree) {
      Console.WriteLine($"{Environment.NewLine}How many elements do you want to input?");
      int nodesQuantity = GetInt();
      while (nodesQuantity < 1) {
        Console.WriteLine("Quantity can't be less than one!");
        nodesQuantity = GetInt();
      }
      if (tree == null) {
        Console.WriteLine("Enter the node of the tree:");
        int root = GetInt();
        tree = new Tree(root);
        nodesQuantity--;
        for (int i = nodesQuantity; i > 0; i--) {
          Console.WriteLine("Enter the node of the tree:");
          int node = GetInt();
          tree.Insertion(node);
        }
      }
      else {
        for (int i = nodesQuantity; i > 0; i--) {
          Console.WriteLine("Enter the node of the tree:");
          int node = GetInt();
          tree.Insertion(node);
        }
      }
      return tree;
    }

    public static Tree RandomInput(Tree tree) {
      Console.WriteLine($"{Environment.NewLine}How many elements do you want to input?");
      int nodesQuantity = GetInt();
      while (nodesQuantity < 1) {
        Console.WriteLine("Quantity can't be less than one!");
        nodesQuantity = GetInt();
      }
      Console.WriteLine("Set the lower border of randomizer:");
      int lowerBorder = Input.GetInt();
      Console.WriteLine($"{Environment.NewLine}Set the higher border of randomizer:");
      int higherBorder = Input.GetInt();
      while (higherBorder < lowerBorder) {
        Console.WriteLine($"{Environment.NewLine}Higher border can`t be less than lower border!");
        Console.WriteLine($"{Environment.NewLine}Set the higher border of randomizer:");
        higherBorder = Input.GetInt();
      }
      Random randomizer = new Random();
      if (tree == null) {
        int root = randomizer.Next(lowerBorder, higherBorder);
        tree = new Tree(root);
        nodesQuantity--;
        for (int i = nodesQuantity; i > 0; i--) {
          int node = randomizer.Next(lowerBorder, higherBorder);
          tree.Insertion(node);
        }
      }
      else {
        for (int i = nodesQuantity; i > 0; i--) {
          int node = randomizer.Next(lowerBorder, higherBorder);
          tree.Insertion(node);
        }
      }
      return tree;
    }

    public static Tree InputNodes(Tree tree) {
      InputType mode = UI.AskType();
      if (mode == InputType.Manual) {
        tree = ManualInput(tree);
      }
      else if (mode == InputType.Random) {
        tree = RandomInput(tree);
      }
      else {
        Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}!!!Please pay attention that data in file need to be in strict format: Each number on separate string!!!");
        Console.WriteLine($"{Environment.NewLine}Print path to file:");
        string path = Console.ReadLine();
        tree = FileWork.ReadFromFile(path, tree);
      }
      return tree;
    }
  }
}
