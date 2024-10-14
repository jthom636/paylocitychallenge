using BenefitsWorker;

namespace BenefitsWorkerTests
{
    public class Tests
    {
        private Employee TestEmployee;
        private Dependent TestDependent;
        private Dependent TestDependent2;
        [SetUp]
        public void Setup()
        {
            TestEmployee = new Employee();
            TestEmployee.FirstName = "Mary";
            TestEmployee.LastName = "Testerson";
            TestEmployee.DateOfBirth = new DateTime(1975, 7, 5);
            TestDependent = new Dependent();
            TestDependent.FirstName = "Joe";
            TestDependent.LastName = "Testerson";
            TestDependent.DateOfBirth = new DateTime(1970, 10, 14);
            TestDependent.Age = 54;
            TestDependent.Relationship = Relationship.DomesticPartner;
            TestDependent2 = new Dependent();
            TestDependent2.FirstName = "Ryan";
            TestDependent2.LastName = "Spouse";
            TestDependent2.Age = 55;
            TestDependent2.DateOfBirth = new DateTime(1969, 10, 14);
            TestDependent2.Relationship = Relationship.Spouse;
        }

        [Test]
        public void AddDependentValid()
        {
            bool employee = TestEmployee.AddDependent(TestDependent);
            Assert.AreEqual(1, TestEmployee.Dependents.Count);
            Assert.IsTrue(employee);
        }

        [Test]
        public void AddDependentInValidSpouse()
        {
            bool employee = TestEmployee.AddDependent(TestDependent);
            employee = TestEmployee.AddDependent(TestDependent2);
            Assert.AreEqual(1, TestEmployee.Dependents.Count);
            Assert.IsFalse(employee);
        }

        [Test]
        public void AddDependentNullSpouse()
        {
            bool employee = TestEmployee.AddDependent(null);
            Assert.IsFalse(employee);
            Assert.AreEqual(0, TestEmployee.Dependents.Count);
        }
    }
}