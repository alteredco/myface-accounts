using NUnit.Framework;

namespace TestProject1
{
    public class AuthServiceTests
    {
        private AuthService _authService;
        private IUsersRepo _fakeUsersRepo;
        
        [SetUp]
        public void Setup()
        {
            _authService = new AuthService();
            _fakeUsersRepo = A.Fake<IUserRepo>();
            
        }

        [Test]
        public void ReturnsTrueIfRequestIsValid()
        {
            var request = A.Fake<HttpRequest>();
            A.CallTo(()=> request.Headers)Returns(new HeaderDictionary
            {
                {'Authorization', new [] {'Basic dGVzdC11c2VyOnN1Y3JldA=='} }
            });
        }
        
        [Test]
        public void ReturnsTrueIfRequestIsValid()
        {
            var request = A.Fake<HttpRequest>();
            A.CallTo(()=> request.Headers)Returns(new HeaderDictionary());
        }
        
        [Test]
        public void ReturnsTrueIfRequestIsValid()
        {
            var request = A.Fake<HttpRequest>();
            A.CallTo(()=> request.Headers)Returns(new HeaderDictionary
            {
                {'Authorization', new [] {'_Other dGVzdC11c2VyOnN1Y3JldA==' }}
            });
        }
    }
}