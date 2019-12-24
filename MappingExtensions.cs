using System;
using System.Collections.Generic;
using System.Linq;

namespace MMapp
{
    public static class MappingExtensions
    {
        public static TOut Map<TOut, TIn>(this TIn obj) where TOut : IMappable<TIn> where TIn : class
        {
            TOut instance = Activator.CreateInstance<TOut>();
            _ = instance.Map(obj);
            return instance;
        }

        public static IEnumerable<TOut> Map<TOut, TIn>(this IEnumerable<TIn> objs) where TOut : IMappable<TIn> where TIn : class
        {
            List<TOut> outs = new List<TOut>();
            List<TIn> ins = objs.ToList();
            ins.ForEach(i => outs.Add((TOut)Activator.CreateInstance<TOut>().Map(i)));
            return outs;
        }
    }
}