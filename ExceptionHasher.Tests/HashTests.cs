using System;
using ExceptionHash;
using NUnit.Framework;

namespace ExceptionHash.Tests
{
    [TestFixture]
    public class HashTests
    {
        [Test]
        public void When_Exception_Is_Null_Throw()
        {
            Exception target = null;

            Assert.Throws<NullReferenceException>(() => target.Hash());
        }

        [Test]
        public void Ensure_Message_IsHashed()
        {
            var expectedHash = string.Format("{0:X8}", "Fail Message!".GetHashCode());

            var target = new Exception("Fail Message!");

            Assert.That(expectedHash, Is.EqualTo(target.Hash()));
        }

        [Test]
        public void Ensure_InnerException_IsHashed()
        {
            var expectedHash = string.Format("{0:X8}", "Fail Message!Inner Fail!".GetHashCode());

            var target = new Exception("Fail Message!", new Exception("Inner Fail!"));

            Assert.That(expectedHash, Is.EqualTo(target.Hash()));
        }

        [Test]
        public void Ensure_Stack_Trace_Is_Included()
        {
            try
            {
                throw new Exception("Fail Message!");
            }
            catch (Exception target)
            {
                //Ok so this horrible code is the easiest way to create an exception with a stack trace

                var expectedHash = string.Format("{0:X8}", "Fail Message!   at ExceptionHash.Tests.HashTests.Ensure_Stack_Trace_Is_Included() in C:\\Users\\Rob\\ExceptionHash\\ExceptionHasher.Tests\\HashTests.cs:line 43".GetHashCode());           

                Assert.That(expectedHash, Is.EqualTo(target.Hash()));
            }
        }
    }
}
