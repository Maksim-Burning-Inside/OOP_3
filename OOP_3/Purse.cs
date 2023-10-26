using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    class Purse
    {
        private IСurrency[] _money;

        public Purse(CurrencyRates currencyRates, double dollar = 0, double euro = 0, double pound = 0, double xdr = 0)
        {
            _money = new IСurrency[4] { new Dollar(currencyRates, dollar), new Euro(currencyRates, euro), new Pound(currencyRates, pound), new SpecialDrawingRights(currencyRates, xdr) };
        }

        public double ReturnAllRubles()
        {
            double sum = 0;
            for (int i = 0; i < _money.Length; i++)
            {
                sum += _money[i].TranslateRubs();
            }
            return sum;
        }

        public double ReturnThisRubles(int i)
        {
            return _money[i].TranslateRubs();
        }

        public void FillRandom()
        {
            for (int i = 0; i < _money.Length; i++)
            {
                _money[i].Spawn_RandomAmount();
            }
        }

        public Dictionary<string, double> CrushMoney()
        {
            Dictionary<string, double> shallow_valute = new Dictionary<string, double>();
            for (int i = 0; i < _money.Length; i++)
            {
                shallow_valute.Add(_money[i].CODE, _money[i].CrushCurrency);
            }
            return shallow_valute;
        }

        public Dictionary<string, double> ReturnStateValute()
        {
            Dictionary<string, double> valute = new Dictionary<string, double>();
            for (int i = 0; i < _money.Length; i++)
            {
                valute.Add(_money[i].CODE, _money[i].STATE);
            }
            return valute;
        }

        public int NUM_VALUTE
        {
            get
            {
                return _money.Length;
            }
        }

        public string GetCurrentCode(int i)
        {
            return _money[i].CODE;
        }
    }
}
