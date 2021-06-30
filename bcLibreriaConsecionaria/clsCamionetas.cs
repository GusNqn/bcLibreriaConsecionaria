using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bcLibreriaConsecionaria
{
    public class clsCamionetas : clsVehiculos
    {
        #region Atributos
        private string _marca;
        private string _modelo;
        private string _gama;
        private DateTime _fechaFabricacion;
        private DateTime _fechaCompra;
        private bool _usado;
        private double _precioCosto;
        private int _porcentajeGanancia;
        private bool _cuatroXcuatro;
        #endregion

        #region Propiedades
        public string MARCA
        {
            get
            {
                return _marca;
            }
            set
            {
                _marca = value;
            }
        }

        public string MODELO
        {
            get
            {
                return _modelo;
            }
            set
            {
                _modelo = value;
            }
        }
        public string GAMA
        {
            get
            {
                return _gama;
            }
            set
            {
                _gama = value;
            }
        }

        public DateTime FECHAFABRICACION
        {
            get
            {
                return _fechaFabricacion;
            }
            set
            {
                _fechaFabricacion = value;
            }
        }

        public DateTime FECHACOMPRA
        {
            get
            {
                return _fechaCompra;
            }
            set
            {
                _fechaCompra = value;
            }
        }

        public bool USADO
        {
            get
            {
                return _usado;
            }
            set
            {
                _usado = value;
            }
        }

        public double PRECIOCOSTO
        {
            get
            {
                return _precioCosto;
            }
            set
            {
                if (Math.Abs(value) > 0)
                    _precioCosto = value;
            }
        }

        public int PORCENTAJEGANANCIA
        {
            get
            {
                return _porcentajeGanancia;
            }
            set
            {
                if (Math.Abs(value) > 0)
                    _porcentajeGanancia = value;
            }
        }

        public bool CUATROXCUATRO
        {
            get
            {
                return _cuatroXcuatro;
            }
            set
            {
                _cuatroXcuatro = value;
            }
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            string cuatroXcuatro;

            if (_cuatroXcuatro)
                cuatroXcuatro = "Si";
            else cuatroXcuatro = "No";
            return $"{base.ToString()} - {_marca} - {_modelo} - Año: {_fechaFabricacion.Year} - Es 4x4: {cuatroXcuatro}";
        }

        public override double calcularGanancia(DateTime fechaVenta)
        {
            double ganancia;
            int descuento;
            int añoCompra = _fechaCompra.Year;
            int mesCompra = _fechaCompra.Month;
            int añoVenta = fechaVenta.Year;
            int mesVenta = fechaVenta.Month;
            if ((mesVenta - mesCompra < 6) && (añoVenta - añoCompra <= 1))
            {
                descuento = 0;
            }
            else if ((mesVenta - mesCompra < 11) && (añoVenta - añoCompra <= 1))
            {
                descuento = 4;
            }
            else if (añoVenta - añoCompra < 2)
            {
                descuento = 8;
            }
            else if (añoVenta - añoCompra < 4)
            {
                descuento = 15;
            }
            else
            {
                descuento = 20;
            }
            ganancia = (_precioCosto * (_porcentajeGanancia - descuento) / 100);
            return ganancia;
        }

        #endregion

        #region Metodos Estaticos

        #endregion

        #region Constructores
        public clsCamionetas()
        {
            _marca = string.Empty;
            _modelo = string.Empty;
            _gama = string.Empty;
            _fechaFabricacion = new DateTime(1900, 01, 01);
            _usado = false;
            _precioCosto = 0;
            _porcentajeGanancia = 0;
            _cuatroXcuatro = false;
        }

        public clsCamionetas(string patente) : base(patente)
        {
            _marca = string.Empty;
            _modelo = string.Empty;
            _gama = string.Empty;
            _fechaFabricacion = new DateTime(1900, 01, 01);
            _usado = false;
            _precioCosto = 0;
            _porcentajeGanancia = 0;
            _cuatroXcuatro = false;
        }

        public clsCamionetas(string marca, string modelo, string gama, DateTime fechaFabricacion, DateTime fechaCompra, bool usado, double precioCosto, int porcentajeGanancia, bool cuatroXcuatro, string codigo, string tipo, string patente, clsDistribuidores distribuidor) : base(codigo, tipo, patente, distribuidor)
        {
            _marca = marca;
            _modelo = modelo;
            _gama = gama;
            _fechaFabricacion = fechaFabricacion;
            _fechaCompra = fechaCompra;
            _usado = usado;
            if (Math.Abs(precioCosto) > 0)
                _precioCosto = precioCosto;
            else _precioCosto = 0;
            if (Math.Abs(porcentajeGanancia) > 0)
                _porcentajeGanancia = porcentajeGanancia;
            else porcentajeGanancia = 0;
            _cuatroXcuatro = cuatroXcuatro;
        }
        #endregion
    }
}
