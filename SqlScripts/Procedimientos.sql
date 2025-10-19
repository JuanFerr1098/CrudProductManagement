IF NOT EXISTS (
    SELECT TOP 1 1 
    FROM [sys].[objects] 
    WHERE [type] = 'P' 
    AND [object_id] = OBJECT_ID('masters.SP_CrearProducto')
)
   exec('CREATE PROCEDURE masters.SP_CrearProducto AS ')
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: juan.tamayo
-- Create date: 18/10/2025
-- Description:	Crea un producto nuevo
-- exec masters.SP_CrearProducto @Nombre = 'Producto', @Descripcion = 'Descripcion', @Precio = 100, @Estado = 'ACTIVO'
-- =============================================
ALTER PROCEDURE masters.SP_CrearProducto
(
	@Nombre NVARCHAR(100),
    @Descripcion NVARCHAR(255),
    @Precio DECIMAL(10,2),
	@Estado NVARCHAR(50)
)
AS
BEGIN
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED  
	SET NOCOUNT ON
	DECLARE @strMsg VARCHAR(2000)
	BEGIN TRY
		BEGIN TRAN
			INSERT INTO Productos (Nombre, Descripcion, Precio, Estado, FechaCreacion)
			VALUES (@Nombre, @Descripcion, @Precio, @Estado, GETDATE());
			declare @Id int;
			set @id = (SELECT MAX(ID) FROM masters.Productos)
		COMMIT TRAN
	exec masters.SP_ObtenerProductoPorId @Id;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRAN
		SET @strMsg = 'Error en masters.SP_CrearProducto' + ERROR_MESSAGE()
		RAISERROR(@strMsg,16,1)	
	END CATCH
END
GO

IF NOT EXISTS (
    SELECT TOP 1 1 
    FROM [sys].[objects] 
    WHERE [type] = 'P' 
    AND [object_id] = OBJECT_ID('masters.SP_ObtenerProductos')
)
   exec('CREATE PROCEDURE masters.SP_ObtenerProductos AS ')
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: juan.tamayo
-- Create date: 18/10/2025
-- Description:	Obtiene todos los productos
-- exec masters.SP_ObtenerProductos
-- =============================================
ALTER PROCEDURE masters.SP_ObtenerProductos
AS
BEGIN
    SELECT * FROM Productos ORDER BY Id DESC;
END
GO

IF NOT EXISTS (
    SELECT TOP 1 1 
    FROM [sys].[objects] 
    WHERE [type] = 'P' 
    AND [object_id] = OBJECT_ID('masters.SP_ObtenerProductoPorId')
)
   exec('CREATE PROCEDURE masters.SP_ObtenerProductoPorId AS ')
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: juan.tamayo
-- Create date: 18/10/2025
-- Description:	Obtiene un producto por id
-- exec masters.SP_ObtenerProductoPorId @Id = 1
-- =============================================
ALTER PROCEDURE masters.SP_ObtenerProductoPorId
(
	@Id INT
)
AS
BEGIN
    SELECT * FROM Productos WHERE Id = @Id;
END
GO

IF NOT EXISTS (
    SELECT TOP 1 1 
    FROM [sys].[objects] 
    WHERE [type] = 'P' 
    AND [object_id] = OBJECT_ID('masters.SP_ActualizarProducto')
)
   exec('CREATE PROCEDURE masters.SP_ActualizarProducto AS ')
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: juan.tamayo
-- Create date: 18/10/2025
-- Description:	Actualiza un producto
-- exec masters.SP_ActualizarProducto @Id=1, @Nombre = 'Producto1', @Descripcion = 'Descripcion', @Precio = 100, @Estado = 'ACTIVO'
-- =============================================
ALTER PROCEDURE masters.SP_ActualizarProducto
(
	@Id INT,
    @Nombre NVARCHAR(100),
    @Descripcion NVARCHAR(255),
    @Precio DECIMAL(10,2),
	@Estado NVARCHAR(50)
)
AS
BEGIN
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED  
	SET NOCOUNT ON
	DECLARE @strMsg VARCHAR(2000)
	BEGIN TRY
		BEGIN TRAN
			UPDATE Productos
			SET Nombre = @Nombre,
				Descripcion = @Descripcion,
				Precio = @Precio,
				Estado = @Estado
			WHERE Id = @Id;
		COMMIT TRAN
		exec masters.SP_ObtenerProductoPorId @Id;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRAN
		SET @strMsg = 'Error en masters.SP_ActualizarProducto' + ERROR_MESSAGE()
		RAISERROR(@strMsg,16,1)	
	END CATCH
END
GO

IF NOT EXISTS (
    SELECT TOP 1 1 
    FROM [sys].[objects] 
    WHERE [type] = 'P' 
    AND [object_id] = OBJECT_ID('masters.SP_EliminarProducto')
)
   exec('CREATE PROCEDURE masters.SP_EliminarProducto AS ')
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: juan.tamayo
-- Create date: 18/10/2025
-- Description:	Elimina un producto
-- exec masters.SP_EliminarProducto @Id=1, @Estado='INACTIVO'
-- =============================================
ALTER PROCEDURE masters.SP_EliminarProducto
(
	@Id INT,
	@Estado NVARCHAR(50)
)
AS
BEGIN
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED  
	SET NOCOUNT ON
	DECLARE @strMsg VARCHAR(2000)
	BEGIN TRY
		BEGIN TRAN
			UPDATE Productos
			SET Estado = @Estado
			WHERE Id = @Id;
		COMMIT TRAN
		exec masters.SP_ObtenerProductoPorId @Id;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRAN
		SET @strMsg = 'Error en masters.SP_EliminarProducto' + ERROR_MESSAGE()
		RAISERROR(@strMsg,16,1)	
	END CATCH
END;
GO

IF NOT EXISTS (
    SELECT TOP 1 1 
    FROM [sys].[objects] 
    WHERE [type] = 'P' 
    AND [object_id] = OBJECT_ID('masters.SP_ObtenerProductoPorNombre')
)
   exec('CREATE PROCEDURE masters.SP_ObtenerProductoPorNombre AS ')
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: juan.tamayo
-- Create date: 18/10/2025
-- Description:	Obtiene un producto por id
-- exec masters.SP_ObtenerProductoPorNombre @Nombre = 'Producto'
-- =============================================
ALTER PROCEDURE masters.SP_ObtenerProductoPorNombre
(
	@Nombre NVARCHAR(200)
)
AS
BEGIN
    SELECT * FROM Productos WHERE UPPER(Nombre) LIKE '%' + UPPER(@Nombre) + '%';
END
GO