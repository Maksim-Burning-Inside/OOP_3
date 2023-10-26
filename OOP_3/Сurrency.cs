using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    class Dollar : IСurrency
    {
        private string _string_code = "USD";
        private CurrencyRates _currencyRates;
        private double _state_account;

        public Dollar(CurrencyRates currencyRates, double state_account)
        {
            _currencyRates = currencyRates;
            _state_account = state_account;
        }

        public double TranslateRubs()
        {
            List<CurrencyRate> exchange_rates = _currencyRates.VALUTE_INFO;
            CurrencyRate dollar_info = exchange_rates.FindLast(item => item.CurrencyStringCode == _string_code);

            return (_state_account / dollar_info.Nominal) * dollar_info.ExchangeRate;
        }
        public double Spawn_RandomAmount()
        {
            Random R = new Random();
            _state_account = (double)R.Next(0, 100001) / (double)100;

            return TranslateRubs();
        }

        public double CrushCurrency
        {
            get
            {
                return 100 * _state_account;
            }
        }

        public string CODE
        {
            get
            {
                return _string_code;
            }
        }

        public double STATE
        {
            get
            {
                return _state_account;
            }
        }
    }

    class Euro : IСurrency
    {
        private string _string_code = "EUR";
        private CurrencyRates _currencyRates;
        private double _state_account;

        public Euro(CurrencyRates currencyRates, double state_account)
        {
            _currencyRates = currencyRates;
            _state_account = state_account;
        }

        public double TranslateRubs()
        {
            List<CurrencyRate> exchange_rates = _currencyRates.VALUTE_INFO;
            CurrencyRate dollar_info = exchange_rates.FindLast(item => item.CurrencyStringCode == _string_code);

            return (_state_account / dollar_info.Nominal) * dollar_info.ExchangeRate;
        }
        public double Spawn_RandomAmount()
        {
            Random R = new Random();
            _state_account = (double)R.Next(0, 700001) / (double)500;

            return TranslateRubs();
        }

        public double CrushCurrency
        {
            get
            {
                return 100 * _state_account;
            }
        }

        public string CODE
        {
            get
            {
                return _string_code;
            }
        }

        public double STATE
        {
            get
            {
                return _state_account;
            }
        }
    }

    class Pound : IСurrency
    {
        private string _string_code = "GBP";
        private CurrencyRates _currencyRates;
        private double _state_account;

        public Pound(CurrencyRates currencyRates, double state_account)
        {
            _currencyRates = currencyRates;
            _state_account = state_account;
        }

        public double TranslateRubs()
        {
            List<CurrencyRate> exchange_rates = _currencyRates.VALUTE_INFO;
            CurrencyRate dollar_info = exchange_rates.FindLast(item => item.CurrencyStringCode == _string_code);

            return (_state_account / dollar_info.Nominal) * dollar_info.ExchangeRate;
        }
        public double Spawn_RandomAmount()
        {
            Random R = new Random();
            _state_account = (double)R.Next(0, 400001) / (double)1300;

            return TranslateRubs();
        }

        public double CrushCurrency
        {
            get
            {
                return 100 * _state_account;
            }
        }

        public string CODE
        {
            get
            {
                return _string_code;
            }
        }

        public double STATE
        {
            get
            {
                return _state_account;
            }
        }
    }

    class SpecialDrawingRights : IСurrency
    {
        private string _string_code = "XDR";
        private CurrencyRates _currencyRates;
        private double _state_account;

        public SpecialDrawingRights(CurrencyRates currencyRates, double state_account)
        {
            _currencyRates = currencyRates;
            _state_account = state_account;
        }

        public double TranslateRubs()
        {
            List<CurrencyRate> exchange_rates = _currencyRates.VALUTE_INFO;
            CurrencyRate dollar_info = exchange_rates.FindLast(item => item.CurrencyStringCode == _string_code);

            return (_state_account / dollar_info.Nominal) * dollar_info.ExchangeRate;
        }
        public double Spawn_RandomAmount()
        {
            Random R = new Random();
            _state_account = (double)R.Next(0, 56471) / (double)199;

            return TranslateRubs();
        }

        public double CrushCurrency
        {
            get
            {
                return _state_account;
            }
        }

        public string CODE
        {
            get
            {
                return _string_code;
            }
        }

        public double STATE
        {
            get
            {
                return _state_account;
            }
        }
    }
}
