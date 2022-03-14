using System;
using System.Collections.Generic;
using System.IO;

namespace RedBlackTree {
  static class FileWork {
    public static bool AllowedName(string name) {
      FileInfo file = new FileInfo(name);
      if(file.Exists) {
        return true;
      }
      else {
        try {
          FileStream testFile = file.Create();
          testFile.Close();
        }
        catch {
          return false;
        }
        if (file.Exists) {
          file.Delete();
          return true;
        }
        else return false;
      }
    }

    public static bool AskOverwrite(string name) {
      FileInfo file = new FileInfo(name);
      Console.WriteLine($"{Environment.NewLine}This file is already exists! Do you want to overwrite it?");
      bool isOverwrite = UI.Ask();
      if (isOverwrite) {
        return true;
      }
      else return false;
    }

    public static void FileNodesPrint(Node node, FileInfo file) {
      if (node.rightNode != null) {
        node.children.Add(node.rightNode);
      }
      if (node.leftNode != null) {
        node.children.Add(node.leftNode);
      }
      using (StreamWriter sw = file.AppendText()) {
        sw.WriteLine(node.number);
      }
      for (int i = 0; i < node.children.Count; i++) {
        FileNodesPrint(node.children[i], file);
      }
      node.children.Clear();
    }

    public static void SaveToFile(string name, Tree tree) {
      FileInfo file = new FileInfo(name);
      if (file.Exists) {
        bool isOverwrite = false;
        while (file.Exists && !isOverwrite) {
          isOverwrite = AskOverwrite(name);
          if (!isOverwrite) {
            Console.WriteLine($"{Environment.NewLine}Print another name:");
            name = Console.ReadLine();
            while (!FileWork.AllowedName(name)) {
              Console.WriteLine($"{Environment.NewLine}Please, enter correct path:");
              name = Console.ReadLine();
            }
            file = new FileInfo(name);
          }
        }
        if (isOverwrite) {
          if (file.IsReadOnly) {
            Console.WriteLine($"{Environment.NewLine}File is read only. I can`t overwrite it");
            return;
          }
          file.Delete();
        }
      }
      Node root = tree.GetRoot();
      FileNodesPrint(root, file);
    }

   public static Tree ReadFromFile(string name, Tree tree) {
      FileInfo file = new FileInfo(name);
      List<int> nodes = new List<int>();
      bool isShowed = false;
      while (!file.Exists) {
        Console.WriteLine($"{Environment.NewLine}This file doesn`t exist!");
        Console.WriteLine($"{Environment.NewLine}Print path to another file:");
        name = Console.ReadLine();
        file = new FileInfo(name);
      }
      using (StreamReader reader = file.OpenText()) {
        string line = "";
        while((line = reader.ReadLine()) != null) {
          try {
            int node = Int32.Parse(line);
            nodes.Add(node);
          }
          catch {
            if(!isShowed) {
              Console.WriteLine($"{Environment.NewLine}There was some problems. I`ve read all that I could.");
              isShowed = true;
            }
          }
        }
      }
      foreach (int node in nodes) {
        if (tree == null) {
          tree = new Tree(node);
        }
        else {
          tree.Insertion(node);
        }
      }
      return tree;
    }
  }
}
