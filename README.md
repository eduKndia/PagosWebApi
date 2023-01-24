# PagosWebApi
# Instrucciones
1. Clone del repositorio
2. restaurar dependencias con dotnet restore
3. Crea el servidor de datos postgresql- ejecuta docker-compose up dentro de la carpeta PostgreSQL
4. Ejecutar migraciones para crear estructura de tablas y población de datos de prueba - ejecuta dotnet ef database update
5. Levantar la API - ejecuta en la raiz del proyecto dotnet run
6. en localhost:7137/swagger encontrará la documentación openApi


# Obs
- Por fata de tiempo solo se encuntra funcional la simulación de busqueda de servicios 



