using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Infrastructure
{
    public class DataTableAjaxRequestUtility
    {
        private HttpRequest _httpRequest;

        public  int Start
        {
            get
            {
                return Convert.ToInt32(_httpRequest.Query["start"]);
            }
        }
        public  int Length
        {
            get
            {
                return Convert.ToInt32(_httpRequest.Query["length"]);
            }
        }
        public  String SearchText
        {
            get
            {
                return _httpRequest.Query["search(value)"];
            }
        }

        public DataTableAjaxRequestUtility(HttpRequest httpRequest)
        {
            _httpRequest = httpRequest;
        }

        public int PageIndex
        {
            get
            {
                if (Length > 0)
                {
                    return (Start / Length) + 1;
                }
                else
                {
                    return 1;
                }
            }
        }

        public int PageSize
        {
            get
            {
                if (Length == 0)
                {
                    return 10;
                }
                else
                {
                    return Length;
                }
            }
        }

        public string GetShortText(string[] columns)
        {
            var method = _httpRequest.Method.ToUpper();
            if (method == "GET")
            {
               return  Readvalues(_httpRequest.Query, columns);
            }
            else if (method == "POST")
            {
               return  Readvalues(_httpRequest.Form, columns);
            }
            else
            {
                throw new InvalidOperationException("Wrong Request");
            }
        }

        public  string Readvalues(IEnumerable<KeyValuePair<string,StringValues>>
                     requestValues,string[] columnNames)
        {
           var  strText = new StringBuilder();

            for (var i = 0; i < columnNames.Length; i++)
            {
                if (requestValues.Any(x => x.Key == $"order[{i}][column]"))
                {
                    if (strText.Length > 0)
                    {
                        strText.Append(",");
                    }
                    var columnValue = requestValues.Where(x => x.Key == $"order[{i}][column]")
                                                     .FirstOrDefault();

                    var DirectionValue = requestValues.Where(x => x.Key == $"order[{i}][dir]")
                                        .FirstOrDefault();


                    var column = int.Parse(columnValue.Value.ToArray()[0]);
                    var direction = DirectionValue.Value.ToArray()[0];
                    var strDirection = $"{columnNames[column]}{(direction == "asc"? "asc":"desc")}";
                    strText.Append(strText);
                   
                
                
                }
            }
            return strText.ToString();


        }
        
    }
}

