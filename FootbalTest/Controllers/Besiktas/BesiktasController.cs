using FootballTeam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace FootbalTest.Controllers
{
    public class BesiktasController : Controller
    {
        // GET: Besiktas
        public ActionResult Index()
        {
            return View();
        }
        #region List
        public ActionResult GetPlayersBesiktas()
        {
            PlayersBesiktas player = new PlayersBesiktas();
            List<PlayersBesiktas> players = player.List();
            return View(players);
        }

        #endregion

        #region Create/Edit/Delete
        [HttpGet]
        public ActionResult Create()
        {
            var player = new PlayersBesiktas();
            return View(player);
        }
        [HttpPost]
        public ActionResult Create(PlayersBesiktas player)
        {
            PlayersBesiktas players = new PlayersBesiktas();
            players.InsertBesiktas(player.Name, player.Surname, player.Position, player.Age);
            return RedirectToAction("GetPlayersBesiktas");
        }
        public ActionResult Edit(int id)
        {
            PlayersBesiktas player = new PlayersBesiktas();
            List<PlayersBesiktas> players = player.List();

            PlayersBesiktas selectedPlayer = players.FirstOrDefault(p => p.PlayerID == id);

            if (selectedPlayer == null)
            {
                return HttpNotFound();
            }

            return View(selectedPlayer);
        }

        [HttpPost]
        public ActionResult Edit(PlayersBesiktas player)
        {
            PlayersBesiktas players = new PlayersBesiktas();
            players.UpdateBesiktas(player.PlayerID, player.Name, "Name");
            players.UpdateBesiktas(player.PlayerID, player.Surname, "Surname");
            players.UpdateBesiktas(player.PlayerID, player.Position, "Position");
            players.UpdateBesiktas(player.PlayerID, null, "Age", player.Age);
            return RedirectToAction("GetPlayersBesiktas");
        }
        [HttpPost]

        public ActionResult DeleteBesiktas(PlayersBesiktas player)
        {
            PlayersBesiktas players = new PlayersBesiktas();
            players.DeleteBesiktas(player.PlayerID);
            return RedirectToAction("GetPlayersBesiktas");
        }
    }
    #endregion

}