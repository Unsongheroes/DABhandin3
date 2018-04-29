using System;

namespace DAB32
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository PersonRepository { get; }
        int Complete();


    }
}