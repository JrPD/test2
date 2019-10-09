using System;

namespace DefaultInterfaceMembers
{
    public interface IObject
    {
        void Interact();
    }

    public interface IWave : IObject
    {
        void IObject.Interact()
        {
            Console.WriteLine("From IWave");
        }
    }

    public interface IParticle : IObject
    {
        void IObject.Interact()
        {
            Console.WriteLine("From IParticle");
        }
    }

    //public class ILight : IWave, IParticle
    //{
    //}
}
