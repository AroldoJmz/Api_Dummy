using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi_Dummy.Interfaces;

namespace WebApi_Dummy.Models
{
    public class AuthorizationModel: IValidatable
    {
        public string TransactionIdOXXO { get; set; }
        public Nullable<DateTime> TransactionDateOXXO { get; set; }
        public string TransactionIdOCSI { get; set; }
        public string ReferenceId { get; set; }
        public string Reference { get; set; }
        public decimal Amount { get; set; }
        public string BeneficiaryId { get; set; }

        public List<string> Validation()
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrEmpty(this.TransactionIdOXXO))
            {
                errors.Add("Favor de enviar el campo: TransactionId");
            }
            if (this.TransactionDateOXXO == null)
            {
                errors.Add("Favor de enviar el campo: TransactionDateOXXO");
            }
            if (string.IsNullOrEmpty(this.TransactionIdOCSI))
            {
                errors.Add("Favor de enviar el campo: TransactionIdOCSI");
            }
            if (string.IsNullOrEmpty(this.ReferenceId))
            {
                errors.Add("Favor de enviar el campo: ReferenceId");
            }
            if (string.IsNullOrEmpty(this.Reference))
            {
                errors.Add("Favor de enviar el campo: Reference");
            }
            if (this.Amount < 0.0m)
            {
                errors.Add("Favor de enviar el campo: Amount");

            }
            if (string.IsNullOrEmpty(this.BeneficiaryId))
            {
                errors.Add("Favor de enviar el campo: Reference");
            }

            return errors;
        }
    }

    public class ReversalModel: IValidatable
    {
        public string TransactionIdOXXO { get; set; }
        public DateTime TransactionDateOXXO { get; set; }
        public string TransactionIdOCSI { get; set; }
        public string ReferenceId { get; set; }
        public string Reference { get; set; }
        public decimal Amount { get; set; }
        public string BeneficiaryId { get; set; }
        public string Authorization { get; set; }

        public List<string> Validation()
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrEmpty(this.TransactionIdOXXO))
            {
                errors.Add("Favor de enviar el campo: TransactionId");
            }
            if (this.TransactionDateOXXO == null)
            {
                errors.Add("Favor de enviar el campo: TransactionDateOXXO");
            }
            if (string.IsNullOrEmpty(this.TransactionIdOCSI))
            {
                errors.Add("Favor de enviar el campo: TransactionIdOCSI");
            }
            if (string.IsNullOrEmpty(this.ReferenceId))
            {
                errors.Add("Favor de enviar el campo: ReferenceId");
            }
            if (string.IsNullOrEmpty(this.Reference))
            {
                errors.Add("Favor de enviar el campo: Reference");
            }
            if (this.Amount < 0.0m)
            {
                errors.Add("Favor de enviar el campo: Amount");

            }
            if (string.IsNullOrEmpty(this.BeneficiaryId))
            {
                errors.Add("Favor de enviar el campo: Reference");
            }

            if (string.IsNullOrEmpty(this.Authorization))
            {
                errors.Add("Favor de enviar el campo: Authorization");
            }

            return errors;
        }
    }

    public class AuthorizationOutput: StdResponse
    {
        //public InternalDataAuthorizationOutput Data { get; set; }
        public string TransactionId { get; set; }
        public string Authorization { get; set; }
        public string AuthorizationDate { get; set; }
    }

    public class InternalDataAuthorizationOutput
    {
        public int TransactionId { get; set; }
        public int Authorization { get; set; }
        public DateTime AuthorizationDate { get; set; }
    }

    public class ReversalOutput: StdResponse
    {
        //public InternalReversalOutput Data { get; set; }
        public string TransactionId { get; set; }
        public string Authorization { get; set; }
        public string AuthorizationDate { get; set; }
    }

    public class InternalReversalOutput
    {
        public int TransactionId { get; set; }
        public int Authorization { get; set; }
        public DateTime AuthorizationDate { get; set; }
    }

    public class StdResponse
    {
        public bool Success { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
    }
}