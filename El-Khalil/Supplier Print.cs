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
    public partial class Supplier_Print : Form
    {
        DateTime Day, Day2;
        public Supplier_Print(DateTime day,DateTime day2)
        {
            InitializeComponent();
            Day = day;
            Day2 = day2;
        }

        private void Supplier_Print_Load(object sender, EventArgs e)
        {
            string path = Application.StartupPath;
            string directory = Path.GetDirectoryName(path); //without file name
            string oneUp = Path.GetDirectoryName(directory); // Temp folder


            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(oneUp + @"\Supplier Report.rpt");
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();




            crParameterDiscreteValue.Value = Day;
            ParameterFieldDefinitions crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["@Day"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);




            crParameterDiscreteValue.Value = Day2;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["@Day2"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();
        }
    }
}
