namespace IndependentUtils.Testing.Attributes
{
    public sealed class UnitTestAttribute : SingleNameTestCategoryBaseAttribute
    {
        public const string UnitTestTag = "UnitTest";

        public UnitTestAttribute()
            : base(UnitTestTag)
        {
        }
    }
}
