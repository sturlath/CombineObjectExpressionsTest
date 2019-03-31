using AutoMapper;

namespace CombineObjectExpressions
{
    public abstract class BaseMapper
    {
        private IMapper mapper;

        public BaseMapper()
        {
            // Setup automappings
            Init();
        }

        public IMapper Mapper
        {
            get
            {
                return mapper;
            }
        }

        protected abstract void ConfigMapping(IMapperConfigurationExpression cfg);
        private void Init()
        {
            var config = new MapperConfiguration(cfg =>
            {
                ConfigMapping(cfg);
            });

            mapper = config.CreateMapper();

#if DEBUG
            // Validates the mapping
            config.AssertConfigurationIsValid();
#endif
        }
    }
}
