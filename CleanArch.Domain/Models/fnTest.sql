USE [UniversityCourseDB]
GO


CREATE FUNCTION [dbo].[fnTest]
(	
	@par1 int,@par2 varchar(50)
)
RETURNS @totaTable table (retValue1 varchar(50),retValue2 int)
AS 
begin

insert into @totaTable(retValue1,retValue2)
values ('XValue1',23)

insert into @totaTable(retValue1,retValue2)
values (@par2,@par1)

RETURN
end
GO


