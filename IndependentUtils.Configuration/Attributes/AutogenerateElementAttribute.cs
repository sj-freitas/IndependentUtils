using System;

namespace IndependentUtils.Configuration.Attributes
{
    public class AutogenerateElementAttribute : Attribute
    {
        private readonly string _lambdaString;

        public string LambdaString
        {
            get
            {
                return _lambdaString ?? "t => new System.Object()";
            }
        }

        public AutogenerateElementAttribute(string lambdaString = null)
        {
            _lambdaString = lambdaString;
        }
    }
}
