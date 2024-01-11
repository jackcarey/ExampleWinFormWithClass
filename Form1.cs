namespace ExampleWinFormWithClass
{
    public partial class Form1 : Form
    {
        public class Formula1Car
        {
            public string model;
            public string teamName;
            public int year;
            public int horsePower;
            public string color;
            public string description;
            public Formula1Car(string model,string teamName,int year,int horsePower,string color,string description)
            {
                this.model = model;
                this.teamName = teamName;
                this.year = year;
                this.horsePower = horsePower;
                this.color = color;
                this.description = description;
            }
        }

        public Formula1Car[] cars = new Formula1Car[100];

        public Form1()
        {
            InitializeComponent();
            PopulateCarList();
            PopulateYears();
            UpdateListBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Intentionally do nothing here. Is this the design choice you prefer? What work could happen here?
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        public void UpdateListBox()
        {
            listBox1.Items.Clear();
            string searchValue = textBox1.Text.ToLower();
            int yearIndex = comboBox1.SelectedIndex;
            Int32.TryParse(comboBox1.Text, out int yearValue);
            Formula1Car[] results = cars.Where<Formula1Car>(
                c => c!=null && (
                c.year == yearIndex ||
                c.model.ToLower().Contains(searchValue) ||
                c.teamName.ToLower().Contains(searchValue) ||
                c.color.ToLower().Contains(searchValue) ||
                c.description.ToLower().Contains(searchValue)
                )).ToArray();
            listBox1.Items.Clear();
            foreach ( Formula1Car c in results)
            {
                listBox1.Items.Add(c.teamName + " " + c.model + ", " + c.color + ": " + c.description);
            }
        }

        public void PopulateCarList()
        {
            cars[0] = new Formula1Car("M2B", "McLaren", 1966, 300, "white", "driven by Bruce McLaren");
            cars[1] = new Formula1Car("MCL60", "McLaren", 2023, 740, "papaya", "driven by Lando Norris");
            cars[2] = new Formula1Car("RB1", "Red Bull", 2005, 915, "blue/red", "driven by by David Coulthard");
            cars[3] = new Formula1Car("RB19", "Reb Bull", 2023, 1080, "blue/red", "driven by Max Verstappen");
        }
        public void PopulateYears()
        {
            comboBox1.Items.Insert(0, "Select a year...");
            int thisYear = DateTime.Today.Year;
            int startYear = 1950;
            while (startYear <= thisYear)
            {
                comboBox1.Items.Add(startYear);
                startYear++;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
