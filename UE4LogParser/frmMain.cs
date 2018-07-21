using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace UE4LogParser
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            toolStripStatusLabel.Text = "";
        }

        private string[] keywords = { "ERROR", "WARNING", "INFO" };
        private Color[] keyword_colors = { ColorTranslator.FromHtml("#FFD2D2"), ColorTranslator.FromHtml("#FEEFB3"), Color.CadetBlue };
        private List<string> export_log = new List<string>();

        private string opened_log;

        private void menuOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = "Open your UE4 Log",
                Filter = "UE4 Log (*.log;*.txt)|*.log;*.txt"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Clear previous log data
                logView.Rows.Clear();
                export_log.Clear();
                opened_log = "";

                opened_log = ofd.FileName;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void menuExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Title = "Export your UE4 Log",
                Filter = "UE4 Log (*.log, *.txt)|*.log;*.txt"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllLines(sfd.FileName, export_log);
                MessageBox.Show($"Saved to {sfd.FileName}", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void logView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                logView.Rows[e.RowIndex].DefaultCellStyle.BackColor = keyword_colors[Array.IndexOf(keywords, logView.Rows[e.RowIndex].Cells[1].Value).Clamp(0, 2)];
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuSettings_Click(object sender, EventArgs e)
        {
            frmSettings settings = new frmSettings();
            settings.ShowDialog();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            using (FileStream fs = File.Open(opened_log, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (BufferedStream bs = new BufferedStream(fs))
                {
                    using (StreamReader sr = new StreamReader(bs))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            foreach (string keyword in keywords)
                            {
                                if (Utils.Contains(line, keyword, StringComparison.OrdinalIgnoreCase))
                                {
                                    logView.Invoke(new Action(() =>
                                    {
                                        logView.Rows.Add(new string[] {
                                            logView.Rows.Count.ToString(), keyword, line
                                        });
                                    }));
                                    export_log.Add(line);
                                }
                            }
                        }
                    }
                }

              //  int percent = (int)(((double)fs.Length) * 100.0) + 1;
               // backgroundWorker1.ReportProgress(percent);
            }

            if (export_log.Count >= 1)
            {
                menuExport.Enabled = true;
                logView.Invoke(new Action(() => { logView.Enabled = true; }));
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar.Value = e.ProgressPercentage;
            toolStripStatusLabel.Text = $"{e.ProgressPercentage.ToString()}% Loaded";

            if (e.ProgressPercentage == 100)
            {
                backgroundWorker1.CancelAsync();
                toolStripStatusLabel.Text = "Loaded Log";
            }
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("UE4LogParser \r\nDeveloped by Russ 'trdwll' Treadwell\r\nwww.trdwll.com", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
