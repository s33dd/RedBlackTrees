using System;

namespace RedBlackTree {
  internal class Program {
    static void Main(string[] args) {
      Tree usersTree = null;
      UI.StartInfo();
      while(true) {
        Action action = UI.AskAction();
        if (action == Action.Input) {
          Input.InputNodes(usersTree);
        }
        else if (action == Action.Delete) {
          UI.DeleteNode(usersTree);
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
          //Saving to file is not completed yet
        }
        else if (action == Action.Exit) {
          Console.Write(Environment.NewLine);
          Console.WriteLine("Do you really want to close  the program?");
          bool isExit = UI.Ask();
          if (isExit) {
            Environment.Exit(0);
          }
        }
      }
    }
  }
}