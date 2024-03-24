<h1 align="center">Librería Projecto Bootcamp CódigoFacilito</h1>
<p align="center">
  <img src="https://codigofacilito.com/assets/codys/cody_thinking-0c05231ba09a4c632952602216983caaacb9a208a593cba9bc913341236e030a.png" alt="Cody Thinking">
</p>
Este proyecto es el resultado de mi participación en el Bootcamp de CódigoFacilito, diseñado para demostrar las habilidades adquiridas y la aplicación práctica de diversas tecnologías y metodologías en el desarrollo de software. La librería digital permite a los usuarios registrarse, iniciar sesión, y acceder a una variedad de recursos y funcionalidades.

## Tecnologías y Herramientas Utilizadas

- **Lenguaje de Programación:** C# con .NET 8
- **Frontend:** Blazor, HTML, CSS, JavaScript, Bootstrap
- **Backend:** API RESTful, Autenticación con JWT (JSON Web Tokens)
- **Base de Datos:** SQL Server
- **Librerías y Frameworks:**
  - Serilog para logging
  - AutoMapper para el mapeo objeto-objeto
  - Flutter Validation para validación de datos
  - Chart.js para la creación de gráficos
- **Testing:** Unit Testing para asegurar la calidad del código
- **Patrones de Diseño:** Implementación de varios patrones para estructurar el código de manera eficiente
- **Principios SOLID:** Aplicados para garantizar un diseño de software robusto y mantenible

## Características del Proyecto

- **Registro y Autenticación de Usuarios:** Creación de cuentas de usuario con autenticación segura mediante JWT.
- **Gestión de Libros:** Los usuarios pueden explorar, buscar y acceder a diferentes libros y recursos.
- **Interfaz de Usuario:** Desarrollada con Blazor y Bootstrap, ofreciendo una experiencia de usuario interactiva y amigable.
- **Seguridad:** Implementación de Serilog para el manejo de logs, y uso de buenas prácticas en seguridad de APIs.
- **API RESTful:** Diseño y desarrollo de una API RESTful para la integración y manipulación de los datos.
- **Unit Testing:** Pruebas unitarias para validar la lógica de negocio y garantizar el rendimiento del software.

## Iniciando

Para ejecutar este proyecto localmente, necesitarás una instancia de SQL Server y .NET 8 SDK. Sigue estos pasos:

1. Clona el repositorio en tu máquina local.
2. Configura la cadena de conexión a tu base de datos SQL en el archivo de configuración.
3. Ejecuta las migraciones para configurar tu base de datos.
4. Inicia el proyecto con .NET CLI utilizando `dotnet run` en la raíz del proyecto.


## Aclaraciones Importantes

Este proyecto ha sido desplegado utilizando el proveedor de hosting gratuito **smarterasp.net**. Dada la naturaleza de este servicio, hay ciertas limitaciones que se reflejan en la experiencia del usuario:

- **Autenticación de Hosting:** Al acceder al sitio por primera vez, se requerirá autenticación para conectar con el hosting. Este es un requisito estándar del proveedor.
- **Intermitencias en Blazor:** Se han identificado ciertas irregularidades en el funcionamiento de Blazor en el entorno de hosting, afectando elementos como el botón de "Cerrar Sesión".

### Credenciales de Acceso a la Aplicación
Para explorar la aplicación, puede utilizar las siguientes credenciales:
- Usuario: `11168622`
- Contraseña: `60-dayfreetrial`

## Problemas Técnicos y Limitaciones

Durante el desarrollo y despliegue del proyecto, me encontré con varios desafíos:

- **Certificado SSL:** No se logró adquirir un certificado SSL adecuado, lo que puede resultar en advertencias de seguridad en los navegadores web.
- **Visibilidad Web:** Actualmente, la configuración de privacidad del sitio no ha podido modificarse a través del proveedor de hosting, por lo que la web permanece privada.
- **Compatibilidad con Blazor:** A pesar de que la aplicación funciona perfectamente en un entorno local, algunas funcionalidades, como la opción de "Cerrar Sesión", no están operativas en el hosting.
- **Estructura de Base de Datos:** Se enfrentaron retos con las migraciones de base de datos al intentar implementar una tabla intermedia para la asignación de libros a librerías. Esto me llevó a optar por una relación uno a uno para simplificar la solución.
- **Desarrollo Continuo:** Aunque nos hubiera gustado incorporar características adicionales como imágenes para los libros, mejoras en la interfaz de usuario y la integración con APIs de terceros, el alcance del proyecto y el tiempo disponible limitaron estas extensiones.


## Contribuciones
Este proyecto fue creado por `Joel Garbagnate` sin participacion de otro alumno del BootCamp, fue un proyecto individual. Agradecimientos a todos los mentores que contribuyeron con su conocimiento y experiencia.
