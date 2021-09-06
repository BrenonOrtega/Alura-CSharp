# Scaling Applications with Microservices, MassTransit, and RabbitMQ - Pluralsight

## Objective

 - Develop a microsservice based system for a logistic enterprise.
 - Using Distribuded system and messaging for communication between services.
 - Learn how to implement the messaging system by hand using RabbitMq native API.
 - Learn how to abstract messaging using MassTransit.
 - Learn how to Orchestrate and centralized the system workflow inside a Saga using MassTransit Automatonimous.
 - How to handle events, behaviors, exceptions and resiliency.


A arquitetura de microsserviços é excelente em prover escalabilidade, desacoplamentos e facil manutentabilidade visto que cada um dos seus serviços possuem tarefas bem definidas, expondo e recebendo dados através de pontos bem definidos.

A idéia de utilizar mensageria é de tornar sua rede de serviços agnostica a linguagem de programação, permitindo assim aplicar as ferramentas certas as necessidades certas, um serviço que lida com grandes volumes de dados pode ser feito em python enquanto API's podem ser feitas em Elixir e se comunicar através de mensageria sem nenhum problema, isso facilita integrações da mesma maneira que API's Restful possibilitam essa comunicação.




Contanto a complexidade deste tipo de arquitetura é altissimo e muitas vezes implementar diversos provedores de mensageria e até mesmo trocar de provedor é um trabalho extremamente custoso visto a necessidade de lidar diretamente com as API's Nativas para a linguagem de cada um deles, seja o RabbitMQ, Apache Kafka, Azure Service Bus e etc, é neste ponto que a biblioteca MassTransit já começa a demonstrar seu poder.


Falarei um pouco mais a respeito do RabbitMQ, que foi o foco do curso. 

Através do Sistema de Topologia de Mensagens, o MassTransit cria Exchanges especificas para cada tipo de mensagem ( o que permite algumas features interessantes como heranças de mensagem) e filas para cada uma dessas mensagens através do tipo de mensagem configurado e automaticamente ao configurar um consumer que receberá esta mensagem através dos métodos de configuração de endpoints, faz o bind deste consumer a esta fila automaticamente, praticamente automático, incrível não?

A implementação dos padrões Pub/Sub se torna fluida, necessitando apenas a configuração de qual provedor será utilizado e os "endpoints". Nos serviços consumidores, qual tipo de mensagem ele estará consumindo e pronto, a partir disso.

Sagas: Sagas são maneiras de orquestrar o workflow de uma aplicação feita em microsserviços, garantindo um "ponto único de verdade" saga é um assuntos extenso portanto não entrarei em muitos detalhes mas uma das principais razões de se utilizar uma saga é facilitar o fluxo da comunicação entre serviços e conseguir garantir atomicidade em uma operação, permitindo que em caso de falha por qualquer motivo que seja, todas as alterações e operações que já foram executadas possam ser revertidas (visto que cada serviço tem sua própria base de dado e dados de uma operação não possuirão sempre o mesmo estado ao mesmo tempo, isto é importantissimo)

Para nos auxiliar com isso o MassTransit oferece built-in a biblioteca (feita pelo mesmo criados) Automatonymous, esta permite a criação de máquinas de estado de forma simples e fluida que possibilitam a orquestração de sagas de maneira simples, definindo eventos, comportamentos e estados da saga, sendo assim é possivel tratar da maneira desejada uma "transação" distribuida da maneira correta a cada momento que um evento é disparado e uma mensagem é tratada automaticamente, definindo em cada um dos seus steps o que deve ou não ser feito.


A implementação de sagas é extremamente simplificada utilizando a biblioteca de máquina de estado que o MassTransit disponibiliza, "Automatonymous" sendo necessário construir a máquina de estado, definindo os eventos, estados e behaviors que estão associadas a cada instance de saga, o disparo de uma mensagem (e o recebimento da mesma) é um evento, o que deve ser feito quando o evento ocorre é um behavior e a troca de estado sinaliza quais eventos e behaviors podem ser executados a partir deste anterior.

Para tanto é necessário criar a máquina de estado e a instancia da mesma (essa por sua vez seria a definição da saga), definindo a maneira que cada evento recebido se correlaciona com a saga, porque diversas sagas são iniciadas em diversos pontos é necessário correlacionar os eventos (normalmente através de um GUID na propriedade "CorrelatedBy", porém pode ser qualquer identificador único) e a partir disso definir um InstanceState que define qual é o estado inicial, Qual Event iniciará a saga, disparando por sua vez os Behaviors desejados e para qual State a Aplicação passará.

É importante frisar que é possível definir que durante dado estado, mais de um Event pode ser configurado, permitindo que falhas e ou exceções sejam tratadas desde que sejam definidas como um dos Events daquele estado.

Esse foi um resumo não tão curto do meu entendimento com relação a tudo isso, porém há muito que desconheço e muitos conceitos que ainda não me aprofundei, portanto podem haver erros.

O MassTransit é uma ferramenta poderosissíma e vale a pena conhecer seus internos pelas diversas possibilidades que a mesma oferece, conforme for me aprofundando e entendendo mais a respeito planejo atualizar este projeto.



https://github.com/BrenonOrtega/CSharp-Study/tree/main/Pluralsight/MassTransitRabbitMQ