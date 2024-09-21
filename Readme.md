# Introduccion
Proyecto de TEST para cubrir el objetivo PRUEBA TECNICA para el puesto de Desarrollador .NET

# Getting Started
Este proyecto usa .NET 8, .NET Framework 4.6.2 y SqlServer para persistencia de datos
Consta de 2 Proyectos de WebApis en .NET 8, en una Arquitectura de microservicos, con una capa compartida de Acceso a datos (Data Acces Layer) que usan entityframework con migraciones,
se implementa un patron "REPOSITORY" con el adicional de una Unidad de trabajo, como ejemplo para poderlo escalar a mayores proporciones y controlar transaccionalmente los flujos de trabajo
Cuenta con 1 WCF, que cubre las mismas necesidades planteadas en la prueba tecnica 
, se agrega para dar cuanta de la experiencia en el desarrolo de estos servicios 

Cada uno de los 2 microservicios, cuenta con su DockerFile, donde se especifican las ordenes para levantar los contenedores de estas aplicaciones.
Existe tambien un proyecto Docker-Compose, donde se detallan las instrucciones de orquestacion de los 2 contenedores de los MS, ademas de un contenedor
adicional con una dockerimage de MSSQlserver 2022, para alojar la base de datos

En cada archivo Docker y en el Docker-compose se detallan las instrucciones de cada comando.


# Build and Test
Ejecutar el proyecto en Visual Studio 2022
Se requiere tener instaladas las dependencias de Servicio WCF, Asp.net Core, compatibilidad con .NET 8, .NET Framework 4.6.2
Tambien, para ejecutar el proyecto Docker-Compose, Tener instalado Docker Desktop para windows.
Al abrir el proyecto, restaurar los paquetes de NuGet, validar que proyecto Docker-Compose sea el proyecto de inicio
Las URL a las cuales se pueden acceder a los microservicios: 
https://localhost:5001/swagger/index.html (MS PAGOS con consulta de bitacora) 
https://localhost:5002/swagger/index.html (MS DE Alta de Ordenantes y Beneficiarios )

El proyecto NET_TEST_BASE_WCF, debe coorerse en depuracion una ves levantada la base de de datos SQLServer en el contenedor docker
una ves en depuracion, puedes encontrar este proyecto en la siguiente URL:
http://localhost:53342/PagoService.svc
En este proyect encontraran interfaces para las operaciones principales de pagos, dar de alta beneficiarios y Ordenantes desde el microservico destinado para estas operaciones

# Contribuir al proyecto
Este es un proyecto para una prueba tecnica, por lo cual no es necesario contribuir, aun asi si, puedes hacerlo mientras exista, el proyecto es de dominio publico ! 

If you want to learn more about creating good readme files then refer the following [guidelines](https://docs.microsoft.com/en-us/azure/devops/repos/git/create-a-readme?view=azure-devops). You can also seek inspiration from the below readme files:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [Chakra Core](https://github.com/Microsoft/ChakraCore)