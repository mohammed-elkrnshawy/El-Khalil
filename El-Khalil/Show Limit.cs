using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace El_Khalil
{
    public partial class Show_Limit : Form
    {
        bool f;
        DataSet dataSet;
        public Show_Limit(bool F)
        {
            InitializeComponent();
            f = !F;
        }

        private void Show_Limit_Load(object sender, EventArgs e)
        {
            using (dataSet = Ezzat.GetDataSet("select_CreditLimit"
                    , "X"
                    , new SqlParameter("@Type", f)
                    ))
            {
                dataGridView1.DataSource = dataSet.Tables["X"];
            }
        }
    }
}
