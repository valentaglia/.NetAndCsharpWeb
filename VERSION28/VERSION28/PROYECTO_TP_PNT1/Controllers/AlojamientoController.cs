using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROYECTO_TP_PNT1.Context;
using PROYECTO_TP_PNT1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTO_TP_PNT1.Controllers
{
    public class AlojamientoController : Controller
    {
        private readonly ReservaDatabaseContext _context;

        public AlojamientoController(ReservaDatabaseContext context)
        {
            _context = context;
        }

        // GET: Alojamiento
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alojamientos.ToListAsync());
        }

        // GET: Alojamiento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alojamiento = await _context.Alojamientos
                .FirstOrDefaultAsync(m => m.idAlojamiento == id);
            if (alojamiento == null)
            {
                return NotFound();
            }

            return View(alojamiento);
        }

        // GET: Alojamiento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alojamiento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idAlojamiento,nombre,direccion,cantHabitacionesDisponibles,capacidadHabitaciones, tipo,precio, precioDesayuno")] Alojamiento alojamiento)
        {
            if (ModelState.IsValid)
            {
                if (!alojamientoExists(alojamiento.direccion))
                {
                    _context.Add(alojamiento);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.alojamientoExistente = "El alojamiento ya existe";
                    return View();
                }

            }
            return View(alojamiento);
        }

        private bool alojamientoExists(String direccion)
        {
            return _context.Alojamientos.Any(a => a.direccion == direccion);
        }

        // GET: Alojamiento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alojamiento = await _context.Alojamientos.FindAsync(id);
            if (alojamiento == null)
            {
                return NotFound();
            }
            return View(alojamiento);
        }

        // POST: Alojamiento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idAlojamiento,nombre,direccion,cantHabitacionesDisponibles,capacidadHabitaciones,tipo,precio, precioDesayuno")] Alojamiento alojamiento)
        {
            if (id != alojamiento.idAlojamiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                { 
                        _context.Update(alojamiento);
                        await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlojamientoExists(alojamiento.idAlojamiento))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(alojamiento);
        }

        // GET: Alojamiento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alojamiento = await _context.Alojamientos
                .FirstOrDefaultAsync(m => m.idAlojamiento == id);
            if (alojamiento == null)
            {
                return NotFound();
            }

            return View(alojamiento);
        }

        // POST: Alojamiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {  //esto valida que si el alojamiento ya esta asociado a una reserva no se pueda borrar
            if (!alojamientoConReserva(id))
            {
                var alojamiento = await _context.Alojamientos.FindAsync(id);
                _context.Alojamientos.Remove(alojamiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.AlojamientoConReserva = "El alojamiento tiene una reserva activa";
                var alojamiento = await _context.Alojamientos
                .FirstOrDefaultAsync(m => m.idAlojamiento == id);
                return View(alojamiento);
            }
        }

        private bool AlojamientoExists(int id)
        {
            return _context.Alojamientos.Any(e => e.idAlojamiento == id);
        }

        private bool alojamientoConReserva(int id)
        {
            bool rExistente = false;
            List<Reserva> reservas = new List<Reserva>();
            if (_context.Reservas.Any(r => r.idAlojamiento == id))
            {
                rExistente = true;
            }
            return rExistente;
        }


    }
}
