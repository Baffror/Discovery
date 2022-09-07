using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Discovery.Models
{
    public class ForgetPassswordViewModel
    {

        [EmailAddress, Required]
        public string Email { get; set; }

    }
}
