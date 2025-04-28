namespace backend_sc.Services.AulaService
{
    public class AulaService : IAulaInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AulaService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



    }
}
