using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    [Serializable]
    public class EquipamentoInfBO
    {
        #region Member Variables
        public int codigo;
        public string modelo;
        public string marca;
        public string tipo;
        public DateTime dataAquisicao;
        #endregion

        #region Constructors
        public EquipamentoInfBO(int c, string t, string mar, string mod, DateTime dt)
        {
            codigo = c + 1;
            tipo = t;
            marca = mar;
            modelo = mod;
            dataAquisicao = dt;
        }
        #endregion

        #region Properties 
        public int Codigo
        {
            get { return codigo; }
        }

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        public DateTime DataAquisicao
        {
            get { return dataAquisicao; }
            set { dataAquisicao = value; }
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return string.Format("Codigo: {0} \nTipo: {1} \nMarca: {2} \nModelo: {3} \nData Aquisicao: {4}\n", codigo.ToString(), tipo, marca, modelo, dataAquisicao.ToString());
        }
        #endregion
    }
}
