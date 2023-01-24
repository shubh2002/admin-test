using InventoryManagement.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public class ApplicationConstants
    {
        public static List<SelectListItem> GetTargets()
        {
            List<SelectListItem> targets = new List<SelectListItem>();
            targets.Add(new SelectListItem() { Value = Target.Both.ToString(), Text = Target.Both.ToString() });
            targets.Add(new SelectListItem() { Value = Target.Mobile.ToString(), Text = Target.Mobile.ToString() });
            targets.Add(new SelectListItem() { Value = Target.Website.ToString(), Text = Target.Website.ToString() });
            return targets;
        }
        public static List<SelectListItem> GetFlags()
        {
            List<SelectListItem> targets = new List<SelectListItem>();
            targets.Add(new SelectListItem() { Value = "True", Text = "True" });
            targets.Add(new SelectListItem() { Value = "False", Text = "False" });
            return targets;
        }
        public static List<SelectListItem> GetItemOrdering()
        {
            return Enumerable.Range(1, 10).Select(x => new SelectListItem() { Value = x.ToString(), Text = x.ToString() }).ToList();
        }
    }
}
