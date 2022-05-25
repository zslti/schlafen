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
using System.Text.RegularExpressions;

namespace WindowsFormsApp10
{
    public partial class Form1 : Form
    {
        Form formPopup = new Form();
        Form openFilePopup = new Form();
        Form helpForm = new Form();
        private void formPopup_FormClosing(object sender, FormClosingEventArgs e)
        {
            formPopup.Hide();
            e.Cancel = true;
        }
        private void openFilePopup_FormClosing(object sender, FormClosingEventArgs e)
        {
            openFilePopup.Hide();
            e.Cancel = true;
        }

        private void helpForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            helpForm.Hide();
            e.Cancel = true;
        }

        TextBox filenameTextBox = new TextBox()
        {
            Location = new Point(65, 5),
        };
        Button createFileButton = new Button()
        {
            Location = new Point(10, 30),
            Text = "Create file",

        };
        Label fileNameLabel = new Label()
        {
            Location = new Point(10, 7),
            Text = "File name:"
        };

        public Form1()
        {
            InitializeComponent();
            input.Width = this.Width - 53;
            console.Width = this.Width - 30;
            input.Height = this.Height - 220;
            lineNumberLabel.Height = this.Height - 200;
            console.Top = Math.Max(this.Height - 180, 85);
            input.SelectionTabs = new int[] { 30, 60, 90, 120, 150, 180, 210, 240, 270, 300, 330, 360, 390, 420, 450, 480, 510, 540, 570, 600, 630, 660, 690, 720, 750, 780, 810, 840, 870 };
            hideEditor();
            panel2.Top = input.Top;
            panel2.Left = input.Right - panel2.Width;
            searchTextBox.Top = panel2.Top + 5;
            replaceTextBox.Top = searchTextBox.Bottom + 5;
            searchTextBox.Left = replaceTextBox.Left = panel2.Left + 5;
            searchButton.Left = searchTextBox.Right + 5;
            searchButton.Top = searchTextBox.Top;
            replaceButton.Left = replaceTextBox.Right + 5;
            replaceButton.Top = replaceTextBox.Top;

            this.Text = "Schlafen";
            formPopup.Text = "Create file";
            openFilePopup.Text = "Open file";

            //searchTextBox.Parent = replaceTextBox.Parent = panel2;
        }
        public static int GetVerticalScrollPos(RichTextBox box)
        {
            int index = box.GetCharIndexFromPosition(new Point(1, 1));
            int topline = box.GetLineFromCharIndex(index);
            return topline;
        }
        public static int GetBottomLinePos(RichTextBox box)
        {
            int index = box.GetCharIndexFromPosition(new Point(1, box.Height - 1));
            int topline = box.GetLineFromCharIndex(index);
            return topline;
        }
        int getCursorPosition(RichTextBox box)
        {
            int cursorPosition = box.SelectionStart;
            return box.GetLineFromCharIndex(cursorPosition);
        }

        private void onResize(object sender, EventArgs e)
        {
            input.Width = this.Width - 53;
            console.Width = this.Width - 30;
            input.Height = this.Height - 220;
            lineNumberLabel.Height = this.Height - 200;
            console.Top = Math.Max(this.Height - 180, 85);
            panel2.Top = input.Top;
            panel2.Left = input.Right - panel2.Width;
            searchTextBox.Top = panel2.Top + 5;
            replaceTextBox.Top = searchTextBox.Bottom + 5;
            searchTextBox.Left = replaceTextBox.Left = panel2.Left + 5;
            searchButton.Left = searchTextBox.Right + 5;
            searchButton.Top = searchTextBox.Top;
            replaceButton.Left = replaceTextBox.Right + 5;
            replaceButton.Top = replaceTextBox.Top;
        }

        void hideEditor()
        {
            console.Enabled = false;
            input.Enabled = false;
            input.Hide();
            console.Hide();
            lineNumberLabel.Hide();
            closeFileButton.Hide();
            panel1.Hide();
            runPictureBox.Hide();
            hideSearch();
        }

        void showEditor()
        {
            console.Enabled = true;
            input.Enabled = true;
            input.Show();
            console.Show();
            lineNumberLabel.Show();
            closeFileButton.Show();
            panel1.Show();
            runPictureBox.Show();
        }

        long lastSearchTime = 0;
        void showSearch()
        {
            if (Math.Abs(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - lastSearchTime) < 500 || !input.Visible)
                return;
            lastSearchTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            panel2.Show();
            searchTextBox.Show();
            replaceTextBox.Show();
            searchButton.Show();
            replaceButton.Show();
            replaceTextBox.BringToFront();
            searchTextBox.BringToFront();
            searchButton.BringToFront();
            replaceButton.BringToFront();
        }
        void hideSearch()
        {
            if (Math.Abs(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - lastSearchTime) < 500)
                return;
            lastSearchTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            panel2.Hide();
            searchTextBox.Hide();
            replaceTextBox.Hide();
            searchButton.Hide();
            replaceButton.Hide();
        }
        void hideHomeScreen()
        {
            getStartedLabel.Hide();
            createNewLabel.Hide();
            openFile.Hide();
        }

        void showHomeScreen()
        {
            getStartedLabel.Show();
            createNewLabel.Show();
            openFile.Show();
            hideSearch();
        }

        void _openFile(String text, String name)
        {
            hideHomeScreen();
            input.Text = text;
            currentlyEditingLabel.Location = new Point(15, 6);
            currentlyEditingLabel.Text = name;
            closeFileButton.Left = currentlyEditingLabel.Right;
            panel1.Location = new Point(currentlyEditingLabel.Left + 16, currentlyEditingLabel.Top);
            panel1.Width = currentlyEditingLabel.Width + closeFileButton.Width + 20;
            currentlyEditingLabel.BringToFront();
            closeFileButton.BringToFront();
            currentlyEditingLabel.Parent = panel1;
            closeFileButton.Parent = panel1;
            runPictureBox.Left = closeFileButton.Right + 45;
            runPictureBox.Top = closeFileButton.Top + 10;
            showEditor();
        }

        String rightAlignedNumber(int num)
        {
            if (num > 99)
            {
                return num.ToString();
            }
            else if (num > 9)
            {
                return " " + num.ToString();
            }
            else
            {
                return "  " + num.ToString();
            }
        }
       
        public static void HighlightText(RichTextBox myRtb, string word, Color color)
        {
            if (word == string.Empty)
                return;

            int s_start = myRtb.SelectionStart, startIndex = 0, index;

            while ((index = myRtb.Text.IndexOf(word, startIndex)) != -1)
            {
                myRtb.Select(index, word.Length);
                myRtb.SelectionColor = color;

                startIndex = index + word.Length;
            }

            myRtb.SelectionStart = s_start;
            myRtb.SelectionLength = 0;
            myRtb.SelectionColor = Color.Black;
        }
     
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(ModifierKeys.HasFlag(Keys.Control) && fDown)
            {
                if (panel2.Visible)
                    hideSearch();
                else
                    showSearch();
            }
            int lineIndex = GetVerticalScrollPos(input);
            int cursorPos = getCursorPosition(input);
            int bottomLinePos = GetBottomLinePos(input);
            String text = "";

            for (int i = lineIndex; i < Math.Max(bottomLinePos, 1); i++)
            {
                if (i == lineIndex)
                    text += rightAlignedNumber(lineIndex + 1) + "\n";
                if (bottomLinePos != 0)
                    if (i != Math.Max(bottomLinePos, 1) - 1 || Math.Abs(cursorPos - bottomLinePos) <= 1)
                        text += rightAlignedNumber(i + 2) + "\n";
            }

            lineNumberLabel.Text = text;

            lineNumberLabel.Font = new Font("Consolas", 11 * input.ZoomFactor);
            lineNumberLabel.Location = new Point(input.Left - lineNumberLabel.Width, 40);
        }
        private void createFileButtonHandler(object sender, EventArgs e)
        {
            String fileName = filenameTextBox.Text + ".sch";
            File.WriteAllText(fileName, "schreiben \"hallo welt\";\nschlafen;");
            _openFile(File.ReadAllText(fileName), fileName);
            formPopup.Hide();
        }
        private void createNewLabel_Click(object sender, EventArgs e)
        {
            formPopup = new Form();
            formPopup.Height = 100;
            formPopup.Width = 200;

            filenameTextBox = new TextBox()
            {
                Location = new Point(65, 5),
            };
            createFileButton = new Button()
            {
                Location = new Point(10, 30),
                Text = "Create file",

            };
            fileNameLabel = new Label()
            {
                Location = new Point(10, 7),
                Text = "File name:"
            };

            createFileButton.Click += new EventHandler(createFileButtonHandler);
            formPopup.Text = "Create file";
            formPopup.Controls.Add(filenameTextBox);
            formPopup.Controls.Add(createFileButton);
            formPopup.Controls.Add(fileNameLabel);
            formPopup.Show();
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            openFilePopup = new Form();
            openFilePopup.Text = "Open file";
            DirectoryInfo d = new DirectoryInfo(Directory.GetCurrentDirectory());
            FileInfo[] Files = d.GetFiles("*.sch");

            int i = 0;

            foreach (FileInfo file in Files)
            {
                void openFileButtonHandler(object _sender, EventArgs _e)
                {
                    string text = File.ReadAllText(file.FullName);
                    _openFile(text, file.Name);
                    openFilePopup.Hide();
                }
                Label fileNameLabel = new Label()
                {
                    Location = new Point(10 + 100 * (i / 13), 20 * (i % 13)),
                    Text = file.Name,
                };
                fileNameLabel.Click += new EventHandler(openFileButtonHandler);
                openFilePopup.Controls.Add(fileNameLabel);
                i++;

                formPopup.FormClosing += formPopup_FormClosing;
                openFilePopup.FormClosing += openFilePopup_FormClosing;
                helpForm.FormClosing += helpForm_FormClosing;
            }

            if (Files.Length == 0)
            {
                Label noFilesLabel = new Label()
                {
                    Location = new Point(10, 20 * i),
                    Text = "No files found",
                };
                openFilePopup.Controls.Add(noFilesLabel);
            }
            openFilePopup.Show();
        }

        private void closeFileButton_Click(object sender, EventArgs e)
        {
            hideEditor();
            showHomeScreen();
        }

        private void currentlyEditingLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(new Point(Cursor.Position.X, Cursor.Position.Y));
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideEditor();
            showHomeScreen();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllText(currentlyEditingLabel.Text, input.Text);
        }

        Dictionary<String, String> stringVariables = new Dictionary<String, String>();
        Dictionary<String, bool> boolVariables = new Dictionary<String, bool>();
        Dictionary<String, int> intVariables = new Dictionary<String, int>();
        Dictionary<String, float> floatVariables = new Dictionary<String, float>();
        String inputFile = "";
        String[] inputFileContents;
        int inputLine = 0;

        bool executeLine(String keyword, String args)
        {
            keyword = keyword.Replace("\n", "").Replace("\r", "").Replace("\t", "");
            if (keyword == "schreiben")
            {
                if (args.Contains(" ist ") || args.Contains(">") || args.Contains("<"))
                {
                    console.Text += getBoolExpressionValue(args) ? "richtig" : "falsch";
                    return true;
                }
                String arg = getStringExpressionValue(args);
                bool stringExists = false;
                try
                {
                    String larg = args;
                    while(larg.StartsWith(" "))
                    {
                        larg = larg.Remove(0, 1);
                    }
                    larg = stringVariables[larg];
                    stringExists = true;
                }
                catch(KeyNotFoundException e)
                {

                }
                if (arg == "" && !stringExists)
                {
                    bool value = getBoolExpressionValue(args);
                    bool boolExists = false;
                    try
                    {
                        bool t = boolVariables[args.Replace(" ","")];
                        boolExists = true;
                    }
                    catch(KeyNotFoundException e)
                    {

                    }
                    bool intExists = false;
                    bool floatExists = false;
                    try
                    {
                        int t = intVariables[args.Replace(" ", "")];
                        intExists = true;
                    }
                    catch (KeyNotFoundException e)
                    {

                    }
                    try
                    {
                        float t = intVariables[args.Replace(" ", "")];
                        floatExists = true;
                    }
                    catch (KeyNotFoundException e)
                    {

                    }
                    if (!value && !args.Contains("false") && !boolExists && getFloatExpressionValue(args) != 0 || (intExists || floatExists))
                    {
                        //arg = getIntExpressionValue(args).ToString();
                        //if(arg == "0" || args.Contains(".") || getIntExpressionValue(args).ToString() != getFloatExpressionValue(args).ToString())
                        arg = getFloatExpressionValue(args).ToString();
                    }
                    else
                    {
                        arg = value ? "richtig" : "falsch";
                    } 
                }
                console.Text += arg;
                return true;
            }
            else if (keyword == "neuezeile")
            {
                console.Text += "\r\n";
                return true;
            }
            else if (keyword == "schlafen")
            {
                console.Text += "\r\nfinished executing successfully";
                return false;
            }
            else if (keyword == "schnur")
            {
                String arg = args;
                while (arg.StartsWith(" "))
                {
                    arg = arg.Remove(0, 1);
                }
                if (!arg.Contains("="))
                {
                    stringVariables.Add(arg, "");
                    return true;
                }
                else
                {
                    String name = arg.Split('=')[0];
                    name = name.Replace(" ", "");
                    String value = getStringExpressionValue(arg.Split('=')[1]);
                    stringVariables.Add(name, value);
                }
                return true;
            }
            else if (keyword == "zweiteilig")
            {
                String arg = args;
                while (arg.StartsWith(" "))
                {
                    arg = arg.Remove(0, 1);
                }
                if (!arg.Contains("="))
                {
                    boolVariables.Add(arg, false);
                    return true;
                }
                else
                {
                    String name = arg.Split('=')[0];
                    name = name.Replace(" ", "");
                    bool value = getBoolExpressionValue(arg.Split('=')[1]);
                    boolVariables.Add(name, value);
                }
                return true;
            }
            else if (keyword == "ganzzahl")
            {
                String arg = args;
                while (arg.StartsWith(" "))
                {
                    arg = arg.Remove(0, 1);
                }
                if (!arg.Contains("="))
                {
                    intVariables.Add(arg, 0);
                    return true;
                }
                else
                {
                    String name = arg.Split('=')[0];
                    name = name.Replace(" ", "");
                    int value = getIntExpressionValue(arg.Split('=')[1]);
                    intVariables.Add(name, value);
                }
                return true;
            }
            else if (keyword == "flieskommazahl")
            {
                String arg = args;
                while (arg.StartsWith(" "))
                {
                    arg = arg.Remove(0, 1);
                }
                if (!arg.Contains("="))
                {
                    floatVariables.Add(arg, 0);
                    return true;
                }
                else
                {
                    String name = arg.Split('=')[0];
                    name = name.Replace(" ", "");
                    float value = getFloatExpressionValue(arg.Split('=')[1]);
                    floatVariables.Add(name, value);
                }
                return true;
            }
            else if (keyword == "aufklaren")
            {
                console.Text = "";
                return true;
            }
            else if (keyword == "eingangspfad")
            {
                String arg = args;
                while (arg.StartsWith(" ") || arg.StartsWith("\t") || arg.StartsWith("\n") || arg.StartsWith("\r"))
                {
                    arg = arg.Remove(0, 1);
                }
                inputFile = getStringExpressionValue(arg);
                inputFileContents = File.ReadAllLines(inputFile);
                inputLine = 0;
                return true;
            }
            else if (keyword == "eingang")
            {
                String arg = args;
                while (arg.StartsWith(" ") || arg.StartsWith("\t") || arg.StartsWith("\n") || arg.StartsWith("\r"))
                {
                    arg = arg.Remove(0, 1);
                }

                try
                {
                    String t = stringVariables[arg];
                    stringVariables[arg] = inputFileContents[inputLine++];
                    return true;
                }
                catch (IndexOutOfRangeException e)
                {

                }
                catch (KeyNotFoundException e)
                {

                }

                try
                {
                    bool t = boolVariables[arg];
                    boolVariables[arg] = getBoolExpressionValue(inputFileContents[inputLine++]);
                    return true;
                }
                catch (IndexOutOfRangeException e)
                {

                }
                catch (KeyNotFoundException e)
                {

                }

                try
                {
                    int t = intVariables[arg];
                    intVariables[arg] = getIntExpressionValue(inputFileContents[inputLine++]);
                    return true;
                }
                catch (IndexOutOfRangeException e)
                {

                }
                catch (KeyNotFoundException e)
                {

                }

                try
                {
                    float t = floatVariables[arg];
                    floatVariables[arg] = getFloatExpressionValue(inputFileContents[inputLine++]);
                    return true;
                }
                catch (IndexOutOfRangeException e)
                {

                }
                catch (KeyNotFoundException e)
                {

                }
                return true;
            }
            else if(keyword == "wenn")
            {
                while (args.StartsWith(" "))
                {
                    args = args.Remove(0, 1);
                }
                bool condition = getBoolExpressionValue(args.Split(':')[0]);
                int index = args.LastIndexOf(',');
                if (index == -1)
                    index = args.Length - 1;
                int colonIndex = args.IndexOf(':');
                String code = args.Substring(0, index + 1);
                code = code.Remove(0, colonIndex + 1);
                String lastLine = args.Substring(index + 1);
                String[] lines = code.Split(',');

                if (condition)
                {
                    for(int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i].Contains(":"))
                        {
                            String currentLine = lines[i];

                            try
                            {
                                while (Regex.Matches(lines[i + 1], "\t").Count > 1)
                                {
                                    currentLine += "," + lines[++i];
                                }
                            }
                            catch(IndexOutOfRangeException e)
                            {

                            }
                            //console.Text += currentLine + "\n\r\n\r\n\r\n\r";
                            try
                            {
                                String[] l = currentLine.Split(',');
                                int spaceIndex = l[0].Split(':')[0].IndexOf(" ");
                                if (l[0].Contains("solange"))
                                {
                                    l[0] = l[0].Split(':')[1];
                                    //bool lCondition = getBoolExpressionValue(l[0].Split(':')[0].Substring(spaceIndex + 1));
                                    while (getBoolExpressionValue(l[0].Split(':')[0].Substring(spaceIndex + 1)))
                                    {
                                        foreach (String line in l)
                                        {
                                            executeLine(line.Split(' ')[0], line.Remove(0, line.Split(' ')[0].Length));
                                        }
                                    }
                                }
                                else
                                {
                                    bool lCondition = getBoolExpressionValue(l[0].Split(':')[0].Substring(spaceIndex + 1));
                                    if (lCondition)
                                    {
                                        foreach (String line in l)
                                        {
                                            executeLine(line.Split(' ')[0], line.Remove(0, line.Split(' ')[0].Length));
                                        }
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                executeLine(currentLine.Split(' ')[0], currentLine.Remove(0, currentLine.Split(' ')[0].Length));
                            }
                            
                        }
                        else
                        {
                            if(lines[i].Split(' ')[0].Length>1)
                                executeLine(lines[i].Split(' ')[0], lines[i].Remove(0, lines[i].Split(' ')[0].Length));
                        }
                    }
                }

                if(lastLine.Length > 1)
                    executeLine(lastLine.Split(' ')[0], lastLine.Remove(0, lastLine.Split(' ')[0].Length));
                return true;
            }
            else if (keyword == "solange")
            {
                while (args.StartsWith(" "))
                {
                    args = args.Remove(0, 1);
                }
                //bool condition = getBoolExpressionValue(args.Split(':')[0]);
                int index = args.LastIndexOf(',');
                if (index == -1)
                    index = args.Length - 1;
                int colonIndex = args.IndexOf(':');
                String code = args.Substring(0, index + 1);
                code = code.Remove(0, colonIndex + 1);
                String lastLine = args.Substring(index + 1);
                String[] lines = code.Split(',');

                while (getBoolExpressionValue(args.Split(':')[0]))
                {
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i].Contains(":"))
                        {
                            String currentLine = lines[i];

                            try
                            {
                                while (Regex.Matches(lines[i + 1], "\t").Count > 1)
                                {
                                    currentLine += "," + lines[++i];
                                }
                            }
                            catch (IndexOutOfRangeException e)
                            {

                            }
                            //console.Text += currentLine + "\n\r\n\r\n\r\n\r";
                            try
                            {
                                String[] l = currentLine.Split(',');
                                int spaceIndex = l[0].Split(':')[0].IndexOf(" ");
                                if (l[0].Contains("solange"))
                                {
                                    l[0] = l[0].Split(':')[1];
                                    //bool lCondition = getBoolExpressionValue(l[0].Split(':')[0].Substring(spaceIndex + 1));
                                    while (getBoolExpressionValue(l[0].Split(':')[0].Substring(spaceIndex + 1)))
                                    {
                                        foreach (String line in l)
                                        {
                                            executeLine(line.Split(' ')[0], line.Remove(0, line.Split(' ')[0].Length));
                                        }
                                    }
                                }
                                else
                                {
                                    bool lCondition = getBoolExpressionValue(l[0].Split(':')[0].Substring(spaceIndex + 1));
                                    if (lCondition)
                                    {
                                        foreach (String line in l)
                                        {
                                            executeLine(line.Split(' ')[0], line.Remove(0, line.Split(' ')[0].Length));
                                        }
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                executeLine(currentLine.Split(' ')[0], currentLine.Remove(0, currentLine.Split(' ')[0].Length));
                            }

                        }
                        else
                        {
                            if (lines[i].Split(' ')[0].Length > 1)
                                executeLine(lines[i].Split(' ')[0], lines[i].Remove(0, lines[i].Split(' ')[0].Length));
                        }
                    }
                }

                if (lastLine.Length > 1)
                    executeLine(lastLine.Split(' ')[0], lastLine.Remove(0, lastLine.Split(' ')[0].Length));
                return true;
            }
            else
            {
                try
                {
                    String t = stringVariables[keyword];
                    String largs = args;
                    while (largs.StartsWith(" ") || largs.StartsWith("="))
                    {
                        largs = largs.Remove(0, 1);
                    }
                    stringVariables[keyword] = getStringExpressionValue(largs);
                    return true;
                }
                catch (KeyNotFoundException e)
                {

                }

                try
                {
                    bool t = boolVariables[keyword];
                    String largs = args;
                    while (largs.StartsWith(" ") || largs.StartsWith("="))
                    {
                        largs = largs.Remove(0, 1);
                    }
                    boolVariables[keyword] = getBoolExpressionValue(largs);
                    return true;
                }
                catch (KeyNotFoundException e)
                {

                }

                try
                {
                    int t = intVariables[keyword];
                    String largs = args;
                    while (largs.StartsWith(" ") || largs.StartsWith("="))
                    {
                        largs = largs.Remove(0, 1);
                    }
                    intVariables[keyword] = getIntExpressionValue(largs);

                    if (intVariables[keyword] == 0)
                    {
                        intVariables[keyword] = Convert.ToInt32(getFloatExpressionValue(largs));
                    }
                    return true;
                }
                catch (KeyNotFoundException e)
                {

                }

                try
                {
                    float t = floatVariables[keyword];
                    String largs = args;
                    while (largs.StartsWith(" ") || largs.StartsWith("="))
                    {
                        largs = largs.Remove(0, 1);
                    }
                    floatVariables[keyword] = getFloatExpressionValue(largs);
                    if(floatVariables[keyword] == 0)
                    {
                        floatVariables[keyword] = getIntExpressionValue(largs);
                    }
                    return true;
                }
                catch (KeyNotFoundException e)
                {

                }
            }
            console.Text += "\r\n" + keyword + " is not a valid keyword\r\n";
            return false;
        }

        String getStringExpressionValue(String expression)
        {
            if (expression.Contains("+"))
            {
                String[] splits = expression.Split('+');
                String final = "";
                foreach(String split in splits)
                {
                    final += getStringExpressionValue(split);
                }
                return final;
            }
            if (expression.Contains("\""))
            {
                while (expression.StartsWith(" "))
                {
                    expression = expression.Remove(0, 1);
                }
                while (expression.EndsWith(" "))
                {
                    expression = expression.Remove(expression.Length-1, 1);
                }
                return expression.Replace("\"", "");
            }
            else
            {
                String variableValue = "";
                try
                {
                    expression = expression.Replace("\n", "").Replace("\r", "").Replace(" ", "");
                    variableValue = stringVariables[expression];
                }
                catch (KeyNotFoundException e)
                {

                }
                return variableValue;
            }
        }

        bool getBoolExpressionValue(String expression)
        {
            if (expression.Contains(">"))
            {
                String[] operands = Regex.Split(expression, ">");
                float floatValue = getFloatExpressionValue(operands[0]);
                foreach(String operand in operands)
                {
                    if(getFloatExpressionValue(operand) < floatValue)
                    {
                        return true;
                    }
                }
                return false;
            }
            if (expression.Contains("<"))
            {
                String[] operands = Regex.Split(expression, "<");
                float floatValue = getFloatExpressionValue(operands[0]);
                foreach (String operand in operands)
                {
                    if (getFloatExpressionValue(operand) > floatValue)
                    {
                        return true;
                    }
                }
                return false;
            }
            if (expression.Contains(" ist nicht "))
            {
                String[] operands = Regex.Split(expression, " ist nicht ");
                bool boolValue = getBoolExpressionValue(operands[0]);
                string stringValue = getStringExpressionValue(operands[0]);
                float floatValue = getFloatExpressionValue(operands[0]);

                if (boolValue || stringValue == "falsch")
                {
                    foreach (String operand in operands)
                    {
                        if (getBoolExpressionValue(operand) != boolValue)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                if (stringValue != "")
                {
                    foreach (String operand in operands)
                    {
                        if (getStringExpressionValue(operand) != stringValue)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                foreach (String operand in operands)
                {
                    if (getFloatExpressionValue(operand) != floatValue)
                    {
                        return true;
                    }
                }
                return false;
            }
            if (expression.Contains(" ist "))
            {
                String[] operands = Regex.Split(expression," ist ");
                bool boolValue = getBoolExpressionValue(operands[0]);
                string stringValue = getStringExpressionValue(operands[0]);
                float floatValue = getFloatExpressionValue(operands[0]);
                if(boolValue || stringValue == "falsch")
                {
                    foreach (String operand in operands)
                    {
                        if (getBoolExpressionValue(operand) != boolValue)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                if (stringValue != "")
                {
                    foreach (String operand in operands)
                    {
                        if (getStringExpressionValue(operand) != stringValue)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                foreach (String operand in operands)
                {
                    if (getFloatExpressionValue(operand) != floatValue)
                    {
                        return false;
                    }
                }
                return true;
            }
            expression = expression.Replace(" ", "");
            if (expression == "richtig")
            {
                return true;
            }
            else if (expression == "falsch")
            {
                return false;
            }
            else
            {
                bool variableValue = false;
                try
                {
                    expression = expression.Replace("\n", "").Replace("\r", "").Replace(" ", "");
                    variableValue = boolVariables[expression];
                }
                catch (KeyNotFoundException e)
                {

                }
                return variableValue;
            }
        }

        int getIntExpressionValue(String expression)
        {
            expression = expression.Replace(" ", "");
            if (expression.Contains("+"))
            {
                String[] splits = expression.Split('+');
                int final = 0;
                foreach (String split in splits)
                {
                    final += getIntExpressionValue(split);
                }
                return final;
            }
            if (expression.Contains("-"))
            {
                String[] splits = expression.Split('-');
                int final = 0;
                bool firstExpression = true;
                foreach (String split in splits)
                {
                    if (firstExpression)
                    {
                        final += getIntExpressionValue(split);
                        firstExpression = false;
                    }
                    else
                    {
                        final -= getIntExpressionValue(split);
                    }
                }
                return final;
            }
            if (expression.Contains("*"))
            {
                String[] splits = expression.Split('*');
                int final = 1;
                foreach (String split in splits)
                {
                    final *= getIntExpressionValue(split);
                }
                return final;
            }
            if (expression.Contains("/"))
            {
                String[] splits = expression.Split('/');
                int final = 0;
                bool firstExpression = true;
                foreach (String split in splits)
                {
                    if (firstExpression)
                    {
                        final = getIntExpressionValue(split);
                        firstExpression = false;
                    }
                    else
                    {
                        final /= getIntExpressionValue(split);
                    }
                }
                return final;
            }
            if (expression.Contains("%"))
            {
                String[] splits = expression.Split('%');
                int final = 0;
                bool firstExpression = true;
                foreach (String split in splits)
                {
                    if (firstExpression)
                    {
                        final = getIntExpressionValue(split);
                        firstExpression = false;
                    }
                    else
                    {
                        final %= getIntExpressionValue(split);
                    }
                }
                return final;
            }
            try
            {
                return intVariables[expression];
            }
            catch(KeyNotFoundException e)
            {

            }
            try
            {
                return Convert.ToInt32(floatVariables[expression]);
            }
            catch (KeyNotFoundException e)
            {

            }
            expression = Regex.Replace(expression, "[^0-9]", "");
            if (expression == "")
                return 0;
            return Int32.Parse(expression);
        }
        float getFloatExpressionValue(String expression)
        {
            expression = expression.Replace(" ", "");
            if (expression.Contains("+"))
            {
                String[] splits = expression.Split('+');
                float final = 0;
                foreach (String split in splits)
                {
                    final += getFloatExpressionValue(split);
                }
                return final;
            }
            if (expression.Contains("-"))
            {
                String[] splits = expression.Split('-');
                float final = 0;
                bool firstExpression = true;
                foreach (String split in splits)
                {
                    if (firstExpression)
                    {
                        final += getFloatExpressionValue(split);
                        firstExpression = false;
                    }
                    else
                    {
                        final -= getFloatExpressionValue(split);
                    }
                }
                return final;
            }
            if (expression.Contains("*"))
            {
                String[] splits = expression.Split('*');
                float final = 1;
                foreach (String split in splits)
                {
                    final *= getFloatExpressionValue(split);
                }
                return final;
            }
            if (expression.Contains("/"))
            {
                String[] splits = expression.Split('/');
                float final = 0;
                bool firstExpression = true;
                foreach (String split in splits)
                {
                    if (firstExpression)
                    {
                        final = getFloatExpressionValue(split);
                        firstExpression = false;
                    }
                    else
                    {
                        final /= getFloatExpressionValue(split);
                    }
                }
                return final;
            }
            try
            {
                return floatVariables[expression];
            }
            catch (KeyNotFoundException e)
            {

            }
            try
            {
                return intVariables[expression];
            }
            catch (KeyNotFoundException e)
            {

            }
            expression = Regex.Replace(expression, @"^*[^0-9\.]+$", "");
            if (expression == "")
                return 0;
            try
            {
                return float.Parse(expression);
            }
            catch (FormatException e)
            {
                return getIntExpressionValue(expression);
            }
        }
        private void runPictureBox_Click(object sender, EventArgs e)
        {
            console.Text = "";
            stringVariables.Clear();
            boolVariables.Clear();
            intVariables.Clear();
            floatVariables.Clear();
            String code = input.Text;
            while (code.Contains("  "))
            {
                code = code.Replace("  ", " ");
            }

            String[] lines = code.Split(new char[] { ';' });

            foreach (String line in lines)
            {
                String currentLine = line;
                while (currentLine.StartsWith(" ") || currentLine.StartsWith("\t") || currentLine.StartsWith("\n"))
                {
                    currentLine = currentLine.Remove(0, 1);
                }

                if (currentLine.Contains("//")) {
                    currentLine = Regex.Split(currentLine, "//")[0];
                }
                if (currentLine.Length > 1)
                {
                    String keyword = currentLine.Split(' ')[0];
                    if (keyword.Contains("="))
                    {
                        keyword = keyword.Split('=')[0];
                    }
                    String args = currentLine.Remove(0, keyword.Length);

                    bool success = executeLine(keyword, args);

                    if (!success)
                    {
                        if (!keyword.Contains("schlafen"))
                            console.Text += "error was thrown at line: " + line;
                        break;
                    }
                }
            }
        }

        bool fDown = false;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F1)
            {
                helpForm = new Form();
                helpForm.Text = "Help";
                Label helpText = new Label();
                helpText.Text = "keywords:\n\r    schreiben - print\n\r    neuezeile - new line\n\r    schlafen - quit\n\r    schnur - string\n\r    zweiteilig - bool\n\r    ganzzahl - int\n\r    flieskommazahl - float\n\r    aufklaren - clear\n\r    eingang - read from file\n\r    eingangspfad - set input file path\n\r    richtig - true\n\r    falsch - false\n\r    wenn - if\n\r    solange - while\n\r\n\roperators:\n\r    ist - ==\n\r    ist nicht - !=\n\r    =\n\r    +\n\r    -\n\r    *\n\r    /\n\r    %\n\r    >\n\r    <\n\r    ";
                helpText.AutoSize = true;
                helpForm.Width = 200;
                helpForm.Height = 400;

                helpForm.Controls.Add(helpText);
                helpForm.Show();
            }

            if(e.KeyCode == Keys.F)
            {
                fDown = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F)
            {
                fDown = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int s_start = input.SelectionStart;
            input.SelectAll();
            input.SelectionColor = Color.Black;
            input.SelectionStart = s_start;
            input.SelectionLength = 0;

            HighlightText(input, "schreiben ", Color.Green);
            HighlightText(input, "neuezeile", Color.Green);
            HighlightText(input, "schlafen", Color.Green);
            HighlightText(input, "schnur ", Color.Blue);
            HighlightText(input, "zweiteilig ", Color.Blue);
            HighlightText(input, "ganzzahl ", Color.Blue);
            HighlightText(input, "flieskommazahl ", Color.Blue);
            HighlightText(input, "aufklaren", Color.Green);
            HighlightText(input, "eingang ", Color.Green);
            HighlightText(input, "eingangspfad ", Color.Green);
            HighlightText(input, "richtig", Color.Blue);
            HighlightText(input, "falsch", Color.Blue);
            HighlightText(input, "wenn ", Color.Green);
            HighlightText(input, "solange ", Color.Green);
            HighlightText(input, " ist ", Color.Green);
            HighlightText(input, " ist nicht ", Color.Green);
            HighlightText(input, "1", Color.DarkOrange);
            HighlightText(input, "2", Color.DarkOrange);
            HighlightText(input, "3", Color.DarkOrange);
            HighlightText(input, "4", Color.DarkOrange);
            HighlightText(input, "5", Color.DarkOrange);
            HighlightText(input, "6", Color.DarkOrange);
            HighlightText(input, "7", Color.DarkOrange);
            HighlightText(input, "8", Color.DarkOrange);
            HighlightText(input, "9", Color.DarkOrange);
            HighlightText(input, "0", Color.DarkOrange);
        }

        private void input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                helpForm = new Form();
                helpForm.Text = "Help";
                Label helpText = new Label();
                helpText.Text = "keywords:\n\r    schreiben - print\n\r    neuezeile - new line\n\r    schlafen - quit\n\r    schnur - string\n\r    zweiteilig - bool\n\r    ganzzahl - int\n\r    flieskommazahl - float\n\r    aufklaren - clear\n\r    eingang - read from file\n\r    eingangspfad - set input file path\n\r    richtig - true\n\r    falsch - false\n\r    wenn - if\n\r    solange - while\n\r\n\roperators:\n\r    ist - ==\n\r    ist nicht - !=\n\r    =\n\r    +\n\r    -\n\r    *\n\r    /\n\r    %\n\r    >\n\r    <\n\r    ";
                helpText.AutoSize = true;
                helpForm.Width = 200;
                helpForm.Height = 400;

                helpForm.Controls.Add(helpText);
                helpForm.Show();
            }

            if (e.KeyCode == Keys.F)
            {
                fDown = true;
            }
        }

        private void input_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F)
            {
                fDown = false;
            }
        }

        List<int> AllIndexesOf(string str, string value)
        {
            if (String.IsNullOrEmpty(value))
                return new List<int>();
            List<int> indexes = new List<int>();
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }

        int currentIndex = 0;

        private void searchButton_Click(object sender, EventArgs e)
        {
            List<int> indexList = AllIndexesOf(input.Text, searchTextBox.Text);
            try
            {
                input.SelectionStart = indexList[currentIndex++];
                input.SelectionLength = searchTextBox.Text.Length;
            }
            catch(ArgumentOutOfRangeException ex)
            {
                currentIndex = 0;
            }
            try
            {
                input.SelectionStart = indexList[currentIndex++];
                input.SelectionLength = searchTextBox.Text.Length;
            }
            catch (ArgumentOutOfRangeException ex)
            {

            }
            input.Focus();
        }

        private void replaceButton_Click(object sender, EventArgs e)
        {
            input.Text = input.Text.Replace(searchTextBox.Text, replaceTextBox.Text);
        }
    }
}
