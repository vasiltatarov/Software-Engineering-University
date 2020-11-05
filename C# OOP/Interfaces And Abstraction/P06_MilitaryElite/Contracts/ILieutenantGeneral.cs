using System.Collections.Generic;

namespace P07MilitaryElite
{
    public interface ILieutenantGeneral : IPrivate
    {
        public IReadOnlyCollection<IPrivate> Privates { get; }

        public void AddPrivate(IPrivate @private);
    }
}
