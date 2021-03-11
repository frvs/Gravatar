using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gravatar.Tests
{
    [TestClass]
    public class GravatarExtensionTests
    {
        [TestCategory("Gravatar Tests")]
        [TestMethod("Should validate Gravatar extension method.")]
        [DataRow(null, 200, false)]
        [DataRow("", 200, false)]
        [DataRow(" ", 200, false)]
        [DataRow("a", 200, false)]
        [DataRow("a@a", 200, false)]
        [DataRow("frois.dev@gmail.com", null, true)]
        [DataRow("frois.dev@gmail.com", 200, true)]
        public void ShouldValidateGravatar(string email, int? size, bool status)
        {
            var imageSize = size.HasValue ? size.Value.ToString() : "80";

            var result = $"https://www.gravatar.com/avatar/8A66E46C6BAFF35464A394253BAC5121?s={imageSize}".ToLower();
            
            Assert.AreEqual((email.ToGravatar(size ?? 80) == result), status);
        }
    }
}
