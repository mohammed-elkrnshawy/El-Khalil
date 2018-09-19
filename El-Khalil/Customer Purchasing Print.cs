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
    public partial class Customer_Purcahsing_Print : Form
    {
        double Trana;
        bool typep;
        int Bill_ID;
        string custome_name, Bill_Details;
        double Bill_Total, Discout, old, payment;
        public Customer_Purcahsing_Print(int bill_ID,string customername,string BillDetails,double billtotal,double discount,double old,double payment,bool type,double tran)
        {
            InitializeComponent();
            this.Bill_ID = bill_ID;
            this.custome_name = customername;
            this.Bill_Details = BillDetails;
            this.Bill_Total = billtotal;
            this.Discout = discount;
            this.old = old;
            this.payment = payment;
            this.typep = type;
            this.Trana = tran;
        }

        private void Customer_Print_Load(object sender, EventArgs e)
        {
            if (typep)
            {

                string path = Application.StartupPath;
                string directory = Path.GetDirectoryName(path); //without file name
                string oneUp = Path.GetDirectoryName(directory); // Temp folder
                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(oneUp + @"\Customer Returned Report.rpt");


                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();




                crParameterDiscreteValue.Value = Bill_ID;
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["@Bill_ID"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;
                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);




                crParameterDiscreteValue.Value = typep;
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["@Bill_Type"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;
                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);



                crParameterDiscreteValue.Value = custome_name;
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["Customer_Name"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;
                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);




                crParameterDiscreteValue.Value = Bill_Details;
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["Bill_Details"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;
                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);




                crParameterDiscreteValue.Value = Bill_ID;
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["ID"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;
                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);




                crParameterDiscreteValue.Value = Bill_Total;
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["Bill_Total"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;
                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);



                crParameterDiscreteValue.Value = Discout;
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["Discout"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;
                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);




                crParameterDiscreteValue.Value = old;
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["old"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;
                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

                crParameterDiscreteValue.Value = payment;
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["payment"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;
                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);




                crystalReportViewer1.ReportSource = cryRpt;
                crystalReportViewer1.Refresh();
            }
            else
            {

                string path = Application.StartupPath;
                string directory = Path.GetDirectoryName(path); //without file name
                string oneUp = Path.GetDirectoryName(directory); // Temp folder
                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(oneUp + @"\Customer Purchasing Rport.rpt");


                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();




                crParameterDiscreteValue.Value = Bill_ID;
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["@Bill_ID"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;
                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);




                crParameterDiscreteValue.Value = typep;
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["@Bill_Type"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;
                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);



                crParameterDiscreteValue.Value = custome_name;
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["Customer_Name"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;
                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);




                crParameterDiscreteValue.Value = Bill_Details;
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["Bill_Details"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;
                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);




                crParameterDiscreteValue.Value = Bill_ID;
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["ID"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;
                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);




                crParameterDiscreteValue.Value = Bill_Total;
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["Bill_Total"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;
                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);



                crParameterDiscreteValue.Value = Discout;
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["Discout"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;
                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);




                crParameterDiscreteValue.Value = old;
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["old"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;
                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

                crParameterDiscreteValue.Value = payment;
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["payment"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;
                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);



                crParameterDiscreteValue.Value = Trana;
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["Trana"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;
                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

                crystalReportViewer1.ReportSource = cryRpt;
                crystalReportViewer1.Refresh();

            }
        }
   
    }
}
