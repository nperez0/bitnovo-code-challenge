using System.Linq;
using AutoMapper;

namespace Bitnovo.Infrastructure.Extensions
{
    public static class AutoMapperExtensions
    {
        public static T Map<T>(this IMapper mapper, params object[] sources) where T : class
        {
            if (!sources.Any())
            {
                return default(T);
            }

            var initialSource = sources[0];

            var mappingResult = Map<T>(mapper, initialSource);

            if (sources.Count() > 1)
                Map(mapper, mappingResult, sources.Skip(1).ToArray());

            return mappingResult;
        }

        private static void Map(IMapper mapper, object destination, params object[] sources)
        {
            if (!sources.Any())
            {
                return;
            }

            var destinationType = destination.GetType();

            foreach (var source in sources)
            {
                var sourceType = source.GetType();

                mapper.Map(source, destination, sourceType, destinationType);
            }
        }

        private static T Map<T>(IMapper mapper, object source) where T : class
        {
            var destinationType = typeof(T);
            var sourceType = source.GetType();

            var mappingResult = mapper.Map(source, sourceType, destinationType);

            return mappingResult as T;
        }
    }
}
