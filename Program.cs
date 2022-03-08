using System;

namespace RedBlackTree {
  internal class Program {
    static void Main(string[] args) {
      UI.StartInfo();
      InputType mode = UI.AskType();
      Tree usersTree = null;
      if (mode == InputType.Manual) {
        usersTree = Input.ManualInput();
      }
      else if (mode == InputType.Random) { 
       //Are not completed yet
      }
      else {
        //File input are not completed yet
      }
      Console.WriteLine(Environment.NewLine);
      UI.ShowTree(usersTree.GetRoot(), "", true);
    }
  }
}