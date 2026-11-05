# CRUD de Empleados con .NET MAUI y SQLite



## Descripción 📋

Esta aplicación móvil esta desarrollada en .NET MAUI y permite gestionar empleados utilizando una base de datos local SQLite. La aplicación implementa las operaciones básicas de un CRUD (Crear, Leer, Actualizar y Eliminar), además de guardar los datos aunque se cierre la aplicación gracias a SQLite.



## Funcionalidades 🔧

- Registro de empleados.
- Visualización de empleados en un ListView.
- Edición de información de empleados.
- Eliminación de empleados con confirmación previa.
- Validación de campos obligatorios.
- Validación de correo electrónico.
- Validación de salario mayor que cero.
- Almacenamiento local mediante SQLite.



## Tecnologías utilizadas 🖥️

- .NET MAUI
- C#
- XAML
- SQLite
- SQLite-net-pcl



## Estructura del proyecto 🔩

```text
CrudEmpleados
│
├── Models
│   └── Empleado.cs
│
├── Services
│   └── DatabaseService.cs
│
├── Views
│   ├── EmpleadosPage.xaml
│   └── EmpleadosPage.xaml.cs
│
├── MauiProgram.cs
└── App.xaml.cs
```


## Capturas de pantalla 🎞️

Formulario y Lista de Empleados vacios

<img width="200" height="400" alt="image" src="https://github.com/user-attachments/assets/220d2ca6-d121-4381-84c5-da7691fe9401" />

Registro de empleado mensaje de confirmación

<img width="200" height="400" alt="image" src="https://github.com/user-attachments/assets/c93ad3cf-cf51-430c-90a1-da1e526a91a8" />

Lista de empleados y visualización de datos del empleado seleccionado en el formulario para poder actualizar datos

<img width="200" height="400" alt="image" src="https://github.com/user-attachments/assets/483e3f70-4abd-4286-b765-e49347859b63" />

Mensaje de actualización de datos exitosa

<img width="200" height="400" alt="image" src="https://github.com/user-attachments/assets/4fa716ad-10ad-4cbe-865f-154cfe2a4ffe" />

<img width="200" height="400" alt="image" src="https://github.com/user-attachments/assets/778ddbb5-4100-43e6-ad25-225878485f6c" />


Mensaje de confirmación para la eliminación de un empleado

<img width="200" height="400" alt="image" src="https://github.com/user-attachments/assets/f0af589c-8416-4d83-87df-25114a54c4c7" />

<img width="200" height="400" alt="image" src="https://github.com/user-attachments/assets/3a9b79ee-4540-4c62-bd44-497a22561e24" />

<img width="200" height="400" alt="image" src="https://github.com/user-attachments/assets/d210c1af-7c04-4e41-b136-402445693aec" />


Mensajes de error al no llenar un dato requerido

<img width="200" height="400" alt="image" src="https://github.com/user-attachments/assets/1be8c600-a6e9-4254-ae7f-45bae55834c3" />

<img width="200" height="400" alt="image" src="https://github.com/user-attachments/assets/a7239942-dcc1-430a-8275-3b50cd350dc9" />

<img width="200" height="400" alt="image" src="https://github.com/user-attachments/assets/8436ea9a-3b1f-46b9-a3fe-e0a519a2b81f" />


<img width="200" height="400" alt="image" src="https://github.com/user-attachments/assets/737302a0-9341-4b85-b61b-0cbe4ed75d07" />

<img width="200" height="400" alt="image" src="https://github.com/user-attachments/assets/48b6b2bc-cb12-4bd6-844c-85a06f573183" />


Mensaje de aviso al intentar eliminar a un empleado sin seleccionarlo

<img width="200" height="400" alt="image" src="https://github.com/user-attachments/assets/b8f93cce-e888-4249-88e2-e72820d6156e" />



