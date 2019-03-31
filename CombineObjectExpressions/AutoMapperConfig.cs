using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;

namespace CombineObjectExpressions
{
    public class AutoMapperConfig : BaseMapper
    {
        private static AutoMapperConfig busMeMapperConfig;

        public static AutoMapperConfig Instance => busMeMapperConfig ?? (busMeMapperConfig = new AutoMapperConfig());

        /// <summary>
        /// Maps to type.
        /// </summary>
        /// <typeparam name="TDest">The type of the destination.</typeparam>
        /// <param name="obj">The object.</param>
        /// <returns>Returns an object of the provided type.</returns>
        public TDest MapToType<TDest>(object obj) => Mapper.Map<TDest>(obj);

        protected override void ConfigMapping(IMapperConfigurationExpression cfg)
        {
            cfg.AddExpressionMapping();
        }
    }
}