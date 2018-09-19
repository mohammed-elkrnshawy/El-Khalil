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
    public partial class Employee_Account_Print : Form
    {
        int Employer_ID;
        public Employee_Account_Print(int employer_ID)
        {
            InitializeComponent();
            this.Employer_ID = employer_ID;
        }

        private void Employee_Account_Print_Load(object sender, EventArgs e)
        {
            string path = Application.StartupPath;
            string directory = Path.GetDirectoryName(path); //without file name
            string oneUp = Path.GetDirectoryName(directory); // Temp folder


            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(oneUp + @"\Employee Account Report.rpt");

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();




            crParameterDiscreteValue.Value = Employer_ID;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["@Employer_ID"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            
            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();
        }
    }
}
