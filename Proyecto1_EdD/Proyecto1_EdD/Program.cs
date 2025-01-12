﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_EdD
{
    internal class Program
    {
        const int tamaño = 10;

        static int[] numPago = new int[tamaño];
        static string[] fecha = new string[tamaño];
        static string[] hora = new string[tamaño];
        static string[] cedula = new string[tamaño];
        static string[] nombre = new string[tamaño];
        static string[] apellido1 = new string[tamaño];
        static string[] apellido2 = new string[tamaño];
        static int[] numCaja = new int[tamaño];
        static int[] tipoServicio = new int[tamaño];
        static string[] numFactura = new string[tamaño];
        static float[] montoAPagar = new float[tamaño];
        static float[] montoComision = new float[tamaño];
        static float[] montoDeducido = new float[tamaño];
        static float[] montoPagadoCliente = new float[tamaño];
        static float[] vuelto = new float[tamaño];

        static int indiceActual = 0;

        static void Main(string[] args)
        {
            Console.Clear();
            MostrarMenuPrincipal();
        }

        public static void MostrarMenuPrincipal()
        {
            string opcion = "";
            string menuPrincipal = "**Menú Principal**\n";
            menuPrincipal += "1. Inicialiar vectores\n";
            menuPrincipal += "2. Realizar pagos\n";
            menuPrincipal += "3. Consultar pagos\n";
            menuPrincipal += "4. Modifiar pagos\n";
            menuPrincipal += "5. Eliminar pagos\n";
            menuPrincipal += "6. Submenú reportes\n";
            menuPrincipal += "7. Salir";
            do
            {
                Console.WriteLine(menuPrincipal);
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        IniciarVectores();
                        break;
                    case "2":
                        RealizarPagos();
                        break;
                    case "3":
                        ConsultarPagos();
                        break;
                    case "4":
                        modificarPagos();
                        break;
                    case "5":
                        EliminarPagos();
                        break;
                    case "6":
                        Console.Clear(); // Limpia la pantalla
                        SubMenu();
                        break;
                    case "7":
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (opcion != "7");
        }

        public static void SubMenu()
        {
            Console.Clear(); // Limpia la pantalla
            string opcion = "";
            string menuSub = "**Submenú reportes**\n";
            menuSub += "1. Ver todos los pagos\n";
            menuSub += "2. Ver pagos por tipo de servicio\n";
            menuSub += "3. Ver pagos por código de caja\n";
            menuSub += "4. Ver dinero comisionado por servicios\n";
            menuSub += "5. Regresar al menú principal";
            do
            {
                Console.WriteLine(menuSub);
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        VerTodosLosPagos();
                        break;
                    case "2":
                        VerPagosPorTipoServicio();
                        break;
                    case "3":
                        VerPagosPorCodigoCaja();
                        break;
                    case "4":
                        VerDineroComisionado();
                        break;
                    case "5":
                        Console.Clear(); // Limpia la pantalla
                        MostrarMenuPrincipal();
                        break;
                    default:
                        break;
                }
            } while (true);
        }
        public static void IniciarVectores()
        {
            for (int i = 0; i < tamaño; i++)
            {
                numPago[i] = 0;
                fecha[i] = "";
                hora[i] = "";
                cedula[i] = "";
                nombre[i] = "";
                apellido1[i] = "";
                apellido2[i] = "";
                numCaja[i] = 0;
                tipoServicio[i] = 0;
                numFactura[i] = "";
                montoAPagar[i] = 0;
                montoComision[i] = 0;
                montoDeducido[i] = 0;
                montoPagadoCliente[i] = 0;
                vuelto[i] = 0;
            }
            indiceActual = 0;
            Console.Clear(); // Limpia la pantalla
            Console.WriteLine("Vectores inicializados con éxito.");
            Console.WriteLine("Presione cualquier tecla para continuar");


        }
        public static void RealizarPagos() //Incompleto *IVÁN*
        {
            while (indiceActual < tamaño)
            {
                numPago[indiceActual] = indiceActual + 1;
                Console.WriteLine($"Número de pago: {indiceActual + 1}");

                DateTime now = DateTime.Now;
                Console.WriteLine("Fecha y hora actual:" + now);
                fecha[indiceActual] = Convert.ToString(now);

                Console.WriteLine("Ingrese su número de cédula:");
                cedula[indiceActual] = Console.ReadLine();

                Console.WriteLine("Ingrese su nombre: ");
                nombre[indiceActual] = Console.ReadLine();

                Console.WriteLine("Ingrese su primer apellido: ");
                apellido1[indiceActual] = Console.ReadLine();

                Console.WriteLine("Ingrese su segundo apellido: ");
                apellido2[indiceActual] = Console.ReadLine();

                Random randm = new Random();
                numCaja[indiceActual] = randm.Next(1, 4);

                Console.WriteLine("Ingrese el tipo de servicio por el cual realiza su pago. (1: Luz, 2: Teléfono, 3: Agua): ");
                tipoServicio[indiceActual] = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese el número de factura: ");
                numFactura[indiceActual] = Console.ReadLine();

                Console.WriteLine("Ingrese el monto a pagar: ");
                montoAPagar[indiceActual] = float.Parse(Console.ReadLine());

                //Monto comision y monto deducido van aquí
                float comision = 0;
                float montoFacturado = montoAPagar[indiceActual];
                switch (tipoServicio[indiceActual])
                {
                    case 1:
                        comision = 0.04f;
                        break;
                    case 2:
                        comision = 0.055f;
                        break;
                    case 3:
                        comision = 0.065f;
                        break;
                }

                montoComision[indiceActual] = montoFacturado * comision;

                Console.WriteLine(montoComision[indiceActual]);

                Console.WriteLine("Ingrese el monto que paga el cliente: ");
                montoPagadoCliente[indiceActual] = float.Parse(Console.ReadLine());

                if (montoPagadoCliente[indiceActual] < montoAPagar[indiceActual])
                {
                    Console.WriteLine("Cantidad isuficiente.");
                    return;
                }

                vuelto[indiceActual] = montoPagadoCliente[indiceActual] - montoAPagar[indiceActual];

                Console.WriteLine("Pago realizado correctamente.");
                indiceActual++;
                if (indiceActual >= tamaño)
                {
                    Console.WriteLine("Vectores Llenos");
                    break;
                }

                Console.WriteLine("¿Desea realizar otro pago? s/n: ");
                string continuar = Console.ReadLine();
                if (continuar.ToLower() != "s")
                {
                    break;
                }
            }
        }

        public static void ConsultarPagos()
        {
            Console.WriteLine("Ingrese el número de pago que desea consultar: ");
            int numeroPago = int.Parse(Console.ReadLine());

            bool encontrado = false;
            for (int i = 0; i < tamaño; i++)
            {
                if (numPago[i] == numeroPago)
                {
                    MostrarPago(i);
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Pago no se encuentra registrado.");
            }
        }

        // modificarpagos() va aquí *IVÁN*
        public static void modificarPagos()
        {
            Console.WriteLine("Ingrese el número de pago que desea modificar: ");
            int numeroPago = int.Parse(Console.ReadLine());

            bool encontrado = false;
            for (int i = 0; i < tamaño; i++)
            {
                if (numPago[i] == numeroPago)
                {
                    edicion(i);
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Pago no se encuentra registrado.");
            }
        }

        public static void mostrarRegistro(int indice)
        {
            Console.WriteLine($"Número de Pago: {numPago[indice]}");
            Console.WriteLine($"Fecha: {fecha[indice]}");
            Console.WriteLine($"Cédula: {cedula[indice]}");
            Console.WriteLine($"Nombre: {nombre[indice]}");
            Console.WriteLine($"Primer Apellido: {apellido1[indice]}");
            Console.WriteLine($"Segundo Apellido: {apellido2[indice]}");
            Console.WriteLine($"Número de Caja: {numCaja[indice]}");
            Console.WriteLine($"Tipo de Servicio: {tipoServicio[indice]}");
            Console.WriteLine($"Monto a Pagar: {montoAPagar[indice]}");
            Console.WriteLine($"Monto Deducido: {montoDeducido[indice]}");
            Console.WriteLine($"Monto Pagado por el Cliente: {montoPagadoCliente[indice]}");
            Console.WriteLine($"Vuelto: {vuelto[indice]}");
        }

        public static void edicion(int indice)
        {
            Console.Clear(); // Limpia la pantalla

            mostrarRegistro(indice);
            string opcion = "";
            string menuOpciones = "**Submenú reportes**\n";
            menuOpciones += "1. Modificar Cédula";
            menuOpciones += "2. Modificar Nombre\n";
            menuOpciones += "3. Modificar Primer Apellido\n";
            menuOpciones += "4. Modificar Segundo Apellido\n";
            menuOpciones += "5. Modificar tipo de Servicio";
            menuOpciones += "6. Modificar Monto a Pagar";
            menuOpciones += "7. Modificar Monto Pagado por el Cliente";
            menuOpciones += "8. Menu Principal";
            do
            {
                Console.WriteLine(menuOpciones);
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Dato registrado:" + cedula[indice]);
                        Console.WriteLine("Ingrese su número de cédula:");
                        cedula[indice] = Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Dato registrado:" + nombre[indice]);
                        Console.WriteLine("Ingrese su nombre:");
                        nombre[indice] = Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("Dato registrado:" + apellido1[indice]);
                        Console.WriteLine("Ingrese su primer apellido:");
                        apellido1[indice] = Console.ReadLine();
                        break;
                    case "4":
                        Console.WriteLine("Dato registrado:" + apellido2[indice]);
                        Console.WriteLine("Ingrese su primer apellido:");
                        apellido2[indice] = Console.ReadLine();
                        break;
                    case "5":
                        Console.WriteLine("Dato registrado:" + tipoServicio[indice]);
                        Console.WriteLine("Ingrese el tipo de servicio:");
                        tipoServicio[indice] = int.Parse(Console.ReadLine());
                        float comision = 0;
                        float montoFacturado = montoAPagar[indice];
                        switch (tipoServicio[indice])
                        {
                            case 1:
                                comision = 0.04f;
                                break;
                            case 2:
                                comision = 0.055f;
                                break;
                            case 3:
                                comision = 0.065f;
                                break;
                        }
                        montoComision[indice] = montoFacturado * comision;
                        break;
                    case "6":
                        Console.WriteLine("Dato registrado:" + montoAPagar[indice]);
                        Console.WriteLine("Ingrese el monto a pagar: ");
                        montoAPagar[indiceActual] = float.Parse(Console.ReadLine());
                        comision = 0;
                        montoFacturado = montoAPagar[indice];
                        switch (tipoServicio[indice])
                        {
                            case 1:
                                comision = 0.04f;
                                break;
                            case 2:
                                comision = 0.055f;
                                break;
                            case 3:
                                comision = 0.065f;
                                break;
                        }
                        montoComision[indice] = montoFacturado * comision;
                        break;
                    case "7":
                        Console.WriteLine("Dato registrado:" + montoPagadoCliente[indice]);
                        Console.WriteLine("Ingrese el monto que paga el cliente: ");
                        montoPagadoCliente[indice] = float.Parse(Console.ReadLine());

                        if (montoPagadoCliente[indice] < montoAPagar[indice])
                        {
                            Console.WriteLine("Cantidad isuficiente.");
                            return;
                        }
                        break;
                    case "8":
                        MostrarMenuPrincipal();
                        break;
                    default:
                        break;
                }
            } while (true);
        }


        public static void EliminarPagos()
        {
            Console.Write("Ingrese el número de pago que desea eliminar: ");
            int numeroPago = int.Parse(Console.ReadLine());

            for (int i = 0; i < tamaño; i++)
            {
                if (numPago[i] == numeroPago)
                {
                    MostrarPago(i);

                    Console.Write("¿Está seguro de eliminar el pago? s/n: ");
                    string confirmar = Console.ReadLine();
                    if (confirmar.ToLower() == "s")
                    {
                        numPago[i] = 0;
                        fecha[i] = "";
                        cedula[i] = "";
                        nombre[i] = "";
                        apellido1[i] = "";
                        apellido2[i] = "";
                        numCaja[i] = 0;
                        tipoServicio[i] = 0;
                        numFactura[i] = "";
                        montoAPagar[i] = 0;
                        montoComision[i] = 0;
                        montoDeducido[i] = 0;
                        montoPagadoCliente[i] = 0;
                        vuelto[i] = 0;

                        Console.WriteLine("La información ya fue eliminada.");
                    }
                    else
                    {
                        Console.WriteLine("La información no fue eliminada.");
                    }
                    return;
                }
            }
            Console.WriteLine("Pago no se encuentra registrado.");
        }

        public static void MostrarPago(int indice)
        {
            Console.WriteLine($"Número de Pago: {numPago[indice]}");
            Console.WriteLine($"Fecha: {fecha[indice]}");
            Console.WriteLine($"Hora: {hora[indice]}");
            Console.WriteLine($"Cédula: {cedula[indice]}");
            Console.WriteLine($"Nombre: {nombre[indice]}");
            Console.WriteLine($"Primer Apellido: {apellido1[indice]}");
            Console.WriteLine($"Segundo Apellido: {apellido2[indice]}");
            Console.WriteLine($"Número de Caja: {numCaja[indice]}");
            Console.WriteLine($"Tipo de Servicio: {tipoServicio[indice]}");
            Console.WriteLine($"Número de Factura: {numFactura[indice]}");
            Console.WriteLine($"Monto a Pagar: {montoAPagar[indice]}");
            Console.WriteLine($"Monto Comisión: {montoComision[indice]}");
            Console.WriteLine($"Monto Deducido: {montoDeducido[indice]}");
            Console.WriteLine($"Monto Pagado por el Cliente: {montoPagadoCliente[indice]}");
            Console.WriteLine($"Vuelto: {vuelto[indice]}");
        }
        public static void VerTodosLosPagos()
        {
            for (int i = 0; i < tamaño; i++)
            {
                if (numPago[i] != 0)
                {
                    MostrarPago(i);
                }
            }
            //Se debe mejorar **
        }
        public static void VerPagosPorTipoServicio()
        {
            Console.WriteLine("Ingrese el tipo de servicio (1: Luz, 2: Teléfono, 3: Agua): ");
            int tipo = int.Parse(Console.ReadLine());

            for (int i = 0; i < tamaño; i++)
            {
                if (tipoServicio[i] == tipo)
                {
                    MostrarPago(i);
                }
            }//Se debe mostrar un mensaje si no hay datos en el tipo de sevicios consultado **
        }
        public static void VerPagosPorCodigoCaja()
        {
            Console.Write("Ingrese el número de caja: ");
            int codigoCaja = int.Parse(Console.ReadLine());

            for (int i = 0; i < tamaño; i++)
            {
                if (numCaja[i] == codigoCaja)
                {
                    MostrarPago(i);
                }
            }//Se debe mostrar un mensaje si no hay datos en el seleccionado **
        }
        public static void VerDineroComisionado()
        {
            for (int i = 0; i < tamaño; i++)
            {
                if (numPago[i] != 0)
                {
                    Console.WriteLine($"Número de Pago: {numPago[i]}");
                    Console.WriteLine($"Monto Comisionado: {montoComision[i]}");
                }// Se debe mejorar **
            }
        }
    }
}


