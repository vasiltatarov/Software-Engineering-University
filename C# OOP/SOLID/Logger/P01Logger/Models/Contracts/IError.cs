using P01Logger.Enumerations;
using System;

namespace P01Logger.Models.Contracts
{
    public interface IError
    {
        Level Level { get; }

        DateTime DateTime { get; }

        string Message { get; }
    }
}
