using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Departamental_non_conformance_metrics
{
    public partial class Goals : Form
    {
        List<Goal> goals = new List<Goal>();

        public Goals()
        {
            InitializeComponent();
        }

        private void Goals_Load(object sender, EventArgs e)
        {
            // deserialize
            goals = Deserialize();

            // check if no file available
            if(goals == null)
            {
                MessageBox.Show("Problem loading serialized binary data. Contact IT support for help");
            }

            // get all textboxes
            var allTextBoxes = groupBox.Controls.OfType<TextBox>();

            TextBox temp = null;
            // fill out textboxes
            foreach (var goal in goals)
            {
                temp = allTextBoxes.First(t => t.Name.Equals(goal.department));

                temp.Text = goal.goal.ToString();
            }

        }

        public static void Serialize(List<Goal> goals)
        {
            try
            {
                using (Stream stream = File.Open("data.bin", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, goals);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There is a problem with binary issue\nContact IT support");
            }
        }

        public static List<Goal> Deserialize()
        {
            try
            {
                using (Stream stream = File.Open("data.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    var goals = (List<Goal>)bin.Deserialize(stream);
                    return goals;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There is a problem with binary issue\nContact IT support");
                return null;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            int value;
            // add all textboxes
            var allTextBoxes = groupBox.Controls.OfType<TextBox>();

            // validate all textboxes
            foreach (TextBox tb in allTextBoxes)
            {
                if (tb.Text.Trim().Length == 0 || !int.TryParse(tb.Text.Trim(), out value))
                {
                    MessageBox.Show("Textbox " + tb.Name + " formatted incorrectly");
                    return;
                }
            }

            // create new goals to save
            goals = new List<Goal>();

            // add goals
            foreach (TextBox tb in allTextBoxes)
                goals.Add(new Goal(tb.Name, int.Parse(tb.Text)));

            // serialize object
            Serialize(goals);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            // deserialize
            goals = Deserialize();

            // check if no file available
            if (goals == null)
            {
                MessageBox.Show("Problem loading serialized binary data. Contact IT support for help");
            }

            // get all textboxes
            var allTextBoxes = groupBox.Controls.OfType<TextBox>();

            TextBox temp = null;
            // fill out textboxes
            foreach (var goal in goals)
            {
                temp = allTextBoxes.First(t => t.Name.Equals(goal.department));

                temp.Text = goal.goal.ToString();
            }
        }
    }
}
