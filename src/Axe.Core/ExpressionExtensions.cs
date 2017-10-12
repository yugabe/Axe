using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Axe.Core
{
    public static class ExpressionExtensions
    {
        public static X<T, TResult> X<T, TResult>(this Expression<Func<T, TResult>> expression) => expression;
    }
}
