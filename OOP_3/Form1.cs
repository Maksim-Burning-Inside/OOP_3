using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_3
{
    public partial class Form1 : Form
    {
        static public CurrencyRates _tmp = new CurrencyRates();

        private Translator _translator = new Translator(new Purse(_tmp, 10, 10, 10, 10));

        public Form1()
        {
            InitializeComponent();
        }

        private void CountRubles()
        {
            List<ListViewItem> valute_info = _translator.GetListViewItems_Valute();
            double sum = 0;

            for (int i = 0; i < valute_info.Count; i++)
            {
                sum += ((Dictionary<string, double>)valute_info[i].Tag)["rubles"];
            }
            label8.Text = sum.ToString() + " руб.";
        }

        private void FillItems()
        {
            List<ListViewItem> valute_info = _translator.GetListViewItems_Valute();
            listView1.Items.Clear();

            foreach (ListViewItem item in valute_info)
            {
                listView1.Items.Add(item);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                FillItems();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Ошибка соеденения с сервером");
            }

            CountRubles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _translator.GetListViewItems_RandomValute();
            FillItems();
            CountRubles();

            label3.Text = "...";
            label4.Text = "...";
            label7.Text = "...";
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Dictionary<string, double> item = (Dictionary<string, double>)e.Item.Tag;
            label3.Text = item["state"].ToString();
            label4.Text = item["shallow state"].ToString();
            label7.Text = item["rubles"].ToString();
        }
    }
}
