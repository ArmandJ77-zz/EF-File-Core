using AutoMapper;

namespace Domain.Infrastructure
{
    public class BaseService
    {
        public readonly IMapper _mapper;
        public BaseService(IMapper mapper) {
            _mapper = mapper;
        }
    }
}
