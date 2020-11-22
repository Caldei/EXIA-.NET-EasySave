﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.NS_Model
{
    class Work
    {
        // Attributes
        public string name { get; set; }
        public string src { get; set; }
        public string dst { get; set; }
        public BackupType backupType { get; set; }


        // Constructor
        public Work (string _name, string _src, string _dst, BackupType _backupType)
        {
            this.name = _name;
            this.src = _src;
            this.dst = _dst;
            this.backupType = _backupType;
        }


        // Methods 
        // DoBackup() ?
    }
}
