# Caminhoes

Instruções:

1) Antes de rodar o aplicativo, é necessário instalar os seguintes pré-requisitos:
  - .NET Core 2.1 - https://dotnet.microsoft.com/download/dotnet/2.1
  
  - Sql Server 2017 Express - https://www.microsoft.com/pt-br/download/details.aspx?id=55994
    * Selecionar a opção "Baixar Mídia"
    * Baixar a versão "LocalDB"
    * Instalar o Sql Server 2017 Express LocalDB a partir do arquivo que foi extraído da instalação.
    * Realizar o download da atualização cumulativa - https://www.microsoft.com/en-us/download/details.aspx?id=56128
    * Instalar a atualização cumulativa.
    
2) Para rodar a aplicação, abra o prompt de comando do Windows como administrador.
  - Vá até a pasta raiz do projeto.
  - Entre na pasta "CadastroCaminhoes".
  - Execute o commando:
    - dotnet dev-certs https --trust
  - Para rodar a aplicação execute o comando:
    - dotnet run
  
3) Para executar o conjunto de testes, abra o prompt de comando do Windows como administrador.
  - Vá até a pasta raiz do projeto.
  - Entre na pasta "CaminhaoTestes".
  - Execute o commando:
    - dotnet test
