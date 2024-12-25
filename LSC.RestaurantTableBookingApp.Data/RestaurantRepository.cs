using LSC.RestaurantTableBookingApp.Core;
using LSC.RestaurantTableBookingApp.Core.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSC.RestaurantTableBookingApp.Data
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantTableBookingDbContext _context;
        public RestaurantRepository(RestaurantTableBookingDbContext context)
        {
            _context = context;
        }
        public Task<List<RestaurantModel>> GetAllRestaurantsAsync()
        {
            var restaurants = _context.Restaurants
                .OrderBy(r => r.Name)
                .Select(r => new RestaurantModel
            {
                Id = r.Id,
                Name = r.Name,
                Address = r.Address,
                Phone = r.Phone,
                Email = r.Email,
                ImageUrl = r.ImageUrl
            }).ToListAsync();

            return restaurants;
        }

        public async Task<IEnumerable<DiningTableWithTimeSlotsModel>> GetDiningTablesByBranchAsync(int branchId, DateTime date)
        {
            var diningTables = await _context.DiningTables
                .Where(t => t.RestaurantBranchId == branchId)
                .SelectMany(t => t.TimeSlots, (t, ts) => new 
                {
                    t.RestaurantBranchId,
                    t.TableName,
                    t.Capacity,
                    ts.ReservationDay,
                    ts.MealType,
                    ts.TableStatus,
                    ts.Id,
                })
                .Where(ts => ts.ReservationDay.Date == date.Date)
                .OrderBy(ts => ts.Id)
                .ThenBy(ts => ts.MealType)
                .ToListAsync();

            return diningTables.Select(dt => new DiningTableWithTimeSlotsModel
            {
                BranchId = dt.RestaurantBranchId,
                TableName = dt.TableName,
                Capacity = dt.Capacity,
                ReservationDay = dt.ReservationDay,
                MealType = dt.MealType,
                TableStatus = dt.TableStatus,
                TimeSlotId = dt.Id
            });
        }

        public async Task<IEnumerable<DiningTableWithTimeSlotsModel>> GetDiningTablesByBranchAsync(int branchId)
        {
            var data = await (
                from rb in _context.RestaurantBranches
                join dt in _context.DiningTables on rb.Id equals dt.RestaurantBranchId
                join ts in _context.TimeSlots on dt.Id equals ts.DiningTableId
                where dt.RestaurantBranchId == branchId && ts.ReservationDay >= DateTime.Now.Date
                orderby ts.Id, ts.MealType
                select new DiningTableWithTimeSlotsModel()
                {
                    BranchId = rb.Id,
                    Capacity = dt.Capacity,
                    TableName = dt.TableName,
                    MealType = ts.MealType,
                    ReservationDay = ts.ReservationDay,
                    TableStatus = ts.TableStatus,
                    TimeSlotId = ts.Id,
                })
                .ToListAsync();


            return data;
        }

        public async Task<IEnumerable<RestaurantBranchModel>> GetRestaurantBranchsByRestaurantIdAsync(int restaurantId)
        {
            var branches = await _context.RestaurantBranches
                .Where(b => b.RestaurantId == restaurantId)
                .OrderBy(b => b.Name)
                .Select(b => new RestaurantBranchModel
                {
                    Id = b.Id,
                    RestaurantId = b.RestaurantId,
                    Name = b.Name,
                    Address = b.Address,
                    Phone = b.Phone,
                    Email = b.Email,
                    ImageUrl = b.ImageUrl
                }).ToListAsync();

            return branches;
        }

        public Task<RestaurantReservationDetails> GetRestaurantReservationDetailsAsync(int timeSlotId)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserAsync(string emailId)
        {
            throw new NotImplementedException();
        }
    }
}
