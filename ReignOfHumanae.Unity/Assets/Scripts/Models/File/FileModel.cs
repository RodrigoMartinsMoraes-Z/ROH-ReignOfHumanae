using System;

namespace Assets.Scripts.Models.File
{
    [Serializable]
    public class FileModel
    {
        public string Name { get; set; }
        public string Format { get; set; }
        public byte[] Content { get; set; }

        public FileModel(string name, string format, byte[] content)
        {
            Name = name;
            Format = format;
            Content = content;
        }
    }
}