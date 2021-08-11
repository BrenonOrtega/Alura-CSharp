Tests in C# - TDD and XUnit.
What have we learned.
Why Testing?
Quick Feedbacks
Tests give you quick feedbacks about changes to your system changes and new implementations. Whenever you add new features or implements changes to your actual code base the tests assure you that no regression happened and diminish the number of bugs in your system while helping your system to be more modular. A testable system by default has low coupling, this means a better design.

Code Documentation
Since tests ensure the funcionality of the system, reading tests helps developers understand what each function do and what is expected to be returned. Documents the type of the data a class receives, what is given back, exceptions thrown and overall behavior.

Test Processes
Differents but related test process: AAA - Arranje, Act, Assert and Given, When, Then. These are two ways to set up your test suite in a consistent and understandable way for others developers and testers to interact with your code.

XUnit Principles
[Fact] and [Theory] annotations. [Fact] stands for an immutable assertion, this means the data does not change inside this test, while [Theory] is a data driven test that given different inputs the output should be the same.

TDD - Test Driven Development
Test Driven Development is a discipline that teaches you to develop your code based on the tests it should pass. Write a tests, see it fails, write the minimum code to make it pass, test again, see the test passing, refactor your code, run your test again and keep doing this 'till finish.

Testing Standards
Naming standards : Test Suite names should be descriptive and show the intent of the test, what is being tested and how to feed the data for the test to run. We should split these in classes based on Equivalence Partitioning. Each feature being tested should have it's own file and detecting the equivalence partioning prevents you from writing the same tests again and again.

Referências de Aula - TDD e Xunit com C# - Alura
[Testes e Xunit:]
Definição de Teste

Padrão AAA (Arrange, Act, Assert)

Padrão Given/When/Then

xUnit

MSTests

NUnit

[Comparativo entre os frameworks de Test] (https://xunit.github.io/docs/comparisons)

Porque xUnit?

Microsoft está usando o xUnit

Conceitos de Testes e aplicação:
Classes de Equivalência - técnica para identificação de testes relevantes

Análise de Fronteira - outra técnica:

Definição de Product Owner

Diferença entre [Fact] e [Theory]

[Nomenclatura de testes:]

Docs Microsoft

Docs Asp Net Core

Regressão:
Testes de regressão

Intro a Métodos Ágeis na Alura

Livro TDD By Example, de Kent Beck

Livro sobre TDD na Casa do Código

Testes de métodos privados

Testando Exceções:
Diferenças entre os frameworks ao testar exceções

Visual Studio tem uma ferramenta de cobertura de código, mas infelizmente apenas nas suas versões pagas.

https://docs.microsoft.com/en-us/visualstudio/test/using-code-coverage-to-determine-how-much-code-is-being-tested
Esse artigo do Martin Fowler debate o real propósito da cobertura de código, que em sua opinião (na minha também!) deveria ser para encontrar partes não testadas do seu sistema ao invés de ser uma métrica utilizada em contratos e objetivos do time.

https://www.martinfowler.com/bliki/TestCoverage.html
Testes e Design de Código:
Design OO, Interfaces e Implementação

Princípios de Design: SOLID