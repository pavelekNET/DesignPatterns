using System;
using System.Collections.Generic;
using System.Linq;

namespace Commons
{
    public abstract class Maybe<T> : IEquatable<Maybe<T>>, IEquatable<T>
    {
        public abstract void Do(Action<T> action);
        public abstract Maybe<TNew> Map<TNew>(Func<T, TNew> mapping);
        public abstract T Reduce(Func<T> whenNone);
        public abstract T Reduce(T whenNone);
        public abstract IEnumerable<T> AsEnumerable();
        public abstract bool Equals(Maybe<T> other);
        public abstract bool Equals(T other);
        public abstract override int GetHashCode();

        public static bool operator ==(Maybe<T> a, Maybe<T> b) =>
            (ReferenceEquals(null, a) && ReferenceEquals(null, b)) ||
            (!ReferenceEquals(null, a) && a.Equals(b));

        public static bool operator !=(Maybe<T> a, Maybe<T> b)
            => !(a == b);

        public static bool operator ==(Maybe<T> a, T b) =>
            !ReferenceEquals(null, a) && a.Equals(b);

        public static bool operator !=(Maybe<T> a, T b)
            => !(a == b);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Maybe<T>)obj);
        }
    }

    public static class Maybe
    {
        public static Maybe<T> Some<T>(T value) => new SomeImpl<T>(value);
        public static Maybe<T> None<T>() => new NoneImpl<T>();

        private class SomeImpl<T> : Maybe<T>
        {
            private T Content { get; }

            public SomeImpl(T content)
            {
                Content = content;
            }

            public override void Do(Action<T> action) =>
                action(Content);

            public override Maybe<TNew> Map<TNew>(Func<T, TNew> mapping) =>
                new SomeImpl<TNew>(mapping(Content));

            public override T Reduce(Func<T> whenNone) =>
                Content;

            public override T Reduce(T whenNone) =>
                Content;

            public override IEnumerable<T> AsEnumerable() =>
                new[] { Content };

            public override bool Equals(Maybe<T> other) =>
                Equals(other as SomeImpl<T>);

            public override bool Equals(T other) =>
                ContentEquals(other);

            private bool Equals(SomeImpl<T> other) =>
                !ReferenceEquals(null, other) &&
                ContentEquals(other.Content);

            private bool ContentEquals(T other) =>
                (ReferenceEquals(null, Content) && ReferenceEquals(null, other)) ||
                (!ReferenceEquals(null, Content) && Content.Equals(other));

            public override int GetHashCode() =>
                Content?.GetHashCode() ?? 0;
        }

        private class NoneImpl<T> : Maybe<T>
        {
            public override void Do(Action<T> action) { }

            public override Maybe<TNew> Map<TNew>(Func<T, TNew> mapping) =>
                new NoneImpl<TNew>();

            public override T Reduce(Func<T> whenNone) =>
                whenNone();

            public override T Reduce(T whenNone) =>
                whenNone;

            public override IEnumerable<T> AsEnumerable() =>
                Enumerable.Empty<T>();

            public override bool Equals(Maybe<T> other) =>
                this.Equals(other as NoneImpl<T>);

            public override bool Equals(T other) => false;

            private bool Equals(NoneImpl<T> other) =>
                !ReferenceEquals(null, other);

            public override int GetHashCode() => 0;
        }
    }
}
