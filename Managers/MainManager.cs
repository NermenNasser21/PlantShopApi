using InfraStructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers
{
    public class MainManager <T> where T :class
    {
        private readonly PlantContext dbContext;
        private DbSet<T> dbset;

        public MainManager(PlantContext _dbContext)
        {
            dbContext= _dbContext;
            dbset =dbContext.Set<T>();
        }

        public IQueryable<T> GetAll() 
        {
            return dbset.AsQueryable();
        }

        public async Task<T> GetOne(object _Id)
        {
           
            return await dbset.FindAsync(_Id);
        }

        public async Task<bool> Add(T _Item)
        {
            try
            {
                await dbset.AddAsync(_Item);
                await dbContext.SaveChangesAsync();
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Update(T _Item)
        {
            try
            {
                 dbset.Update(_Item);
                await dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public async Task<bool> Delete(T _Item)
        {
            try
            {
                dbset.Remove(_Item);
                await dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
