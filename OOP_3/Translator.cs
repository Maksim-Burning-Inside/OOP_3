using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_3
{
    class Translator
    {
        private Purse _purse;

        public Translator(Purse purse)
        {
            _purse = purse;
        }

        public List<ListViewItem> GetListViewItems_Valute()
        {
            List<ListViewItem> listViewItems = new List<ListViewItem>();

            Dictionary<string, Dictionary<string, double>> valute_info = CreateVaiuteInfo();
            for (int i = 0; i < _purse.NUM_VALUTE; i++)
            {
                listViewItems.Add(new ListViewItem(_purse.GetCurrentCode(i)));
                listViewItems[listViewItems.Count - 1].Tag = valute_info[_purse.GetCurrentCode(i)];
            }

            return listViewItems;
        }

        public void GetListViewItems_RandomValute()
        {
            _purse.FillRandom();
        }

        private Dictionary<string, Dictionary<string, double>> CreateVaiuteInfo()
        {
            Dictionary<string, Dictionary<string, double>> valute_info = new Dictionary<string, Dictionary<string, double>>();

            for (int i = 0; i < _purse.NUM_VALUTE; i++)
            {
                valute_info.Add(_purse.GetCurrentCode(i), new Dictionary<string, double> { { "state", _purse.ReturnStateValute()[_purse.GetCurrentCode(i)] }, { "shallow state", _purse.CrushMoney()[_purse.GetCurrentCode(i)] }, { "rubles", _purse.ReturnThisRubles(i) } });
            }

            return valute_info;
        }
    }
}
