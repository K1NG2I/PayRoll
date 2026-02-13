using Microsoft.AspNetCore.Mvc;
using RFQ.UI.Application.Interface;
using RFQ.UI.Application.Provider;
using RFQ.UI.Domain.Model;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

namespace RFQ.UI.Controllers
{

    public class BaseController : Controller
    {
        private readonly IMenuServices _menuServices;
        private readonly GlobalClass _globalClass;
        public BaseController(IMenuServices menuServices, GlobalClass globalClass)
        {
            _menuServices = menuServices;
            _globalClass = globalClass;
        }
        public async Task SetMenuAsync()
        {
            try
            {
                // If token is not available, skip menu population
                if (string.IsNullOrEmpty(_globalClass?.Token))
                {
                    ViewData["menulist"] = new List<MenulistModel>();
                    return;
                }

                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(_globalClass.Token);
                string profileid = jwt.Claims.First(c => c.Type == "profileid").Value;
                int profileID = Convert.ToInt32(profileid);
                var menuList = await _menuServices.GetMenu(profileID);
                ViewData["menulist"] = menuList.ToList();
                var profileList = await _menuServices.GetProfileRightsByProfileId(profileID);
                int LinkId = /*Request.Query.ContainsKey("LinkId") ? Convert.ToInt32(Request.Query["LinkId"]) : 0*/ 1;
                if (LinkId != 0)
                {
                    var list = profileList.FirstOrDefault(x => x.LinkId == LinkId);
                    if (list != null)
                    {
                        ViewData["IsAdd"] = list.IsAdd;
                        ViewData["IsEdit"] = list.IsEdit;
                        ViewData["IsView"] = list.IsView;
                        ViewData["IsCancel"] = list.IsCancel;
                    }
                }
                if (menuList.Count() > 0)
                {
                    //menuList = menuList
                    //.Where(item => profileList.Any(x => x.LinkId == item.LinkId && x.IsView))
                    //.ToList();
                    ViewData["menulist"] = menuList.ToList();
                }
            }
            catch
            {
                // If any error occurs while fetching menu (API down, invalid token, etc.),
                // set an empty menu so the UI can still render without crashing.
                ViewData["menulist"] = new List<MenulistModel>();
            }
        }
    }
}
