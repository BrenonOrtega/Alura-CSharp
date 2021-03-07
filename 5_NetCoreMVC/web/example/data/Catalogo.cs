using System.Collections.Generic;

namespace example {
    public class Catalogo : ICatalogo
    {
        public List<Livro> GetLivros()
        {
            var livros = new List<Livro>();
            livros.Add(new Livro("001", "C# para idiotas", 12.99m));
            livros.Add(new Livro("002", "python rules", 15.00m));
            livros.Add(new Livro("003", "Django and Flask", 25.99m));

            return livros;
        }

    }

}
