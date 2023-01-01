using System.Data;

namespace Note_app
{
    public partial class Form1 : Form
    {

        DataTable table;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("Title", typeof(string));
             table.Columns.Add("Message", typeof(string));  

            dataGridView1.DataSource = table;


            dataGridView1.Columns["Message"].Visible = false;
            dataGridView1.Columns["Title"].Width = 183;
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            richTextBox1.Clear();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            table.Rows.Add(textBox1.Text, richTextBox1.Text);

            textBox1.Clear();
            richTextBox1.Clear();
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            try 
                {
                int index = dataGridView1.CurrentCell.RowIndex;

                if (index > -1)
                {
                    textBox1.Text = table.Rows[index].ItemArray[0].ToString();
                    richTextBox1.Text = table.Rows[index].ItemArray[1].ToString();
                }


            }
            catch(NullReferenceException ev1) 
            {
                Console.WriteLine(ev1.ToString());
            }
            
            
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                table.Rows[index].Delete();

            }
            catch (NullReferenceException ev2)
            {
                Console.WriteLine(ev2.ToString());
            }
        }
    }
}