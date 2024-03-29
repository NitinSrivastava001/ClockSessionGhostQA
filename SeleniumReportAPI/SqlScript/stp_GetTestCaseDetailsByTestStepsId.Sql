CREATE OR ALTER PROCEDURE [dbo].[stp_GetTestStepsDetailsByTestStepsId]
@TestStepsId int
AS
/**************************************************************************************
PROCEDURE NAME	:	stp_GetTestStepsDetailsByTestStepsId
CREATED BY		:	Mohammed Yaseer
CREATED DATE	:	4th March 2024
MODIFIED BY		:	
MODIFIED DATE	:	
PROC EXEC		:
				EXEC stp_GetTestStepsDetailsByTestStepsId
**************************************************************************************/
BEGIN TRY
    IF EXISTS (SELECT 1 FROM tbl_TestStepsDetails WHERE [TestCaseDetailsId] = @TestStepsId)
    BEGIN
        SELECT [result] = JSON_QUERY((
           SELECT  [TestStepsDetailsId],
					[TestCaseDetailsId],
					ISNULL([selectedModifierKey],'') AS [selectedModifierKey],
					ISNULL([stepDescription],'') AS [stepDescription],
					ISNULL([type],'') AS [type],
					ISNULL([selectorValue],'') AS [selectorValue],
					ISNULL([selectorType],'') AS [selectorType],
					ISNULL([variableName],'') AS [variableName],
					ISNULL([accessibility],'') AS [accessibility],
					ISNULL([accessibilityModifier],'') AS [accessibilityModifier],
					ISNULL([assignInputValue],'') AS [assignInputValue],
					ISNULL([clickType],'') AS [clickType],
					ISNULL([elementSelector],'') AS [elementSelector],
					ISNULL([executeJavaScript],'') AS [executeJavaScript],
					ISNULL([exitTestStatus],'') AS [exitTestStatus],
					ISNULL([extractVariable],'') AS [extractVariable],
					ISNULL([importingStepFrom],'') AS [importingStepFrom],
					ISNULL([isOptional],'') AS [isOptional],
					ISNULL([javaScriptCode],'') AS [javaScriptCode],
					ISNULL([javaScriptVariable],'') AS [javaScriptVariable],
					ISNULL([keyPressValue],'') AS [keyPressValue],
					ISNULL([navigateTo],'') AS [navigateTo],
					ISNULL([pauseTime],'') AS [pauseTime],
					ISNULL([selectedDragDropType],'') AS [selectedDragDropType],
					ISNULL([variableInput],'') AS [variableInput]
		    FROM tbl_TestStepsDetails
            WHERE [TestCaseDetailsId] = @TestStepsId
            FOR JSON PATH
        ))
    END
    ELSE
    BEGIN
        SELECT [result] = JSON_QUERY((
            SELECT 'fail' AS [status], 
                   'TestCaseDetailsId not found' AS [message]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER
        ))
    END
END TRY
BEGIN CATCH
    SELECT [result] = JSON_QUERY((
        SELECT 'fail' AS [status], 
               ERROR_MESSAGE() AS [message]
        FOR JSON PATH, WITHOUT_ARRAY_WRAPPER
    ))
END CATCH
