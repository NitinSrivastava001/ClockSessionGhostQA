CREATE OR ALTER PROCEDURE [dbo].[stp_SaveExecutionInProgress]
@TestSuiteName		VARCHAR(150),
@TestRunName		VARCHAR(150),
@TestCaseName		VARCHAR(150),
@TesterName			VARCHAR(150),
@TestEnvironment	VARCHAR(150)
AS
/**************************************************************************************
PROCEDURE NAME	:	stp_AddUpdateApplication
CREATED BY		:	Mohammad Mobin
CREATED DATE	:	22 Feb 2024
MODIFIED BY		:	
MODIFIED DATE	:	
PROC EXEC		:  EXEC stp_AddUpdateApplication
				
**************************************************************************************/
BEGIN TRY
	INSERT INTO tbl_TestExecution ([TestSuiteName], [TestRunName], [TestCaseName], [TestEnvironment], [TesterName], [ExecutionStartTime], [IsExecutionInProgress])
	SELECT @TestSuiteName, @TestRunName, @TestCaseName, @TestEnvironment, @TesterName, GETDATE(), 1
END TRY
BEGIN CATCH
	SELECT ERROR_MESSAGE()
END CATCH