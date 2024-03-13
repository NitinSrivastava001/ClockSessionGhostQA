CREATE OR ALTER PROCEDURE [dbo].[stp_UpdateExecutionInProgressFlag]
@TestSuiteName		VARCHAR(150),
@TestRunName		VARCHAR(150),
@TestCaseName		VARCHAR(150),
@TesterName			VARCHAR(150),
@TestEnvironment	VARCHAR(150)
AS
/**************************************************************************************
PROCEDURE NAME	:	stp_UpdateExecutionInProgressFlag
CREATED BY		:	Mohammad Mobin
CREATED DATE	:	22 Feb 2024
MODIFIED BY		:	
MODIFIED DATE	:	
PROC EXEC		:  EXEC stp_UpdateExecutionInProgressFlag
				
**************************************************************************************/
BEGIN TRY
	UPDATE tbl_TestExecution
		SET [IsExecutionInProgress] = 0
	WHERE [TestSuiteName]	= @TestSuiteName
	  AND [TestRunName]		= @TestRunName
	  AND [TestCaseName]	= @TestCaseName
	  AND [TestEnvironment]	= @TestEnvironment
	  AND [TesterName]		= @TesterName
END TRY
BEGIN CATCH
	SELECT ERROR_MESSAGE()
END CATCH
