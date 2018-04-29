using System;

namespace DAB32
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository Persons { get; }
        int Complete();


    }
}