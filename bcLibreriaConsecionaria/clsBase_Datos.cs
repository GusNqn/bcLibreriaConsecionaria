using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bcLibreriaConsecionaria
{
    public class clsBase_Datos
    {
        List<clsVehiculos> listaVehiculos;
        List<clsDistribuidores> listaDistribuidores;
        public clsBase_Datos()
        {
            listaVehiculos = new List<clsVehiculos>();
            listaDistribuidores = new List<clsDistribuidores>();
        }

        #region Metodos

        public bool existeCuitDistribuidor(string cuit)
        {
            clsDistribuidores distribuidor;
            bool existe = false;

            distribuidor = new clsDistribuidores(cuit, "", false);
            if (listaDistribuidores.Contains(distribuidor))
            {
                existe = true;
            }
            return existe;
        }

        public bool existePatenteVehiculo(string patente)
        {
            bool existe = false;
            foreach (clsVehiculos vehiculo in listaVehiculos)
            {
                if (vehiculo.PATENTE == patente)
                {
                    existe = true;
                }
            }
            return existe;
        }

        public bool existeRazonDistribuidor(string razon)
        {
            bool existe = false;
            List<string> razonSocial;

            razonSocial = listaRazonDistribuidores();

            if (razonSocial.Contains(razon))
            {
                existe = true;
            }
            return existe;
        }

        public bool esDistribuidorInternacional(string cuit)
        {
            clsDistribuidores distribuidor = new clsDistribuidores(cuit, "", false);
            int indice = listaDistribuidores.IndexOf(distribuidor);
            if (indice >= 0)
            {
                distribuidor = listaDistribuidores[indice];
            }
            return distribuidor.INTERNACIONAL;
        }

        public string getRazonSocial(string cuit)
        {
            clsDistribuidores distribuidor = new clsDistribuidores(cuit, "", false);
            int indice = listaDistribuidores.IndexOf(distribuidor);
            if (indice >= 0)
            {
                distribuidor = listaDistribuidores[indice];
            }
            return distribuidor.RAZONSOCIAL;
        }

        public List<string> listaRazonDistribuidores()
        {
            List<string> lista;

            lista = new List<string>();

            foreach (clsDistribuidores distribuidor in listaDistribuidores)
            {
                lista.Add(distribuidor.RAZONSOCIAL);
            }

            return lista;
        }

        public int buscarIndiceDist(string valorFiltro, int indiceFiltro)
        {
            int contador = -1;
            int indice = -1;
            int i = 0;
            bool encontrado = false;

            if (valorFiltro == "Nacional")
            {
                while ((i <= listaDistribuidores.Count && (!encontrado)))
                {
                    contador++;
                    if (contador == indiceFiltro)
                    {
                        encontrado = true;
                        indice = i;
                    }
                    i++;
                }
            }
            else if (valorFiltro == "Internacional")
            {
                while ((i <= listaDistribuidores.Count && (!encontrado)))
                {
                    contador++;
                    if (contador == indiceFiltro)
                    {
                        encontrado = true;
                        indice = i;
                    }
                    i++;
                }
            }
            else
            {
                indice = indiceFiltro;
            }
            return indice;
        }

        public clsVehiculos buscarVehiculo(string patente)
        {
            int indice = 0;
            foreach (clsVehiculos vehiculo in listaVehiculos)
            {
                if (vehiculo.PATENTE == patente)
                {
                    indice = listaVehiculos.IndexOf(vehiculo);
                }
            }
            return listaVehiculos[indice];
        }

        public int buscarIndice(string patente)
        {
            return listaVehiculos.IndexOf(buscarVehiculo(patente));
        }

        public bool esAuto(int indice)
        {
            return listaVehiculos[indice].GetType() == typeof(clsAutos);
        }

        public clsAutos datosAuto(string patente)
        {
            clsAutos autoBuscado = new clsAutos();

            foreach (clsVehiculos vehiculo in listaVehiculos)
            {
                if (vehiculo.PATENTE == patente)
                {
                    if (vehiculo.GetType() == typeof(clsAutos))
                    {
                        autoBuscado = (clsAutos)vehiculo;
                    }
                }
            }
            return autoBuscado;
        }

        public clsCamionetas datosCamionetas(string patente)
        {
            clsCamionetas camionetaBuscada = new clsCamionetas();
            foreach (clsVehiculos vehiculo in listaVehiculos)
            {
                if (vehiculo.PATENTE == patente)
                {
                    if (vehiculo.GetType() == typeof(clsCamionetas))
                    {
                        camionetaBuscada = (clsCamionetas)vehiculo;
                    }
                }
            }
            return camionetaBuscada;
        }

        public List<string> listarDistribuidores(string procedencia)
        {
            List<string> lista;

            lista = new List<string>();

            if (procedencia == "Internacional")
            {
                foreach (clsDistribuidores distribuidor in listaDistribuidores)
                {
                    if (distribuidor.INTERNACIONAL)
                    {
                        lista.Add(distribuidor.ToString());
                    }
                }
            }
            else if (procedencia == "Nacional")
            {
                foreach (clsDistribuidores distribuidor in listaDistribuidores)
                {
                    if (!distribuidor.INTERNACIONAL)
                    {
                        lista.Add(distribuidor.ToString());
                    }
                }
            }
            else
            {
                foreach (clsDistribuidores distribuidor in listaDistribuidores)
                {
                    lista.Add(distribuidor.ToString());
                }
            }

            return lista;
        }

        public int cantidadVehiculosDelDistribuidor(string cuitDistribuidor)
        {
            int contador = 0;
            clsDistribuidores distribuidorACompararar = new clsDistribuidores(cuitDistribuidor, getRazonSocial(cuitDistribuidor), esDistribuidorInternacional(cuitDistribuidor));
            foreach (clsVehiculos vehiculos in listaVehiculos)
            {
                if (distribuidorACompararar.Equals(vehiculos.DISTRIBUIDOR))
                {
                    contador++;
                }
            }
            return contador;
        }

        public List<string> listarVehiculos(string tipo_Vehiculo, string marca, string modelo, string cuitDistribuidor, bool usado, bool nuevo, bool cuatroXcuatro, bool tracSimple, string gama)
        {
            List<string> lista;
            bool controlTipoVehiculo, controlMarca, controlDistribuidor, controlModelo, controlUsado, controlNuevo, controlCuaXcua, controlTracSimple, controlGama;

            lista = new List<string>();
            foreach (clsVehiculos vehiculos in listaVehiculos)
            {
                controlTipoVehiculo = false;
                controlMarca = false;
                controlDistribuidor = false;
                controlUsado = false;
                controlCuaXcua = false;
                controlGama = false;
                controlModelo = false;
                controlNuevo = false;
                controlTracSimple = false;

                if (tipo_Vehiculo == "Todos")
                {
                    controlTipoVehiculo = true;
                }
                else if (tipo_Vehiculo == "Auto")
                {
                    controlTipoVehiculo = vehiculos.GetType() == typeof(clsAutos);
                }
                else if (tipo_Vehiculo == "Camioneta")
                {
                    controlTipoVehiculo = vehiculos.GetType() == typeof(clsCamionetas);
                }
                if (vehiculos.GetType() == typeof(clsAutos))
                {
                    clsAutos auto = (clsAutos)vehiculos;
                    switch (marca)
                    {
                        case "Todos":
                            controlMarca = true;
                            if ((modelo == "Todos") || (modelo == string.Empty))
                            {
                                controlModelo = true;
                            }
                            else
                            {
                                controlModelo = modelo == auto.MODELO;
                            }
                            break;
                        default:
                            controlMarca = marca == auto.MARCA;
                            if ((modelo == "Todos") || (modelo == string.Empty))
                            {
                                controlModelo = true;
                            }
                            else
                            {
                                controlModelo = modelo == auto.MODELO;
                            }
                            break;
                    }
                }
                else if (vehiculos.GetType() == typeof(clsCamionetas))
                {
                    clsCamionetas camioneta = (clsCamionetas)vehiculos;
                    switch (marca)
                    {
                        case "Todos":
                            controlMarca = true;
                            if ((modelo == "Todos") || (modelo == string.Empty))
                            {
                                controlModelo = true;
                            }
                            else
                            {
                                controlModelo = modelo == camioneta.MODELO;
                            }
                            break;
                        default:
                            controlMarca = marca == camioneta.MARCA;
                            if ((modelo == "Todos") || (modelo == string.Empty))
                            {
                                controlModelo = true;
                            }
                            else
                            {
                                controlModelo = modelo == camioneta.MODELO;
                            }
                            break;
                    }
                }
                else
                {
                    controlMarca = true;
                }

                if (cuitDistribuidor == "Todos")
                {
                    controlDistribuidor = true;
                }
                else
                {
                    clsDistribuidores dist = new clsDistribuidores(cuitDistribuidor, "", false);
                    controlDistribuidor = vehiculos.DISTRIBUIDOR.Equals(dist);
                }
                if (tipo_Vehiculo == "Todos" || tipo_Vehiculo == "Auto")
                {
                    if (vehiculos.GetType() == typeof(clsAutos))
                    {
                        clsAutos auto = (clsAutos)vehiculos;
                        if (usado && nuevo)
                        {
                            controlUsado = true;
                            controlNuevo = true;
                        }
                        else if (usado)
                        {
                            controlUsado = auto.USADO == usado;
                            controlNuevo = true;
                        }
                        else
                        {
                            controlUsado = true;
                            controlNuevo = !auto.USADO == nuevo;
                        }
                        controlCuaXcua = true;
                        controlTracSimple = true;
                    }
                    else
                    {
                        clsCamionetas camionetas = (clsCamionetas)vehiculos;
                        if (usado && nuevo)
                        {
                            controlUsado = true;
                            controlNuevo = true;
                        }
                        else if (usado)
                        {
                            controlUsado = camionetas.USADO == usado;
                            controlNuevo = true;
                        }
                        else
                        {
                            controlUsado = true;
                            controlNuevo = !camionetas.USADO == nuevo;
                        }
                        controlCuaXcua = true;
                        controlTracSimple = true;
                    }
                }
                else if (tipo_Vehiculo == "Camioneta")
                {
                    if (vehiculos.GetType() == typeof(clsCamionetas))
                    {
                        clsCamionetas camionetas = (clsCamionetas)vehiculos;
                        if (usado && nuevo)
                        {
                            controlUsado = true;
                            controlNuevo = true;
                        }
                        else if (usado)
                        {
                            controlUsado = camionetas.USADO == usado;
                            controlNuevo = true;
                        }
                        else
                        {
                            controlUsado = true;
                            controlNuevo = !camionetas.USADO == nuevo;
                        }
                        if (cuatroXcuatro && tracSimple)
                        {
                            controlCuaXcua = true;
                            controlTracSimple = true;
                        }
                        else if (cuatroXcuatro)
                        {
                            controlCuaXcua = camionetas.CUATROXCUATRO == cuatroXcuatro;
                            controlTracSimple = true;
                        }
                        else
                        {
                            controlCuaXcua = true;
                            controlTracSimple = !camionetas.CUATROXCUATRO == tracSimple;
                        }
                    }
                }
                if (vehiculos.GetType() == typeof(clsAutos))
                {
                    clsAutos auto = (clsAutos)vehiculos;
                    if (gama == "Todos")
                    {
                        controlGama = true;
                    }
                    else
                    {
                        controlGama = auto.GAMA == gama;
                    }
                }
                else if (vehiculos.GetType() == typeof(clsCamionetas))
                {
                    clsCamionetas camionetas = (clsCamionetas)vehiculos;
                    if (gama == "Todos")
                    {
                        controlGama = true;
                    }
                    else
                    {
                        controlGama = camionetas.GAMA == gama;
                    }
                }

                if (controlDistribuidor && controlMarca && controlModelo && controlTipoVehiculo && controlNuevo && controlTracSimple && controlUsado && controlCuaXcua && controlGama)
                {
                    lista.Add(vehiculos.ToString());
                }
            }
            return lista;
        }

        public List<string> mostrarVehiculosDist(string cuitDistribuidor)
        {
            List<string> lista;
            bool controlDistribuidor;

            lista = new List<string>();
            foreach (clsVehiculos vehiculos in listaVehiculos)
            {
                controlDistribuidor = false;

                if (cuitDistribuidor == "Todos")
                {
                    controlDistribuidor = true;
                }
                else
                {
                    clsDistribuidores dist = new clsDistribuidores(cuitDistribuidor, "", false);
                    controlDistribuidor = vehiculos.DISTRIBUIDOR.Equals(dist);
                }
                if (controlDistribuidor)
                {
                    lista.Add(vehiculos.ToString());
                }
            }
            return lista;
        }

        public void insertarDistribuidor(string cuit, string razon, bool internacional)
        {
            clsDistribuidores distribuidor = new clsDistribuidores(cuit, razon, internacional);

            if (!listaDistribuidores.Contains(distribuidor))
            {
                listaDistribuidores.Add(distribuidor);
            }
        }

        public void modificarDistribuidor(string cuit, string razon, bool internacional)
        {
            clsDistribuidores distribuidor = new clsDistribuidores(cuit, razon, internacional);
            int posicion;

            posicion = listaDistribuidores.IndexOf(distribuidor);
            if (posicion >= 0)
            {
                listaDistribuidores.RemoveAt(posicion);
                listaDistribuidores.Insert(posicion, distribuidor);
            }
        }

        public void insertarAuto(string marca, string modelo, string gama, DateTime fechaFabricacion, DateTime fechaCompra, bool usado, double precioCosto, int porcentajeGanancia, string codigo, string tipo, string patente, clsDistribuidores distribuidor)
        {
            clsAutos auto = new clsAutos(marca, modelo, gama, fechaFabricacion, fechaCompra, usado, precioCosto, porcentajeGanancia, codigo, tipo, patente, distribuidor);

            if (!listaVehiculos.Contains(auto))
            {
                listaVehiculos.Add(auto);
            }
        }

        public void modificarAuto(string marca, string modelo, string gama, DateTime fechaFabricacion, DateTime fechaCompra, bool usado, double precioCosto, int porcentajeGanancia, string codigo, string tipo, string patente, clsDistribuidores distribuidor)
        {
            clsAutos auto = new clsAutos(marca, modelo, gama, fechaFabricacion, fechaCompra, usado, precioCosto, porcentajeGanancia, codigo, tipo, patente, distribuidor);
            int posicion;

            posicion = listaVehiculos.IndexOf(auto);
            if (posicion >= 0)
            {
                listaVehiculos.RemoveAt(posicion);
                listaVehiculos.Insert(posicion, auto);
            }
        }

        public void insertarCamioneta(string marca, string modelo, string gama, DateTime fechaFabricacion, DateTime fechaCompra, bool usado, double precioCosto, int porcentajeGanancia, bool cuatroXcuatro, string codigo, string tipo, string patente, clsDistribuidores distribuidor)
        {
            clsCamionetas camioneta = new clsCamionetas(marca, modelo, gama, fechaFabricacion, fechaCompra, usado, precioCosto, porcentajeGanancia, cuatroXcuatro, codigo, tipo, patente, distribuidor);

            if (!listaVehiculos.Contains(camioneta))
            {
                listaVehiculos.Add(camioneta);
            }
        }

        public void modificarCamioneta(string marca, string modelo, string gama, DateTime fechaFabricacion, DateTime fechaCompra, bool usado, double precioCosto, int porcentajeGanancia, bool cuatroXcuatro, string codigo, string tipo, string patente, clsDistribuidores distribuidor)
        {
            clsCamionetas camioneta = new clsCamionetas(marca, modelo, gama, fechaFabricacion, fechaCompra, usado, precioCosto, porcentajeGanancia, cuatroXcuatro, codigo, tipo, patente, distribuidor);
            int posicion;

            posicion = listaVehiculos.IndexOf(camioneta);
            if (posicion >= 0)
            {
                listaVehiculos.RemoveAt(posicion);
                listaVehiculos.Insert(posicion, camioneta);
            }
        }

        public void eliminarVehiculos(int posicion)
        {
            listaVehiculos.RemoveAt(posicion);
        }

        public void eliminarDistribuidor(int posicion)
        {
            listaDistribuidores.RemoveAt(posicion);
        }

        public int cantidadVehiculos()
        {
            int cantidad;

            cantidad = listaVehiculos.Count;

            return cantidad;
        }

        public int cantidadDistribuidores()
        {
            int cantidad;

            cantidad = listaDistribuidores.Count;

            return cantidad;
        }
        #endregion
    }
}
