using DataTransmissionAPI.Data;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DataTransmissionAPI.Dto;

namespace DataTransmissionAPI.Service
{
    public class StoragePreDataService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;

        // Constructor to initialize the service with required dependencies
        public StoragePreDataService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
        }

        // Method to retrieve a list of CT_ThongTin entities based on specified filters
        public async Task<List<StoragePreDataDto>> GetAllAsync()
        {

            var query = _context.StoragePreData!
                .OrderBy(x => x.Id)
                .AsQueryable();

            var stations = await query.ToListAsync();

            // Map the result to DTOs
            var stationDtos = _mapper.Map<List<StoragePreDataDto>>(stations);

            // Return the list of DTOs
            return stationDtos;
        }

        // Method to retrieve a single CT_ThongTin entity by Id
        public async Task<List<StoragePreDataDto>> GetByConstructionCode(string ConstructionCode)
        {
            var query = _context.StoragePreData!
                .Where(ct => ct.ConstructionCode == ConstructionCode)
                .OrderByDescending(x => x.Id)
                .Take(11);

            var PreData = await query.ToListAsync();

            if (PreData == null)
            {
                // Handle the case where the record is not found
                return null;
            }

            var PreDataDto = _mapper.Map<List<StoragePreDataDto>>(PreData);

            return PreDataDto;
        }

        // Method to save or update a CT_ThongTin entity
        public async Task<int> SaveAsync(List<StoragePreDataDto> dtos)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);
            StoragePreData item = null; // Declare item variable

            foreach(var d in dtos)
            {
                // Retrieve an existing item based on Id or if dto.Id is 0
                var existingItem = await _context.StoragePreData!.FirstOrDefaultAsync(e => e.Id == d.Id);

                if (existingItem == null || d.Id == 0)
                {
                    // If the item doesn't exist or dto.Id is 0, create a new item
                    item = _mapper.Map<StoragePreData>(d);
                    _context.StoragePreData!.Add(item);
                }
                else
                {
                    // If the item exists, update it with values from the dto
                    item = existingItem;
                    _mapper.Map(d, item);
                    _context.StoragePreData!.Update(item);
                }

            }

            // Save changes to the database
            var res = await _context.SaveChangesAsync();

            // Return the id
            return res;
        }

        // Method to delete a CT_ThongTin entity
        public async Task<bool> DeleteAsync(int Id)
        {
            // Retrieve an existing item based on Id
            var existingItem = await _context.StoragePreData!.FirstOrDefaultAsync(d => d.Id == Id);

            if (existingItem == null) { return false; } // If the item doesn't exist, return false

            _context.StoragePreData!.Remove(existingItem);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return true to indicate successful deletion
            return true;
        }
    }
}
