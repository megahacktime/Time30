using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideas.Google.GCM
{
    public interface INotificacao
    {
        int? Id { get; set; }
        string Title { get; set; }
        string Message { get; set; }
        string Image { get; set; }
        string Icon { get; set; }
        string Sound { get; set; }
        int Count { get; set; }
        string Content { get; set; }
    }
}
