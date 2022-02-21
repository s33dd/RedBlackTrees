using System;
using System.Collections.Generic;

enum NodeType {
  Black = 0,
  Red = 1
}

internal class Node {
  public Node leftNode;
  public Node rightNode;
  public Node parent;
  public int number;
  public NodeType color;
  public List<Node> children;

  public Node(int value) {
    this.number = value;
    this.leftNode = null;
    this.rightNode = null;
    this.parent = null;
    children = new List<Node>();
  }

}
internal class Tree {
  protected Node root;

  public Node GetRoot() {
    return this.root;
  }

  public Tree(int value) {
    this.root = new Node(value) {
      color = NodeType.Black
    };
  }

  public Node Search(int value) {
    bool found = false;
    Node tempRoot = this.root;
    Node desired = null;
    while (!found) {
      if (value < tempRoot.number) {
        tempRoot = tempRoot.leftNode;
      }
      if (value > tempRoot.number) {
        tempRoot = tempRoot.rightNode;
      }
      if (value == tempRoot.number) {
        found = true;
        desired = tempRoot;
      }
      if (tempRoot == null) {
        break;
      }
    }
    if (found) {
      return desired;
    }
    else {
      return null;
    }
  }

  public Node MinimumElement(Node subroot) {
    while (subroot.leftNode != null) {
      subroot = subroot.leftNode;
    }
    return subroot;
  }

  public void LeftRotate(Node axis) {
    Node subroot = axis.rightNode;
    axis.rightNode = subroot.leftNode;
    if (subroot.leftNode != null) {
      subroot.leftNode.parent = axis;
    }
    subroot.parent = axis.parent;
    if (axis.parent == null) {
      this.root = subroot;
    }
    else {
      if (axis == axis.parent.leftNode) {
        axis.parent.leftNode = subroot;
      }
      else {
        axis.parent.rightNode = subroot;
      }
    }
    subroot.leftNode = axis;
    axis.parent = subroot;
  }

  public void RightRotate(Node axis) {
    Node subroot = axis.leftNode;
    axis.leftNode = subroot.rightNode;
    if (subroot.rightNode != null) {
      axis.rightNode.parent = axis;
    }
    subroot.parent = axis.parent;
    if (axis.parent == null) {
      this.root = subroot;
    }
    else {
      if (axis == axis.parent.rightNode) {
        axis.parent.rightNode = subroot;
      }
      else {
        axis.parent.leftNode = subroot;
      }
    }
    subroot.rightNode = axis;
    axis.parent = subroot;
  }

  public void InsertionFixing(Node newElement) {
    while (newElement != root && newElement.parent.color == NodeType.Red) {
      if (newElement.parent == newElement.parent.parent.leftNode) {
        Node uncle = newElement.parent.parent.rightNode;
        if (uncle != null && uncle.color == NodeType.Red) {
          newElement.parent.color = NodeType.Black;
          uncle.color = NodeType.Black;
          newElement.parent.parent.color = NodeType.Red;
          newElement = newElement.parent.parent;
        }
        else {
          if (newElement == newElement.parent.rightNode) {
            newElement = newElement.parent;
            this.LeftRotate(newElement);
          }
          newElement.parent.color = NodeType.Black;
          newElement.parent.parent.color = NodeType.Red;
          this.RightRotate(newElement.parent.parent);
        }
      }
      else {
        Node uncle = newElement.parent.parent.leftNode;
        if (uncle != null && uncle.color == NodeType.Red) {
          newElement.parent.color = NodeType.Black;
          uncle.color = NodeType.Black;
          newElement.parent.parent.color = NodeType.Red;
          newElement = newElement.parent.parent;
        }
        else {
          if (newElement == newElement.parent.leftNode) {
            newElement = newElement.parent;
            this.RightRotate(newElement);
          }
          newElement.parent.color = NodeType.Black;
          newElement.parent.parent.color = NodeType.Red;
          this.LeftRotate(newElement.parent.parent);
        }
      }
    }
    this.root.color = NodeType.Black;
  }

  public void Insertion(int value) {
    Node newElement = new(value);
    Node leaf = null;
    Node root = this.root;

    while (root != null) {
      leaf = root;
      if (newElement.number < root.number) {
        root = root.leftNode; ;
      }
      else {
        root = root.rightNode;
      }
    }
    newElement.parent = leaf;
    if (leaf == null) {
      this.root = newElement;
    }
    else {
      if (newElement.number < leaf.number) {
        leaf.leftNode = newElement;
      }
      else {
        leaf.rightNode = newElement;
      }
    }
    newElement.leftNode = null;
    newElement.rightNode = null;
    newElement.color = NodeType.Red;
    this.InsertionFixing(newElement);
  }

  public void DeletionFixing(Node movedElement) {
    while (movedElement != null && movedElement != this.root && movedElement.color == NodeType.Black) {
      if (movedElement == movedElement.parent.leftNode) {
        Node brother = movedElement.parent.rightNode;
        if (brother.color == NodeType.Red) {
          brother.color = NodeType.Black;
          movedElement.parent.color = NodeType.Red;
          this.LeftRotate(movedElement.parent);
          brother = movedElement.parent.rightNode;
        }
        if (brother.leftNode.color == NodeType.Black && brother.rightNode.color == NodeType.Black) {
          brother.color = NodeType.Red;
          movedElement = movedElement.parent;
        }
        else {
          if (brother.rightNode.color == NodeType.Black) {
            brother.leftNode.color = NodeType.Black;
            brother.color = NodeType.Red;
            this.RightRotate(brother);
            brother = movedElement.parent.rightNode;
          }
          brother.color = movedElement.parent.color;
          movedElement.parent.color = NodeType.Black;
          brother.rightNode.color = NodeType.Black;
          this.LeftRotate(movedElement.parent);
          movedElement = this.root;
        }
      }
      else {
        if (movedElement == movedElement.parent.rightNode) {
          Node brother = movedElement.parent.leftNode;
          if (brother.color == NodeType.Red) {
            brother.color = NodeType.Black;
            movedElement.parent.color = NodeType.Red;
            this.RightRotate(movedElement.parent);
            brother = movedElement.parent.leftNode;
          }
          if (brother.leftNode.color == NodeType.Black && brother.rightNode.color == NodeType.Black) {
            brother.color = NodeType.Red;
            movedElement = movedElement.parent;
          }
          else {
            if (brother.leftNode.color == NodeType.Black) {
              brother.rightNode.color = NodeType.Black;
              brother.color = NodeType.Red;
              this.RightRotate(brother);
              brother = movedElement.parent.leftNode;
            }
            brother.color = movedElement.parent.color;
            movedElement.parent.color = NodeType.Black;
            brother.leftNode.color = NodeType.Black;
            this.RightRotate(movedElement.parent);
            movedElement = this.root;
          }
        }
      }
    }
    if (movedElement != null) {
      movedElement.color = NodeType.Black;
    }
  }

  public void Deletion(int value) {
    Node removableElement = this.Search(value);
    if (removableElement == null) {
      Console.WriteLine($"There is no {value} in this tree {Environment.NewLine}");
      return;
    }

    Node temp = removableElement;
    NodeType trueColor = temp.color;
    Node movedElement = null;

    if (removableElement.leftNode == null || removableElement.rightNode == null) {
      temp = removableElement;
    }
    else {
      temp = this.MinimumElement(removableElement);
    }
    if (temp.leftNode != null) { 
      movedElement = temp.leftNode;
    }
    else {
      movedElement = temp.rightNode;
    }
    if (temp == this.root) {
      this.root = movedElement;
    }
    else if (temp == temp.parent.leftNode) {
      temp.parent.leftNode = movedElement;
    }
    else {
      temp.parent.rightNode = movedElement;
    }
    if (temp != removableElement) {
      removableElement.number = temp.number;
    }
    if (trueColor == NodeType.Black) {
      this.DeletionFixing(movedElement);
    }
  }
}