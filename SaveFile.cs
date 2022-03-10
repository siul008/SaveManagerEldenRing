using System;

namespace SaveManagerEldenRing
{
    internal class SaveFile
    {
        public SaveFile()
        {
            id = new Random().Next(1, 100000);
            Date = DateTime.Now;
        }
        public long id { get; set; }
        public string SaveName { get; set; }
        public DateTime Date { get; set; }
    }
}