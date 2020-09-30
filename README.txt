-- Conexión a base de datos El string de conexión se sitúa en el archivo "WebApiConfig.cs" en la carpeta "App_Start", en el cual encontraremos el nombre del servidor,
 nombre de la base de datos, el usuario y la contraseña, a modo de ejemplo sería algo así. // string conn_string = "server=localhost;port=3306;database=api;username=root"; 
// Aquí dando acceso a los parametros de conexión, en este caso está configurado en "Phpmyadmin" en un puerto liberado por el software XAMPP control panel.

-- Controllers Cada controller en la carpeta "Controllers" hace referencia a la tabla que deseamos consultar, dando cabida a los métodos POST, GET, PUT y DELETE.
 Dentro de el archivo "AlumnoController.cs" está el método createCode(), que es el encargado de la generación del código que se necesita para la confirmación del mail 
entregado al alumno al momento de registrar la contraseña.

-- Clase La clase hace referencia a los atributos y métodos que tiene "Alumno.cs" para que sirva de intermediario en la conexión Controller-Database.

--Para desarrollar la API, ocupamos XAMP, para habilitar y crear la base de datos en PhpMyAdmin, y para desarrollar el codigo de la api ocupamos Visual Studio Code 2019,
Tambien para metodos de validación de metodos POST, Get, Put ocupamos la aplicación Post Man.

Videos Explicativos a modo de referencia en la construcción de la API: https://www.youtube.com/playlist?list=PLo80-9-Cbwm8apgGEyIVWaxbypl9oWh5x 
https://www.youtube.com/watch?v=TcovfE8IsHs

--SEGURIDAD DE LA API CON TOKEN MEDIANTE JWT----

# WebAPI-Segura-JWT
Proyecto WebAPI para securitar API REST mediante JWT con Secret-Key y expiración.

![](https://github.com/santimacnet/WebAPI-Segura-JWT/blob/master/Meetup-Barcelona-Foto.jpg)
## Fundamentos de JWT

Entrando en materia, partimos de la base que conocemos JTW y su ciclo de vida, sino es asi, visitar: https://jwt.io/introduction

![](https://cdn.auth0.com/content/jwt/jwt-diagram.png)

## Implementación de JWT

Basicamente lo que se busca generar implementando un token mediante el estandar JWT, es para transmitir información de sus datos
de una forma segura entre cliente/servidor. Quiere decir que la implementación de este token, genera un codigo encriptado
el cual sirve para validar si el usuario tiene acceso a los datos datos o no.
En este caso añadimos el token al rut del usuario, de manera que si el rut existe genera un token automaticamente que te permitirá
ver los datos de dicho usuario, en caso contrario, el token no permitirá el acceso a los datos.

Adjunto links de donde aprendimos a implementar los tokens en el programa:

http://enmilocalfunciona.io/construyendo-una-web-api-rest-segura-con-json-web-token-en-net-parte-i/
http://enmilocalfunciona.io/construyendo-una-web-api-rest-segura-con-json-web-token-en-net-parte-ii/
http://enmilocalfunciona.io/construyendo-una-web-api-rest-segura-con-json-web-token-en-net-parte-iii/

Usamos la siguiente aplicación para la generación del token:
https://swagger.io/
Esta aplicación la usan en los links adjuntos señalados anteriormente, ahi explican de mejor manera su funcionamiento.
