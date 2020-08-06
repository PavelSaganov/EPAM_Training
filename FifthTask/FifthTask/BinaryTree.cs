using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex1
{
    public class BinaryTree<T>
    {
        public BinaryTree<T> Parent { get; private set; }
        public List<BinaryTree<T>> Children { get; private set; } = new List<BinaryTree<T>>();
        public T Value { get; set; }
        public int Deep { get; private set; }

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
        public BinaryTree(T value) : this(null, value) { Deep = 1; }

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
            Deep = Parent.Deep + 1;
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
            Deep = Parent.Deep + 1;
            this.Children = Children;
        }

        #endregion

        /// <summary>
        /// Adds new child to node
        /// </summary>
        /// <param name="child"></param>
        public void Add(BinaryTree<T> child)
        {
            if (Children.Count >= 2)
                throw new Exception("The tree already has 2 children!");
            child.Deep = Deep + 1;
            child.Parent = this;
            Children.Add(child);
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

        public BinaryTree<T> this[int i]
        {
            get => Children.ElementAt(i);
            // set => Children.ElementAt(i) = value;
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
                BinaryTree<T> finded = child.Find(match);
                if (finded != null)
                    return finded;
            }
            return null;
        }

        public BinaryTree<T> Find(T value)
        {

            return Find(m => m.Value.Equals(value));
                
                
                //typeof(IEquatable<T>).IsAssignableFrom(typeof(T))
                //            ? (Predicate<BinaryTree<T>>)(node => (((IEquatable<T>)node.Value).Equals(value)))
                //            : node => (ReferenceEquals(node.Value, value)));
        }
    }
}
