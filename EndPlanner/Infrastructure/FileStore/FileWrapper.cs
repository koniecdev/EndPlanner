using Application.Common.Interfaces;

namespace Infrastructure.FileStore;

public class FileWrapper : IFileWrapper
{
	public void WriteAllBytes(string outputFile, byte[] content)
	{
		File.WriteAllBytes(outputFile, content);
	}
}
