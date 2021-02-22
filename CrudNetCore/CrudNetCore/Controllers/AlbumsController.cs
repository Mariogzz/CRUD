using CrudNetCore.Data;
using CrudNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCore.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlbumsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Http Get Index
        public IActionResult Index()
        {
            IEnumerable<Album> listAlbums = _context.Albums;
            return View(listAlbums);
        }

        //Http Get Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Http Post Create
        public IActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                _context.Albums.Add(album);
                _context.SaveChanges();

                TempData["mensaje"] = "El album se ha creado correctamente";
                return RedirectToAction("index");
            }
            return View();
        }

        //Http Get Edit
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var album = _context.Albums.Find(id);
            if(album == null)
            {
                return NotFound();
            }
            return View(album);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Http Post Edit
        public IActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                _context.Albums.Update(album);
                _context.SaveChanges();

                TempData["mensaje"] = "El album se ha actualizado correctamente";
                return RedirectToAction("index");
            }
            return View();
        }

        //Http Get Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var album = _context.Albums.Find(id);
            if (album == null)
            {
                return NotFound();
            }
            return View(album);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Http Post Edit
        public IActionResult DeleteAlbum(int? id)
        {
            //Obtener el libro por ID
            var album = _context.Albums.Find(id);

            if(album == null)
            {
                return NotFound();
            }

            _context.Albums.Remove(album);
            _context.SaveChanges();

            TempData["mensaje"] = "El album se ha eliminado correctamente";
            return RedirectToAction("index");
           
        }
    }
}
