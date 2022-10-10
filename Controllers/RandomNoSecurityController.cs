using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_Dummy.Interfaces;
using WebApi_Dummy.Models;

namespace WebApi_Dummy.Controllers
{
    [RoutePrefix("api/NoSecure/OXXO/Random")]
    public class RandomNoSecurityController : ApiController
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private static Random code = new Random();
        int value = code.Next(0, 2);

        [AllowAnonymous]
        [Route("Auth")]
        [HttpPost]
        public IHttpActionResult AuthRandom(AuthorizationModel model)
        {
            List<string> errors = Validation(model);
            if (value == 0)
            {
                logger.Info($"Auth Success: {JsonConvert.SerializeObject(model)}");

                if (errors.Count > 0)
                {
                    return Ok(new AuthorizationOutput
                    {
                        Success = false,
                        Code = "999",
                        Message = errors[0]
                    });
                }

                Random rnd = new Random();
                int auth = rnd.Next(100000, 999999);
                int transactionId = rnd.Next(100000000, 999999999);
                var successResponse = Ok(new AuthorizationOutput
                {
                    Success = true,
                    Code = "00",
                    Message = "OK",
                    Authorization = auth.ToString(),
                    AuthorizationDate = DateTime.Now.ToString("yy/MM/dd HH:mm:ss"),
                    TransactionId = Guid.NewGuid().ToString("N").ToUpper()
                }); ;

                return successResponse;
            }
            else
            {
                logger.Info($"Auth Error: {JsonConvert.SerializeObject(model)}");
                var error = Ok(new AuthorizationOutput
                {
                    Success = false,
                    Code = "04",
                    Message = "Error"
                });

                if (errors.Count > 0)
                {
                    return Ok(new AuthorizationOutput
                    {
                        Success = false,
                        Code = "999",
                        Message = errors[0]
                    });
                }
                return error;
            }
        }

        [Route("Reversal/Random")]
        [HttpPost]
        public IHttpActionResult ReversalRandom(ReversalModel model)
        {
            List<string> errors = Validation(model);
            if (value == 0)
            {
                logger.Info($"Reversal Success: {JsonConvert.SerializeObject(model)}");
                if (errors.Count > 0)
                {
                    return Ok(new AuthorizationOutput
                    {
                        Success = false,
                        Code = "999",
                        Message = errors[0]
                    });
                }
                Random rnd = new Random();
                int auth = rnd.Next(100000, 999999);
                int transactionId = rnd.Next(100000000, 999999999);
                var successResponse = Ok(new ReversalOutput
                {
                    Success = true,
                    Code = "00",
                    Message = "OK",
                    Authorization = auth.ToString(),
                    AuthorizationDate = DateTime.Now.ToString("yy/MM/dd HH:mm:ss"),
                    TransactionId = Guid.NewGuid().ToString("N").ToUpper()

                }); ;
                return successResponse;
            }
            else
            {
                logger.Info($"Reversal Reversal: {JsonConvert.SerializeObject(model)}");
                var error = Ok(new ReversalOutput
                {
                    Success = false,
                    Code = "04",
                    Message = "Error"
                });

                if (errors.Count > 0)
                {
                    return Ok(new AuthorizationOutput
                    {
                        Success = false,
                        Code = "999",
                        Message = errors[0]
                    });
                }
                return error;
            }
        }


        protected List<string> Validation(IValidatable validatable)
        {
            if (validatable == null)
            {
                return new List<string>()
                {
                    "Favor de enviar un modelo."
                };
            }

            return validatable.Validation();
        }
    }
}
