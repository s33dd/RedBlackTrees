using System;

namespace RedBlackTree {
  internal class Program {
    static void Main(string[] args) {
      Tree usersTree = null;
      UI.StartInfo();
      while(true) {
        Action action = UI.AskAction();
        if (action == Action.Input) {
          usersTree = Input.InputNodes(usersTree);
        }
        else if (action == Action.Delete) {
          if (usersTree != null) { 
            UI.DeleteNode(usersTree);
          }
          else Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}You haven`t created a tree yet! Plant one! :)");
        }
        else if (action == Action.Draw) {
          Console.WriteLine(Environment.NewLine);
          if (usersTree != null) { 
            UI.ShowTree(usersTree.GetRoot(), "", true);
          }
          else {
            UI.ShowTree(null, "", true);
          }
        }
        else if (action == Action.Save) {
          if (usersTree == null) {
            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}Nothing to save!");
          }
          else {
            Console.WriteLine($"{Environment.NewLine}Print path to file:");
            string path = Console.ReadLine();
            while (!FileWork.AllowedName(path)) {
              Console.WriteLine($"{Environment.NewLine}Please, enter correct path:");
              path = Console.ReadLine();
            }
            FileWork.SaveToFile(path, usersTree);
          }
        }
        else if (action == Action.Search) {
          if (usersTree != null) {
            UI.SearchNode(usersTree);
          }
          else Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}You haven`t created a tree yet! Plant one! :)");
        }
        else if (action == Action.Exit) {
          Console.Write(Environment.NewLine);
          Console.WriteLine("Do you really want to close the program?");
          bool isExit = UI.Ask();
          if (isExit) {
            Environment.Exit(0);
          }
        }
      }
    }
  }
}