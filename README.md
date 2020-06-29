# Solución Prueba Técnica

La implementación se baso en la creación de multiples micro servicios, cada uno con la finalidad de crear contextos limitados separandolos por modulos:

* ApiGateway : Sirve como servicio de fachada para conectarse con el resto de micro servicios
* IdentityService [Pendiente]: Cubré toda la parte de autenticación 
* Customers: Contiene toda la lógica para la administración de clientes
* Banking: Contiene toda la lógica para la administración de cuentas

### Requerimientos

* Docker

### Ejecución

Situarse en el directorio padre y ejecutar:

```sh
$ docker-compose up
```

En el navegador ir al siguente sitio:

```sh
http://localhost:8081/swagger
```

### Tecnologías

- [x] Ocelot
- [x] Log4Net
- [ ] RabitMQ
- [ ] JWT
- [x] Swagger
- [x] Postgres
- [x] AutoMapper
