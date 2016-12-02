using System;

namespace FluentBuilder.Model.Common
{
    /// <remarks>
    /// Source : http://blogs.tedneward.com/patterns/Builder-CSharp/
    /// </remarks>
    public static class FnUtils
    {
        public static Func<A, C> Compose<A, B, C>(Func<A, B> f1, Func<B, C> f2)
        {
            return a => f2(f1(a));
        }
    }
}
