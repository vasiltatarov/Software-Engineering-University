namespace P01Logger.Models.Contracts
{
    public interface IIOManager
    {
        string CurrentDirectoryPath { get; }
        string CurrentFilePath { get; }

        string GetCurrentDirectoryes();

        void EnsureDirectoryAndFileExist();
    }
}
