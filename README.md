# CrudProductManagement

Descargar el reposotirio

## Ejecutando el Proyecto en debug

* Se debe tener una instancia de sql server corriendo
* Ejecutar los Scripts de la base de datos
* El orden es
  - Esquemas
  - Tablas
  - Procedimientos
* Se valida que se halla creado la base de datos
  
<img width="289" height="245" alt="image" src="https://github.com/user-attachments/assets/c577bbf7-e579-4929-8104-802ff6d2b680" />

* Se abre el proecto CrudProductManagement en Visual Studio
* En el appsettings.json se valida la conexión (se cambia la dirección IP en caso de que la db esté en otra url u otro puerto)

<img width="623" height="121" alt="image" src="https://github.com/user-attachments/assets/1e2a805e-c79d-400c-ab4a-fbaa48303f5c" />

* Se presiona el botón 'https' para ejecutar el proyecto

<img width="357" height="124" alt="image" src="https://github.com/user-attachments/assets/6bd9fa4a-3ff4-4807-8605-59cf5888681f" />


* Se abre swagger, donde se podrán probar los enspoints definidos
  * El ClimaControlador apunta a una api externa para consultar el clima (openweathermap)
  * Producto son los endpoints del crud de productos, con interacción con la base de datos 

<img width="1539" height="641" alt="image" src="https://github.com/user-attachments/assets/becc1bea-10a4-4e9f-bb36-fcd76c571248" />

<img width="1418" height="933" alt="image" src="https://github.com/user-attachments/assets/9426a845-e9fb-4b65-8be6-4ab43a3086e9" />

<img width="1440" height="912" alt="image" src="https://github.com/user-attachments/assets/e6301a58-a956-4a5a-895f-ad714a58e573" />


## Para levantar el contenedor, ejecutar los comandos en la carpeta raiz

docker-compose build

docker-compose up -d


Sepuede verificar si esta corriendo con 

docker ps

Ejecutar el backend en 

http://localhost:8080/swagger
