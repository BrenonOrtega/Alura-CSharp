using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Aula5PilhaFilaLinkedList
{
    public class AulaStack
    {
        static Stack<string> paginasAnteriores = new();
        static Stack<string> paginasPosteriores = new();
        static string paginaAtual = string.Empty;

        public static void Run()
        {
            string str1 = "str1 - Entrei primeiro";
            string str2 = "str2 - Entrei Segundo";
            string str3 = "str3 - Entrei Terceiro";

            Stack<string> stack = new();

            List<string> list = new(){str1,str2,str3};
        
        #region Push
            System.Console.WriteLine("Método Push da Stack sempre coloca o último elemento a entrar como o primeiro da pilha.");
            foreach (var item in list)
            {
                System.Console.WriteLine(item);
                stack.Push(item);
            }
            System.Console.WriteLine();
        
           /*  stack.Push(str1);
            stack.Push(str2);
            stack.Push(str3); */

        #endregion

        #region Pop

            System.Console.WriteLine("Utilizando o método pop - Sempre retira o último elemento a entrar e o devolve");        
            int ordemSaida=0;
            do
            {   ordemSaida++;
                System.Console.WriteLine(stack.Pop().Replace("Entrei", "Sai").Remove(10) + " " +ordemSaida.ToString());
            }
            while (stack.Count > 0);
            System.Console.WriteLine("items na stack:" + stack.Count);
            System.Console.WriteLine();

        #endregion
        
        
        #region Exercício de Aula - Navegação entre páginas
            System.Console.WriteLine("Exercício de Aula - Navegação entre páginas");    

            void NavegarPara(string url){
                if (!string.Empty.Equals(paginaAtual))  
                    paginasAnteriores.Push(paginaAtual);
                paginasPosteriores.Clear();
                paginaAtual = url;
            }

            void RetornarPagina()
            {
                if (paginasAnteriores.Count > 0) 
                {   var paginaAnterior = paginasAnteriores.Pop();
                    paginasPosteriores.Push(paginaAtual);
                    paginaAtual= paginaAnterior;
                }
            }

            void avancarPagina() 
            {
                if ( paginasPosteriores.Count > 0 )
                {   var paginaPosterior = paginasPosteriores.Pop();
                    paginasAnteriores.Push(paginaAtual);
                    paginaAtual = paginaPosterior;
                }
            }

            NavegarPara("www.google.com");
            run();

            NavegarPara("www.instagram.com");
            run();

            NavegarPara("www.youtube.com");
            run();

            run(RetornarPagina);
            run(avancarPagina);

            run(avancarPagina);
            run(avancarPagina);
            run(avancarPagina);

            /* run(RetornarPagina);
            run(RetornarPagina);
            run(RetornarPagina); */

            NavegarPara("www.facebook.com");
            run();
            NavegarPara("www.alura.com.br");
            run();

            run(RetornarPagina);
            run(RetornarPagina);
            run(RetornarPagina);

        #endregion
        }

        static void PrintStack(Stack<string> stack)
        {
            foreach (var item in stack)
            {
                System.Console.WriteLine(item);
            }
        }
        
        static void PaginaAtual() => System.Console.WriteLine("PaginaAtual: " + paginaAtual);

        static void run(Action action=null) {
            if (action is not null) {
                action();
                System.Console.WriteLine(action.GetMethodInfo());
            }
            PaginaAtual();
            System.Console.WriteLine("Paginas Anteriores :");
            PrintStack(paginasAnteriores);
            System.Console.WriteLine("Paginas Posteriores :");
            PrintStack(paginasPosteriores);
            System.Console.WriteLine();
        }
    }
} 