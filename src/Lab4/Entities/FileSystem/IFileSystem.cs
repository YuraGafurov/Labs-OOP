using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;

public interface IFileSystem
{
    public string? CurPath { get; set; }
    public string? Mode { get; set; }

    public void Connect(string path, string mode);
    public void Disconnect();
    public void TreeGoto(string path);
    public IList<string> TreeList(int depth);
    public void FileShow(string path, string mode);
    public void FileMove(string sourcePath, string destinationPath);
    public void FileCopy(string sourcePath, string destinationPath);
    public void FileDelete(string path);
    public void FileRename(string path, string newName);
}