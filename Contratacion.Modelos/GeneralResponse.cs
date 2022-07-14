using System.Collections.Generic;

namespace Contratacion.Modelos
{
    public class GeneralResponse
    {
        public bool Status { get; set; }
        public List<string> Errors { get; set; }
    }

    public class UserNameRequest 
    {
        public string UserName { get; set; }
    }
}
