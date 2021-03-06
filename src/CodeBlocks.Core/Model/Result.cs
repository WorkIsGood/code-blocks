﻿using System.Collections.Generic;
using System.Linq;

namespace CodeBlocks.Core.Model
{
    public class Result : IResult
    {
        public bool Success { get; set; } = true;

        public List<ValidationError> ValidationErrors { get; } = new List<ValidationError>();
        public List<ResultMessage> Messages { get; } = new List<ResultMessage>();

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public List<ResultMessage> SuccessMessages
        {
            get
            {
                return Messages?.Where(m => m.Type == ResultMessageType.Success).ToList();
            }
        }
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public List<ResultMessage> ErrorsMessages
        {
            get
            {
                return Messages?.Where(m => m.Type == ResultMessageType.Error).ToList();
            }
        }

        public Result()
        {

        }

        public Result(bool success, List<ResultMessage> resultMessages = null, List<ValidationError> validationErrors = null)
        {
            Success = success;
            if (resultMessages != null)
            {
                Messages.AddRange(resultMessages);
            }
            if (validationErrors != null)
            {
                ValidationErrors.AddRange(validationErrors);
            }
        }





        public virtual void AddMessage(ResultMessage message)
        {
            Messages.Add(message);
        }

        public virtual void AddErrorMessage(string message, string code = null)
        {
            Messages.Add(ResultMessage.Error(message, code));
        }

        public virtual void AddSuccessMessage(string message, string code = null)
        {
            Messages.Add(ResultMessage.Success(message, code));
        }

        public virtual void AddWarningMessage(string message, string code = null)
        {
            Messages.Add(ResultMessage.Error(message, code));
        }

        public virtual void AddInformationMessage(string message, string code = null)
        {
            Messages.Add(ResultMessage.Information(message, code));
        }
    }
}
