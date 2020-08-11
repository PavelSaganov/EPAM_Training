using Ex2.Enumerables;
using Ex2.Static_Classes;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;

namespace Ex2.Tests
{
    public class Tests
    {
        MyGenericCollection<Animal> animals;

        [SetUp]
        public void Setup()
        {
            animals = new MyGenericCollection<Animal>();
            animals.Add(new Animal("Elephant", 4, 4.52, Gender.Male));
            animals.Add(new Animal("Mouse", 1, 0.07, Gender.Male));
            animals.Add(new Animal("Dog", 6, 0.5, Gender.Female));
            animals.Add(new Animal("Dog", 4, 0.43, Gender.Female));
        }

        [Test]
        public void XmlSerialize()
        {
            WorkWithFile.XmlSerialize(@"../Animals.xml", animals);
        }

        [Test]
        public void XmlDeserialize()
        {
            // arrange
            var arrange = animals;

            // actual
            var actual = WorkWithFile.XmlDeserialize<Animal>(@"../Animals.xml");

            // assert
            Assert.AreEqual(arrange, actual);
        }

        [Test]
        public void BinSerialize()
        {
            WorkWithFile.BinSerialize(@"../Animals.bin", animals);
        }

        [Test]
        public void BinDeserialize()
        {
            // arrange
            var arrange = animals;

            // actual
            var actual = WorkWithFile.BinDeserialize<Animal>(@"../Animals.bin");

            // assert
            Assert.AreEqual(arrange, actual);
        }

        [Test]
        public void JsonSerialize()
        {
            WorkWithFile.JsonSerialize(@"../Animals.json", animals);
        }

        [Test]
        public void JsonDeserialize()
        {
            // arrange
            var arrange = animals;

            // actual
            var actual = WorkWithFile.JsonDeserialize<Animal>(@"../Animals.json");

            //  assert
            Assert.AreEqual(arrange, actual);
        }

    }
}