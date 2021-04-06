using Inventory.BAL.Models;
using Inventory.BAL.Utilities;
using InventoryAPI.Models;
using InventoryAPI.Providers;
using System;
using System.Data;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace InventoryAPI.Controllers
{
    [BasicAuthentication]
    [RoutePrefix("api/Inventory")]
    public class InventoryController : ApiController
    {
        [Route("GetInventory")]
        [HttpGet]
        public async Task<IHttpActionResult> GetInventory(InventoryVM obj)
        {
            DataTable objResponse = new DataTable();
            try
            {
                Logger.WriteToFile("Client request received  to GetInventory.");
                Logger.WriteToFile("Request Recieved: " + obj);
                objResponse = InventoryUtility.Instance.ListInventory(obj, AppConstants.getConnectionString());
                if (objResponse !=null)
                {
                    return await Task.FromResult(Ok(new
                    {
                        Data = objResponse,
                        Message = "Inventory Items Fetch Succesfuuly!",
                        Status = HttpStatusCode.OK
                    }));
                }
                else
                {
                    return await Task.FromResult(BadRequest("{ \"Message\":\"failure\", \"Status\":\"" + HttpStatusCode.BadRequest));
                }
            }
            catch (Exception ex)
            {
                Logger.WriteToFile(ex.Message);
                return await Task.FromResult(BadRequest("{ \"Message\":\"Error occured while processing your request.\"" + ex.Message + ", \"Status\":\"" + HttpStatusCode.BadRequest));
            }
        }

        [Route("RegisterInventory")]
        [HttpPost]
        public async Task<IHttpActionResult> RegisterInventory(InventoryVM obj)
        {
            int result = 0;
            try
            {
                Logger.WriteToFile("Client request received  to RegisterInventory.");
                Logger.WriteToFile("Request Recieved: " + obj);
                result = InventoryUtility.Instance.AddInventory(obj, AppConstants.getConnectionString());
                if (result > 0)
                {
                    return await Task.FromResult(Ok(new
                    {
                        Message = "Inventory Saved Successfully!",
                        Status = HttpStatusCode.OK
                    }));
                }
                else
                {
                    return await Task.FromResult(BadRequest("{ \"Message\":\"failure\", \"Status\":\"" + HttpStatusCode.BadRequest));
                }
            }
            catch (Exception ex)
            {
                Logger.WriteToFile(ex.Message);
                return await Task.FromResult(BadRequest("{ \"Message\":\"Error occured while processing your request.\"" + ex.Message + ", \"Status\":\"" + HttpStatusCode.BadRequest));
            }
        }

        [Route("UpdateInventory")]
        [HttpPost]
        public async Task<IHttpActionResult> UpdateInventory(InventoryVM obj)
        {
            int result = 0;
            try
            {
                Logger.WriteToFile("Client request received  to UpdateInventory.");
                Logger.WriteToFile("Request Recieved: " + obj);
                result = InventoryUtility.Instance.ModifyInventory(obj, AppConstants.getConnectionString());
                if (result > 0)
                {
                    return await Task.FromResult(Ok(new
                    {
                        Message = "Inventory Updated Successfully!",
                        Status = HttpStatusCode.OK
                    }));
                }
                else
                {
                    return await Task.FromResult(BadRequest("{ \"Message\":\"failure\", \"Status\":\"" + HttpStatusCode.BadRequest));
                }
            }
            catch (Exception ex)
            {
                Logger.WriteToFile(ex.Message);
                return await Task.FromResult(BadRequest("{ \"Message\":\"Error occured while processing your request.\"" + ex.Message + ", \"Status\":\"" + HttpStatusCode.BadRequest));
            }
        }

        [Route("DeleteInventory")]
        [HttpPost]
        public async Task<IHttpActionResult> DeleteInventory(InventoryVM obj)
        {
            int result = 0;
            try
            {
                Logger.WriteToFile("Client request received  to DeleteInventory.");
                Logger.WriteToFile("Request Recieved: " + obj);
                result = InventoryUtility.Instance.DeleteInventory(obj, AppConstants.getConnectionString());
                if (result > 0)
                {
                    return await Task.FromResult(Ok(new
                    {
                        Message = "Inventory Deleted Successfully!",
                        Status = HttpStatusCode.OK
                    }));
                }
                else
                {
                    return await Task.FromResult(BadRequest("{ \"Message\":\"failure\", \"Status\":\"" + HttpStatusCode.BadRequest));
                }
            }
            catch (Exception ex)
            {
                Logger.WriteToFile(ex.Message);
                return await Task.FromResult(BadRequest("{ \"Message\":\"Error occured while processing your request.\"" + ex.Message + ", \"Status\":\"" + HttpStatusCode.BadRequest));
            }
        }

    }
}
