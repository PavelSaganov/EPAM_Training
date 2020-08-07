using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex1
{
    [Serializable]
    public class BinaryTree<T>
    {
        public BinaryTree<T> Parent { get; private set; }
        public List<BinaryTree<T>> Children { get; private set; } = new List<BinaryTree<T>>();
        public T Value { get; set; }
        public int Deep { get; private set; }
        public int BalanceOfNode
        {
            get
            {
                int leftHight = -1;
                int rightHight = -1;

                if (Children[0] == null)
                    leftHight = Children[0].Deep;
                if (Children[1] == null)
                    rightHight = Children[1].Deep;

                return leftHight - rightHight;
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
            Deep = Parent.Deep + 1;
            Value = value;
        }

        /// <summary>
        /// Creates a root
        /// </summary>
        /// <param name="value"></param>
        public BinaryTree(T value)
        {
            Value = value;
            Deep = 1;
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

        // TODO: нужен паблик сеттер
        public BinaryTree<T> this[int i]
        {
            get => Children.ElementAt(i);
            set
            {
                var temp = Children.ElementAt(i);
                temp = value;
            }
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

        public BinaryTree<T> Find(T value) => Find(m => m.Value.Equals(value));

        // TODO: Доделай нормально фикс глубины
        private void FixDeep()
        {
            if (Children[0] != null)
                Deep = Children[0].Deep + 1;

        }

        // TODO: Разберись с поворотом, но сначала фиксани глубину
        private BinaryTree<T> RightRotate(BinaryTree<T> node)
        {
            BinaryTree<T> q = node.Children[0];
            node.Children[0] = q.Children[1];
            q.Children[1] = node;

            //fixheight(node);
            //fixheight(q);
            return q;
        }
    }
}
