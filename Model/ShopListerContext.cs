using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

using ShopLister.Utils;

namespace ShopLister.Model
{
    public class ShopListerOperations : BaseOperations<ShopListerContext>
    {
        public ShopListerOperations()
         : base() {}

         public async Task<ListItem> GetAsync(string id)
         {
             return await Context.ListItems.Where(li => li.Id == id).FirstAsync();
         }

         public async Task<ListItem> CreateAsync(ListItem item)
         {
             item.Id = NewId;
             item.Created = DateTime.Now;
             item.Updated = DateTime.Now;
             Context.ListItems.Add(item);
             await Context.SaveChangesAsync();
             return item;
         }

         public async Task<ListItem> UpdateAsync(ListItem item)
         {
             var updatedValue = MapForSave(item, await GetAsync(item.Id));
             updatedValue.Updated = DateTime.Now;
             await Context.SaveChangesAsync();
             return updatedValue;
         }

         public async Task<IEnumerable<ListItem>> GetCollectionAsync<TKey>(string orderBy)
         {
             return await Context.ListItems.AsQueryable().OrderbyString(orderBy).ToListAsync();
         }

         
         public enum ListItemOrderBy
         {
             Title,
             Category,
             Updated,
             Created
         }

         public async Task DeleteAsync(string id)
         {
             Context.Remove(await GetAsync(id));
             await Context.SaveChangesAsync();
         }

         protected ListItem MapForSave(ListItem fro, ListItem to)
         {
            return Mapper.Map(fro, to);
         }
    }
    public class ShopListerContext : DbContext
    {
        public ShopListerContext(DbContextOptions<ShopListerContext> options)
            :base(options) { }

        public DbSet<ListItem> ListItems { get; set; }
    }

    public static class ShopListerContextExtensions
    {
        public static IOrderedQueryable<ListItem> OrderbyString(this IQueryable<ListItem> list, string orderBy)
        {
            var enumValue = SLConvert.ListSortToEnum<ShopListerOperations.ListItemOrderBy>(orderBy);

            switch(enumValue)
            {
                case ShopListerOperations.ListItemOrderBy.Title:
                    return list.OrderBy(i => i.Title);
                case ShopListerOperations.ListItemOrderBy.Category:
                    return list.OrderBy(i => i.Category);
                case ShopListerOperations.ListItemOrderBy.Updated:
                    return list.OrderBy(i => i.Updated);
                case ShopListerOperations.ListItemOrderBy.Created:
                    return list.OrderBy(i => i.Created);
                default:
                    throw new Exception($"Unexpected enum value {enumValue.ToString()} sorting list items");
            }

        }
    }
}