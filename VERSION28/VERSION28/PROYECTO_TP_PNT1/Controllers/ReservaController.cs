using System;
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
    public class ReservaController : Controller
    {
        private readonly ReservaDatabaseContext _context;

        public ReservaController(ReservaDatabaseContext context)
        {  //se crea la variable contexto 
            _context = context;
        }

        // GET: Reserva
        public async Task<IActionResult> Index() 
        {
            return View(await _context.Reservas.Include(r => r.cliente).Include(r => r.alojamiento).ToListAsync());
            
        }

        // GET: Reserva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .FirstOrDefaultAsync(m => m.idReserva == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reserva/Create
        public IActionResult Create()
        {   
            ViewBag.almessage = listaAlojamientos();

            ViewBag.clmessage = listaClientes();
            
            return View();
        }


        // POST: Reserva/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idReserva, idAlojamiento, alojamiento,idCliente,cliente, entrada,salida,cantPersonas,desayuno")] Reserva reserva)
        {
            //estas listas que estan en el get deben estar en el POST tambien
            ViewBag.almessage = listaAlojamientos();
            ViewBag.clmessage = listaClientes();

            if (ModelState.IsValid)
            {

                    reserva.cliente = _context.Clientes.Find(reserva.idCliente);
                    reserva.alojamiento = _context.Alojamientos.Find(reserva.idAlojamiento);

                    if (habitacionesDisponible(reserva))
                    {  
                        if (!clienteConReserva(reserva))
                        {
                            reserva.CantHabitaciones = cantHabitacionesRequeridas(reserva.alojamiento, reserva.cantPersonas);
                            reserva.precioTotal = precioTotal(reserva);
                            descontarHabitaciones(reserva.alojamiento, reserva.CantHabitaciones);
                            _context.Add(reserva);
                            await _context.SaveChangesAsync();
                            return RedirectToAction(nameof(Index));
                        }
                        else
                        {
                            ViewBag.ReservaExistente = "El cliente ya cuenta con una reserva para la misma fecha";
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.ErrorHabitaciones = "Las cantidad de personas excede el limite de habitaciones disponibles.\n Habitaciones disponibles: " + reserva.alojamiento.cantHabitacionesDisponibles + ". \n Capacidad por habitacion: " + reserva.alojamiento.capacidadHabitaciones + " personas";
                        return View();
                    }
            }
            //si el modelo no es valido sigue devolviendo la vista Create con los datos que esten cargados
            return View(reserva);
        }




        // GET: Reserva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {   //estas son las listas que usa en la vista del edit, al igual que en las otras actions
            ViewBag.almessage = listaAlojamientos();

            ViewBag.clmessage = listaClientes();


            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.FindAsync(id);

            if (reserva == null)
            {
                return NotFound();
            }
            return View(reserva);
        }

        // POST: Reserva/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
       //el BIND establece las propiedades a las cuales se va acceder
        public async Task<IActionResult> Edit(int id, [Bind("idReserva, idAlojamiento, alojamiento,idCliente,cliente, entrada,salida,cantPersonas,desayuno,CantHabitaciones, precioTotal")] Reserva reserva)
        {
            ViewBag.almessage = listaAlojamientos();

            ViewBag.clmessage = listaClientes();
            int cantRequeridaHab = 0;
            if (ModelState.IsValid)
            {
                //se setea el cliente y el alojamiento
                reserva.cliente = _context.Clientes.Find(reserva.idCliente);
                reserva.alojamiento = _context.Alojamientos.Find(reserva.idAlojamiento);

                // se crean las variables
                int cantActualHabitaciones = cantHabitacionesRequeridas(reserva.alojamiento, reserva.cantPersonas);
                int cantAntiguaHabitaciones = _context.Reservas.Find(reserva.idReserva).CantHabitaciones; 
                bool descontar = cantAntiguaHabitaciones < cantActualHabitaciones; 
               

                 if (descontar)
                 {
                    cantRequeridaHab = cantActualHabitaciones - cantAntiguaHabitaciones; 
                 }
                 else if(cantActualHabitaciones < cantAntiguaHabitaciones)
                 {
                     cantRequeridaHab = cantActualHabitaciones - cantAntiguaHabitaciones;
                     actualizarHabitaciones(reserva.alojamiento, cantRequeridaHab); 
                 }

                try 
                {
                    if (habitacionesDisponible(reserva, cantRequeridaHab))
                    {

                        if (!clienteConReserva(reserva)) 
                        {
                            if (descontar)  
                            {
                                descontarHabitaciones(reserva.alojamiento, cantRequeridaHab);
                            }
                           
                            reserva.CantHabitaciones = cantActualHabitaciones;
                            reserva.precioTotal = precioTotal(reserva);

                            _context.Remove(_context.Reservas.Find(id));
                            _context.Add(reserva);
                            await _context.SaveChangesAsync();

                        }
                        else
                        {
                            ViewBag.ReservaExistente = "El cliente ya cuenta con una reserva para la misma fecha";
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.ErrorHabitaciones = "Las cantidad de personas excede el limite de habitaciones disponibles.\n Habitaciones disponibles: " + reserva.alojamiento.cantHabitacionesDisponibles + ". \n Capacidad por habitacion: " + reserva.alojamiento.capacidadHabitaciones + " personas";
                        return View();
                    }
                }
                catch (DbUpdateConcurrencyException dE)
                {
                    Console.WriteLine(dE.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reserva);
        }

        // GET: Reserva/Delete/5     // desde la base de datos mandas a la pagina
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.FirstOrDefaultAsync(m => m.idReserva == id);

            if (reserva == null)
            {
                return NotFound();
            }


            return View(reserva);
        }

        // POST: Reserva/Delete/5      //tomas los datos desde la pagina y los envias a la base de datos
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {   
            var reserva = await _context.Reservas.FindAsync(id);

            int cant1 = reserva.CantHabitaciones;
            int? idAloj = reserva.idAlojamiento;
            actualizarHabitaciones(buscarAlojamiento((int)idAloj), cant1);

            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        //METODO PARA ENLISTAR A LOS ALOJAMIENTOS DE LA BASE DE DATOS
        private List<Alojamiento> listaAlojamientos()
        {
            List<Alojamiento> al = new List<Alojamiento>();
            al = (from a in _context.Alojamientos select a).ToList();
            return al;
        }

        //METODO PARA ENLISTAR A LOS CLIENTES DE LA BASE DE DATOS
        private List<Cliente> listaClientes()
        {
            List<Cliente> cl = new List<Cliente>();
            cl = (from c in _context.Clientes select c).ToList();
            return cl;
        }

        //METODO QUE DEVUELVE EL PRECIO TOTAL DE LA RESERVA
        private double precioTotal(Reserva reserva)
        {
            double precio = (((reserva.salida - reserva.entrada).TotalDays * precioAlojamiento((int)reserva.idAlojamiento)) * reserva.cantPersonas) * reserva.CantHabitaciones;
            if (reserva.desayuno)
            {
                precio += (precioDesayuno((int)reserva.idAlojamiento)) * reserva.cantPersonas;
            }
            return Math.Round(precio);
        }
        private Alojamiento buscarAlojamiento(int id)
        {
            Alojamiento alojamientoId = _context.Alojamientos.Where(a => a.idAlojamiento == id).FirstOrDefault();
            return alojamientoId;
        }

        //METODO QUE TRAE EL PRECIO DEL ALOJAMIENTO POR SU ID
        public double precioAlojamiento(int id)
        {
            return buscarAlojamiento(id).precio;
        }

        //METODO QUE TRAE EL PRECIO DEL DESAYUNO DEL ALOJAMIENTO POR SU ID
        public double precioDesayuno(int id)
        {
            return buscarAlojamiento(id).precioDesayuno;
        }

        //METODO QUE VALIDA SI HAY SUFICIENTES HABITACIONES PARA LA RESERVA
        private bool habitacionesDisponible(Reserva reserva)
        {
            Alojamiento alojamiento = buscarAlojamiento((int)reserva.idAlojamiento);
            int cantHabDisp = alojamiento.cantHabitacionesDisponibles;
            int habTotales = cantHabitacionesRequeridas(alojamiento, reserva.cantPersonas);
            bool disponible = habTotales <= cantHabDisp;
            return disponible;
        }
        private bool habitacionesDisponible(Reserva reserva, int cantHab)
        {
            Alojamiento alojamiento = buscarAlojamiento((int)reserva.idAlojamiento);
            int cantHabDisp = alojamiento.cantHabitacionesDisponibles;

            bool disponible = cantHab <= cantHabDisp;
            return disponible;
        }

        //DESCUENTA EN EL ALOJAMIENTO LAS HABITACIONES 
        private void descontarHabitaciones(Alojamiento alojamiento, int habTotales)
        {
            alojamiento.cantHabitacionesDisponibles -= habTotales;
        }

        //ACTUALIZA EN EL ALOJAMIENTO LAS HABITACIONES 
        private void actualizarHabitaciones(Alojamiento alojamiento, int habTotales)
        {
            alojamiento.cantHabitacionesDisponibles += habTotales;
        }

        //ALGORITMO PARA SACAR LA CANTIDAD DE HABITACIONES NECESARIAS
        private int cantHabitacionesRequeridas(Alojamiento alojamiento, int cantPers)
        {
            int capPersXHab = alojamiento.capacidadHabitaciones;
            double resultado = (double)cantPers / (double)capPersXHab;
            //redondeamos el numero
            int habTotales = (int)Math.Ceiling(resultado);
            return habTotales;
        }

        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(r => r.idReserva == id);
        }

        private bool clienteConReserva(Reserva reserva)
        {  // aca hicimos dos validaciones que va a ir modificando la variable rExistente.
           
            bool rExistente = false;
            List<Reserva> reservas = new List<Reserva>();
            if (_context.Reservas.Any(r => r.idCliente == reserva.idCliente && r.idAlojamiento == reserva.idAlojamiento))
            {
                // GENERA UNA LISTA DE RESERVAS CON LA CONSULTA CUYA CONDICION ES QUE SEA EL MISMO CLIENTE Y EL MISMO ALOJAMIENTO
                reservas = (from r in _context.Reservas where r.idCliente == reserva.idCliente && r.idAlojamiento == reserva.idAlojamiento select r).ToList();
                // ENVIA LA LISTA A EL ALGORITMO QUE COMPRUEBA SI EXISTE LA FECHA RESERVADA
                rExistente = fechaReservada(reservas, reserva);
            }

            if (!rExistente && _context.Reservas.Any(r => r.idCliente == reserva.idCliente))
            {
                //LISTA DE RESERVAS DEL CLIENTE
                reservas = (from r in _context.Reservas where r.idCliente == reserva.idCliente select r).ToList();
                //COMPRUEBA SI YA REALIZO UNA RESERVA
                rExistente = fechaReservada(reservas, reserva);
            }

            return rExistente;
        }

        private bool fechaReservada(List<Reserva> reservas, Reserva reserva)
        {
            bool rExistente = false;
            int i = 0;
            Reserva r = reservas[i];
            //ciclo para recorrer las reservas
            while (reservas.Count > i && rExistente == false && r.idReserva != reserva.idReserva)
            {
                // SI LA RESERVA A COMPARAR ES MAYOR A LA SALIDA DE LA RESERVA COMPARADA
                // O
                // SI LA ENTRADA DE LA RESERVA COMPARADA ES MAYOR A LA SALIDA DE LA RESERVA A COMPARAR
                if (r.salida < reserva.entrada || r.entrada > reserva.salida)
                {
                    i++;
                }
                else
                //sino quiere decir que la reserva existe
                {
                    rExistente = true;
                }

            }
            return rExistente;

        }
    }
}
