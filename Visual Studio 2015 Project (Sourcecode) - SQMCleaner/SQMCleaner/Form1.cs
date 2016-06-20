using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace SQMCleaner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string[] RAWTextLines { get; set; }

        private void PathButton_Click(object sender, EventArgs e)
        {
            try
            {
                var openSQMDialog = new OpenFileDialog();
                openSQMDialog.Title = "Select SQM File:";
                openSQMDialog.Filter = "SQM File|*.sqm";
                openSQMDialog.InitialDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                openSQMDialog.Multiselect = false;
                var DialogResult = openSQMDialog.ShowDialog(this);
                if (DialogResult == DialogResult.OK)
                {
                    PathTextBox.Text = openSQMDialog.FileName;
                    CleanButton.Enabled = true;
                }
                else
                {
                    CleanButton.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void CleanButton_Click(object sender, EventArgs e)
        {
            try
            {
                PathButton.Enabled = false;
                DeleteAllCheckBox.Enabled = false;
                CleanButton.Enabled = false;
                if (!DeleteAllCheckBox.Checked)
                {
                    SimpleDeleteTextBox.Enabled = false;
                }

                if (File.Exists(PathTextBox.Text))
                {
                    RAWTextLines = File.ReadAllLines(PathTextBox.Text);
                    var NextCustomAttributeIndex = GetTextLineIndex(0, "class CustomAttributes", string.Empty);
                    var NextAttributeIndex = 0;
                    var NextExpressionIndex = 0;
                    var DeleteFromIndex = 0;
                    var DeleteToIndex = -1;
                    while (NextCustomAttributeIndex > -1)
                    {
                        if (!DeleteAllCheckBox.Checked)
                        {
                            NextAttributeIndex = GetTextLineIndex(NextCustomAttributeIndex, "class Attribute", "nAttributes=");
                            while (NextAttributeIndex > -1)
                            {
                                NextExpressionIndex = GetTextLineIndex(NextAttributeIndex, "expression=", string.Empty);
                                if (RAWTextLines[NextExpressionIndex].ToLowerInvariant().Contains(SimpleDeleteTextBox.Text.ToLowerInvariant()))
                                {
                                    DeleteFromIndex = NextAttributeIndex;
                                    DeleteToIndex = GetTextLineIndex(NextExpressionIndex, "class Attribute", "nAttributes=");
                                    if (DeleteToIndex == -1)
                                    {
                                        DeleteToIndex = GetTextLineIndex(NextExpressionIndex, "nAttributes=", string.Empty);
                                    }
                                    CleanUpLines(DeleteFromIndex, DeleteToIndex - 1);
                                }
                                NextAttributeIndex = GetTextLineIndex(NextExpressionIndex, "class Attribute", "nAttributes=");
                            }
                            var CurrentRawTextLines = RAWTextLines.ToList().GetRange(NextCustomAttributeIndex, NextExpressionIndex - NextCustomAttributeIndex);
                            var LeftAttributeCount = CurrentRawTextLines.Where(TextLine => TextLine.ToLowerInvariant().Contains("class Attribute".ToLowerInvariant())).Count();
                            if (LeftAttributeCount == 0)
                            {
                                DeleteFromIndex = NextCustomAttributeIndex;
                                DeleteToIndex = GetTextLineIndex(NextCustomAttributeIndex, "nAttributes=", string.Empty);
                                CleanUpLines(DeleteFromIndex, DeleteToIndex + 1);
                            }
                            else
                            {
                                DeleteFromIndex = NextCustomAttributeIndex;
                                DeleteToIndex = GetTextLineIndex(NextCustomAttributeIndex, "nAttributes=", string.Empty);
                                ChangeAttributesIndex(DeleteFromIndex, DeleteToIndex);
                            }
                        }
                        else
                        {
                            DeleteFromIndex = NextCustomAttributeIndex;
                            DeleteToIndex = GetTextLineIndex(NextCustomAttributeIndex, "nAttributes=", string.Empty);
                            CleanUpLines(DeleteFromIndex, DeleteToIndex + 1);
                        }
                        NextCustomAttributeIndex = GetTextLineIndex(DeleteToIndex, "class CustomAttributes", string.Empty);
                    }
                    var NewRawTextLines = RAWTextLines.ToList();
                    NewRawTextLines.RemoveAll(TextLine => TextLine == "-1");

                    var saveSQMDialog = new SaveFileDialog();
                    saveSQMDialog.CheckPathExists = true;
                    saveSQMDialog.CheckFileExists = false;
                    saveSQMDialog.OverwritePrompt = true;
                    saveSQMDialog.ValidateNames = true;
                    saveSQMDialog.Title = "Save SQM File:";
                    saveSQMDialog.Filter = "SQM File|*.sqm";
                    saveSQMDialog.InitialDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    var DialogResult = saveSQMDialog.ShowDialog(this);
                    if (DialogResult == DialogResult.OK)
                    {
                        if (File.Exists(saveSQMDialog.FileName))
                        {
                            File.Delete(saveSQMDialog.FileName);
                        }
                        File.WriteAllLines(saveSQMDialog.FileName, NewRawTextLines);
                        MessageBox.Show("Successful");
                    }

                    PathButton.Enabled = true;
                    DeleteAllCheckBox.Enabled = true;
                    CleanButton.Enabled = true;
                    if (!DeleteAllCheckBox.Checked)
                    {
                        SimpleDeleteTextBox.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("File doesn't exist anymore");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private bool ChangeAttributesIndex(int From, int To)
        {
            var AttributeCounter = 0;
            for (int i = From; i <= To; i++)
            {
                if (RAWTextLines[i].ToLowerInvariant().Contains("class Attribute".ToLowerInvariant()))
                {
                    RAWTextLines[i] = RAWTextLines[i].Split(new string[1] { "class Attribute" }, StringSplitOptions.None)[0] + "class Attribute" + AttributeCounter++.ToString();
                }
                if (RAWTextLines[i].ToLowerInvariant().Contains("nAttributes=".ToLowerInvariant()))
                {
                    RAWTextLines[i] = RAWTextLines[i].Split(new string[1] { "nAttributes=" }, StringSplitOptions.None)[0] + "nAttributes=" + AttributeCounter.ToString() + ";";
                }
            }
            return true;
        }

        private int GetTextLineIndex(int StartIndex, string SearchText, string BreakText)
        {
            for (int i = StartIndex; i < RAWTextLines.Length; i++)
            {
                if (RAWTextLines[i].ToLowerInvariant().Contains(SearchText.ToLowerInvariant()))
                {
                    return i;
                }
                else if (!BreakText.Equals(string.Empty) && RAWTextLines[i].ToLowerInvariant().Contains(BreakText.ToLowerInvariant()))
                {
                    return -1;
                }
            }
            return -1;
        }

        private void CleanUpLines(int From, int To)
        {
            for (int i = From; i <= To; i++)
            {
                RAWTextLines[i] = "-1";
            }
        }

        private void DeleteAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DeleteAllCheckBox.Checked)
            {
                SimpleDeleteTextBox.Enabled = false;
            }
            else
            {
                SimpleDeleteTextBox.Enabled = true;
            }
        }
    }
}
