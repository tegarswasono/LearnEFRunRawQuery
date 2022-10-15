using LearnEFRunRawQuery.Module.EntityFramework;
using LearnEFRunRawQuery.Module.EntityFramework.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Data.Common;
using System.Data;

namespace LearnEFRunRawQuery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly DBContext _context;
        public ProductController(DBContext context)
        {
            _context = context;
        }
        [HttpGet("ChildProduct")]
        public ActionResult<List<ChildProduct>> ChildProduct()
        {
            var result = _context.ChildProducts.ToList();
            return Ok(result);
        }
        [HttpGet("AllProduct")]
        public ActionResult<List<ChildProduct>> AllProduct()
        {
            string query = @"select * from AdultProducts
                            union 
                            select * from ChildProducts;";
            var result = _context.ChildProducts.FromSqlRaw(query).ToList();
            return Ok(result);
        }
        [HttpGet("CustomQuery")]
        public ActionResult CustomQuery()
        {
            string query = @"select Name, Stok from AdultProducts
                            union 
                            select Name, Stok from ChildProducts
                            order by Stok;";

            var result = Helper.RawSqlQuery<CustomModel>(_context, query, x => new CustomModel()
            {
                Name = (string)x[0],
                Stok = (long)x[1]
            });
            return Ok(result);
        }
    }
    public static class Helper
    {
        public static List<T> RawSqlQuery<T>(DBContext _context, string query, Func<DbDataReader, T> map)
        {
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                _context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    var entities = new List<T>();
                    while (result.Read())
                    {
                        entities.Add(map(result));
                    }
                    return entities;
                }
            }
        }
    }
    public class CustomModel
    {
        public string Name { set; get; }
        public long Stok { set; get; }
    }
}
