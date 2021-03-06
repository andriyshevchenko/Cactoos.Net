﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Cactoos.List
{
    public class Infinite<T> : IEnumerable<T>
    {
        private Func<int, T> _generator;

        public Infinite(Func<int, T> next)
        {
            _generator = next;
        }

        public Infinite(Func<T> next)
        {
            _generator = (int i) => next();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            int i = 0;
            while (true)
            {
                yield return _generator(i++);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
