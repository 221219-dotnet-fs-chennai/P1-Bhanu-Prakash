using df = DataFluentAPI;
using BusinessLogic;

namespace Testing
{
    [TestFixture]
    public class TestMapper
    {
        [Test]
        public void TestUser1()
        {
            df.Entities.UserDetails ud = new df.Entities.UserDetails();
            var res = Mapper.Map(ud);
            Assert.AreEqual(res.GetType(), typeof(Models.UserDetails));
        }

        [Test]
        public void TestUser2()
        {
            Models.UserDetails ud = new Models.UserDetails();
            var res = Mapper.Map(ud);
            Assert.AreEqual(res.GetType(), typeof(df.Entities.UserDetails));
        }

        [Test]
        public void Testskill1()
        {
            df.Entities.Skills ud = new df.Entities.Skills();
            var res = Mapper.Map(ud);
            Assert.AreEqual(res.GetType(), typeof(Models.Skills));
        }

        [Test]
        public void Testskill2()
        {
            Models.Skills ud = new Models.Skills();
            var res = Mapper.Map(ud);
            Assert.AreEqual(res.GetType(), typeof(df.Entities.Skills));
        }

        [Test]
        public void TestCompany1()
        {
            df.Entities.Company ud = new df.Entities.Company();
            var res = Mapper.Map(ud);
            Assert.AreEqual(res.GetType(), typeof(Models.Company));
        }

        [Test]
        public void TestCompany2()
        {
            Models.Company ud = new Models.Company();
            var res = Mapper.Map(ud);
            Assert.AreEqual(res.GetType(), typeof(df.Entities.Company));
        }

        [Test]
        public void TestContact1()
        {
            df.Entities.Contact ud = new df.Entities.Contact();
            var res = Mapper.Map(ud);
            Assert.AreEqual(res.GetType(), typeof(Models.Contact));
        }

        [Test]
        public void TestContact2()
        {
            Models.Contact ud = new Models.Contact();
            var res = Mapper.Map(ud);
            Assert.AreEqual(res.GetType(), typeof(df.Entities.Contact));
        }

        [Test]
        public void TestEdu1()
        {
            df.Entities.Education ud = new df.Entities.Education();
            var res = Mapper.Map(ud);
            Assert.AreEqual(res.GetType(), typeof(Models.Education));
        }

        [Test]
        public void TestEdu2()
        {
            Models.Education ud = new Models.Education();
            var res = Mapper.Map(ud);
            Assert.AreEqual(res.GetType(), typeof(df.Entities.Education));
        }


    }
}
