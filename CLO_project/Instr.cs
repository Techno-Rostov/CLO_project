using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLO_project
{
    public partial class Instr : Form
    {
        public Instr()
        {
            InitializeComponent();
            Instruction.LoadFile(Path.GetFullPath("Инструкция конфигуратора CLO.rtf"));
            Instruction.ScrollToCaret();
        }
    }
}
