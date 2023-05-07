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


CREATE PROCEDURE ListarECursos
	@Identificacion VARCHAR(20)
AS
BEGIN
	SELECT C .*FROM Cursos C 
	INNER JOIN EstudiantesCursos EC ON C.NombreCurso = EC.NombreCurso
	WHERE EC.Identificacion = @Identificacion

END

go



CREATE PROCEDURE ObtenerEstudiante
	@Identificacion VARCHAR(20)
AS
BEGIN
   SELECT * FROM Estudiantes WHERE Identificacion = @Identificacion
END

go

