# Simulador de Micro-ondas

Este projeto foi criado para simular um micro-ondas digital usando C#. A ideia foi separar bem a lógica do aparelho (backend) da interface que o usuário vê (frontend), seguindo o que foi pedido no desafio.

## O que já foi feito até agora

### Fase 1: O Básico
*   Dá pra configurar tempo (1 a 120s) e potência (1 a 10).
*   Botão de Início Rápido (joga 30s na potência máxima se vc tiver com pressa).
*   Se vc apertar iniciar com o o tempo já rolando, ele soma mais 30s.

### Fase 2: Programas e Regras
*   O sistema já vem com 5 programas prontos (Pipoca, Leite, etc).
*   Dá pra cadastrar seus próprios programas.
*   Tem validações pra não deixar colocar caractere repetido ou usar o ponto (.) que é o padrão.

### Fase 3: Interface Web (Blazor)
*   Fiz uma tela em Blazor que tenta imitar um painel de micro-ondas de verdade.
*   Dá pra clicar nos números e controlar tudo pelo mouse ou teclado.

### Fase 4: Integração com API e Segurança
*   Toda a parte de login e autenticação já tá batendo na API.
*   Criei um middleware que pega qualquer erro que der no servidor e salva num log (`erros_microondas.log`), pra não deixar o usuário na mão.
*   Tem uma tela de **Configurações** onde dá pra ajustar o endereço da API e os dados de acesso de um jeito fácil.

## Detalhes Importantes (Spec)

*   **Persistência**: Optei por salvar os programas customizados num arquivo `programas.json`. Achei que ficava mais leve e simples pro nível do projeto, mas a lógica tá toda preparada se precisar virar um banco de dados depois.
*   **Segurança**: O campo de senha tá mascarado na interface. A API usa Bearer Token pra garantir que só quem tá logado consiga mexer nos controles.
*   **Conexão**: Se precisar mudar a porta ou o IP da API, é só ir na tela de Configurações do site e salvar o novo endereço por lá mesmo.

## Como rodar o sistema

1. **Subir a API**:
   Entre na pasta `Microondas.Api` e mande um `dotnet run`. Ela vai subir por padrão no `http://localhost:5018`.

2. **Rodar o Site**:
   Na pasta `MicroondasWeb`, rode o `dotnet watch` ou `dotnet run`. O site vai abrir no `http://localhost:5000`.

3. **Testes**:
   Pra conferir se a lógica tá batendo, vá em `microodas.Tests` e rode `dotnet test`.

Qualquer dúvida na rota ou porta, dá uma olhada na tela de Configurações no painel lateral do site!
