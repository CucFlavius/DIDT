using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDT
{
    public class PatchList
    {
        public IDictionary<string, string> patch_timestamp { get; set; }

        public string GetFullUUID()
        {
            if (patch_timestamp == null)
            {
                Debug.Log("patch_timestamp == null");
                return null;
            }

            if (patch_timestamp.TryGetValue("full", out string uuid))
            {
                return uuid;
            }
            else
            {
                Debug.Log("Couldn't find \"full\" UUID");
            }
            return null;
        }
    }
}
