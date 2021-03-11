using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gravatar.Tests
{
    [TestClass]
    public class GravatarExtensionTests
    {
        [TestCategory("Gravatar Tests")]
        [TestMethod("Should validate Gravatar extension method.")]
        [DataRow(null, false)]
        [DataRow("", false)]
        [DataRow(" ", false)]
        [DataRow("a", false)]
        [DataRow("a@a", false)]
        [DataRow("frois.dev@gmail.com", true)]
        public void ShouldValidateGravatar(string email, bool status)
        {
            var result = "https://www.gravatar.com/avatar/8A66E46C6BAFF35464A394253BAC5121".ToLower();
            Assert.AreEqual((email.ToGravatar() == result), status);
        }
    }
}
