using SupplySearchV1.Context;
using SupplySearchV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupplySearchV1.Services
{
    public class Service : IService
    {
        private readonly Contexto _Context;
        public Service(Contexto context)
        {
            _Context = context;

        }

        public Doacoes CreateDoacoes(Doacoes obj)
        {
            _Context.Doacoes.Add(obj);
            _Context.SaveChanges();

            return obj;
        }

        public Doador CreateDoador(Doador obj)
        {
            _Context.Doador.Add(obj);
            _Context.SaveChanges();

            return obj;
        }

        public Donatario CreateDonatario(Donatario obj)
        {
            _Context.Donatario.Add(obj);
            _Context.SaveChanges();

            return obj;
        }

        public Local CreateLocal(Local obj)
        {
            if (obj.complemento == null)
                obj.complemento = "";

            _Context.Local.Add(obj);
            _Context.SaveChanges();

            return obj;
        }

        public bool Delete(Donatario obj)
        {
            _Context.Remove(obj.ID);
            var retorno = _Context.SaveChanges();

            if (retorno > 0)
                return true;

            return false;

        }

        public void DeleteDoacao(int id)
        {
            var doacao = _Context.Doacoes.First(x => x.ID == id);
            _Context.Doacoes.Remove(doacao);
            _Context.SaveChanges();
        }

        public bool DeleteDoador(Doador obj)
        {
            _Context.Remove(obj.ID);
            var retorno = _Context.SaveChanges();

            if (retorno > 0)
                return true;

            return false;
        }

        public bool DeleteLocal(Local obj)
        {
             _Context.Remove(obj.ID);
            var retorno = _Context.SaveChanges();

            if (retorno > 0)
                return true;

            return false;
        }

        public IEnumerable<Doacoes> GetDoacoes()
        {
            var retorno = _Context.Doacoes.ToList();
            return retorno;
        }

        public IEnumerable<Doacoes> GetDoacoesByID(int id)
        {
            var retorno = _Context.Doacoes.Where(x => x.IDDoador == id).ToList();
            return retorno;
        }
        public Doacoes GetDoacoesByIDDoacao(int id)
        {
            var retorno = _Context.Doacoes.FirstOrDefault(x => x.ID == id);
            return retorno;
        }

        public IEnumerable<Doador> GetDoador()
        {
            var retorno = _Context.Doador.ToList();

            return retorno;
        }

        public Doador GetDoadorByID(int id)
        {
            var retorno = _Context.Doador.First(x => x.ID == id);

            return retorno;
        }

        public IEnumerable<Donatario> GetDonatario()
        {
            var retorno = _Context.Donatario.ToList();

            return retorno;
        }

        public Donatario GetDonatarioByID(int id)
        {
            var retorno = _Context.Donatario.First(x => x.ID == id);

            return retorno;
        }

        public IEnumerable<Local> GetLocal()
        {
            var retorno = _Context.Local.ToList();

            return retorno;
        }

        public Local GetLocalByID(int id)
        {
            var retorno = _Context.Local.First(x => x.ID == id);

            return retorno;
        }

        public Doacoes UpdateDoacao(Doacoes obj)
        {
            _Context.Doacoes.Update(obj);
            _Context.SaveChanges();

            return obj;
        }

        public Doador UpdateDoador(Doador obj)
        {
            _Context.Doador.Update(obj);
            _Context.SaveChanges();

            return obj;
        }

        public Donatario UpdateDoador(Donatario obj)
        {
            _Context.Donatario.Update(obj);
            _Context.SaveChanges();

            return obj;
        }

        public Local UpdateLocal(Local obj)
        {
            _Context.Local.Update(obj);
            _Context.SaveChanges();

            return obj;
        }
    }
}
