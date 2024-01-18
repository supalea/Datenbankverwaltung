namespace Datenbankverwaltung
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("Name", 300);
            listView1.Columns.Add("Größe", 100);
            listView1.Columns.Add("Typ", 100);
            listView1.Columns.Add("Geändert am", 200);

            string verz = "C:/Temp";
            if (Directory.Exists(verz))
                Directory.SetCurrentDirectory(verz);
            else
                MessageBox.Show($"Verzeichnis {verz} existiert nicht");

            string verzeichnis = Directory.GetCurrentDirectory();
            label1.Text = verzeichnis;



            string[] liste = Directory.GetFileSystemEntries(verz);

            foreach (string file in liste)
            {

                ImageList bildList = new();

                if (File.Exists(file))
                {
                    FileInfo fileInfo = new FileInfo(file);
                    string name = fileInfo.Name;
                    string size = Convert.ToString(fileInfo.Length);
                    string typ = "Datei";
                    string last = Convert.ToString(fileInfo.LastWriteTime);

                    ListViewItem eins = new(name);
                    eins.SubItems.Add(size);
                    eins.SubItems.Add(typ);
                    eins.SubItems.Add(last);
                    eins.ImageIndex = 0;
                    listView1.Items.Add(eins);
                    bildList.Images.Add(Image.FromFile("File.gif"));
                    listView1.SmallImageList = bildList;
                }
                else if (Directory.Exists(file))
                {

                    DirectoryInfo Info = new DirectoryInfo(file);
                    string name = Info.Name;
                    string typ = "Ordner";
                    string last = Convert.ToString(Info.LastWriteTime);

                    ListViewItem eins = new(name);
                    eins.SubItems.Add("");
                    eins.SubItems.Add(typ);
                    eins.SubItems.Add(last);
                    eins.ImageIndex = 1;
                    listView1.Items.Add(eins);
                    bildList.Images.Add(Image.FromFile("Folder.gif"));
                    listView1.SmallImageList = bildList;
                }
            }
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            string select = "";

            foreach (ListViewItem item in listView1.SelectedItems)
            {
                select += item.Text + "\n";
            }

            label2.Text = select;

        }
    }
}
