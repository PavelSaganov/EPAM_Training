using Client;
using Client.Enumerables;
using Server;
using System;
using System.Net;
using System.Threading;
using Xunit;

namespace FourthTask.Tests
{
    public class TranslateTests
    {
        [Fact]
        public void Translate_Rus_To_Eng()
        {
            Translater t = new Translater();

            // arrange
            string arrange = t.Translate("переведенный текст?", Language.Russian, Language.English);

            // actual
            string actual = "perevedennii tekst?";

            // assert
            Assert.Equal(actual, arrange);
        }

        [Fact]
        public void Translate_Eng_To_Rus()
        {
            Translater t = new Translater();

            // arrange
            string arrange = t.Translate("perevel tekst", Language.English, Language.Russian);

            // actual
            string actual = "перевел текст";

            // assert
            Assert.Equal(actual, arrange);
        }

        [Fact]
        public void Translate_Eng_To_Rus2()
        {
            Translater t = new Translater();

            // arrange
            string arrange = t.Translate("eto perevedennii tekst, ведь так?", Language.English, Language.Russian);

            // actual
            string actual = "ето переведеннии текст, ведь так?";

            // assert
            Assert.Equal(actual, arrange);
        }
    }
}
