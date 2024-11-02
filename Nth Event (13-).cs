//I know that a script with this functionality already exists, but I wanted to learn a bit about WinForms ^^.

using System;
using System.Collections.Generic;
using Sony.Vegas;
using System.Windows.Forms;

public class EntryPoint {

    Vegas myVegas;

    int gap = 2;

    public void FromVegas(Vegas vegas){
        
        /*----------------------Form code start--------------------*/

        Form prompt = new Form();
        prompt.Width = 240;
        prompt.Height = 80;
        prompt.Text = "Nth Event";
        prompt.FormBorderStyle = FormBorderStyle.FixedSingle;

        /*-----------------Label-----------------*/

        Label label = new Label();
        label.Text = "Selection Gap: ";
        label.Left = 95 - label.PreferredSize.Width;
        label.AutoSize = true;
        label.Top = (prompt.ClientSize.Height - label.PreferredSize.Height - 4) / 2;

        /*------------NumericUpDown--------------*/

        NumericUpDown updown = new NumericUpDown();
        updown.Minimum = 0;
        updown.Maximum = 1000000;
        updown.Increment = 1;
        updown.Value = 2;
        
        updown.Left = 101;
        updown.Top = (prompt.ClientSize.Height - updown.Height - 4) / 2;

        /*------------Apply Button--------------*/

        Button button = new Button();
        button.Text = "Apply";
        button.Top = prompt.ClientSize.Height - 4;
        button.Width = 80;
        button.Left = 80;
        button.Click += new EventHandler((sender, e) => buttonClicked(sender, e, updown));

        /*----------Form Initialization----------*/

        prompt.Controls.Add(updown);
        prompt.Controls.Add(label);
        prompt.Controls.Add(button);
        prompt.ClientSize = new System.Drawing.Size(240, 80);

        if (prompt.ShowDialog() != DialogResult.OK){return;}

        /*------*/

        

        /*----------------------Form code end----------------------*/

        myVegas = vegas;

        foreach (Track tr in vegas.Project.Tracks){
            List<TrackEvent> layerSelection = new List<TrackEvent>();
            int i = 0;
            foreach (TrackEvent ev in tr.Events){
                if (ev.Selected){
                    if (i % gap != 0){
                        ev.Selected = false;
                    }
                    i++;
                }
            }
        }  
    }
    
    private void buttonClicked(object sender, EventArgs e, NumericUpDown updown){
        Form prompt = (Form)((Button)sender).Parent; // Access the parent form
        prompt.DialogResult = DialogResult.OK;
        gap = (int)updown.Value;
        prompt.Close();
    }

}