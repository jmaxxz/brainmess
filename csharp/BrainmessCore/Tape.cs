using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace Welch.Brainmess
{
    /// <summary>
    /// Represents an infinite tape of numbers. An instance of this tape is used as a memory store during the execution of a
    /// Brainmess program. The tape maintains a cursor which points to a cell. This cell is considered the "current" cell.
    /// The methods MoveForward, MoveBackward, Current, Increment, and Decrement all take action relative to the current' cell.
    /// (Do the methods on this really match a tape or a "tape drive"? Perhaps the name of this class
    /// is not exactly correct. One doesn't think of a tape moving itself forward or backward. Something does that to the 
    /// tape. In any case, it is a convenient name, but if it were to cause confusion it should be changed.)
    /// </summary>
    public class Tape
    {

        // Mutable State
        private LinkedListNode<int> _currentCell;

        /// <summary>
        /// Creates a tape with a value of 0 in every cell. 
        /// </summary>
        public static Tape Default
        {
            get { return LoadState(Enumerable.Range(0, 1), 0); }
        }

        /// <summary>
        /// Creates a tape that has the specified values located sequentially somewhere in the middle
        /// of the tape. The cursor is set to point to the cell indicated by <paramref name="position"/>.
        /// All other cells on the tape are set to 0.
        /// </summary>
        /// <param name="cells">A sequence of integers to load onto the new tape.</param>
        /// <param name="position">An "index" into <paramref name="cells"/> that indicates which one should
        /// be considered the current cell for the initial state of the tape.</param>
        public static Tape LoadState(IEnumerable<int> cells, int position)
        {
            if (cells == null) throw new ArgumentNullException("cells");
            var array = cells.ToArray(); 
            
            if (array.Length == 0) throw new ArgumentException("This collection is expected to have at least one element. Use Tape.Default if you don't want to customize the state.", "cells");
            if (position < 0) throw new ArgumentOutOfRangeException("position");
            if (position > array.Length - 1) throw new ArgumentOutOfRangeException("position");

            var list = new LinkedList<int>(array);
            var currentNode = list.GetNodeAtIndex(position);
            return new Tape(currentNode);
        }

        private Tape(LinkedListNode<int> startingCell)
        {
            // This is a private constructor so I assume that I'll always call it correctly.
            // The Debug.Assert leaves a check in place that documents the assumption and catches
            // any errors during unit tests in case I refactor and forget.

            // make sure that startingCell is linked into a list.
            Debug.Assert(startingCell.List != null);
            _currentCell = startingCell;
        }

        /// <summary>
        /// Moves the cursor forward one position.
        /// </summary>
        public void MoveForward()
        {
            _currentCell = _currentCell.MoveForward();
        }

        /// <summary>
        /// Moves the cursor backward one position.
        /// </summary>
        public void MoveBackward()
        {
            _currentCell = _currentCell.MoveBackward();
        }

        /// <summary>
        /// Increments the value at the cursor.
        /// </summary>
        public void Increment()
        {
            _currentCell.Value++;
        }

        /// <summary>
        /// Decrements the value at the cursor.
        /// </summary>
        public void Decrement()
        {
            _currentCell.Value--;
        }

        /// <summary>
        /// Gets or sets the value at the cursor.
        /// </summary>
        public int Current
        {
            get
            {
                return _currentCell.Value;
            }
            set
            {
                _currentCell.Value = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Tape)) return false;

            Tape other = (Tape)obj;
            return _currentCell.List.IsEqualTo(other._currentCell.List) &&
                   _currentCell.IndexOf() == other._currentCell.IndexOf();
        }

        /// <summary>
        /// Does not provide a userful implementation. Always returns 0.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 0;
        }
    }
}

