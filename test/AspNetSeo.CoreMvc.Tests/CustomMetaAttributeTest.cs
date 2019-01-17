using Xunit;

namespace AspNetSeo.CoreMvc.Tests
{
    public class CustomMetaAttributeTest
    {
        [Fact]
        public void OnHandleSeoValues_MultipleAttributes_AddsEntriesToCustomMetas()
        {
            // Arrange
            var seoHelper = new SeoHelper();

            var attribute1 = new CustomMetaAttribute(
                "TEST_META_CUSTOM_KEY1",
                "TEST_META_CUSTOM_VALUE1");
            var attribute2 = new CustomMetaAttribute(
                "TEST_META_CUSTOM_KEY2",
                "TEST_META_CUSTOM_VALUE1");
            var attribute3 = new CustomMetaAttribute(
                "TEST_META_CUSTOM_KEY2",
                "TEST_META_CUSTOM_VALUE2");

            // Act
            attribute1.OnHandleSeoValues(seoHelper);
            attribute2.OnHandleSeoValues(seoHelper);
            attribute3.OnHandleSeoValues(seoHelper);

            // Assert
            var customMetas = seoHelper.CustomMetas;

            Assert.Equal(2, customMetas.Count);
            Assert.Equal(
                "TEST_META_CUSTOM_VALUE1",
                customMetas["TEST_META_CUSTOM_KEY1"]);
            Assert.Equal(
                "TEST_META_CUSTOM_VALUE2",
                customMetas["TEST_META_CUSTOM_KEY2"]);
        }
    }
}
