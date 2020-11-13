using P01Logger.Enumerations;

namespace P01Logger.Models.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }

        Level Level { get; }
         
        void Append(IError error);

        int AppendedMessages { get; }
    }
}
