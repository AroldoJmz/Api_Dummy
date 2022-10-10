﻿using Newtonsoft.Json;
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
    [Authorize]
    [RoutePrefix("api/OXXO")]
    public class DummyController : ApiController
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        [Route("Auth/Success")]
        [HttpPost]
        public IHttpActionResult AuthSuccess(AuthorizationModel model)
        {
            logger.Info($"Auth Success: {JsonConvert.SerializeObject(model)}");
            List<string> errors = Validation(model);
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
            return Ok(new AuthorizationOutput
            {
                Success = true,
                Code = "00",
                Message = "OK",
                Authorization = auth.ToString(),
                AuthorizationDate = DateTime.Now.ToString("yy/MM/dd HH:mm:ss"),
                TransactionId = Guid.NewGuid().ToString("N").ToUpper()
            }); ;
        }

        [Route("Auth/Error")]
        [HttpPost]
        public IHttpActionResult AuthError(AuthorizationModel model)
        {
            logger.Info($"Auth Error: {JsonConvert.SerializeObject(model)}");

            List<string> errors = Validation(model);
            if (errors.Count > 0)
            {
                return Ok(new AuthorizationOutput
                {
                    Success = false,
                    Code = "999",
                    Message = errors[0]
                });
            }

            return Ok(new AuthorizationOutput
            {
                Success = false,
                Code = "04",
                Message = "Error"
            });
        }

        [Route("Reversal/Success")]
        [HttpPost]
        public IHttpActionResult ReversalSuccess(ReversalModel model)
        {
            logger.Info($"Reversal Success: {JsonConvert.SerializeObject(model)}");

            List<string> errors = Validation(model);
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
            int auth = rnd.Next(100000,999999);
            int transactionId = rnd.Next(100000000, 999999999);
            return Ok(new ReversalOutput
            {
                Success = true,
                Code = "00",
                Message = "OK",
                Authorization = auth.ToString(),
                AuthorizationDate = DateTime.Now.ToString("yy/MM/dd HH:mm:ss"),
                TransactionId = Guid.NewGuid().ToString("N").ToUpper()

            }); ;
        }

        [Route("Reversal/Error")]
        [HttpPost]
        public IHttpActionResult ReversalError(ReversalModel model)
        {
            logger.Info($"Reversal Reversal: {JsonConvert.SerializeObject(model)}");

            List<string> errors = Validation(model);
            if (errors.Count > 0)
            {
                return Ok(new AuthorizationOutput
                {
                    Success = false,
                    Code = "999",
                    Message = errors[0]                    
                });
            }
            return Ok(new ReversalOutput
                {
                    Success = false,
                    Code = "04",
                    Message = "Error"
                });
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
