using System;

namespace DefaultInterfaceMembers
{
    public interface IOrder
    {
        DateTime Purchased { get; }
        decimal Cost { get; }
    }
}
