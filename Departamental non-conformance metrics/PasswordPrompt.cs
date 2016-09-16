using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Departamental_non_conformance_metrics
{
    class PasswordPrompt
    {
        static readonly string passowrd = "4321";

        public static bool ShowDialog(string text, string caption)
        {
            Form prompt = new Form();
            prompt.Width = 200;
            prompt.Height = 150;
            prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
            prompt.Text = caption;
            prompt.StartPosition = FormStartPosition.CenterScreen;
            Label textLabel = new Label() { Left = 25, Top = 15, Width = 150, Text = text };
            TextBox textBox = new TextBox() { Left = 35, Top = 40, Width = 100 };
            textBox.PasswordChar = '*';
            textBox.MaxLength = 15;
            Button confirmation = new Button() { Text = "Ok", Left = 50, Width = 75, Top = 75, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            if (prompt.ShowDialog() == DialogResult.OK)
                if (textBox.Text.Equals(passowrd))
                    return true;

            return false;
        }
    }
}
