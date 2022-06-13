namespace Multiple_Folder_Selection
{
    public partial class Form1 : Form
    {
        List<string> _items = new List<string>();
        Point _point = new Point(-1, -1);
        int resX = -1;
        int resY = -1;
        string[] dirs;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog x = new FolderBrowserDialog();
            x.Description = "Select the FIRST folder. Note: make sure you are sorting the files by name";
            x.ShowDialog();
            if (x.SelectedPath != "")
            {
                string[] folderName = x.SelectedPath.Split("\\");
                int len = folderName.Length;

                string parentAddy = x.SelectedPath.Substring(0, x.SelectedPath.IndexOf(folderName[len - 1]));

                dirs = Directory.GetDirectories(parentAddy);

                for (int i = 0; i < dirs.Length; i++)
                {
                    resX = dirs[i].IndexOf(folderName[len - 1]);
                    if (resX != -1)
                    {
                        _point.X = i;

                        textBox1.Text = folderName[len - 1];

                        break;
                    }
                    _point.X = -1;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog x = new FolderBrowserDialog();
            x.Description = "Select the LAST folder. Note: make sure you are sorting the files by name";
            x.ShowDialog();
            if (x.SelectedPath != "")
            {
                string[] folderName = x.SelectedPath.Split("\\");
                int len = folderName.Length;

                string parentAddy = x.SelectedPath.Substring(0, x.SelectedPath.IndexOf(folderName[len - 1]));

                dirs = Directory.GetDirectories(parentAddy);

                for (int i = 0; i < dirs.Length; i++)
                {
                    resY = dirs[i].IndexOf(folderName[len - 1]);
                    if (resY != -1)
                    {
                        _point.Y = i;
                        textBox2.Text = folderName[len - 1];

                        break;
                    }
                    _point.Y = -1;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((_point.X != -1) & (_point.Y != -1))
                for (int i = _point.X; i <= _point.Y; i++)
                {
                    _items.Add(dirs[i]); // <-- Any string you want
                    listBox1.DataSource = null;
                    listBox1.DataSource = _items;
                }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog x = new FolderBrowserDialog();
            x.Description = "Select a folder";
            x.ShowDialog();
            _items.Add(x.SelectedPath); // <-- Any string you want
            listBox1.DataSource = null;
            listBox1.DataSource = _items;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _items.Clear(); // <-- Any string you want
            listBox1.DataSource = null;
            listBox1.DataSource = _items;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string[] res = _items.ToArray();
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}