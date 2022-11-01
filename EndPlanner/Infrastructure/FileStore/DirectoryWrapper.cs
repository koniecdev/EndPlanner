using Application.Common.Interfaces;

namespace Infrastructure.FileStore;

public class DirectoryWrapper : IDirectoryWrapper
{
	public void CreateDirectory(string path)
	{
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}
	}
}
