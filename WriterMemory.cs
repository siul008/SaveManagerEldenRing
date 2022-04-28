using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memory.Utils;
using Memory.Win64;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SaveManagerEldenRing
{
    public class WriteMemory
    {
        MemoryHelper64 helper;
        Process p;
        ulong quitoutPtr, quitoutBaseAddr;
        ulong hpPtr, hpBaseAdress;
        int[] offsetQuitout = { 0x10 };
        int[] offsetHp = { 0x0, 0x190, 0x0, 0x138 };

        public WriteMemory()
        {
            p = Process.GetProcessesByName("eldenring").FirstOrDefault();
            if (p != null)
            {
                helper = new MemoryHelper64(p);
                quitoutBaseAddr = helper.GetBaseAddress(0x3C68758);
                hpBaseAdress = helper.GetBaseAddress(0x3A2ED50);
                quitoutPtr = MemoryUtils.OffsetCalculator(helper, quitoutBaseAddr, offsetQuitout);
                hpPtr = MemoryUtils.OffsetCalculator(helper, hpBaseAdress, offsetHp);
            }
        }
        public void Quitout()
        {
            helper.WriteMemory(quitoutPtr, 1);
        }
        public int ReadHp()
        {
            return helper.ReadMemory<int>(hpPtr);
        }
    }
}
