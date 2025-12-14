# 📝 Blog Personal - ASP.NET Core + React

Proyecto de blog personal con funcionalidades CRUD completas (Crear, Leer, Actualizar, Eliminar), sistema de comentarios y persistencia de datos en JSON.

## 🚀 Características

- ✅ Lista de posts con diseño responsivo
- ✅ Crear nuevos posts
- ✅ Editar posts existentes
- ✅ Eliminar posts con confirmación
- ✅ Vista detallada de cada post
- ✅ Sistema de comentarios
- ✅ Persistencia de datos en archivo JSON
- ✅ API RESTful con ASP.NET Core
- ✅ Interfaz moderna con Bootstrap
- ✅ Validación de datos
- ✅ Manejo de errores

## 🛠️ Tecnologías Utilizadas

### Backend
- **ASP.NET Core 6.0+** - Framework web
- **C#** - Lenguaje de programación
- **JSON** - Almacenamiento de datos
- **Swagger** - Documentación de API

### Frontend
- **React 18** - Librería de interfaz de usuario
- **Bootstrap 5** - Framework CSS
- **JavaScript ES6+** - Lenguaje de programación
- **Fetch API** - Comunicación con backend

## 📋 Requisitos Previos

Antes de comenzar, asegúrate de tener instalado:

- [Visual Studio 2022](https://visualstudio.microsoft.com/) (Community, Professional o Enterprise)
- [.NET 6.0 SDK o superior](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/) (versión 16 o superior)
- [npm](https://www.npmjs.com/) (incluido con Node.js)

## 📁 Estructura del Proyecto

```
BlogAPI/
│
├── BlogAPI/                          # Backend (ASP.NET Core)
│   ├── Controllers/
│   │   └── PostsController.cs        # Controlador de la API
│   ├── Models/
│   │   └── Post.cs                   # Modelos de datos
│   ├── Services/
│   │   └── BlogService.cs            # Lógica de negocio
│   ├── Data/
│   │   └── posts.json                # Almacenamiento de datos
│   └── Program.cs                    # Configuración de la aplicación
│
└── blog-frontend/                    # Frontend (React)
    ├── public/
    ├── src/
    │   ├── App.js                    # Componente principal
    │   ├── index.js                  # Punto de entrada
    │   └── index.css                 # Estilos
    └── package.json                  # Dependencias de npm
```

## 🔧 Instalación

### 1. Clonar o Descargar el Proyecto

```bash
git clone <url-del-repositorio>
cd BlogAPI
```

O simplemente descarga y extrae el proyecto.

### 2. Configurar el Backend

1. Abre `BlogAPI.sln` con Visual Studio 2022
2. Restaura los paquetes NuGet (automático al abrir)
3. Verifica que todos los archivos estén presentes:
   - `Controllers/PostsController.cs`
   - `Models/Post.cs`
   - `Services/BlogService.cs`
   - `Program.cs`

### 3. Configurar el Frontend

Abre una terminal en la carpeta `blog-frontend`:

```bash
cd blog-frontend
npm install
```

### 4. Configurar la URL de la API

Abre el archivo `blog-frontend/src/App.js` y verifica la línea 3:

```javascript
const API_URL = 'https://localhost:7296/api/posts';
```

**Importante:** Cambia `7296` por el puerto que usa tu backend (lo verás al ejecutar Visual Studio).

## ▶️ Ejecución

### 1. Iniciar el Backend

1. En Visual Studio, presiona **F5** o click en **▶ BlogAPI**
2. Se abrirá Swagger en tu navegador
3. Anota el puerto (ejemplo: `https://localhost:7296`)
4. **No cierres Visual Studio** - debe seguir corriendo

### 2. Iniciar el Frontend

En una terminal, dentro de `blog-frontend`:

```bash
npm start
```

La aplicación se abrirá automáticamente en `http://localhost:3000`

## 📖 Uso de la Aplicación

### Ver Posts
- Al abrir la aplicación verás todos los posts en formato de tarjetas
- Cada tarjeta muestra: imagen, título, extracto, autor y número de comentarios

### Crear un Nuevo Post
1. Click en el botón **"Nuevo Post"** (esquina superior derecha)
2. Completa el formulario:
   - **Título:** Título del post (requerido)
   - **Autor:** Tu nombre (requerido)
   - **Contenido:** El contenido del post (requerido)
   - **URL de Imagen:** URL de una imagen (opcional)
3. Click en **"Crear"**

### Ver Detalle de un Post
1. Click en **"Ver más"** en cualquier post
2. Verás el contenido completo, comentarios y opciones para editar/eliminar

### Editar un Post
1. Click en el botón **"Editar"** (ícono de lápiz)
2. Modifica los campos que desees
3. Click en **"Guardar"**

### Eliminar un Post
1. Click en el botón **"Eliminar"** (ícono de basura)
2. Confirma la acción en el diálogo

### Agregar Comentarios
1. Entra al detalle de un post
2. Baja hasta la sección de comentarios
3. Completa tu nombre y comentario
4. Click en **"Publicar"**

## 🔌 API Endpoints

### Obtener todos los posts
```http
GET /api/posts
```

### Obtener un post por ID
```http
GET /api/posts/{id}
```

### Crear un nuevo post
```http
POST /api/posts
Content-Type: application/json

{
  "titulo": "Mi post",
  "contenido": "Contenido del post",
  "autor": "Nombre del autor",
  "imagen": "https://url-imagen.com/imagen.jpg"
}
```

### Actualizar un post
```http
PUT /api/posts/{id}
Content-Type: application/json

{
  "titulo": "Post actualizado",
  "contenido": "Nuevo contenido",
  "autor": "Autor",
  "imagen": "https://url-imagen.com/imagen.jpg"
}
```

### Eliminar un post
```http
DELETE /api/posts/{id}
```

### Agregar un comentario
```http
POST /api/posts/{id}/comentarios
Content-Type: application/json

{
  "autor": "Nombre",
  "contenido": "Contenido del comentario"
}
```

## 💾 Persistencia de Datos

Los datos se almacenan en el archivo `Data/posts.json` dentro del proyecto backend.

**Ubicación:** `BlogAPI/bin/Debug/net6.0/Data/posts.json`

Este archivo se crea automáticamente al iniciar la aplicación y se actualiza con cada operación CRUD.

## 🧪 Probando con Swagger

1. Con el backend corriendo, abre Swagger en tu navegador
2. URL: `https://localhost:PUERTO/swagger/index.html`
3. Prueba los endpoints directamente desde la interfaz de Swagger
4. Útil para probar la API sin el frontend

## 🐛 Solución de Problemas

### El frontend no se conecta al backend

**Solución:**
1. Verifica que Visual Studio esté corriendo el backend
2. Comprueba que el puerto en `App.js` coincida con el del backend
3. Abre la consola del navegador (F12) para ver errores

### Error de CORS

**Solución:**
- Verifica que `Program.cs` tenga configurado CORS correctamente
- El backend debe estar corriendo en `localhost`

### No aparecen los posts

**Solución:**
1. Verifica que `posts.json` exista en `bin/Debug/net6.0/Data/`
2. Si no existe, se creará automáticamente con datos de ejemplo
3. Revisa la consola de Visual Studio para ver errores del backend

### Error al crear/editar posts

**Solución:**
- Asegúrate de completar todos los campos requeridos (Título, Autor, Contenido)
- Verifica que el backend esté respondiendo en Swagger

## 📝 Notas Importantes

- Los datos se guardan en un archivo JSON local, no en una base de datos
- Al reiniciar el backend, los datos persisten
- Si eliminas el archivo `posts.json`, se creará uno nuevo con datos de ejemplo
- El proyecto usa HTTPS por defecto - acepta el certificado de desarrollo si es necesario

## 🎓 Información Académica

**Proyecto creado para:** Curso de Desarrollo Web  
**Tecnologías principales:** ASP.NET Core, React, Bootstrap  
**Tipo de almacenamiento:** JSON local (simulación de API REST)  
**Fecha:** Diciembre 2024

## 👨‍💻 Autor

Jose Ariel Arce Aquino 
https://github.com/WannaCry-zip

## 📄 Licencia

Este proyecto es de uso académico.

---

## 🚀 Comandos Rápidos

```bash
# Backend (Visual Studio)
F5                              # Ejecutar

# Frontend
cd blog-frontend
npm install                     # Instalar dependencias
npm start                       # Iniciar aplicación
npm run build                   # Crear build de producción
```

---

**¿Necesitas ayuda?** Revisa la sección de solución de problemas o consulta la documentación oficial de [ASP.NET Core](https://docs.microsoft.com/aspnet/core) y [React](https://react.dev).
