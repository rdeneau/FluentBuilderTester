using System;
using JetBrains.Annotations;

namespace FluentBuilder.Model.Common
{
    /// <summary>
    /// Handle an object with or without a value, as the <see cref="Nullable{T}"/> for reference types.
    /// </summary>
    /// <remarks>
    /// Source : http://enterprisecraftsmanship.com/2016/04/11/applying-functional-principles-in-c-pluralsight-course/
    /// Changed to accept null.
    /// </remarks>
    public struct Maybe<TValue> : IEquatable<Maybe<TValue>> where TValue : class
    {
        private readonly TValue _value;

        public TValue Value
        {
            get
            {
                if (HasNoValue)
                {
                    throw new InvalidOperationException();
                }
                return _value;
            }
        }

        public bool HasValue { get; }
        public bool HasNoValue => !HasValue;

        private Maybe([CanBeNull] TValue value)
        {
            _value = value;
            HasValue = true;
        }

        #region Cast and Equality Operators

        public static implicit operator Maybe<TValue>(TValue value)
        {
            return new Maybe<TValue>(value);
        }

        public static bool operator ==(Maybe<TValue> maybe, TValue value)
        {
            return maybe.HasValue && maybe.Value.Equals(value);
        }

        public static bool operator !=(Maybe<TValue> maybe, TValue value)
        {
            return !(maybe == value);
        }

        public static bool operator ==(Maybe<TValue> first, Maybe<TValue> second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Maybe<TValue> first, Maybe<TValue> second)
        {
            return !(first == second);
        }

        #endregion

        #region Equals(), GetHashCode(), ToString()

        public override bool Equals(object obj)
        {
            if (!(obj is Maybe<TValue>))
            {
                return false;
            }

            var other = (Maybe<TValue>)obj;
            return Equals(other);
        }

        public bool Equals(Maybe<TValue> other)
        {
            if (HasNoValue && other.HasNoValue)
            {
                return true;
            }

            if (HasNoValue || other.HasNoValue)
            {
                return false;
            }

            return _value.Equals(other._value);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public override string ToString()
        {
            return HasNoValue ? "(No value)" : Value.ToString();
        }

        #endregion

        #region Unwrapping (when leaving the domain)

        public TValue Unwrap()
        {
            return Unwrap(default(TValue));
        }

        public TValue Unwrap(TValue defaultValue)
        {
            return HasValue ? Value : defaultValue;
        }

        public TTarget UnwrapAs<TTarget>(Func<TValue, TTarget> selector)
        {
            return UnwrapAs(selector, default(TTarget));
        }

        public T UnwrapAs<T>(Func<TValue, T> selector, T defaultValue)
        {
            return HasValue ? selector(Value) : defaultValue;
        }

        #endregion
    }
}