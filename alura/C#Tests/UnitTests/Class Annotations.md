# Class Annotations - Tests in C# - TDD and XUnit.

## What have we learned.
 
### Why Testing? 
#### Quick Feedbacks
Tests give you quick feedbacks about changes to your system changes and new implementations. 
Whenever you add new features or implements changes to your actual code base the tests assure you that no regression happened and diminish the number of bugs in your system while helping your system to be more modular.
A testable system by default has low coupling, this means a better design.

#### Code Documentation
Since tests ensure the funcionality of the system, reading tests helps developers understand what each function do and what is expected to be returned.
Documents the type of the data a class receives, what is given back, exceptions thrown and overall behavior.

### Test Processes
Differents but related test process: AAA - Arranje, Act, Assert and Given, When, Then. These are two ways to set up your test suite in a consistent and understandable way for others developers and testers to interact with your code.

### XUnit Principles 
[Fact] and [Theory] annotations.
[Fact] stands for an immutable assertion, this means the data does not change inside this test, while [Theory] is a data driven test that given different inputs the output should be the same.

### TDD - Test Driven Development 
Test Driven Development is a discipline that teaches you to develop your code based on the tests it should pass. 
Write a tests, see it fails, write the minimum code to make it pass, test again, see the test passing, refactor your code, run your test again and keep doing this 'till finish.

### Testing Standards 
Naming standards : Test Suite names should be descriptive and show the intent of the test, what is being tested and how to feed the data for the test to run.
We should split these in classes based on Equivalence Partitioning.
Each feature being tested should have it's own file and detecting the equivalence partioning prevents you from writing the same tests again and again.

## Referências de Aula - TDD e Xunit com C# - Alura

### [Testes e Xunit:]

* [Definição de Teste](http://softwaretestingfundamentals.com/definition-of-test/)

* [Padrão AAA (Arrange, Act, Assert)](http://wiki.c2.com/?ArrangeActAssert)

* [Padrão Given/When/Then](https://martinfowler.com/bliki/GivenWhenThen.html)

* [xUnit](https://xunit.github.io/)

* [MSTests](https://github.com/Microsoft/testfx-docs)

* [NUnit](https://nunit.org/)

* [Comparativo entre os frameworks de Test]
(https://xunit.github.io/docs/comparisons)

* [Porque xUnit?](https://www.martin-brennan.com/why-xunit/)

* [Microsoft está usando o xUnit](https://dev.to/hatsrumandcode/net-core-2-why-xunit-and-not-nunit-or-mstest--aei)

### Conceitos de Testes e aplicação:

* [Classes de Equivalência - técnica para identificação de testes relevantes](https://en.wikipedia.org/wiki/Equivalence_partitioning)

* [Análise de Fronteira - outra técnica:](https://en.wikipedia.org/wiki/Boundary-value_analysis)

* [Definição de Product Owner](https://www.scrum.org/resources/what-is-a-product-owner)

* [Diferença entre [Fact] e [Theory]](https://xunit.github.io/docs/getting-started/netfx/visual-studio#write-first-theory)

* [Nomenclatura de testes:]
 - [Docs Microsoft](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices#best-practices)

 - [Docs Asp Net Core](https://docs.microsoft.com/pt-br/dotnet/standard/modern-web-apps-azure-architecture/test-asp-net-core-mvc-apps#test-naming)

### Regressão:

* [Testes de regressão](http://softwaretestingfundamentals.com/regression-testing/)

* [Intro a Métodos Ágeis na Alura](https://cursos.alura.com.br/course/introducao-aos-metodos-ageis)

* [Livro TDD By Example, de Kent Beck](https://www.amazon.com.br/Test-Driven-Development-Kent-Beck/dp/0321146530/)

* [Livro sobre TDD na Casa do Código](https://www.casadocodigo.com.br/products/livro-tdd-dotnet)

* [Testes de métodos privados](https://docs.microsoft.com/pt-br/dotnet/core/testing/unit-testing-best-practices#validate-private-methods-by-unit-testing-public-methods)

### Testando Exceções: 

* [Diferenças entre os frameworks ao testar exceções](https://xunit.github.io/docs/comparisons)

* Visual Studio tem uma ferramenta de cobertura de código, mas infelizmente apenas nas suas versões pagas.

  - https://docs.microsoft.com/en-us/visualstudio/test/using-code-coverage-to-determine-how-much-code-is-being-tested

* Esse artigo do Martin Fowler debate o real propósito da cobertura de código, que em sua opinião (na minha também!) deveria ser para encontrar partes não testadas do seu sistema ao invés de ser uma métrica utilizada em contratos e objetivos do time.

  - https://www.martinfowler.com/bliki/TestCoverage.html


### Testes e Design de Código: 

* [Design OO, Interfaces e Implementação](https://en.wikipedia.org/wiki/Object-oriented_design)

* [Princípios de Design: SOLID](https://en.wikipedia.org/wiki/SOLID)