using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantumLibrary
{
    public class FormUI : System.Windows.Forms.Form
    {
        public bool boolRefreshCache = false;
        public bool boolParseWikipedia = true;
        public bool boolParseImages = true;
        public bool boolBingImages = true;
        public bool boolParseVideos = true;
        public int parsingThreadsToUse = 8;
        public virtual void Message(string message){}
    }
}
