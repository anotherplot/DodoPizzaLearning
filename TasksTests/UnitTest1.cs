using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TasksTests
{
    public class Tests
    {
        [Test]
        public void TasksStatusesShouldBeCorrect()
        {
            var task1 = new Task(() => Thread.Sleep(100));
            var task2 = Task.FromResult("Hello, world!");
            var task3 = Task.FromException(new ArgumentException("Shit happened"));
            var task4 = Task.FromCanceled(new CancellationToken(canceled: true));
            Assert.AreEqual(TaskStatus.Created, task1.Status);
            task1.Start();

            // Wait a bit for task to be definetely scheduled
            Thread.Sleep(10);
            Assert.AreEqual(TaskStatus.Running, task1.Status);
            
            // Wait for computation to complete
            Thread.Sleep(100);
            Assert.AreEqual(TaskStatus.RanToCompletion, task1.Status);
            Assert.AreEqual(TaskStatus.RanToCompletion, task2.Status);
            Assert.AreEqual("Hello, world!", task2.Result);
            Assert.AreEqual(TaskStatus.Faulted, task3.Status);
            Assert.AreEqual(typeof(AggregateException), task3.Exception.GetType());
            Assert.AreEqual(typeof(ArgumentException), task3.Exception.InnerException.GetType());
            Assert.AreEqual("Shit happened", task3.Exception.InnerException.Message);
            Assert.AreEqual(TaskStatus.Canceled, task4.Status);
        }
    }
}