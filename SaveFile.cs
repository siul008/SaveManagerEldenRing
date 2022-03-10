using System;

namespace SaveManagerEldenRing
{
    internal class SaveFile
    {
        public SaveFile()
        {
            Date = DateTime.Now;
            id = Date.Year * Date.Month * Date.Day * Date.Millisecond;    
        }
        public long id { get; set; }
        public string SaveName { get; set; }
        public DateTime Date { get; set; }
    }
}