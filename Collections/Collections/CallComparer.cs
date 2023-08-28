using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Collections
{
    class CallComparer : IEqualityComparer<Call>
    {
        public bool Equals(Call x, Call y)
        {
            return x.Type == y.Type && x.RoomId == y.RoomId && x.WardId == y.WardId && x.ClusterId == y.ClusterId;
        }

        public int GetHashCode([DisallowNull] Call obj)
        {
            return obj.Type.GetHashCode()
                + obj.RoomId.GetHashCode()
                + obj.WardId.GetHashCode()
                + obj.Timestamp.GetHashCode();
        }
    }
}
