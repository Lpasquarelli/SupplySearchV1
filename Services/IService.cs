using SupplySearchV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupplySearchV1.Services
{
    public interface IService
    {
        //Doacoes
        public IEnumerable<Doacoes> GetDoacoes();
        public IEnumerable<Doacoes> GetDoacoesByID(int id);
        public Doacoes CreateDoacoes(Doacoes obj);
        public Doacoes UpdateDoacao(Doacoes obj);
        public Doacoes GetDoacoesByIDDoacao(int id);
        public void DeleteDoacao(int id);

        //Locais
        public IEnumerable<Local> GetLocal();
        public Local GetLocalByID(int id);
        public Local CreateLocal(Local obj);
        public Local UpdateLocal(Local obj);
        public bool DeleteLocal(Local obj);

        //Doador
        public IEnumerable<Doador> GetDoador();
        public Doador GetDoadorByID(int id);
        public Doador UpdateDoador(Doador obj);
        public Doador CreateDoador(Doador obj);
        public bool DeleteDoador(Doador obj);

        //Donatario
        public IEnumerable<Donatario> GetDonatario();
        public Donatario CreateDonatario(Donatario obj);
        public Donatario GetDonatarioByID(int id);
        public Donatario UpdateDoador(Donatario obj);
        public bool Delete(Donatario obj);

    }
}
