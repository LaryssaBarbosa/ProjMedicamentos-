using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoMedicamento
{
    public class Medicamentos
    {
        private List<Medicamento> listaMedicamentos;

        public Medicamentos()
        {
            listaMedicamentos = new List<Medicamento>();
        }

        public void Adicionar(Medicamento medicamento)
        {
            listaMedicamentos.Add(medicamento);
        }

        public bool Deletar(Medicamento medicamento)
        {
            Medicamento med = Pesquisar(medicamento);
            if (med != null && med.QtdeDisponivel() == 0)
            {
                listaMedicamentos.Remove(med);
                return true;
            }
            return false;
        }

        public Medicamento Pesquisar(Medicamento medicamento)
        {
            return listaMedicamentos.FirstOrDefault(m => m.Id == medicamento.Id);
        }

        public void ListarTodos()
        {
            foreach (Medicamento m in listaMedicamentos)
                Console.WriteLine(m);
        }
    }
}
