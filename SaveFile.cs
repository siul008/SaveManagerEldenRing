using System;

namespace SaveManagerEldenRing
{
    public class SaveFile
    {
        public SaveFile(string mSaveName, long mId)
        {     
            this.id = mId;
            this.SaveName = mSaveName;
            Date = DateTime.Now;
        }
        public long id { get; set; }
        public string SaveName { get; set; }
        public DateTime Date { get; set; }
    }
}