using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideas.Google.GCM
{
    public interface IReceberNotificacao
    {
        /// <summary>
        /// O número do device (dispositivo) gerado pelo GCM
        /// ex.: fYJoVi2oxHw:APA91bFUzDopA2NicEqJRAkcmRmbpuPAL9dybw05Byzup53lw4nZk4oa5zFB6VRjRHv1rdo9IPmTG5G2wMelt0ssGDxxdqRBegyBNoKnDyFIA2BtzA6OaBOao4pLiE9rpVhx_Zl_uaoq
        /// </summary>
        string Id { get; set; }
    }
}
