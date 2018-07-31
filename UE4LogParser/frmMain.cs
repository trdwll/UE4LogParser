using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace UE4LogParser
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
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
            try
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
                                    if (line.ToUpper().Contains(keyword.ToUpper()))
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
                }

                if (export_log.Count >= 1)
                {
                    menuExport.Enabled = true;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("UE4LogParser \r\nDeveloped by Russ 'trdwll' Treadwell\r\nwww.trdwll.com", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void logView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void logView_DragDrop(object sender, DragEventArgs e)
        {
            logView.Rows.Clear();
            export_log.Clear();
            opened_log = "";

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            if (files.Length >= 1)
            {
                opened_log = files[0]; // Such a terrible way to handle this, but it's fine. lol
                backgroundWorker1.RunWorkerAsync();
            }
        }
    }
}
