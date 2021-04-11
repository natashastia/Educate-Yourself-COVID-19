ALTER PROC UserAdd
@UserID int,
@FirstName varchar(50),
@LastName varchar(50),
@Username varchar(50),
@Password varchar(50)
AS
	INSERT INTO Table_UserID(FirstName,LastName,Username,Password) 
	VALUES (@FirstName,@LastName,@Username,@Password)
