CREATE TABLE Estudiantes (
    Identificacion VARCHAR(20) PRIMARY KEY,
    Nombre1 VARCHAR(50),
    Apellido1 VARCHAR(50),
    Email VARCHAR(100)
);

CREATE TABLE Cursos (
    NombreCurso VARCHAR(50) PRIMARY KEY,
    Descripcion VARCHAR(200)
);

CREATE TABLE EstudiantesCursos (
    Identificacion VARCHAR(20) REFERENCES Estudiantes(Identificacion),
    NombreCurso VARCHAR(50) REFERENCES Cursos(NombreCurso),
    PRIMARY KEY (Identificacion, NombreCurso)
);
