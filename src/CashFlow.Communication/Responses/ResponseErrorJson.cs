using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Communication.Responses;
public class ResponseErrorJson
{
    public List<string> ErrorMessages { get; set; } = new List<string>();

    public ResponseErrorJson(List<string> erroMessages)
    {
         ErrorMessages = erroMessages;
    }
    public ResponseErrorJson(string errorMessage)
    {
        ErrorMessages = [errorMessage];
    }
}
