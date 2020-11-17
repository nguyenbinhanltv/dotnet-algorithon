using System;
using System.Collections;
using System.Collections.Generic;
using algorithon_server.Models;

namespace algorithon_server.Utils.Languages
{
    public class Languages_Table
    {
        private Table[] LanguagesTable = new Table[]
        {
            
        };
        
        public IEnumerable LanguageTable { get; set; }
        public Dictionary<String, Language[]> LanguagesMap { get; set; }
    }

    public interface Table
    {
        string name { get; set; }
        Language[] languages { get; set; }
    }
}