/* Ashley Smith
 * CPT-206-A01S (Adv Event-Driven Programming)
 * Lab 2: Population Database (Chapter 12; Q:6)
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASmith_Lab_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cityBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.cityBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cityDBDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cityDBDataSet.City' table. You can move, or remove it, as needed.
            this.cityTableAdapter.Fill(this.cityDBDataSet.City);

        }

        //Show the details of the cities in another form
        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            PopulationDetails populationDetails = new PopulationDetails();
            populationDetails.ShowDialog();
        }

        //List out the population in ascending order on the data grid
        private void btnAscending_Click(object sender, EventArgs e)
        {
            this.cityTableAdapter.FillByPopulationAscending(this.cityDBDataSet.City);
        }


        //List out the population in descending order on the data grid
        private void btnDescending_Click(object sender, EventArgs e)
        {
            this.cityTableAdapter.FillByPopulationDescending(this.cityDBDataSet.City);
        }

        //Show the total population in a messagebox
        private void btnTotalPopulation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The total population of all the cities is: " + cityTableAdapter.TotalPopulationQuery().ToString());
        }

        //Show the Average population in a messagebox
        private void btnAverage_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The average population from all of the cities is: " + cityTableAdapter.AveragePopulationQuery().ToString());
        }

        //Show the Highest population in a messagebox
        private void btnHighest_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The highest population from all the cities is: " + cityTableAdapter.HighestPopulationQuery().ToString());
        }

        //Show the Lowest population in a messagebox
        private void btnLowest_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The Lowest population from all the cities is: " + cityTableAdapter.LowestPopulationQuery().ToString());
        }

        //Leave the program
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
