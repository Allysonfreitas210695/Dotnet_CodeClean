# ADICIOANDO SLN VAZIA

dotnet new sln --name CleanArchMvc 

# ADICIOANDO CLASSLIB

dotnet new classlib --name CleanArchMvc.Domain 

# ADICIOANDO CLASSLIB A SLN

dotnet sln CleanArchMvc.sln add .\CleanArchMvc.Application\CleanArchMvc.Application.csproj

# ADICiONANDO REFERENCES

dotnet add .\CleanArchMvc.Infra.IoC\CleanArchMvc.Infra.IoC.csproj reference .\CleanArchMvc.Domain\CleanArchMvc.Domain.csproj

# CRIANDO MIGRATIONS

dotnet ef migrations add NewTables --startup-project .\CleanArchMvc.WebUI\CleanArchMvc.WebUI.csproj --project 
.\CleanArchMvc.Infra.Data\

# ATUALIZANDO BANCO




