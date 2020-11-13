using P01Logger.Models.Contracts;

namespace P01Logger.Models
{
    public interface IFile
    {
        string Path { get; }    

        long Size { get; }

        string Write(ILayout layout, IError error);
    }
}
