using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq.Expressions;

namespace Axe.Core.Tests
{
    [TestClass]
    public class CreationAndConversionTests
    {
        [TestMethod]
        public void XImplicitTypeConversion()
        {
            Expression<Func<int, string>> expression = n => n.ToString();
            X<int, string> x = expression;
            Func<int, string> func = x;
            expression = x;
        }

        [TestMethod]
        public void CanCreateXFromExpression()
        {
            Expression<Func<int, string>> expression = n => n.ToString();
            X<int, string> implicitlyCasted = expression;
            var createdViaFactoryMethod = X.Create<int, string>(n => n.ToString());
            var createdViaExpressionExtension = expression.X();
        }
    }
}
