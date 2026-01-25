# Arquitetura SGVendas - ASP.NET Core MVC

```mermaid
graph TD
    %% Projeto principal
    SGVendas[SGVendas - ASP.NET Core MVC]

    %% Camadas MVC
    Controllers[Controllers]
    Views[Views]
    Models[Models]

    %% Bibliotecas auxiliares
    Domain[SGVendas.Domain]
    Data[SGVendas.Data]
    Services[SGVendas.Services]

    %% Hierarquia MVC dentro do SGVendas
    SGVendas --> Controllers
    SGVendas --> Views
    SGVendas --> Models

    %% Dependências externas
    Controllers --> Services
    Models --> Domain
    Services --> Data
    Data --> Domain
