using System;

namespace TaTava.CommonTypes
{
    [Flags]
    public enum UserAuthorizationType : byte
    {
        Create = 1,
        Read = 2,
        Update = 4,
        Delete = 8
    }
}
