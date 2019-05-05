using System.IO;

namespace BSK1.Crypting
{
    internal class FileWriter
    {
        private string _path;
        private string _text;

        public FileWriter(string path, string text)
        {
            _path = path;
            _text = text;
        }

        public void WriteToFile()
        {
            using (var writer = new StreamWriter(_path))
            {
                var textInParts = _text.Split('\n');
                foreach (var text in textInParts)
                {
                    writer.Write(text);
                }
            }
        }
    }
}
