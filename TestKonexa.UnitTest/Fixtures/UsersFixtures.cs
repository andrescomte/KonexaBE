using TestKonexa.API.Model;

namespace TestKonexa.UnitTest.Fixtures
{
    public class UsersFixtures
    {
        public static List<User> GetTestUsers() => new()
        {
            new User
            {
                Id = 1,
                Name = "NameTest",
                Username = "UserNametest",
                Email = "EmailTest",
                Address = new Address
                {
                    City = "cityTest",
                    Street = "streetTest",
                    ZipCode = "123"
                },
                Phone = "Phone-123",
                Website = "WebSiteTest",
                Company = new Company { Bs = "BS", Name = "companyTest1",CatchPhrase = "CatchPhaseTest" }  
            },
            new User
            {
                Id = 2,
                Name = "NameTest2",
                Username = "UserNametest2",
                Email = "EmailTest2",
                Address = new Address
                {
                    City = "cityTest2",
                    Street = "streetTest2",
                    ZipCode = "1232"
                },
                Phone = "Phone-1232",
                Website = "WebSiteTest2",
                Company = new Company { Bs = "BS2", Name = "companyTest2",CatchPhrase = "CatchPhaseTest2" }
            },
            new User
            {
                Id = 3,
                Name = "NameTest3",
                Username = "UserNametest3",
                Email = "EmailTest3",
                Address = new Address
                {
                    City = "cityTest3",
                    Street = "streetTest3",
                    ZipCode = "1233"
                },
                Phone = "Phone-1233",
                Website = "WebSiteTest3",
                Company = new Company { Bs = "BS3", Name = "companyTest2",CatchPhrase = "CatchPhaseTest3" }
            }
        };
    }
}
