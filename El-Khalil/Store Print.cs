using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace El_Khalil
{
    public partial class Store_Print : Form
    {
        bool b;
        public Store_Print(bool B)
        {
            InitializeComponent();
            b = B;
        }

        private void Store_Print_Load(object sender, EventArgs e)
        {
            if(b)
            {
                string path = Application.StartupPath;
                string directory = Path.GetDirectoryName(path); //without file name
                string oneUp = Path.GetDirectoryName(directory); // Temp folder


                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(Application.StartupPath + @"\Store Product Report.rpt");

               
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

                
                crystalReportViewer1.ReportSource = cryRpt;
                crystalReportViewer1.Refresh();
            }
            else
            {
                string path = Application.StartupPath;
                string directory = Path.GetDirectoryName(path); //without file name
                string oneUp = Path.GetDirectoryName(directory); // Temp folder


                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(oneUp + @"\Strore Material Report.rpt");

               
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();


                crystalReportViewer1.ReportSource = cryRpt;
                crystalReportViewer1.Refresh();
            }
        }
    }
}
