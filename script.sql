DROP PROCEDURE IF EXISTS dbo.SP_SaveJsonDB
GO
CREATE PROCEDURE dbo.SP_SaveJsonDB(@json NVARCHAR(MAX))
AS BEGIN
  INSERT INTO DemoSaveJson (Id, Description, Detalle)
  SELECT Id, Description, Detalle
  FROM OPENJSON(@json)
       WITH (Id int, Description nvarchar(50), [Detalle]  nvarchar(MAX)  AS JSON  )
END
GO