using System;
using System.Collections.Generic;

namespace ProjetoMedicamento
{
    public class Medicamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Laboratorio { get; set; }
        private Queue<Lote> lotes;

        public Medicamento()
        {
            lotes = new Queue<Lote>();
        }

        public Medicamento(int id, string nome, string laboratorio)
        {
            Id = id;
            Nome = nome;
            Laboratorio = laboratorio;
            lotes = new Queue<Lote>();
        }

        public int QtdeDisponivel()
        {
            int total = 0;
            foreach (Lote l in lotes)
                total += l.Qtde;
            return total;
        }

        public void Comprar(Lote lote)
        {
            lotes.Enqueue(lote);
        }

        public bool Vender(int qtde)
        {
            if (QtdeDisponivel() < qtde)
                return false;

            while (qtde > 0 && lotes.Count > 0)
            {
                Lote primeiro = lotes.Peek();

                if (primeiro.Qtde <= qtde)
                {
                    qtde -= primeiro.Qtde;
                    lotes.Dequeue(); // remove lote esgotado
                }
                else
                {
                    primeiro.Qtde -= qtde;
                    qtde = 0;
                }
            }
            return true;
        }

        public override string ToString()
        {
            return $"{Id} - {Nome} - {Laboratorio} - {QtdeDisponivel()}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Medicamento outro)
                return this.Id == outro.Id;
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public void ListarLotes()
        {
            foreach (Lote l in lotes)
                Console.WriteLine($"   {l}");
        }
    }
}
