using System;
using System.Diagnostics;

namespace ByteBank.Modelos
{
    public class ListaContaCorrentes
    {
        
        private ContaCorrente[] _contas;
        private int _posicaoDisponivel;

        public ListaContaCorrentes()    
        {
            _contas = new ContaCorrente[5];
            _posicaoDisponivel = 0;   
        }

        public void Add(params ContaCorrente[] contas) 
        { 
            foreach(var conta in contas)
            {
                if (IsListFull())
                    IncreaseSize();

                _contas[_posicaoDisponivel++] = conta;
            }
        }

        public ContaCorrente this[int index]
        {
            get => _contas[index];
            set => _contas[index] = value;
        }

        public int Count => _contas.Length;

        private bool IsListFull() => this.Count >= _posicaoDisponivel;
        private void IncreaseSize() => Array.Resize(ref _contas, _posicaoDisponivel + 1);
        private void DecreaseSize() => Array.Resize(ref _contas, _posicaoDisponivel - 1);

            
    }
}