using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Axe.Core
{
    public static class X
    {
        public static X<T, TResult> Create<T, TResult>(Expression<Func<T, TResult>> expression) => new X<T, TResult>(expression);
    }

    public class X<T, TResult>
    {
        public Func<T, TResult> Delegate { get; }
        public Expression<Func<T, TResult>> Expression { get; }
        internal X(Expression<Func<T, TResult>> expression) => Delegate = (Expression = expression).Compile();

        public static implicit operator X<T, TResult>(Expression<Func<T, TResult>> expression) => new X<T, TResult>(expression);
        public static implicit operator Expression<Func<T, TResult>>(X<T, TResult> x) => x.Expression;
        public static implicit operator Func<T, TResult>(X<T, TResult> x) => x.Delegate;
    }
}
