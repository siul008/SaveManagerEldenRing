using System;

namespace SaveManagerEldenRing
{
    public class SaveFile
    {
        public SaveFile(string mSaveName, long id)
        {
            if(id == 0)
            {
                id = date.Year * date.Month * date.Day * date.Millisecond;
            }
            else
            {
                this.id = id;
            }
            this.saveName = mSaveName;
            date = DateTime.Now;
        }
        public long id { get; set; }
        public string saveName { get; set; }
        public DateTime date { get; set; }
    }
}