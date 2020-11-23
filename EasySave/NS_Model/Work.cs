﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace EasySave.NS_Model
{
    class Work
    {
        // --- Attributes ---
        public string name { get; set; }
        public string src { get; set; }
        public string dst { get; set; }
        public BackupType backupType { get; set; }
        public State state { get; set; }
        public string lastBackupDate { get; set; }


        // --- Constructors ---
        // Constructor used by LoadWorks()
        public Work()
        {

        }

        // Constructor used by AddWork()
        public Work (string _name, string _src, string _dst, BackupType _backupType)
        {
            this.name = _name;
            this.src = _src;
            this.dst = _dst;
            this.backupType = _backupType;

            this.state = null;
        }
    }
}
