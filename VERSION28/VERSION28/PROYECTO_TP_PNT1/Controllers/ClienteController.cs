﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PROYECTO_TP_PNT1.Context;
using PROYECTO_TP_PNT1.Models;

namespace PROYECTO_TP_PNT1.Controllers
{
    public class ClienteController : Controller
    {   //es la variable que representa la conexio, que luego se usara por las cciones
        private readonly ReservaDatabaseContext _context;

        public ClienteController(ReservaDatabaseContext context)
        {
            _context = context;
        }

        //muestra por defecto los clientes 
        // GET: Cliente
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes.ToListAsync());
        }

        // GET: Cliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.idCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Cliente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        //el bind trae los datos declarados, y los "guarda" dentro de Cliente para poder usarlos despues
        public async Task<IActionResult> Create([Bind("id,nombre,apellido,dni,edad")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {

                if (!clienteExists(cliente.dni))
                {
                    _context.Add(cliente);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.clienteExistente = "El cliente ya existe";
                    return View();
                }

            }
            return View(cliente);
        }

      

        private bool clienteExists(String dni)
        {
            return _context.Clientes.Any(c => c.dni == dni);
        }

        // GET: Cliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idCliente,nombre,apellido,dni,edad")] Cliente cliente)
        {
            if (id != cliente.idCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                        _context.Update(cliente);
                        await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.idCliente))
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
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.idCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {   
            
            if (!clienteConReserva(id))
            {
                var cliente = await _context.Clientes.FindAsync(id);
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            else
            {
                ViewBag.ClienteConReserva = "El cliente tiene una reserva activa";
                var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.idCliente == id);
                return View(cliente);
            }




        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.idCliente == id);
        }

        private bool clienteConReserva(int id)
        {
            bool rExistente = false;
            List<Reserva> reservas = new List<Reserva>();
            if (_context.Reservas.Any(r => r.idCliente == id))
            {
                rExistente = true;
            }
            return rExistente;
        }
    }
}
