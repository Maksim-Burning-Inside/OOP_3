using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

/*
 * Сериализация — процесс перевода структуры данных в последовательность байтов. 
 * Обратной к операции сериализации является операция десериализации — создание структуры данных из битовой последовательности. 
 * Сериализация используется для передачи объектов по сети и для сохранения их в файлы
 */

namespace OOP_3
{
    public struct CurrencyRate
    {
        // Закодированное строковое обозначение валюты
        // Например: USD, EUR, AUD и т.д.
        public string CurrencyStringCode;

        // Наименование валюты
        // Например: Доллар, Евро и т.д.
        public string CurrencyName;

        // Номинал обменного курса
        public int Nominal;

        // Обменный курс
        public double ExchangeRate;
    }

    public class CurrencyRates
    {
        private List<CurrencyRate> _currencyRates;

        public CurrencyRates()
        {
            _currencyRates = GetExchangeRates();
        }

        /*
         * Для удобного сохранения и извлечения объектов из файлов xml используется класс XmlSerializer
         * XmlSerializer предполагает некоторые ограничения. 
         * Класс, подлежащий сериализации, должен иметь стандартный конструктор без параметров. 
         * Также сериализации подлежат только открытые члены. 
         * Если в классе есть поля или свойства с модификатором private, то при сериализации они будут игнорироваться
         * 
         * XmlReader gредоставляет средство чтения, обеспечивающее быстрый прямой доступ (без кэширования) к данным XML.
         */

        // Далее создаются те самые сериализуемые классы со стандартными конструкторами и публичными полями.

        /*
         * Немного о смысле происходящих махинаций с кодом. Рассмотрим как выглядит "элемент" с Xml-сайта ЦБ РФ
         * 
         * <ValCurs Date="28.10.2021" name="Foreign Currency Market">
         *      <Valute ID="R01010">
         *          <NumCode>036</NumCode>
         *          <CharCode>AUD</CharCode>
         *          <Nominal>1</Nominal>
         *          <Name>Австралийский доллар</Name>
         *          <Value>52,3857</Value>
         *      </Valute>
         * 
         * Valute(валюта) - это массив данных, содержащий NumCode(циферный знак валюты), CharCode(буквенный знак валюты),
         * Nominal(наминал, который важен по причине того, что некоторые валюты пересчитываются в рубли по номиналу, например, в 100 денежных едениц),
         * Name(принятое ЦБ РФ полное наименование валюты кириллицей), Value(стоимость номинала данной валюты в пересчёты на рубли на указанную дату).
         * Изменяя параметр Date, мы можем получать данные из прошлого, а так же ежедневно динамически корректировать данные в нашей программе с реальными.
         * 
         * Таким образом мы создаем класс ValuteCurs, содержащий массив данных типа ValuteCursValute, в который считываем CharCode, Name, Nominal, Value.
         * Именно эти классы и будут проходить процесс сериализации, который позволит считать данные с сайта ЦБ РФ в нащу программу.
         */

        public class ValCurs
        {
            [XmlElement("Valute")]
            public ValCursValute[] ValuteList;
        }

        public class ValCursValute
        {

            [XmlElement("CharCode")]
            public string ValuteStringCode;

            [XmlElement("Name")]
            public string ValuteName;

            [XmlElement("Nominal")]
            public string ValuteNominal;

            [XmlElement("Value")]
            public string ExchangeRate;
        }

        // Получить список котировок ЦБ ФР на данный момент
        public List<CurrencyRate> GetExchangeRates()
        {
            List<CurrencyRate> result = new List<CurrencyRate>();                         // Список с результатом будем сохранять в данный лист
            XmlSerializer xs = new XmlSerializer(typeof(ValCurs));                        // Объявляем переменную класса XmlSerializer явно указывая сериализируемый объект ValuteCurs 
            XmlReader xr = new XmlTextReader(@"http://www.cbr.ru/scripts/XML_daily.asp"); // Считываем данные со специального Xml-сайта ЦБ РФ
            foreach (ValCursValute valute in ((ValCurs)xs.Deserialize(xr)).ValuteList)    // Проводим десерилизвцию и передаём данные в CurrencyRate
            {
                result.Add(new CurrencyRate()
                {
                    CurrencyName = valute.ValuteName,
                    CurrencyStringCode = valute.ValuteStringCode,
                    Nominal = int.Parse(valute.ValuteNominal),
                    ExchangeRate = double.Parse(valute.ExchangeRate)
                });
            }
            return result;
        }

        public List<CurrencyRate> VALUTE_INFO
        {
            get
            {
                return _currencyRates;
            }
        }
    }
}
