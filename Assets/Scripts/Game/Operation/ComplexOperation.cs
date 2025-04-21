using Game.Operation.Interfaces;
using UnityEngine;

namespace Game.Operation
{
    // Mniej operacji faktycznych powinno być oddziałowujących na score
    // Jedynie odejmowanie/dodawanie, reszta powinna być obliczana z wewnątrz
    // Ewentualny fun gejmode z włączeniem wszystkiego na score
    public class ComplexOperation : IOperation
    {
        public ComplexOperation()
        {
            Debug.Log("New complex operation!");
            BinaryTree = new BinaryTree.BinaryTree(2);
            Debug.Log($"{BinaryTree.RootNode}");
        }

        public BinaryTree.BinaryTree BinaryTree { get; }

        public double Rhs => 0; // Its redundant, remove it

        public double Evaluate(double lhs)
        {
            return lhs + BinaryTree.RootNode.Evaluate();
        }
    }
}