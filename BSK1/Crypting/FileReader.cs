using System.IO;

namespace BSK1.Crypting
{
    internal class FileReader
    {
        private string _path;

        public FileReader(string path)
        {
            _path = path;
        }

        public string ReadFile()
        {
            using (var reader = new StreamReader(_path))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
