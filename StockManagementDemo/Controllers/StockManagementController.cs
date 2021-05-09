using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockManagementDemo.Models;
using Microsoft.AspNetCore.Cors;

namespace StockManagementDemo.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [EnableCors("AllowOrigin")]
    public class StockManagementController : ControllerBase
    {

        protected readonly StockManagementDbContext DbContext;

        public StockManagementController(StockManagementDbContext dbContext)
        {
            DbContext = dbContext;
        }


        // GET ALL STOCKITEMS
        [HttpGet("getAllStock")]
        public async Task<IActionResult> getAllStockAsync(int pageSize = 10, int pageNumber = 1)
        {
            var response = new ListResponse<StockItem>();

            try
            {
                var query = DbContext.getAllStock();

                response.Model = await query.ToListAsync();

            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";
            }

            return response.ToHttpResponse();
        }

        //GET STOCK AND IMAGE
        [HttpGet("getFullStock")]
        public async Task<IActionResult> getStockAndImageAsync(int pageSize = 10, int pageNumber = 1)
        {
            var response = new ListResponse<fullStockItem>();

            var cItem = new List<fullStockItem>();
            var testList = new List<StockItem>();
            var secondList = new List<Image>();

            try
            {
                var query = DbContext.getAllStock();
                testList = await query.ToListAsync();

                foreach (var item in testList)
                {
                    var tempcItem = new fullStockItem();
                    var query2 = DbContext.getImageByStockID((int)item.ID);
                    secondList = await query2.ToListAsync();

                    tempcItem.ID = item.ID;
                    tempcItem.Model = item.Model;
                    tempcItem.Make = item.Make;
                    tempcItem.image = secondList;

                    cItem.Add(tempcItem);
                }

                response.Model = cItem;

            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";
            }

            return response.ToHttpResponse();
        }

        //GET STOCK ITEM BY ID
        [HttpGet("getStockByID/{ID}")]
        public async Task<IActionResult> getStockByID(int ID, int pageSize = 10, int pageNumber = 1)
        {
            var response = new SingleResponse<StockItem>();

            try
            {

                response.Model = await DbContext.getStockByID(ID);

            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";
            }

            return response.ToHttpResponse();
        }


        //PUT
        //PUT CAR ITEM
        [HttpPut("putStockItem/{id}")]
        public async Task<IActionResult> putStockItem(int id, [FromBody] putStockItemsRequest request)
        {
            var response = new Response();

            try
            {
                var entity = await DbContext.getStockByID((int)request.ID);

                if (entity == null)
                {
                    return NotFound();
                }
                else {
                    entity.KMS = request.KMS;
                    entity.Make = request.Make;
                    entity.Model = request.Model;
                    entity.ModelYear = request.ModelYear;
                    entity.RegNo = request.RegNo;
                    entity.RetailPrice = request.RetailPrice;
                    entity.CostPrice = request.CostPrice;
                    entity.Colour = request.Colour;
                    entity.VIN = request.VIN;
                }

                // Update entity in repository
                DbContext.Update(entity);

                // Save entity in database
                await DbContext.SaveChangesAsync();
                response.Message = "Succesfully updated";
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";
            }

            return response.ToHttpResponse();
        }

    }
}
