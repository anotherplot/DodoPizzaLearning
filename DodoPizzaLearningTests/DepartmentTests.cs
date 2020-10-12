using System.Linq;
using CSharpLearning.DSL;
using NUnit.Framework;

namespace DodoPizzaLearningTests
{
    [TestFixture]
    public class DepartmentTests
    {
        [Test]
        public void CreateDepartmentWithUnits()
        {
            var department = Create.Department
                .WithName("Сыктывкар")
                .WithId(1)
                .WithType(2)
                .WithUnits(unit => unit.WithName("Сыктывкар-1").WithId(1).Please(),
                    unit => unit.WithName("Сыктывкар-2").WithId(2).Please())
                .Please();

            Assert.IsTrue(department.Units.Count() == 2);
        }
    }
}