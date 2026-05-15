using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.People.Forms
{
    public partial class frmPersonCard : Form
    {
        public frmPersonCard(int ID)
        {
            InitializeComponent();
            ctrlPersonDetails1.PersonID = ID;
        }

        public frmPersonCard(string NationalNo)
        {
            InitializeComponent();
            ctrlPersonDetails1.NationalNo = NationalNo;
        }
    }
}
