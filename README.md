# Simulador de Micro-ondas

Este é um projeto desenvolvido em C# para simular o funcionamento de um micro-ondas digital.

## O que o projeto faz (até a Fase 3)

### Fase 1: Funcionamento Básico
* Controle de tempo de aquecimento (de 1 a 120 segundos).
* Controle de potência (de 1 a 10).
* Botão de Início Rápido (adiciona 30 segundos com potência 10).

### Fase 2: Regras e Customização
* Bloqueios de segurança para o tempo e potência não passarem do limite.
* Opção de cadastrar novos programas de aquecimento salvando os dados.

### Fase 3: Interface Web
* Tela feita em Blazor para operar o aparelho de um jeito mais amigável e visual.

## Como rodar o projeto

### Rodando o Servidor/API
1. Entre na pasta `Microondas.Api`.
2. Rode o comando:
   ```bash
   dotnet run
   ```

### Rodando os Testes
1. Para rodar os testes unitários do sistema, vá na pasta `microodas.Tests`.
2. Rode o comando:
   ```bash
   dotnet test
   ```
