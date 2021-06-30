using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bcLibreriaConsecionaria
{
    public class clsDistribuidores
    {
        #region Atributos
        protected string _cuit;
        protected string _razonSocial;
        protected bool _internacional;
        #endregion

        #region Propiedades
        public string CUIT
        {
            get
            {
                return _cuit;
            }
            set
            {
                if ((value != string.Empty) && (value.Length != 11))
                    _cuit = value;
            }
        }

        public string RAZONSOCIAL
        {
            get
            {
                return _razonSocial;
            }
            set
            {
                if (value != string.Empty)
                    _razonSocial = value;
            }
        }

        public bool INTERNACIONAL
        {
            get
            {
                return _internacional;
            }
            set
            {
                _internacional = value;
            }
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return $"CUIT: {_cuit} - {_razonSocial}";
        }

        public override bool Equals(object distribuidorPedido)
        {
            bool igual;

            if (distribuidorPedido == null)
                igual = this == null;
            else if (this.GetType() != distribuidorPedido.GetType())
                igual = false;
            else
            {
                clsDistribuidores distribuidor = (clsDistribuidores)distribuidorPedido;
                igual = this._cuit == distribuidor.CUIT;
            }
            return igual;
        }

        public override int GetHashCode()
        {
            return (Convert.ToInt32(_cuit) * 2);
        }
        #endregion

        #region Metodos Estaticos
        public static bool esCuitValido(string cuit)
        {
            long cuitaux;
            long cuit2 = Convert.ToInt64(cuit);
            int v1, v2, v3, pos, digito, DigitoVerificador, DigitoVerificadorIngresado;
            bool esValido = false;
            v1 = 0;
            pos = 1;
            cuitaux = cuit2;
            cuit2 = cuit2 / 10;
            do
            {
                digito = (int)(cuit2 % 10);
                pos += 1;
                switch (pos)
                {
                    case 2: v1 += digito * 2; break;
                    case 3: v1 += digito * 3; break;
                    case 4: v1 += digito * 4; break;
                    case 5: v1 += digito * 5; break;
                    case 6: v1 += digito * 6; break;
                    case 7: v1 += digito * 7; break;
                    case 8: v1 += digito * 2; break;
                    case 9: v1 += digito * 3; break;
                    case 10: v1 += digito * 4; break;
                    case 11: v1 += digito * 5; break;
                }
                cuit2 /= 10;
            }
            while (cuit2 > 0);

            v2 = v1 % 11;
            v3 = 11 - v2;

            if (v3 == 11)
            {
                DigitoVerificador = 0;
            }
            else if (v3 == 10)
            {
                DigitoVerificador = 9;
            }
            else
            {
                DigitoVerificador = v3;
            }

            DigitoVerificadorIngresado = (int)(cuitaux % 10); //Obtener el digito verificador del cuit ingresado
            if (DigitoVerificador == DigitoVerificadorIngresado) // Comparar el Digito Verificador calculado con el ingresado en el cuit
            {
                esValido = true;
            }

            return esValido;
        }
        #endregion

        #region Constructores
        public clsDistribuidores()
        {
            _cuit = "00000000000";
            _razonSocial = string.Empty;
            _internacional = false;
        }

        public clsDistribuidores(string cuit, string razonSocial, bool internacional)
        {
            if ((cuit != string.Empty) && (cuit.Length == 11))
                _cuit = cuit;
            else _cuit = "00000000000";
            if (razonSocial != string.Empty)
                _razonSocial = razonSocial;
            else _razonSocial = string.Empty;
            _internacional = internacional;
        }
        #endregion
    }
}
