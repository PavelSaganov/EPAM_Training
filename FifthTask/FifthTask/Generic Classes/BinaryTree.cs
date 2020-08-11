using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Ex1
{
    [Serializable]
    public class BinaryTree<T>
    {
        [NonSerialized]
        public BinaryTree<T> parent;
        public BinaryTree<T> Parent { get => parent; set => parent = value; }
        public List<BinaryTree<T>> Children { get; set; } = new List<BinaryTree<T>> { null, null };
        public T Value { get; set; }

        public int Height { 
            get 
            {
                if (Children[0] != null && Children[1] != null)
                {
                    if (Children[0].Height >= Children[1].Height)
                        return Children[0].Height + 1;
                    if (Children[1].Height >= Children[0].Height)
                        return Children[1].Height + 1;
                }
                return 1;
            } 
        }
        public int BalanceOfNode
        {
            get
            {
                int leftHeight = -1;
                int rightHeight = -1;

                if (Children[0] != null)
                    leftHeight = Children[0].Height;
                if (Children[1] != null)
                    rightHeight = Children[1].Height;

                return rightHeight - leftHeight;
            }
        }

        #region Constructors
        public BinaryTree()
        { }

        /// <summary>
        /// Creates a node without children
        /// </summary>
        /// <param name="Parent">Node Parent</param>
        /// <param name="value">Node Value</param>
        public BinaryTree(BinaryTree<T> Parent, T value)
        {
            this.Parent = Parent;
            Value = value;
        }

        /// <summary>
        /// Creates a root
        /// </summary>
        /// <param name="value"></param>
        public BinaryTree(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Creates a node
        /// </summary>
        /// <param name="Parent">Node Parent</param>
        /// <param name="value">Node Value</param>
        /// <param name="children">children of node</param>
        public BinaryTree(BinaryTree<T> Parent, T value, params BinaryTree<T>[] children) : this(Parent, value)
        {
            if (children.Length > 2)
                throw new Exception("More than two children cannot be added");
            Children = children.ToList();
        }

        /// <summary>
        /// Creates a node
        /// </summary>
        /// <param name="Parent">Node Parent</param>
        /// <param name="value">Node Value</param>
        /// <param name="Children">children of node</param>
        public BinaryTree(BinaryTree<T> Parent, T value, List<BinaryTree<T>> Children) : this(Parent, value)
        {
            if (Children.Count > 2)
                throw new Exception("More than two children cannot be added");
            this.Children = Children;
        }

        #endregion

        public BinaryTree<T> this[int i]
        {
            get
            {
                try
                { return Children?.ElementAt(i); }
                catch
                { return null; }
            }
        }

        /// <summary>
        /// Used to set Parent property for children
        /// </summary>
        /// <param name="context"></param>
        [OnDeserialized()]
        internal void OnSerializedMethod(StreamingContext context)
        {
            if (Children?.FirstOrDefault() != null)
                Children[0].Parent = this;
            if (Children?.LastOrDefault() != null)
                Children[1].Parent = this;
        }

        /// <summary>
        /// Adds new child to node
        /// </summary>
        /// <param name="child"></param>
        public void Add(BinaryTree<T> child)
        {
            if (Children.Count(c => c != null) == 2)
                throw new Exception("The tree already has 2 children!");

            child.Parent = this;
            if (Children[0] == null)
                Children[0] = child;
            else if (Children[1] == null)
                Children[1] = child;
        }

        /// <summary>
        /// Removes the child
        /// </summary>
        /// <param name="child"></param>
        private void Remove(BinaryTree<T> child) => Children.Remove(child);

        /// <summary>
        /// Removes child and all his descendants
        /// </summary>
        /// <param name="child">Child you want to remove</param>
        public void RemoveBranch(BinaryTree<T> child)
        {
            foreach (var item in child.Children)
            {
                RemoveBranch(item);
            }
            Children.Remove(child);
        }

        /// <summary>
        /// Finds a child according to specified conditions
        /// </summary>
        /// <param name="match">Сonditions</param>
        /// <returns></returns>
        public BinaryTree<T> Find(Predicate<BinaryTree<T>> match)
        {
            if (match(this))
                return this;

            foreach (var child in Children)
            {
                BinaryTree<T> finded = child?.Find(match);
                if (finded != null)
                    return finded;
            }
            return null;
        }

        /// <summary>
        /// Finds a value in tree
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public BinaryTree<T> Find(T value) => Find(m => m.Value.Equals(value));

        /// <summary>
        /// Right rotate around this node
        /// </summary>
        /// <returns></returns>
        public BinaryTree<T> RightRotate()
        {
            BinaryTree<T> leftChild = Children[0];
            Children[0] = leftChild.Children[1];
            leftChild.Children[1] = this;

            leftChild.Parent = Parent;
            Parent = leftChild;

            return leftChild;
        }

        /// <summary>
        /// Left rotate around this node
        /// </summary>
        /// <returns></returns>
        public BinaryTree<T> LeftRotate()
        {
            BinaryTree<T> rightChild = Children[1];
            Children[1] = rightChild.Children[0];
            rightChild.Children[0] = this;

            rightChild.Parent = Parent;
            Parent = rightChild;

            return rightChild;
        }

        /// <summary>
        /// Balance a tree
        /// </summary>
        /// <returns></returns>
        public BinaryTree<T> Balance()
        {
            if (BalanceOfNode == 2)
            {
                if (Children[1].BalanceOfNode < 0)
                    Children[1] = Children[1].RightRotate();
                return LeftRotate();
            }

            if (BalanceOfNode == -2)
            {
                if (Children[0].BalanceOfNode > 0)
                    Children[0] = Children[0].LeftRotate();
                return RightRotate();
            }
            return this;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || this == null)
                return false;
            foreach (var item in Children)
            {
                if (item != null)
                return item.Equals(obj);
            }

            return true;
        }

        public override int GetHashCode()
        {
            return Height.GetHashCode() * Height.GetHashCode() * Value.GetHashCode();
        }
    }
}
