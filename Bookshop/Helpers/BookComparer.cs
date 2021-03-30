using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webbutik.Models;

namespace Bookshop
{
    class BookComparer : IEqualityComparer<Book>
    {
        public bool Equals(Book x, Book y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] Book obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
