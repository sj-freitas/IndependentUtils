using System;

namespace IndependentUtils.Tools.Objects
{
    //[Serializable]
    public class SimpleTuple<T1, T2> : MarshalByRefObject
    {
        public T1 Item1 { get; set; }

        public T2 Item2 { get; set; }
    }

    public static class SimpleTuple
    {
        public static SimpleTuple<T1, T2> Create<T1, T2>(T1 value1, T2 value2)
        {
            return new SimpleTuple<T1, T2>
            {
                Item1 = value1,
                Item2 = value2
            };
        }
    }
}
