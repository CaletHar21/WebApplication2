using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly BancaonlinesvContext _context;

        public ClientesController(BancaonlinesvContext context)
        {
            _context = context;
        }


        [HttpGet("login")]
        public async Task<ActionResult> Login(string alias, string contrasena)
        {
            try
            {
                // Buscar el usuario con el alias proporcionado en la base de datos
                var usuario = await _context.Clientes.FirstOrDefaultAsync(c => c.Alias == alias);

                if (usuario == null)
                {
                    // Si no se encuentra el usuario, devolver un código 404 (No encontrado)
                    return NotFound();
                }

                // Verificar si la contraseña proporcionada coincide con la contraseña almacenada
                if (usuario.Contrasena == contrasena)
                {
                    // Si las contraseñas coinciden, devolver un código 200 (Éxito)
                    return Ok();
                }
                else
                {
                    // Si las contraseñas no coinciden, devolver un código 401 (No autorizado)
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que pueda ocurrir durante la consulta
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar la solicitud de inicio de sesión" + ex);
            }
        }


        [HttpGet("saldo-y-numero-cuenta")]
        public async Task<ActionResult> ObtenerSaldoYNumeroCuenta(string alias)
        {
            try
            {
                var resultado = await (from cliente in _context.Clientes
                                       join detalleProducto in _context.Productosactivosdetalles on cliente.Clienteid equals detalleProducto.Clienteid
                                       join cuenta in _context.Cuentas on cliente.Clienteid equals cuenta.Clienteid
                                       join detalleCuenta in _context.Cuentadetalles on cuenta.Cuentaid equals detalleCuenta.Cuentaid
                                       join tipoCuenta in _context.Tipocuentas on cuenta.Tipocuentaid equals tipoCuenta.Tipocuentaid
                                       where cliente.Alias == alias
                                       select new
                                       {
                                           cliente.Clienteid,
                                           cliente.Alias,
                                           NumeroCuenta = cuenta.Ncuenta,
                                           TipoCuenta = tipoCuenta.Nombre,
                                           Saldo = detalleCuenta.Saldo,
                                           
                                       }).FirstOrDefaultAsync();

                if (resultado == null)
                {
                    // Si no se encuentra el cliente, devolver un código 404 (No encontrado)
                    return NotFound();
                }

                // Si se encuentra el cliente, devolver los detalles de la cuenta
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que pueda ocurrir durante la consulta
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el saldo y número de cuenta" + ex);
            }
        }


        [HttpGet("historial-cuenta")]
        public async Task<ActionResult> ObtenerHistorialCuenta(string alias)
        {
            try
            {
                var historial = await (from cliente in _context.Clientes
                                       join detalleProducto in _context.Productosactivosdetalles on cliente.Clienteid equals detalleProducto.Clienteid
                                       join cuenta in _context.Cuentas on cliente.Clienteid equals cuenta.Clienteid
                                       join detalleCuenta in _context.Cuentadetalles on cuenta.Cuentaid equals detalleCuenta.Cuentaid
                                       where cliente.Alias == alias
                                       select new
                                       {
                                           cliente.Clienteid,
                                           cliente.Alias,
                                           NumeroCuenta = cuenta.Ncuenta,
                                           Saldo = detalleCuenta.Saldo,
                                           TipoTransaccion = detalleCuenta.Abono != null ? "Abono" : "Retiro",
                                           DetalleTransaccion = detalleCuenta.Detalle
                                       }).ToListAsync();

                if (historial == null || historial.Count == 0)
                {
                    // Si no se encuentra el historial de transacciones, devolver un código 404 (No encontrado)
                    return NotFound();
                }

                // Devolver el historial de transacciones
                return Ok(historial);
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que pueda ocurrir durante la consulta
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el historial de transacciones de la cuenta" + ex);
            }
        }


        [HttpGet("prestamo-encabezado")]
        public async Task<ActionResult> ObtenerPrestamoEncabezado(string alias)
        {
            try
            {
                var prestamoEncabezado = await (from cliente in _context.Clientes
                                                join detalleProducto in _context.Productosactivosdetalles on cliente.Clienteid equals detalleProducto.Clienteid
                                                join prestamo in _context.Prestamos on detalleProducto.Productosactivosdetalleid equals prestamo.Productosactivosdetalleid
                                                join productoCatalogo in _context.Productoscatalogos on detalleProducto.Productoscatalogoid equals productoCatalogo.Productoscatalogoid
                                                where cliente.Alias == alias
                                                select new
                                                {
                                                    cliente.Clienteid,
                                                    cliente.Alias,
                                                    NombreProducto = productoCatalogo.Nombre,
                                                    MontoPrestamo = prestamo.Monto
                                                }).FirstOrDefaultAsync();

                if (prestamoEncabezado == null)
                {
                    // Si no se encuentra el préstamo, devolver un código 404 (No encontrado)
                    return NotFound();
                }

                // Si se encuentra el préstamo, devolver los detalles del préstamo
                return Ok(prestamoEncabezado);
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que pueda ocurrir durante la consulta
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el préstamo del encabezado" + ex);
            }
        }


        [HttpGet("tarjetas")]
        public async Task<ActionResult> ObtenerTarjetas(string alias)
        {
            try
            {
                var tarjetas = await (from cliente in _context.Clientes
                                      join detalleProducto in _context.Productosactivosdetalles on cliente.Clienteid equals detalleProducto.Clienteid
                                      join tarjeta in _context.Tarjetas on detalleProducto.Productosactivosdetalleid equals tarjeta.Productosactivosdetalleid
                                      join tipoTarjeta in _context.Tipotarjetas on tarjeta.Tipotarjetaid equals tipoTarjeta.Tipotarjetaid
                                      where cliente.Alias == alias
                                      select new
                                      {
                                          cliente.Clienteid,
                                          cliente.Alias,
                                          TipoTarjeta = tipoTarjeta.Nombre,
                                          MontoOtorgado = tarjeta.MontoOtorgado
                                      }).ToListAsync();

                if (tarjetas == null || tarjetas.Count == 0)
                {
                    // Si no se encuentran tarjetas, devolver un código 404 (No encontrado)
                    return NotFound();
                }

                // Devolver las tarjetas
                return Ok(tarjetas);
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que pueda ocurrir durante la consulta
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener las tarjetas: " + ex.Message);
            }
        }




    }
}
