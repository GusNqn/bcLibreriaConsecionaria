using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bcLibreriaConsecionaria
{
    public abstract class clsVehiculos
    {
        #region Atributos
        protected string _codigo;
        protected string _tipo;
        protected clsDistribuidores _distribuidor;
        protected string _patente;
        #endregion

        #region Propiedades
        public string CODIGO
        {
            get
            {
                return _codigo;
            }
            set
            {
                if (_codigo != "")
                    _codigo = value;
            }
        }

        public string TIPO
        {
            get
            {
                return _tipo;
            }
            set
            {
                _tipo = value;
            }
        }

        public clsDistribuidores DISTRIBUIDOR
        {
            get
            {
                return _distribuidor;
            }
            set
            {
                _distribuidor = value;
            }
        }

        public string PATENTE
        {
            get
            {
                return _patente;
            }
            set
            {
                if (patenteValida(value.Trim()))
                    _patente = value;
            }
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return $"Codigo: {_codigo} - {_patente} - {_tipo}";
        }

        public override bool Equals(object vehiculoPedido)
        {
            bool igual;

            if (vehiculoPedido == null)
                igual = this == null;
            else if (this.GetType() != vehiculoPedido.GetType())
                igual = false;
            else
            {
                clsVehiculos vehiculo = (clsVehiculos)vehiculoPedido;
                igual = (this._patente == vehiculo.PATENTE);
            }
            return igual;
        }

        public override int GetHashCode()
        {
            return (Convert.ToInt32(_codigo) * 10);
        }

        public abstract double calcularGanancia(DateTime fechaPedida);
        #endregion

        #region Metodos Estaticos
        public static bool patenteValida(string patente)
        {
            bool esValida = false;

            if (patente.Length == 7)
            {
                if ((Char.IsLetter(Convert.ToChar(patente.Substring(0, 1)))) && (Char.IsLetter(Convert.ToChar(patente.Substring(1, 1)))) && (Char.IsDigit(Convert.ToChar(patente.Substring(2, 1))))
                        && (Char.IsDigit(Convert.ToChar(patente.Substring(3, 1)))) && (Char.IsDigit(Convert.ToChar(patente.Substring(4, 1)))) && (Char.IsLetter(Convert.ToChar(patente.Substring(5, 1))))
                        && (Char.IsLetter(Convert.ToChar(patente.Substring(6, 1)))))
                {
                    esValida = true;
                }
            }

            return esValida;
        }
        #endregion

        #region Constructores

        public clsVehiculos()
        {
            _codigo = "";
            _tipo = string.Empty;
            _distribuidor = null;
            _patente = string.Empty;
        }

        public clsVehiculos(string patente)
        {
            _codigo = string.Empty;
            _tipo = string.Empty;
            _distribuidor = null;
            _patente = patente;
        }

        public clsVehiculos(string codigo, string tipo, string patente, clsDistribuidores distribuidor)
        {
            _codigo = codigo;
            _tipo = tipo;
            _distribuidor = distribuidor;
            if (patenteValida(patente.Trim()))
                _patente = patente;
            else _patente = string.Empty;
        }
        #endregion
    }
}
