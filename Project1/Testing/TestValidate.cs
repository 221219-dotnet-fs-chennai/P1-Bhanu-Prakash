using BusinessLogic;

namespace Testing
{
    [TestFixture]
    public class TestValidate
    {
        [TestCase("bhanu@gmail.com",true)]
        [TestCase("bhanugmail.com",false)]
        [Test]
        public void TestEmail(string email,bool exp)
        {
            bool act = Validate.IsValidEmail(email);
            Assert.AreEqual(exp, act);
        }

        [TestCase("Pass@123", true)]
        [TestCase("pass123", false)]
        [Test]
        public void TestPswd(string pswd, bool exp)
        {
            bool act = Validate.IsValidPassword(pswd);
            Assert.AreEqual(exp, act);
        }

        [TestCase("678678", true)]
        [TestCase("345", false)]
        [Test]
        public void TestZipcode(string zip, bool exp)
        {
            bool act = Validate.IsValidZipcode(zip);
            Assert.AreEqual(exp, act);
        }

        [TestCase("6786786789", true)]
        [TestCase("789797890", false)]
        [Test]
        public void TestPhone(string phone, bool exp)
        {
            bool act = Validate.IsValidPhone(phone);
            Assert.AreEqual(exp, act);
        }





    }
}
