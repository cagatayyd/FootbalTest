using FootballTeam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootbalTest.Controllers
{
    public class PSGController : Controller
    {
        // GET: PSG
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetPlayersPSG()
        {
            PlayersPSG player = new PlayersPSG();
            List<PlayersPSG> players = player.List();
            return View(players);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var player = new PlayersPSG();
            return View(player);
        }
        [HttpPost]
        public ActionResult Create(PlayersPSG player)
        {
            PlayersPSG players = new PlayersPSG();
            players.InsertPSG( player.Name, player.Surname, player.Position, player.Age);
            return RedirectToAction("GetPlayersPSG");
        }
        public ActionResult Edit(int id)
        {
            PlayersPSG player = new PlayersPSG();
            List<PlayersPSG> players = player.List();

            PlayersPSG selectedPlayer = players.FirstOrDefault(p => p.PlayerID == id);

            if (selectedPlayer == null)
            {
                return HttpNotFound();
            }

            return View(selectedPlayer);
        }

        [HttpPost]
        public ActionResult Edit(PlayersPSG player)
        {
            PlayersPSG players = new PlayersPSG();
            players.UpdatePSG(player.PlayerID, player.Name, "Name");
            players.UpdatePSG(player.PlayerID, player.Surname, "Surname");
            players.UpdatePSG(player.PlayerID, player.Position, "Position");
            players.UpdatePSG(player.PlayerID, null, "Age", player.Age);
            return RedirectToAction("GetPlayersPSG");
        }
        [HttpPost]

        public ActionResult DeletePSG(PlayersPSG player)
        {
            PlayersPSG players = new PlayersPSG();
            players.DeletePSG(player.PlayerID);
            return RedirectToAction("GetPlayersPSG");
        }
    }
}