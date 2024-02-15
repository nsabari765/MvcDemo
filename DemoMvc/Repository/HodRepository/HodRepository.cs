using AutoMapper;
using DemoMvc.Data;
using DemoMvc.Models;

namespace DemoMvc.Repository.HodRepository
{
    public class HodRepository
    {
        public readonly DataContext _context;
        private readonly IMapper _mapper;

        public HodRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public HodName Save(HodName hodName)
        {
            var department = _context.Department.Find(hodName.DepartmentId);

            _context.Add(hodName);
            _context.SaveChanges();
            return hodName;
        }

        public IEnumerable<HodName> GetAllHod()
        {
            return _context.HodName.ToList();
        }
    }
}