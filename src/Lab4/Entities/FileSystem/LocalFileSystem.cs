using System;
using System.Collections.Generic;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;

public class LocalFileSystem : IFileSystem
{
    public string? CurPath { get; set; }
    public string? Mode { get; set; }

    public void Connect(string path, string mode)
    {
        if (CurPath is not null)
        {
            throw new ArgumentException("Before connecting to the new file system, you must quit another");
        }

        CurPath = path;
        Mode = mode;
    }

    public void Disconnect()
    {
        CurPath = null;
        Mode = null;
    }

    public void TreeGoto(string path)
    {
        CurPath = path;
    }

    public IList<string> TreeList(int depth)
    {
        var list = new List<string>();
        foreach (string directory in Directory.EnumerateDirectories(CurPath ?? throw new InvalidOperationException()))
        {
            list.Add(directory);
            if (depth > 0)
            {
                list.AddRange(TreeList(depth - 1));
            }
        }

        list.AddRange(Directory.EnumerateFiles(CurPath));

        return list;
    }

    public void FileShow(string path, string mode)
    {
        var sr = new StreamReader(path);
        if (mode == "console")
        {
            Console.WriteLine(sr.ReadToEnd());
        }

        sr.Close();
    }

    public void FileMove(string sourcePath, string destinationPath)
    {
        File.Move(sourcePath, destinationPath);
    }

    public void FileCopy(string sourcePath, string destinationPath)
    {
        File.Copy(sourcePath, destinationPath);
    }

    public void FileDelete(string path)
    {
        File.Delete(path);
    }

    public void FileRename(string path, string newName)
    {
        string oldName = Path.GetFileName(path);
        File.Move(oldName, newName);
    }
}