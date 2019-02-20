using NUnit.Framework;

namespace StringManipulation.Tests
{
    
    public class SpecialStringTest
    {
        [Test]
        public void InputIsEmpty()
        {
            SpecialString s1 = "", s2 = "";
            Assert.That(s1==s2, Is.True, "Empty strings should be equal.");
            Assert.That(s1!=s2, Is.False, "Empty strings should be equal.");
            Assert.That(() => s1<<2, Throws.InvalidOperationException, "Should not be possible to perform shift on strings with higher steps than characters.");
            Assert.That(() => s1>>2, Throws.InvalidOperationException, "Should not be possible to perform shift on strings with higher steps than characters.");
            Assert.That(s1<<0, Is.EqualTo(s1), "Should be possible to perform shift on strings with equal steps and characters.");
            Assert.That(s1>>0, Is.EqualTo(s1), "Should be possible to perform shift on strings with equal steps and characters.");
            Assert.That(s1.ToString(), Is.Empty, "Should return an empty string.");
        }

        [Test]
        public void NullInstantiation()
        {
            SpecialString s;
            Assert.That(() => s = new SpecialString(null), Throws.ArgumentNullException, "Not possible to assign null.");
        }

        [Test]
        public void InputIsNull()
        {
            SpecialString s1 = null, s2 = null;
            Assert.That(() => s1==s2, Throws.InvalidOperationException);
            Assert.That(() => s1!=s2, Throws.InvalidOperationException);
            Assert.That(() => s1<<0, Throws.InvalidOperationException);
            Assert.That(() => s1>>0, Throws.InvalidOperationException);
        }

        [Test]
        public void TestShiftOperation()
        {
            SpecialString s = "Microsoft";

            Assert.That((s<<1).ToString(), Is.EqualTo("tMicrosof"));
            Assert.That((s<<0).ToString(), Is.EqualTo("tMicrosof"));
            Assert.That((s<<-2).ToString(), Is.EqualTo("tMicrosof"));
            Assert.That((s<<9).ToString(), Is.EqualTo("tMicrosof"));
            Assert.That((s<<8).ToString(), Is.EqualTo("Microsoft"));

            Assert.That((s>>1).ToString(), Is.EqualTo("icrosoftM"));
            Assert.That((s>>0).ToString(), Is.EqualTo("icrosoftM"));
            Assert.That((s>>-2).ToString(), Is.EqualTo("icrosoftM"));
            Assert.That((s>>9).ToString(), Is.EqualTo("icrosoftM"));
            Assert.That((s>>8).ToString(), Is.EqualTo("Microsoft"));

            Assert.That(() => s<<10, Throws.InvalidOperationException);
            Assert.That(() => s>>10, Throws.InvalidOperationException);
        }

        [Test]
        public void TestEqualityOperation()
        {
            SpecialString s = "Microsoft", sameS = "Microsoft", longerS = "RandomString", shorterS = "2", lowerCaseS = "microsoft", upperCaseS = "MICROSOFT", sameLengthS = "Softmicro" ;

            Assert.That(s==sameS, Is.True);
            Assert.That(s==longerS, Is.False);
            Assert.That(s==shorterS, Is.False);
            Assert.That(s==lowerCaseS, Is.False);
            Assert.That(s==upperCaseS, Is.False);
            Assert.That(s==sameLengthS, Is.False);

            Assert.That(s!=sameS, Is.False);
            Assert.That(s!=longerS, Is.True);
            Assert.That(s!=shorterS, Is.True);
            Assert.That(s!=lowerCaseS, Is.True);
            Assert.That(s!=upperCaseS, Is.True);
            Assert.That(s!=sameLengthS, Is.True);
        }

        [Test]
        public void TestReAssignment()
        {
            SpecialString s = "Microsoft";
            Assert.That(s.ToString(), Is.EqualTo("Microsoft"));
            s = "RandomString";
            Assert.That(s.ToString(), Is.EqualTo("RandomString"));
        }
    }
}
