using System;
using System.Diagnostics;

namespace ByteBank.Modelos
{
    public class ListaContaCorrentes
    {

        private ContaCorrente[] _contas;
        private int _posicaoDisponivel;

        public ListaContaCorrentes(int capacidadadeInicial = 10)
        {
            _contas = new ContaCorrente[capacidadadeInicial];
            _posicaoDisponivel = 0;
        }

        public void Add(params ContaCorrente[] contas)
        {
            foreach (var conta in contas)
            {
                if (IsListFull())
                    IncreaseSize(_posicaoDisponivel * 2);

                _contas[_posicaoDisponivel++] = conta;
            }
        }

        public void Remove(ContaCorrente conta)
        {
            var indexConta = Array.FindIndex(_contas, x => x.Equals(conta));

            if(indexConta != -1)
                _contas[indexConta] = null;
            
        }

        public ContaCorrente this[int index]
        {
            get => _contas[index];
            set => _contas[index] = value;
        }

        public int Count => _contas.Length;

        private bool IsListFull() => this.Count >= _posicaoDisponivel;
        private void IncreaseSize(int newCapacity = default) => Array.Resize(ref _contas, newCapacity is default(int) ? _posicaoDisponivel * 2 : newCapacity);
        private void DecreaseSize() => Array.Resize(ref _contas, _posicaoDisponivel - 1);


    }
}