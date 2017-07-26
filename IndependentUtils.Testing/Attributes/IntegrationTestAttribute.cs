namespace IndependentUtils.Testing.Attributes
{
    public class IntegrationTestAttribute : SingleNameTestCategoryBaseAttribute
    {
        public const string IntegrationTestsTag = "IntegrationTest";

        public IntegrationTestAttribute()
            : base(IntegrationTestsTag)
        {
        }
    }
}
