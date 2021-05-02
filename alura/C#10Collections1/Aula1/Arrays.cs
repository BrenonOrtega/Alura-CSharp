using System;

namespace Aula1.Arrays
{   
    public static class  Arrays 
    {
        public static void InicializaArrayComValores() 
        {
            string primeiraAula = "Olá, está é a primeira aula.";
            string modelandoAula = "Modelando Arrays na aula!";
            string ListsAula = "Criando Lists na aula!";

            string[] aulas = new string[]
            {
                primeiraAula, modelandoAula, ListsAula
            };

            System.Console.WriteLine(nameof(CriaArrayVazioEAtribuiDepois));
            PrintAll(aulas);
        }

        public static void CriaArrayVazioEAtribuiDepois() 
        {
            string primeiraAula = "Olá, está é a primeira aula. inicializada depois";
            string modelandoAula = "Modelando Arrays na aula! inicializada depois";
            string ListsAula = "Criando Lists na aula! inicializada depois";

            string[] aulas = new string[3];

            aulas[0] = primeiraAula;
            aulas[1] = modelandoAula;
            aulas[2] = ListsAula;

            System.Console.WriteLine(nameof(CriaArrayVazioEAtribuiDepois));
            PrintAll(aulas);
        }
 
        public static void OperacaoComArrays()
        {
            string primeiraAula = "Olá, está é a primeira aula. ";
            string modelandoAula = "Modelando Arrays na aula! ";
            string ListsAula = "Criando Lists na aula!";

            string[] aulas = new string[]{primeiraAula,modelandoAula,ListsAula};

            ///<summary>
            /// Retorna o indíce de um valor compátivel com o valor buscado.
            ///</summary>
            void IndexOf() {
                System.Console.WriteLine("Índice de \"primeiraAula\": " + Array.IndexOf(aulas, primeiraAula));
            }
            ///<summary>inverte todas as posições de um array 
            ///(idepotente, possível reverter ao estado inicial).
            ///</summary>
            void Reverse() {
                System.Console.WriteLine("ArrayOriginal:");
                PrintAll(aulas);
            
                System.Console.WriteLine("Array com reverse:");
                Array.Reverse(aulas);
                PrintAll(aulas);

                System.Console.WriteLine("Array com reverse 2x é identico ao original(Idepotente):");
                Array.Reverse(aulas);
                PrintAll(aulas);
            }

            ///<sumary>Altera o tamanho de um array -> diminuir arrays ocasiona em perda de dados.</summary>
            void Resize() { 
                ///<remark> Importante notar que na verdade não é o array passado para o método que muda de tamanho
                ///internamente o CLR cria uma nova collection com o tamanho específicado e com o tipo de variável
                ///especificado no array passado como argumento, copia os parametros para essa nova collection
                ///e faz nossa variável apontar para essa nova referência.</remark>
                Array.Resize(ref aulas, 2);
                System.Console.WriteLine("Resize - diminuido o tamanho do array para 2");
                PrintAll(aulas);

                Array.Resize(ref aulas, 5);
                System.Console.WriteLine("Resize - aumentado para 5 (perdemos o terceiro valor e null em todos");
                PrintAll(aulas);
                System.Console.WriteLine("três linhas vazias acima representam os 3 espaços com nulos.");

                for(int i=0; i < aulas.Length; i++){
                    if(aulas[i] is null) 
                        aulas[i] = "Não é mais null não kk";
                }
                System.Console.WriteLine("passei o cerol nos nulos.");
                PrintAll(aulas);
            }

            ///<sumary>Ordena o array no caso de strings, ordem alfabética</summary>
            void Sort(){
                ///<remark> O método sort não é idepotente portanto uma vez ordenada a lista, 
                ///não é possível desfazer a ordenação.
                ///</remark>
                Array.Sort(aulas);
                PrintAll(aulas);
            }

            void copy(){
                return;
            }

            IndexOf();
            Reverse();
            Resize();
            Sort();

            
        }
        public static void PrintAll(object[] a) 
        {
            for(int i=0; i < a.Length; i++)
            {
                System.Console.WriteLine(a[i]);
            }
        }
    }
}