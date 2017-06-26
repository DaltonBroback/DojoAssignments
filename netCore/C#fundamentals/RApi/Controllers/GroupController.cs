using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicApi.Controllers {
    public class GroupController : Controller {
        List<Group> allGroups {get; set;}
        List<Artist> allArtists {get; set;}

        public GroupController() {
            allGroups = JsonToFile<Group>.ReadJson();
            allArtists = JsonToFile<Artist>.ReadJson();
        }
        
        [RouteAttribute("groups")]
        [HttpGet]
        public JsonResult Groups(){
            return Json(allGroups);
        }
        [RouteAttribute("groups/name/{name}")]
        [HttpGet]
        public JsonResult GroupsByName(string name, bool displayArtists){
            var foundGroups = allGroups.Where(group => group.GroupName.Contains(name)).ToList();
            if(displayArtists == true){
                foundGroups = foundGroups.GroupJoin(allArtists,
                    group => group.Id,
                    artist => artist.GroupId,
                    (group, artists) => {group.Members = artists.ToList(); return group;}).ToList();
            }
            return Json(foundGroups);
        }
        [RouteAttribute("groups/id/{id}")]
        [HttpGet]
        public JsonResult GroupsById(int id, bool displayArtists){
            var foundGroups = allGroups.Where(group => group.Id == id).ToList();
            if(displayArtists == true){
                foundGroups = foundGroups.GroupJoin(allArtists,
                    group => group.Id,
                    artist => artist.GroupId,
                    (group, artists) => {group.Members = artists.ToList(); return group;}).ToList();
            }
            return Json(foundGroups);
        }
    }
}