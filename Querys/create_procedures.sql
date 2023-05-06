go
use DBSICO
go

--************************ PROCEDIMIENTOS PARA CREAR ************************--
CREATE PROCEDURE sp_InsertarEstudianteCurso
    @Identificacion VARCHAR(20),
    @NombreCurso VARCHAR(50)
AS
BEGIN
    IF NOT EXISTS (SELECT * FROM EstudiantesCursos WHERE Identificacion = @Identificacion AND NombreCurso = @NombreCurso)
    BEGIN
        INSERT INTO EstudiantesCursos (Identificacion, NombreCurso)
        VALUES (@Identificacion, @NombreCurso)
    END
END

go

CREATE PROCEDURE sp_BorrarEstudianteCurso
    @Identificacion VARCHAR(20),
    @NombreCurso VARCHAR(50)
AS
BEGIN
    DELETE FROM EstudiantesCursos WHERE Identificacion = @Identificacion AND NombreCurso = @NombreCurso
END

go

CREATE PROCEDURE ListarEstudiantes
AS
BEGIN
   SELECT * FROM Estudiantes
END

go

CREATE PROCEDURE ListarCursos
AS
BEGIN
   SELECT * FROM Cursos
END

go

CREATE PROCEDURE ListarEstudiantesCursos
AS
BEGIN
   SELECT * FROM EstudiantesCursos
END

go
